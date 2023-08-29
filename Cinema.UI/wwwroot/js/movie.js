document.addEventListener("DOMContentLoaded", function () {
    const tabHeaders = document.querySelectorAll("#page_wrapper .tab_header a");
    const tabs = document.querySelectorAll("#page_wrapper .tab");

    tabHeaders.forEach((tabHeader) => {
        tabHeader.addEventListener("click", function (event) {
            event.preventDefault();

            // Hide all tabs
            tabs.forEach((tab) => {
                tab.style.display = "none";
            });

            // Show the clicked tab
            const tabId = this.getAttribute("id");
            const tabToShow = document.querySelector(`#page_wrapper .tab.${tabId}`);
            tabToShow.style.display = "block";

            // Remove active class from all tab headers
            tabHeaders.forEach((header) => {
                header.classList.remove("active");
            });

            // Add active class to the clicked tab header
            this.classList.add("active");
        });
    });
});


function hideSessionsSpinner() {
    document.getElementById("sessions-spinner").style.display = "none";
    document.getElementById("sessions-current-date").style.display = "block";
}
function showSessionsSpinner() {
    document.getElementById("sessions-spinner").style.display = "block";
    document.getElementById("sessions-current-date").style.display = "none";
}


const todayLink = document.getElementById("today-btn");
const tomorrowLink = document.getElementById("tomorrow-btn");
const dateSelect = document.querySelector("select.home_date_sessions");

const MAX_SESSION_FORMAT_COUNT = 3;
var AllCinemas = "All Cinemas";
var AllLanguages = "All Languages";
function getFormattedTime(dateString) {
    // Create a Date object from the input string
    const dateObject = new Date(dateString);

    // Get the hours and minutes from the Date object
    const hours = dateObject.getHours().toString().padStart(2, "0");
    const minutes = dateObject.getMinutes().toString().padStart(2, "0");

    // Create and return the formatted time string
    return `${hours}:${minutes}`;
}

function createFormatHtml(imageUrl, tooltip, check = true) {
    if (check &&
        imageUrl ===
        "https://media.aykhan.net/assets/images/step-it-academy/diploma-project/flags/512/not-found.png"
    )
        return "";

    const html = `
      <div class='movie-format'>    
        <span>
            <b></b>
            ${tooltip}
        </span>
        <img src="${imageUrl}" alt="#">
      </div>
    `;
    return html;
}

function getMovieFormatsHtml(movie, maxCount = 0, check = true) {
    var formats = [];

    if (movie.languages != null) {
        movie.languages.forEach((language) => {
            const format = createFormatHtml(
                language.flagUrl,
                `Movie Language : ${language.name}`,
                check
            );
            formats.push(format);
        });
    }

    if (movie.subtitles != null) {
        movie.subtitles.forEach((subtitle) => {
            const format = createFormatHtml(subtitle.imageUrl, `Movie Subtitle`, check);
            formats.push(format);
        });
    }

    formats = formats.filter(f => f != '');

    if (formats.length === 0) {
        var format = createFormatHtml("https://media.aykhan.net/assets/images/step-it-academy/diploma-project/flags/512/en.png", "Movie Subtitle : English", check)
        formats.push(format);
    }

    // Get only the first 5 formats
    var selectedFormats = [];
    if (maxCount != 0) {
        selectedFormats = formats.slice(0, maxCount);
    } else {
        selectedFormats = formats.slice(0, MAX_SESSION_FORMAT_COUNT);
    }

    // Join the array of HTML strings into a single string
    const formatsString = selectedFormats.join("");

    return formatsString;
}

function createSessionsRowHtml(session, maxFormatCount) {
    var hall = HALLS.find((h) => h.id === session.hallId);
    var theatre = THEATRES.find((t) => t.id === hall?.theatreId);
    var movie;
    if (session.movie != null) {
        movie = session.movie;
    }
    else {
        movie = MOVIES.find((m) => m.id === session?.movieId);

        const selectedLanguage = movie.languages.find(function (language) {
            return language.name === selectedSessionLanguage;
        });

        if (selectedLanguage) {
            const otherLanguages = movie.languages.filter(function (language) {
                return language.name !== selectedSessionLanguage;
            });

            movie.languages = [selectedLanguage, ...otherLanguages];
        }
    }

    var formats = getMovieFormatsHtml(movie, maxFormatCount, false);

    return `
    <tr style="display: table-row;">
      <td>
        <a href="/home/movies?id=${movie?.id}">${movie.title}</a>
      </td>
      <td>${getFormattedTime(session.startTime)}</td>
      <td>
        <a href="/home/theatres?id=${theatre.id}">${theatre.name}</a>
      </td>
      <td>
        ${hall.name}
      </td>
      <td>
        
         ${formats}
      </td> 
      <td>
        ${movie.price} AZN
      </td>
      <td> 
        <div class="zone_input" onclick="showPlaces('${session.id}')">
            <input type="text" disabled class="zone_main_input" placeholder="Places">
        </div>
      </td>
    </tr>
  `;
}

