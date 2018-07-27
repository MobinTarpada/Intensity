




//FOR LOGO UPLOAD
function UploadUserPhoto_PageLoad(i) {

    if ($("#DivUpload").length != 0)
        UploadUserPhoto(i);
}
function UploadUserPhoto(i) {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,html4,flash,silverlight,browserplus,gears',
        browse_button: 'btnBrowse',
        container: 'DivUpload',
        max_file_size: '10mb',
        url: '/ServicePages/DefaultServices.aspx',
        multi_selection: false,  // Set True for Multi Select //
        multipart_params: { 'MethodName': 'UploadCompanyLogo', 'CompId': '', 'Mode': '' },
        flash_swf_url: '/Scripts/FileUpload/plupload.flash.swf',
        silverlight_xap_url: '/Scripts/FileUpload/plupload.silverlight.xap',
        filters: [{ title: "Image files", extensions: "jpg,gif,png,jpeg" }],
        init: {
            Error: function (up, args) {
                // Called when a error has occured
                $("#" + args.file.id + "").remove();
            }
        }
    });

    uploader.bind('FilesAdded', function (up, files) {

        if ($('#DU_filelistuser').children().length != 0) {

            var Ctrl = $("#DU_filelistuser").children()[0];
            up.removeFile(up.getFile(Ctrl.id));
            $(Ctrl).remove();

        }
        for (var i in files) {
            $('#DU_filelistuser').append('<div id="' + files[i].id + '"><span id="updPercent"></span></div>');
        }

    });

    uploader.bind('UploadProgress', function (up, file) {

        $("#DivBackground").show();
        $("#updPercent").html(file.percent + "%");
        $("#DivProgressBar").css("width", file.percent + "%");
    });


    uploader.bind('QueueChanged', function (up) {

        uploader.settings.multipart_params['CompId'] = $("#hdnCompanyId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnMode").val();

        uploader.start();
    });

    $('#btnUpload').click(function () {

        uploader.settings.multipart_params['CompId'] = $("#hdnCompanyId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnMode").val();
        uploader.start();
        //return false;
    });

    uploader.bind('FileUploaded', function (up, file, info) {

        var json = $.parseJSON(info.response);
        if (json[0] == "Error") {
            alert("Error");
            //window.location = "Error.aspx";
        }
        else if (json[0] == "SessionExpired") {
            window.location = "/FrmLogin.aspx";
        }
        else {

            $("#imgLogo").attr("src", "" + json[2] + "");
            $("#hdnLogoFile").val("" + json[1] + "");
            $("#imgLogo").removeClass("display-none");
        }
    });

    uploader.init();
}

function UploadLocationPhoto_PageLoad(i) {

    if ($("#DivUpload").length != 0)
        UploadLocationPhoto(i);
}
function UploadLocationPhoto(i) {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,html4,flash,silverlight,browserplus,gears',
        browse_button: 'btnBrowse',
        container: 'DivUpload',
        max_file_size: '10mb',
        url: '/ServicePages/DefaultServices.aspx',
        multi_selection: false,  // Set True for Multi Select //
        multipart_params: { 'MethodName': 'UploadLocationImage', 'LocationId': '', 'Mode': '' },
        flash_swf_url: '/Scripts/FileUpload/plupload.flash.swf',
        silverlight_xap_url: '/Scripts/FileUpload/plupload.silverlight.xap',
        filters: [{ title: "Image files", extensions: "jpg,gif,png,jpeg" }],
        init: {
            Error: function (up, args) {
                // Called when a error has occured
                $("#" + args.file.id + "").remove();
            }
        }
    });

    uploader.bind('FilesAdded', function (up, files) {

        if ($('#DU_filelistuser').children().length != 0) {

            var Ctrl = $("#DU_filelistuser").children()[0];
            up.removeFile(up.getFile(Ctrl.id));
            $(Ctrl).remove();

        }
        for (var i in files) {
            $('#DU_filelistuser').append('<div id="' + files[i].id + '"><span id="updPercent"></span></div>');
        }

    });

    uploader.bind('UploadProgress', function (up, file) {

        $("#DivBackground").show();
        $("#updPercent").html(file.percent + "%");
        $("#DivProgressBar").css("width", file.percent + "%");
    });


    uploader.bind('QueueChanged', function (up) {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnMode").val();

        uploader.start();
    });

    $('#btnUpload').click(function () {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnMode").val();
        uploader.start();
        //return false;
    });

    uploader.bind('FileUploaded', function (up, file, info) {

        var json = $.parseJSON(info.response);
        if (json[0] == "Error") {
            alert("Error");
            //window.location = "Error.aspx";
        }
        else if (json[0] == "SessionExpired") {
            window.location = "/FrmLogin.aspx";
        }
        else {

            $("#imgLogo").attr("src", "" + json[2] + "");
            $("#hdnLogoFile").val("" + json[1] + "");
            $("#imgLogo").show();
        }
    });

    uploader.init();
}


