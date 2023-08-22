const MAX_FORMAT_COUNT = 5;
const TITLE_LENGTH_LIMIT = 30;
var ALL_MOVIES;

document.addEventListener("DOMContentLoaded", function () {
    const tabHeaders = document.querySelectorAll(".tab_header a");
    const tabs = document.querySelectorAll(".tab");

    tabHeaders.forEach((tabHeader) => {
        tabHeader.addEventListener("click", function (event) {
            event.preventDefault();

            // Hide all tabs
            tabs.forEach((tab) => {
                tab.style.display = "none";
            });

            // Show the clicked tab
            const tabId = this.getAttribute("rel");
            const tabToShow = document.querySelector(`.tab.${tabId}_list`);
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

// Get the reference to the <a> element
const englishLink = document.getElementById("english-link");
let isBlue = false; // Track the color state

// Add a click event listener to change the color on click
englishLink.addEventListener("click", function (event) {
    event.preventDefault(); // Prevent the link from navigating (since you're using "#")

    // Toggle the color
    if (isBlue) {
        this.style.backgroundColor = "var(--second-color)"; // Back to default color
        this.style.color = "var(--main-text-color)"; // Back to default color
    } else {
        this.style.backgroundColor = "var(--third-color)"; // Change to blue
        this.style.color = "var(--second-color)"; // Back to default color
    }

    isBlue = !isBlue; // Toggle the color state
});

function filterMoviesByDateNewToOld(movieArray) {
    return movieArray.sort((a, b) => new Date(b.Released) - new Date(a.Released));
}

// Function to fetch and display movies from the JSON file
async function fetchMovies() {
    try {
        const fetchedMovies = await makeAjaxRequest("/api/Movie/GetAllMovies");
        console.log(fetchedMovies);

        if (Array.isArray(fetchedMovies)) {
            return filterMoviesByDateNewToOld(fetchedMovies);
        } else {
            return [];
        }
    } catch (error) {
        return [];
    }
}

function createFormatHtml(imageUrl, tooltip) {
    if (
        imageUrl ===
        "https://media.aykhan.net/assets/images/step-it-academy/diploma-project/flags/512/not-found.png"
    )
        return "";

    const html = `
      <div class='movie-format'>
        <span><b>${tooltip}</b></span>
        <img src="${imageUrl}" alt="#">
      </div>
    `;
    return html;
}

function getMovieFormatsHtml(movie, maxCount = 0) {
    const formats = [];

    movie.languages.forEach((language) => {
        const format = createFormatHtml(
            language.flagUrl,
            `Movie Language : ${language.name}`
        );
        formats.push(format);
    });

    movie.subtitles.forEach((subtitle) => {
        const format = createFormatHtml(subtitle.imageUrl, `Movie Subtitle`);
        formats.push(format);
    });

    // Get only the first 5 formats
    var selectedFormats = [];
    if (maxCount != 0) {
        selectedFormats = formats.slice(0, maxCount);
    } else {
        selectedFormats = formats.slice(0, MAX_FORMAT_COUNT);
    }

    // Join the array of HTML strings into a single string
    const formatsString = selectedFormats.join("");

    return formatsString;
}

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

async function addMoviesToView(movies) {
    if (movies != null) {
        var container = document.getElementById("movies");
        if (container != null) {
            var fullHtml = "";
            for (let i = 0; i < movies.length; i++) {
                const movie = movies[i];
                var html = createMovieHtml(movie);
                fullHtml += html;
            }
            container.innerHTML = fullHtml;
        }
    }
}

async function initializeApp() {
    try {
        ALL_MOVIES = await fetchMovies();
        addMoviesToView(ALL_MOVIES);
    } catch (error) {
        console.error("Error initializing the app:", error);
    }
}

// Call the initializeApp function to start the application
initializeApp();
