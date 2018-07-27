// Author : Hardik Vaghela
// Usage  : Popup Script for DeleteConfirmationBox









function DeleteConfirmPopupFromGrid(title, message, controlId) {


    $("body").append("<div id='CustomModalPopup'>" +
                        "<div id='masteroverlay' class='web_dialog_overlay hide'></div>" +
                            "<div id='MsgBoxModal' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'" +
                                "aria-hidden='true'>" +
                            "<div class='wdoHeader'>" +
                                "<button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#MsgBoxModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return false;'>x</button>" +
                                "<span> " + String(title) + "</span>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<p> " + String(message) + "</p>" +
                            "</div>" +
                            "<div class='wdoFooter' align='center'>" +
                             "<input type='button' value='OK' onClick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#" + controlId + "\").next().click();$(\"#CustomModalPopup\").remove();return true;' class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />" +
                             "<input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return false;'/>" +
                            "</div>" +
                        "</div>" +
                    "</div>");

    $('#MsgBoxModal').removeClass('hide');
    $('#masteroverlay').removeClass('hide');
    $('#MsgBoxModal').fadeIn(300);
}
// To Show Message When Click Ok it Calls Next Button Event
function MsgBox(title, message, controlId) {

    $("body").append("<div id='CustomModalPopup'>" +
                        "<div id='masteroverlay' class='web_dialog_overlay hide'></div>" +
                            "<div id='MsgBoxModal' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'" +
                                "aria-hidden='true'>" +
                            "<div class='wdoHeader'>" +
                                "<span> " + String(title) + "</span>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<p> " + String(message) + "</p>" +
                            "</div>" +
                            "<div class='wdoFooter' align='center'>" +
                                "<input type='button' value='OK' onClick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#" + controlId + "\").next().click();$(\"#CustomModalPopup\").remove();return true;' class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />" +
                            "</div>" +
                        "</div>" +
                    "</div>");

    $('#MsgBoxModal').removeClass('hide');
    $('#masteroverlay').removeClass('hide');
    $('#MsgBoxModal').fadeIn(300);

}

// To Show Only Message Not Call any Event
function MessageBox(title, message) {

    $("body").append("<div id='CustomModalPopup'>" +
                        "<div id='masteroverlay' class='web_dialog_overlay hide'></div>" +
                            "<div id='MsgBoxModal' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'" +
                                "aria-hidden='true'>" +
                            "<div class='wdoHeader'>" +
                                "<button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#MsgBoxModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return false;'>x</button>" +
                                "<span> " + String(title) + "</span>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<p> " + String(message) + "</p>" +
                            "</div>" +
                            "<div class='wdoFooter' align='center'>" +

                                //"<input type='button' value='OK' onClick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return true;' class='delete-popup-button btn-glow primary login modalbtn mrgleft10 fltLeft' />" +
                                "<button onClick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return true;' class='btn btn-icon btn-primary glyphicons circle_ok mrgleft10 fltLeft'><i></i>OK</button>" +

                            "</div>" +
                        "</div>" +
                    "</div>");

    $('#MsgBoxModal').removeClass('hide');
    $('#masteroverlay').removeClass('hide');
    $('#MsgBoxModal').fadeIn(300);

}

function MessageBoxForAnotherPopup(title, message, controlId) {

    $("body").append("<div id='CustomModalPopup'>" +
                        "<div id='masteroverlay' class='web_dialog_overlay hide'></div>" +
                            "<div id='MsgBoxModal' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'" +
                                "aria-hidden='true'>" +
                            "<div class='wdoHeader'>" +
                                "<button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick=' $(\"#MsgBoxModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#MsgBoxModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return false;'>x</button>" +
                                "<span> " + String(title) + "</span>" +
                            "</div>" +
                            "<div class='modal-body'>" +
                                "<p> " + String(message) + "</p>" +
                            "</div>" +
                            "<div class='wdoFooter' align='center'>" +

                                "<input type='button' value='OK' onClick='$(\"#ConfirmationModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#ConfirmationModal\").fadeOut(300);$(\"#" + controlId + "\").click();$(\"#CustomModalPopup\").remove();return true;' class='delete-popup-button btn-glow primary login modalbtn mrgleft10 pull-left' />"
                            +
                            "</div>" +
                        "</div>" +
                    "</div>");

    $('#MsgBoxModal').removeClass('hide');
    $('#masteroverlay').removeClass('hide');
    $('#MsgBoxModal').fadeIn(300);

}

// For display message on top of the page  when insert Update or Delete
function FadInMessage(msg) {
    $("#spnMessage").text(msg);
    for (i = 0; i < 1; i++) {
        $("#spnMessage").fadeIn(1000);
        $("#spnMessage").delay(3000).show(0);
        $("#spnMessage").fadeOut(3000);
    }
}

