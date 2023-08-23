// Get references to the elements you want to manipulate
const todayLink = document.getElementById("today-btn");
const tomorrowLink = document.getElementById("tomorrow-btn");
const dateSelect = document.querySelector("select.home_date_sessions");

var SESSIONS = null;
var HALLS = null;
var THEATRES = null;
var MOVIES = null;

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


var selectedSessionCinema = AllCinemas;
var selectedSessionLanguage = AllLanguages;
var sessionsCinemaSelectElement = document.getElementById("sessionsCinemaFilter");
var sessionsLanguageSelectElement = document.getElementById("sessionsLanguageFilter");
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

function hideSessionsSpinner() {
    document.getElementById("sessions-spinner").style.display = "none";
    document.getElementById("sessions-current-date").style.display = "block";
}
function showSessionsSpinner() {
    document.getElementById("sessions-spinner").style.display = "block";
    document.getElementById("sessions-current-date").style.display = "none";
}

function setNewDateText(text) {
    document
        .getElementById("sessions-current-date")
        .querySelector("p").innerText = text;
}

function areDatesEqual(dateStr1, dateStr2) {
    // Convert dateStr1 to a JavaScript Date object
    const date1 = new Date(dateStr1);

    // Extract day, month, and year from dateStr2
    const dateParts = dateStr2.split(".");
    const day = parseInt(dateParts[0], 10);
    const month = parseInt(dateParts[1], 10) - 1; // Months are zero-based in JavaScript
    const year = parseInt(dateParts[2], 10);

    // Create a JavaScript Date object from the extracted date parts
    const date2 = new Date(year, month, day);

    // Compare the two Date objects to check if they represent the same date
    return date1.toDateString() === date2.toDateString();
}

var tableContainer = document.getElementById("sessions-table");
function addTableHeadToView() {
    tableContainer.innerHTML = `
    <table class="sessions_table container" style="display: block;">
      <thead>
          <tr>
              <td class="buy">MOVIE</td>
              <td>SESSIONS</td>
              <td>CINEMA</td>
              <td>HALL</td>
              <td>FORMAT</td>
              <td>PRICE</td>
              <td>BUY NOW</td>
          </tr>
      </thead>
    </table>
    `;
}

function addSessionsTableBody() {
    tableContainer.innerHTML += `<tbody id="sessions-body"></tbody>`;
}

function getFormattedTime(dateString) {
    // Create a Date object from the input string
    const dateObject = new Date(dateString);

    // Get the hours and minutes from the Date object
    const hours = dateObject.getHours().toString().padStart(2, "0");
    const minutes = dateObject.getMinutes().toString().padStart(2, "0");

    // Create and return the formatted time string
    return `${hours}:${minutes}`;
}

const SESSION_TITLE_MAX_LENGTH = 35;

function createSessionsRowHtml(session, maxFormatCount) {
    var hall = HALLS.find((h) => h.id === session.hallId);
    var theatre = THEATRES.find((t) => t.id === hall?.theatreId);
    var movie = MOVIES.find((m) => m.id === session?.movieId);

    var formats = getMovieFormatsHtml(movie, maxFormatCount);

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
        <div class='session-formats-container'>
         ${formats}
        </div>
      </td> 
      <td>
        ${movie.price} AZN
      </td>
      <td>
        <div class="zone_input">
            <input onclick=alert("HI") type="text" disabled class="zone_main_input" placeholder="Places">
        </div>
      </td>
    </tr>
  `;
}

const MAX_SESSION_FORMAT_COUNT = 3;

function areDatesOnSameDay(date1, date2) {
    // Compare year, month, and day components
    return (
        date1.getFullYear() === date2.getFullYear() &&
        date1.getMonth() === date2.getMonth() &&
        date1.getDate() === date2.getDate()
    );
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

async function addSessionsToView(date) {
    if (SESSIONS === null) {
        SESSIONS = await getSessions();
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
        languageFilteredSessions.map(function (session) {
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

    addTableHeadToView();
    addSessionsTableBody();

    var allHtml = "";
    for (let i = 0; i < resultSessions.length; i++) {
        const mySession = resultSessions[i];
        var html = createSessionsRowHtml(mySession, MAX_SESSION_FORMAT_COUNT);
        allHtml += html;
    }
    var sessionsBody = document.getElementById("sessions-body");
    sessionsBody.innerHTML = allHtml;
}

function sortSessionsByDate(mysessions) {
    mysessions.sort((a, b) => {
        const startTimeA = new Date(a.StartTime);
        const startTimeB = new Date(b.StartTime);
        return startTimeA - startTimeB;
    });
}

async function start() {
    showSessionsSpinner();

    MOVIES = await makeAjaxRequest('/api/Movie/GetAllMovies');
    THEATRES = await makeAjaxRequest('/api/Theatre/GetAllTheatres');
    HALLS = await makeAjaxRequest('/api/Hall/GetAllHalls');
    SESSIONS = await makeAjaxRequest('/api/Session/GetAllSessions');

    if (SESSIONS != null && SESSIONS.length > 0) {
        sortSessionsByDate(SESSIONS);
        hideSessionsSpinner();
        handleSelectChange();
    }
}

start();