function UploadProfilePhoto_PageLoad(i) {

    if ($("#DivUserUpload").length != 0)
        UploadProfilePhoto(i);
}
function UploadProfilePhoto(i) {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,html4,flash,silverlight,browserplus,gears',
        browse_button: 'btnUserBrowse',
        container: 'DivUserUpload',
        max_file_size: '10mb',
        url: '/ServicePages/DefaultServices.aspx',
        multi_selection: false,  // Set True for Multi Select //
        multipart_params: { 'MethodName': 'UploadUserLogo', 'UserId': '', 'Mode': '' },
        flash_swf_url: '/Scripts/FileUpload/plupload.flash.swf',
        silverlight_xap_url: '/Scripts/FileUpload/plupload.silverlight.xap',
        filters: [{ title: "Image files", extensions: "jpg,gif,png,jpeg" }],
        init: {
            Error: function (up, args) {
                // Called when a error has occured
                $("#" + args.file.id + "").remove();
            }
        }
    });

    uploader.bind('FilesAdded', function (up, files) {

        if ($('#DU_Userfilelistuser').children().length != 0) {

            var Ctrl = $("#DU_Userfilelistuser").children()[0];
            up.removeFile(up.getFile(Ctrl.id));
            $(Ctrl).remove();

        }
        for (var i in files) {
            $('#DU_Userfilelistuser').append('<div id="' + files[i].id + '"><span id="updPercent"></span></div>');
        }

    });

    uploader.bind('UploadProgress', function (up, file) {

        $("#DivUserBackground").show();
        $("#updPercent").html(file.percent + "%");
        $("#DivUserProgressBar").css("width", file.percent + "%");
    });


    uploader.bind('QueueChanged', function (up) {

        uploader.settings.multipart_params['UserId'] = $("#hdnUserId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnUserMode").val();

        uploader.start();
    });

    $('#btnUpload').click(function () {

        uploader.settings.multipart_params['UserId'] = $("#hdnUserId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnUserMode").val();
        uploader.start();
        //return false;
    });

    uploader.bind('FileUploaded', function (up, file, info) {

        var json = $.parseJSON(info.response);
        if (json[0] == "Error") {
            alert("Error");
            //window.location = "Error.aspx";
        }
        else if (json[0] == "SessionExpired") {
            window.location = "/FrmLogin.aspx";
        }
        else {

            $("#imgUserLogo").attr("src", "" + json[2] + "");
            $("#hdnUserLogoFile").val("" + json[1] + "");
            $("#imgUserLogo").show();
        }
    });

    uploader.init();
}


function UploadLocationVideo_PageLoad(i) {

    if ($("#DvLocationVideo").length != 0)
        UploadLocationVideo(i);
}
function UploadLocationVideo(i) {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,html4,flash,silverlight,browserplus,gears',
        browse_button: 'btnLocationVideoBrowse',
        container: 'DvLocationVideo',
        max_file_size: '20mb',
        url: '/ServicePages/DefaultServices.aspx',
        multi_selection: false,  // Set True for Multi Select //
        multipart_params: { 'MethodName': 'UploadLocationVideo', 'LocationId': '', 'Mode': '' },
        flash_swf_url: '/Scripts/FileUpload/plupload.flash.swf',
        silverlight_xap_url: '/Scripts/FileUpload/plupload.silverlight.xap',
        filters: [{ title: "Video files", extensions: "mp4,mkv,wmd,vmp" }],
        init: {
            Error: function (up, args) {
                // Called when a error has occured
                $("#" + args.file.id + "").remove();
            }
        }
    });

    uploader.bind('FilesAdded', function (up, files) {

        if ($('#LocationVideoDU_filelistuser').children().length != 0) {

            var Ctrl = $("#LocationVideoDU_filelistuser").children()[0];
            up.removeFile(up.getFile(Ctrl.id));
            $(Ctrl).remove();

        }
        for (var i in files) {
            $('#LocationVideoDU_filelistuser').append('<div id="' + files[i].id + '"><span id="updPercentVideoUrl"></span></div>');
        }

    });

    uploader.bind('UploadProgress', function (up, file) {

        $("#LocationVideoDivBackground").show();
        $("#updPercentVideoUrl").html(file.percent + "%");
        $("#LocationVideoDivProgressBar").css("width", file.percent + "%");
    });


    uploader.bind('QueueChanged', function (up) {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationVideoLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnLocationVideoMode").val();

        uploader.start();
    });

    $('#btnUpload').click(function () {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationVideoLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnLocationVideoMode").val();
        uploader.start();
        //return false;
    });

    uploader.bind('FileUploaded', function (up, file, info) {

        var json = $.parseJSON(info.response);
        if (json[0] == "Error") {
            alert("Error");
            //window.location = "Error.aspx";
        }
        else if (json[0] == "SessionExpired") {
            window.location = "/FrmLogin.aspx";
        }
        else {

            $("#LocationVideoURL").attr("href", "" + json[2] + "");
            $("#hdnLocationVideoLogoFile").val("" + json[1] + "");
            if ($("#hdnLocationVideoMode").val() == "Insert") {
                $("#LocationVideoURL").removeClass("display-none");
                $("#LocationVideoURL").show();
                $("#LocationVideoURLEdit").addClass("display-none");
                $("#LocationVideoURLEdit").hide();
            }
            else if ($("#hdnLocationVideoMode").val() == "Update") {
                $("#LocationVideoURL").addClass("display-none");
                $("#LocationVideoURL").hide();
                $("#LocationVideoURLEdit").removeClass("display-none");
                $("#LocationVideoURLEdit").show();
                $("#LocationVideoURLEdit").attr("href", "" + json[2] + "");
            }
        }
    });

    uploader.init();
}

