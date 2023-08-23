var hamburgerBtn = document.getElementById("hamburgerBtn");
var hamburgerDropdown = document.getElementById("hamburgerDropdown");
const hamDivElements = document.querySelectorAll('.hamDiv');
var isShown = false;
hamburgerBtn.addEventListener("click", () => {
    if (!isShown) {
        hamburgerDropdown.classList.remove("unDisplay");
        hamburgerDropdown.classList.add("display");
        hamburgerBtn.classList.remove("fa-solid", "fa-bars");
        hamburgerBtn.classList.add("fa-solid", "fa-xmark");
        hamburgerBtn.style.fontSize = "60px"

        hamDivElements.forEach((element) => {
            element.style.visibility = 'visible';
        });
    } else { 
        hamburgerDropdown.classList.add("unDisplay");
        hamburgerDropdown.classList.remove("display");
        hamburgerBtn.classList.remove("fa-solid", "fa-xmark");
        hamburgerBtn.classList.add("fa-solid", "fa-bars");
        hamburgerBtn.style.fontSize = "50px"
        hamDivElements.forEach((element) => {
            element.style.visibility = 'hidden';
        });
    }
    isShown = !isShown;
});

