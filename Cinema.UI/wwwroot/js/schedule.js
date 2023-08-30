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
        <div class='session-formats-container'>
         ${formats}
        </div>
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


function getformattedDateTime(datetimeString) {
    const options = {
        year: 'numeric',
        month: '2-digit',
        day: '2-digit',
        hour: '2-digit',
        minute: '2-digit'
    };

    const formattedDatetime = new Date(datetimeString).toLocaleString('en-US', options);
    return formattedDatetime.replace(',', ''); // Remove the comma from the default formatting

}



async function createPlaceHtml(sessionId) {
    let layoutBody = document.getElementById("layout-body");
    layoutBody.insertAdjacentHTML('afterbegin', `<div class="spinner-container middle-spinner" id="movies-spinner">
                    <div class="spinner-border" role="status">
                        <span class="sr-only"></span>
                    </div>
                    <h4>Opening Places</h4>
                </div>`);
    let session = await makeAjaxRequest(`/api/Session/GetSessionById/${sessionId}`);
    let spinner = document.getElementById("movies-spinner");
    spinner.remove();

    var formats = getMovieFormatsHtml(session.movie, 3);


    let content = `<div id="place-container" class="place-container">
		<div class="place-inner-container">
		<div onclick='closePlaces()' class="places-close-btn">
			<i class="fa-regular fa-circle-xmark"></i>
		</div>
			<div class="place-inner-up">
				<p>${session.movie.title}</p>
				<p>${getformattedDateTime(session.startTime)}</p>
				<p>${session.hall.name}</p>
        <div class='session-formats-container'>
         ${formats}
        </div>
			</div>

			<div class="place-inner-middle">
				<div class="seats-cont">`


    let seatCount = 0;
    let rowCount = Math.ceil(session.hall.seats.length / 14);

    for (var i = 0; i < rowCount; i++) {
        content += `<div class="seat-row">
						<div class="seat-row-number">
							<h4>${i + 1}</h4>
						</div>`;
        content += `<div style="flex-basis:90%;">
							<div class="seat-list">`;
        for (var k = 0; k < 14; k++) {

            var seatId = session.hall.seats[seatCount].id;
            if (session.hall.seats[seatCount].isAvailable == true) {

                content += `<a style="background-color:white;"  id="seat-${seatId}"  onclick="selectSeat('${session.movie.price}','${seatId}')">${k + 1}</a>`
            }
            else {
                content += `<a id="seat-${seatId}"  onclick="selectSeat('${session.movie.price}','${seatId}')" style="background-color:black;color:white;">${k + 1}</a>`
            }
            seatCount++;
        }

        content += `</div>
                        </div>
						<div class="seat-row-number">
							<h4>${i + 1}</h4>
						</div>
					</div>`;
    }

    content += `</div>
                <div class="screen-label">
					<h4>Screen</h4>
					<img alt="screen" src="/assets/images/zone_footer.png"/>
				</div>
			</div>
<div class="place-inner-down">
								<div class="place-inner-down-sec">
					<div class="seat-info-cont">
						<div class="seat-info-box"></div>
						<b>Empty seats</b>
					</div>

					<div class="seat-info-cont">
						<div class="seat-info-box" style="background-color:#00acec!important;"></div>
						<b>Selected seats</b>
					</div>

					<div class="seat-info-cont">
						<div class="seat-info-box" style="background-color:black!important;"></div>
						<b>Full seats</b>
					</div>
				</div>


				<div class="place-inner-down-sec">
					<div class="place-inner-down-bottom">

					</div>
					<div class="place-inner-down-bottom" style="flex-direction:column;">
						<b style="color:#00b0f0">Total Price:</b>
						<b id="price-display" style="color:white">AZN</b>
					</div>

					<div class="place-inner-down-bottom">
						<a class="confirm-btn">
							Confirm
						</a>
					</div>
				</div>
			</div>
		</div>`;
    layoutBody.insertAdjacentHTML('afterbegin', content);
    layoutBody.style.overflow = "hidden";
}

function showPlaces(sessionId) {
    createPlaceHtml(sessionId);
    let placeContainer = document.getElementById("place-container");

    
}

var totalPrice = 0;
function closePlaces() {
    totalPrice = 0;
    let placeContainer = document.getElementById("place-container");
    let layoutBody = document.getElementById("layout-body");
    layoutBody.style.overflow = "auto";
    placeContainer.remove();
}


function selectSeat(price, seatId) {
    let seatEl = document.getElementById(`seat-${seatId}`);
    let priceDisplay = document.getElementById("price-display");
    if (seatEl.style.backgroundColor != "black") {
        if (seatEl.style.backgroundColor == "white") {
            seatEl.style.backgroundColor = "rgb(0, 175, 240)";
            seatEl.style.color = "white";
            totalPrice += Number(price);
            priceDisplay.innerHTML = `${totalPrice} AZN`;
        }
        else if (seatEl.style.backgroundColor == "rgb(0, 175, 240)") {
            seatEl.style.backgroundColor = "white";
            seatEl.style.color = "black";
            totalPrice -= Number(price);
            priceDisplay.innerHTML = `${totalPrice} AZN`;

        }
    }
    //console.log(sessionData);

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

    addTableHeadToView();
    addSessionsTableBody();


    document.getElementById("sessions-table").style.display = 'block';
    document.getElementById("no_sessions").style.display = 'none';
    var sessionsBody = document.getElementById("sessions-body");
    if (resultSessions.length > 0) {
        var allHtml = "";
        for (let i = 0; i < resultSessions.length; i++) {
            const mySession = resultSessions[i];
            var html = createSessionsRowHtml(mySession, MAX_SESSION_FORMAT_COUNT);
            allHtml += html;
        }
        sessionsBody.innerHTML = allHtml;
    }
    else {
        document.getElementById("sessions-table").style.display = 'none';
        document.getElementById("no_sessions").style.display = 'block';
    }
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