function UploadLocationContractorVideo_PageLoad(i) {

    if ($("#DvLocationContractorVideo").length != 0)
        UploadLocationContractorVideo(i);
}

function UploadLocationContractorVideo(i) {
    var uploader = new plupload.Uploader({
        runtimes: 'html5,html4,flash,silverlight,browserplus,gears',
        browse_button: 'btnLocationContractorVideoBrowse',
        container: 'DvLocationContractorVideo',
        max_file_size: '20mb',
        url: '/ServicePages/DefaultServices.aspx',
        multi_selection: false,  // Set True for Multi Select //
        multipart_params: { 'MethodName': 'UploadLocationVideoForContractor', 'LocationId': '', 'Mode': '' },
        flash_swf_url: '/Scripts/FileUpload/plupload.flash.swf',
        silverlight_xap_url: '/Scripts/FileUpload/plupload.silverlight.xap',
        filters: [{ title: "Video files", extensions: "mp4,mkv,wmd,vmp" }],
        init: {
            Error: function (up, args) {
                // Called when a error has occured
                $("#" + args.file.id + "").remove();
            }
        }
    });

    uploader.bind('FilesAdded', function (up, files) {

        if ($('#LocationContractorVideoDU_filelistuser').children().length != 0) {

            var Ctrl = $("#LocationContractorVideoDU_filelistuser").children()[0];
            up.removeFile(up.getFile(Ctrl.id));
            $(Ctrl).remove();

        }
        for (var i in files) {
            $('#LocationContractorVideoDU_filelistuser').append('<div id="' + files[i].id + '"><span id="updPercentContractorVideo"></span></div>');
        }

    });

    uploader.bind('UploadProgress', function (up, file) {

        $("#LocationContractorVideoDivBackground").show();
        $("#updPercentContractorVideo").html(file.percent + "%");
        $("#LocationContractorVideoDivProgressBar").css("width", file.percent + "%");
    });


    uploader.bind('QueueChanged', function (up) {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationContractorVideoLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnLocationContractorVideoMode").val();

        uploader.start();
    });

    $('#btnUpload').click(function () {

        uploader.settings.multipart_params['LocationId'] = $("#hdnLocationContractorVideoLocationId").val();
        uploader.settings.multipart_params['Mode'] = $("#hdnLocationContractorVideoMode").val();
        uploader.start();
        //return false;
    });

    uploader.bind('FileUploaded', function (up, file, info) {

        var json = $.parseJSON(info.response);
        if (json[0] == "Error") {
            alert("Error");
            //window.location = "Error.aspx";
        }
        else if (json[0] == "SessionExpired") {
            window.location = "/FrmLogin.aspx";
        }
        else {

            $("#LocationContractorVideoURL").attr("href", "" + json[2] + "");
            $("#hdnLocationContractorVideoLogoFile").val("" + json[1] + "");
            if ($("#hdnLocationContractorVideoMode").val() == "Insert") {
                $("#LocationContractorVideoURL").removeClass("display-none");
                $("#LocationContractorVideoURL").show();
                $("#LocationContractorVideoURLEdit").addClass("display-none");
                $("#LocationContractorVideoURLEdit").hide();
            }
            else if ($("#hdnLocationContractorVideoMode").val() == "Update") {
                $("#LocationContractorVideoURL").addClass("display-none");
                $("#LocationContractorVideoURLEdit").removeClass("display-none");
                $("#LocationContractorVideoURLEdit").show();
                $("#LocationContractorVideoURL").hide()
                $("#LocationContractorVideoURLEdit").attr("href", "" + json[2] + "");
            }
        }
    });

    uploader.init();
}






