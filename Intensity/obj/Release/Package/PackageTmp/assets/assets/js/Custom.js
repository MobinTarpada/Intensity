function GiveClass(tagName, className) {
    var ele = document.getElementsByTagName(tagName);
    for (var i = 0; i < ele.length; i++) {
        if (!ele[i].hasAttribute("class")) {
            ele[i].setAttribute("class", className)
        }
    }
}

function RemoveClass() {
    var ele = document.getElementsByTagName("span");
    for (var i = 0; i < ele.length; i++) {
        if (!ele[i].hasAttribute("style")) {
            $(ele[i]).removeProp("font-family");
        }
    }
}