function formatDate(inputDate) {
    var parts = inputDate.split('.');
    if (parts.length === 3) {
        return parts[2] + '-' + parts[1] + '-' + parts[0];
    } else {
        // Return an error message or handle invalid input as needed.
        return 'Invalid date format';
    }
}

function areDatesOnSameDay(date1, date2) {
    // Compare year, month, and day components
    return (
        date1.getFullYear() === date2.getFullYear() &&
        date1.getMonth() === date2.getMonth() &&
        date1.getDate() === date2.getDate()
    );
}

var selectedSessionCinema = AllCinemas;
var selectedSessionLanguage = AllLanguages;
var sessionsCinemaSelectElement = document.getElementById("sessionsCinemaFilter");
var sessionsLanguageSelectElement = document.getElementById("sessionsLanguageFilter");

var tableHead = document.getElementById("table-head");

function addTableHeader() {
    tableHead.innerHTML = `
      <tr style="width: 100% !important;">
        <td>MOVIE</td>
        <td>SESSIONS</td>
        <td>CINEMA</td>
        <td>HALL</td>
        <td>FORMAT</td>
        <td>PRICE</td>
        <td>BUY NOW</td>
    </tr>`;
}

function removeTableHeader() {
    tableHead.innerHTML = '';
}

var SESSIONS = null;
var HALLS = null;
var THEATRES = null;
var MOVIES = null;
var sessionsBody = document.getElementById("movie-details-sessions");
async function addSessionsToView(date) {
    if (SESSIONS === null) {
        SESSIONS = await makeAjaxRequest('/api/Session/GetAllSessions');
    }

    // Convert dateValue to a JavaScript Date object    
    var selectedDate = new Date(formatDate(date));

    var filteredSessions = SESSIONS.filter(session => {
        return areDatesOnSameDay(new Date(session.startTime), selectedDate);
    });

    var cinemaFilteredSessions = filteredSessions.filter(session => {
        if (selectedSessionCinema === AllCinemas) {
            return true;
        }
        return session.hall.theatreId === selectedSessionCinema;
    });

    var languageFilteredSessions = cinemaFilteredSessions.filter(session => {
        if (selectedSessionLanguage === AllLanguages) {
            return true;
        }
        return session.movie.languages.some(function (language) {
            return language.name === selectedSessionLanguage;
        });
    });

    if (selectedSessionLanguage != AllLanguages) {
        languageFilteredSessions = languageFilteredSessions.map(function (session) {
            const selectedLanguage = session.movie.languages.find(function (language) {
                return language.name === selectedSessionLanguage;
            });

            if (selectedLanguage) {
                const otherLanguages = session.movie.languages.filter(function (language) {
                    return language.name !== selectedSessionLanguage;
                });

                session.movie.languages = [selectedLanguage, ...otherLanguages];
            }

            return session;
        });
    }

    var resultSessions = languageFilteredSessions;

    addTableHeader();

    document.getElementById("no_sessions").style.display = 'none';
    sessionsBody.innerHTML = '';
    tableHead.style.display = 'block';
    sessionsBody.style.display = 'block';
    if (resultSessions.length > 0) {
        var allHtml = "";
        for (let i = 0; i < resultSessions.length; i++) {
            const mySession = resultSessions[i];
            var html = createSessionsRowHtml(mySession, MAX_SESSION_FORMAT_COUNT);
            //console.log(html);
            allHtml += html;
        }
        sessionsBody.innerHTML = allHtml;
    }
    else {
        //tableHead.style.display = 'none';
        sessionsBody.style.display = 'none';
        document.getElementById("no_sessions").style.display = 'block';
        removeTableHeader();
    }
}


function setNewDateText(text) {
    document
        .getElementById("sessions-current-date")
        .querySelector("p").innerText = text;
}

