window.addEventListener("load", function () {
    const footer = document.querySelector(".footer");
    const bodyHeight = document.body.offsetHeight;
    const windowHeight = window.innerHeight;

    if (bodyHeight < windowHeight) {
        footer.style.position = "fixed";
        footer.style.bottom = "0";
    }
});


