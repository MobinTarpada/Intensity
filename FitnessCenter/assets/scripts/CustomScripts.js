function SetMenuActive(LI) {
    $("#" + LI).addClass("active");
    $("#" + LI + " a:first span.arrow").removeClass("arrow").addClass("selected");
}