// Function to add 'active' class to the selected link
function setActive(link) {
    // Remove 'active' class from both links
    todayLink.classList.remove("active");
    tomorrowLink.classList.remove("active");

    // Add 'active' class to the selected link
    if (link != null) {
        link.classList.add("active");

        var dateValue = link.getAttribute("data-value");

        addSessionsToView(dateValue);

        var dateText = link.getAttribute("date-text");

        setNewDateText(`${dateText} (${dateValue})`);
    }
}

// Function to handle the change event for the select element
function handleSelectChange() {
    const selectedOptionValue = dateSelect.value;
    const today = new Date();
    const tomorrow = new Date(today);
    tomorrow.setDate(today.getDate() + 1);
    // Check if the selected date is today or tomorrow and update links accordingly
    var todayDate = todayLink.getAttribute("data-value");
    var tomorrowDate = tomorrowLink.getAttribute("data-value");
    if (selectedOptionValue === todayDate) {
        setActive(todayLink);
        addSessionsToView(todayDate);
    } else if (selectedOptionValue === tomorrowDate) {
        setActive(tomorrowLink);
        addSessionsToView(tomorrowDate);
    } else {
        setActive(null);
        setNewDateText(selectedOptionValue);
        addSessionsToView(selectedOptionValue);
    }
}


sessionsCinemaSelectElement.addEventListener("change", function () {
    selectedSessionCinema = sessionsCinemaSelectElement.value;
    handleSelectChange();
});
sessionsLanguageSelectElement.addEventListener("change", function () {
    selectedSessionLanguage = sessionsLanguageSelectElement.value;
    handleSelectChange();
});

// Function to handle the click event for "Today" and "Tomorrow" links
function handleLinkClick(event) {
    event.preventDefault();
    setActive(event.target);

    // Update the selected date in the <select> based on the link clicked
    dateSelect.value = event.target.getAttribute("data-value");
}

// Attach event listeners   
todayLink.addEventListener("click", handleLinkClick);
tomorrowLink.addEventListener("click", handleLinkClick);
dateSelect.addEventListener("change", handleSelectChange);
var anotherMoviesContainer = document.getElementById("another-movies");
const TITLE_LENGTH_LIMIT = 30;

function createMovieHtml(movie) {
    var formats = getMovieFormatsHtml(movie);

    // Truncate the movie title if it's longer than titleLimit characters
    var truncatedTitle =
        movie.title.length > TITLE_LENGTH_LIMIT
            ? movie.title.substring(0, TITLE_LENGTH_LIMIT) + "..."
            : movie.title;

    var html = `
    <div class='movie-card'>
        <div class='movie-title'>
            <a href="/home/movies?id=${movie.id}">
                ${truncatedTitle}
            </a>
        </div>
        <div class="movie-details">

            <a href="/home/movies?id=${movie.id}">
                <div class="poster">
                    <img src="${movie.posterUrl}" alt=${movie.title}>
                </div>
            </a>

            <div class="movie-formats">
                ${formats}
            </div>

            <div class="go-film">
                <a href="/home/movies?id=${movie.id}">SESSIONS</a>

                <span class='age-limit'>${movie.ageLimit}</span>
            </div>
        </div>
    </div>    
    `;
    return html;
}

function addAnotherMovies() {
    var anotherMovies = JSON.parse(localStorage.getItem('AnotherMovies'));
    if (anotherMovies != null) {
        var fullHtml = '';
        for (var i = 0; i < anotherMovies.length; i++) {
            var movie = anotherMovies[i];
            var html = createMovieHtml(movie);
            fullHtml += html;
        }
        anotherMoviesContainer.innerHTML = fullHtml;
    }
}

async function start() {
    showSessionsSpinner();

    MOVIES = await makeAjaxRequest('/api/Movie/GetAllMovies');
    THEATRES = await makeAjaxRequest('/api/Theatre/GetAllTheatres');
    HALLS = await makeAjaxRequest('/api/Hall/GetAllHalls');
    var currentMovieId = localStorage.getItem("CurrentMovieId");
    SESSIONS = await makeAjaxRequest(`/api/Session/GetMovieSessions?movieId=${currentMovieId}`);

    if (SESSIONS != null && SESSIONS.length > 0) {
        hideSessionsSpinner();
        handleSelectChange();

        addAnotherMovies();
    }
}

start();


