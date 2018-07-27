







function ValidateCustom(e) {

    var AllControl = $("." + e + "text-input").not('div');
    var ValidateFlage = true;
    var ControlFlage = true;
    var oldvalue = "";
    var firstPWD = true;
    var oldControl = "";

    //validate textbox and dropdown
    for (var i = 0; i < AllControl.length; i++) {
        var txt = $(AllControl[i]).val().trim();

        if (txt.length > 0) {

            if ($(AllControl[i]).hasClass('customPasswrod')) {

                if (firstPWD == true) {
                    oldvalue = txt;
                    firstPWD = false;
                    oldControl = i;
                }
                else {
                    if (oldvalue != txt) {
                        ErrorToolTip((AllControl[i]), 'Password Mismatch');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                    else if (txt.length < 6) {
                        ErrorToolTip((AllControl[i]), 'Atleast 6 Character Required');
                        ErrorToolTip((AllControl[oldControl]), 'Atleast 6 Character Required');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                    else {
                        ValidateFlage = true;
                    }
                }
            }

                //for MultiSelection
            else if ($(AllControl[i]).hasClass('MultiSelection')) {


                if ($(AllControl[i]).hasClass('MultiSelection')) {
                    var Value = $("#MultiChurch").find("div").length;
                    if (Value == 0) {
                        ErrorToolTip((AllControl[i]), 'Select Atleast One Church');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                    else {
                        ValidateFlage = true;
                    }
                }
            }


            //For Password Length
            else if ($(AllControl[i]).hasClass('minimumPasswrod')) {
                if (txt.length >= 6) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('minimumPasswrod'))
                        ErrorToolTip((AllControl[i]), 'Atleast 6 Character Required');
                    ValidateFlage = false;
                    ControlFlage = false;
                }
            }
            //For ZipCode Length
            else if ($(AllControl[i]).hasClass('zipcode')) {
                if (txt.length < 10) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('zipcode'))
                        ErrorToolTip((AllControl[i]), 'only 10 Character Required');
                    ValidateFlage = false;
                    ControlFlage = false;
                }
            }
            //For URL
            else if ($(AllControl[i]).hasClass('customUrl')) {
                var url = new RegExp(/^(https?|ftp):\/\/(((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:)*@)?(((\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5])\.(\d|[1-9]\d|1\d\d|2[0-4]\d|25[0-5]))|((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?)(:\d*)?)(\/((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)+(\/(([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)*)*)?)?(\?((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|[\uE000-\uF8FF]|\/|\?)*)?(\#((([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(%[\da-f]{2})|[!\$&'\(\)\*\+,;=]|:|@)|\/|\?)*)?$/i);
                if (url.test(txt)) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('customUrl')) {
                        ErrorToolTip((AllControl[i]), 'Invalid URL');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                }
            }

           
            
            //For DropDown
            else if ($(AllControl[i]).hasClass('customDropDown')) {

                //$(AllControl[i]).select2('destroy');

                if (txt != "0") {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('customDropDown')) {
                        ErrorToolTip((AllControl[i]), 'Select one');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                }

                //$(AllControl[i]).select2();
            }

            // Date Format
            else if ($(AllControl[i]).hasClass('customDate')) {
                var Email = new RegExp(/^(0[1-9]|[12][0-9]|3[01])[ \.-](0[1-9]|1[012])[ \.-](19|20|)\d\d$/i);
                if (Email.test(txt)) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('customDate')) {
                        ErrorToolTip((AllControl[i]), 'Invalid Date');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                }
            }

            // For Email
            else if ($(AllControl[i]).hasClass('customEmail')) {
                var Email = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                if (Email.test(txt)) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('customEmail')) {
                        ErrorToolTip((AllControl[i]), 'Invalid Email');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                }
            }

            // For Multiple Email (Comma (,) seperated)
            else if ($(AllControl[i]).hasClass('MultipulecustomEmail')) {
                var Email = new RegExp(/^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$/i);
                var addr = txt.split(",");
                for (var q = 0; q < addr.length; q++) {
                    if (Email.test(addr[q])) {
                        ValidateFlage = true;
                    }
                    else {
                        if ($(AllControl[i]).hasClass('MultipulecustomEmail')) {
                            ErrorToolTip((AllControl[i]), 'Invalid Multipule Email');
                            ValidateFlage = false;
                            ControlFlage = false;

                        }
                        break;
                    }
                }
            }
                // For numeric
            else if ($(AllControl[i]).hasClass('customNumeric')) {
                var Numeric = new RegExp(/^[\-\+]?(([0-9]+)([\.,]([0-9]+))?|([\.,]([0-9]+))?)$/);
                if (Numeric.test(txt)) {
                    ValidateFlage = true;
                }
                else {
                    if ($(AllControl[i]).hasClass('customNumeric')) {
                        ErrorToolTip((AllControl[i]), 'Invalid Number');
                        ValidateFlage = false;
                        ControlFlage = false;
                    }
                }
            }
        }

        else if (txt == "") {
            ValidateFlage = false;
            ControlFlage = false;
            ErrorToolTip((AllControl[i]), 'Required Field');
        } //End IF
    } //End For

    if (ValidateFlage == true && ControlFlage == true) {
        //Write Code for Remove All Validation tooltips
        RemoveAllValidation();
        return true;
    }
    else {
        return false;
    }
}



//Make tooltip into div ctlfield= control name  & message= Errormessage which display into tooptip
function ErrorToolTip(ctlfield, message) {
    var prompt = $('<div class="' + ctlfield.id + ' parentFormformID1 formError" style="top: 68.4167px; left: 402.15px; margin-top: 0px; opacity: 0.87;"><div class="formErrorContent">* ' + message + '<br></div><div class="formErrorArrow"><div class="line10"><!-- --></div><div class="line9"><!-- --></div><div class="line8"><!-- --></div><div class="line7"><!-- --></div><div class="line6"><!-- --></div><div class="line5"><!-- --></div><div class="line4"><!-- --></div><div class="line3"><!-- --></div><div class="line2"><!-- --></div><div class="line1"><!-- --></div></div></div>');
    var arrow = $('<div>').addClass("formErrorArrow");
    prompt.append(arrow);

    $("body").append(prompt);
    var form = $(ctlfield).closest('form');

    //var form = $(ctlfield).closest('pnl2');

    var options = "";

    var pos = calculatePosition($(ctlfield), prompt, options);
    prompt.css({
        "top": pos.callerTopPosition,
        "left": pos.callerleftPosition,
        "marginTop": pos.marginTopSize,
        "opacity": 0
    }).data("callerField", $(ctlfield));

    prompt.animate({
        "opacity": 0.87
    });
}

// Calculate tooltip position
function calculatePosition(field, promptElmt, options) {

    var promptTopPosition, promptleftPosition, marginTopSize;
    var fieldWidth = field.width();
    var promptHeight = promptElmt.height();

    var offset = field.offset();
    promptTopPosition = offset.top;
    promptleftPosition = offset.left;
    marginTopSize = 0;

    switch (field.data("promptPosition")) {
        default:
        case "topRight":
            promptleftPosition += fieldWidth - 30;
            promptTopPosition += -promptHeight - 2;
            break;
        case "topLeft":
            promptTopPosition += -promptHeight - 10;
            break;
        case "centerRight":
            promptleftPosition += fieldWidth + 13;
            break;

        case "customRight":
            promptleftPosition += fieldWidth + 30;
            promptTopPosition += -promptHeight + 30;
            break;

        case "bottomLeft":
            promptTopPosition = promptTopPosition + field.height() + 15;
            break;
        case "bottomRight":
            promptleftPosition += fieldWidth - 30;
            promptTopPosition += field.height() + 5;
    }

    return {
        "callerTopPosition": promptTopPosition + "px",
        "callerleftPosition": promptleftPosition + "px",
        "marginTopSize": marginTopSize + "px"
    };
}

// For remove tooltip when control outfocus
function RemoveValidate(e) {
    $("." + e.id).remove();
}
function RemoveValidationById(e) {
    $("."+e).remove();
}
function RemoveValidationByClass(e) {
    $("." + e.class).remove();
}

// For remove all tooltip when cancel
function RemoveAllValidation() {
    $(".formError").remove();
}

function GetBrowserName() {
    var nVer = navigator.appVersion;
    var nAgt = navigator.userAgent;
    var browserName = navigator.appName;
    var fullVersion = '' + parseFloat(navigator.appVersion);
    var majorVersion = parseInt(navigator.appVersion, 10);
    var nameOffset, verOffset, ix;

    // In Opera, the true version is after "Opera" or after "Version"
    if ((verOffset = nAgt.indexOf("Opera")) != -1) {
        browserName = "Opera";
        fullVersion = nAgt.substring(verOffset + 6);
        if ((verOffset = nAgt.indexOf("Version")) != -1)
            fullVersion = nAgt.substring(verOffset + 8);
    }
    // In MSIE, the true version is after "MSIE" in userAgent
    else if ((verOffset = nAgt.indexOf("MSIE")) != -1) {
        browserName = "Microsoft Internet Explorer";
        fullVersion = nAgt.substring(verOffset + 5);
    }
    // In Chrome, the true version is after "Chrome" 
    else if ((verOffset = nAgt.indexOf("Chrome")) != -1) {
        browserName = "Chrome";
        fullVersion = nAgt.substring(verOffset + 7);
    }
    // In Safari, the true version is after "Safari" or after "Version" 
    else if ((verOffset = nAgt.indexOf("Safari")) != -1) {
        browserName = "Safari";
        fullVersion = nAgt.substring(verOffset + 7);
        if ((verOffset = nAgt.indexOf("Version")) != -1)
            fullVersion = nAgt.substring(verOffset + 8);
    }
    // In Firefox, the true version is after "Firefox" 
    else if ((verOffset = nAgt.indexOf("Firefox")) != -1) {
        browserName = "Firefox";
        fullVersion = nAgt.substring(verOffset + 8);
    }
    // In most other browsers, "name/version" is at the end of userAgent 
    else if ((nameOffset = nAgt.lastIndexOf(' ') + 1) <
          (verOffset = nAgt.lastIndexOf('/'))) {
        browserName = nAgt.substring(nameOffset, verOffset);
        fullVersion = nAgt.substring(verOffset + 1);
        if (browserName.toLowerCase() == browserName.toUpperCase()) {
            browserName = navigator.appName;
        }
    }

    return browserName;
}
