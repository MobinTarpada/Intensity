<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="AttendenceManagement.aspx.cs" 
    Inherits="AttendenceSystem.AttendenceManagement" %>


<html lang="en">
<!-- Head -->
<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Daily Attendence System By Intensity Beyond Fitness</title>
   
    <!-- Meta-Tags -->
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8">
    <meta name="keywords" content="Custom Signup Form Responsive, Login Form Web Template, Flat Pricing Tables, Flat Drop-Downs, Sign-Up Web Templates, Flat Web Templates, Login Sign-up Responsive Web Template, Smartphone Compatible Web Template, Free Web Designs for Nokia, Samsung, LG, Sony Ericsson, Motorola Web Design">
    <script type="application/x-javascript"> addEventListener("load", function() { setTimeout(hideURLbar, 0); }, false); function hideURLbar(){ window.scrollTo(0,1); } </script>
    <!-- //Meta-Tags -->

    <!-- Custom-Style-Sheet -->
    <!-- Index-Page-CSS -->
    <link href="assets/css/bootstrap1.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLES-->
    <link href="assets/css/custom1.css" rel="stylesheet" />
    <!-- DataTables -->
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!-- Validation -->
    <link href="assets/css/ValidationEngine.css" rel="stylesheet" />
    <link rel="stylesheet" href="css/style.css" type="text/css" media="all">
    <!-- Calendar-CSS -->
    <link rel="stylesheet" href="css/jquery-ui.css" type="text/css" media="all">
    <!-- //Custom-Style-Sheet -->

    <!-- Fonts -->
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Roboto:100,300,400,500,700,900" type="text/css" media="all">
    <link rel="stylesheet" href="//fonts.googleapis.com/css?family=Montserrat:400,700" type="text/css" media="all">
    <!-- //Fonts -->

</head>
<!-- //Head -->



<!-- Body -->
<body>

    <%--<h1></h1>--%>
    <%--<asp:Label ID="Label1" ForeColor="White" Font-Size="35px" Font-Bold="true" runat="server" Text="DAILY ATTENDENCE FORM"></asp:Label>
    <br />
    <br />--%>
    <div class="containerw3layouts-agileits">
        <form defaultbutton="btnOk" id="form2" runat="server">
            <div class="w3imageaits" style="padding-left: 10px">

                <%--<input id="imgProfileImage" type="image" src="assets/img/ProfileImage.png" class="profile_img img-responsive" />--%>
                <%-- <input type="file" id="FileUploadControl" style="display: none;" />--%>
                <br />
                <asp:Image Height="150px" ID="imgProfileImage" ImageUrl="~/MemberProfilePicture/ProfileImage.png" AlternateText="Profile Image" runat="server" class="profile_img img-responsive" />
                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                <br />
                <asp:Label runat="server" ID="StatusLabel" ForeColor="Red" />
                <br />

                <asp:Label ID="lblSearch" Font-Size="35px" Font-Bold="true" runat="server" Text="Search:"></asp:Label>
                <asp:TextBox ID="txtSearch" OnTextChanged="txtSearch_TextChanged" runat="server" AutoPostBack="True"></asp:TextBox>

                <asp:Label ID="lblMemberName" ForeColor="Red" Font-Size="50px" Font-Bold="true" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblpKg" Font-Bold="True" Font-Size="Medium" runat="server" Text="Package:"></asp:Label>
                <asp:Label ID="lblPackageName" Font-Bold="True" Font-Size="Medium" runat="server" Text=""></asp:Label>
                <br />
                <asp:Label ID="lblStatus" Font-Bold="True" Font-Size="Medium" runat="server" Text="Status:"></asp:Label>
                <asp:Label ID="txtStatus" Font-Bold="True" Font-Size="Medium" runat="server" Text=""></asp:Label>

                <div style="padding: 50px 0 25px 0;">
                    <div class="text-center">
                        <asp:Label ID="Label8" Font-Bold="true" Font-Size="30px" runat="server" Text="Last Check In"></asp:Label>
                    </div>
                    <div class="text-center">
                        <div>
                            <asp:Label ID="lblCheckInTime" Font-Bold="true" Font-Size="20px" runat="server" Text=""></asp:Label>
                        </div>

                        <div>
                            <asp:Label ID="lblCheckInDate" Font-Bold="true" Font-Size="15px" runat="server" Text=""></asp:Label>
                        </div>

                        <div>
                            <asp:Label ID="lblDays" Font-Size="22px" Font-Bold="true" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                </div>
            </div>


            <div class="aitsloginwthree w3layouts agileits">

                <asp:Label ID="lblMembrId" Font-Bold="true" runat="server" Text="Membership #:"></asp:Label>
                <asp:TextBox ID="txtMemberId" runat="server"></asp:TextBox>

                <asp:Label ID="lblBranchName" Font-Bold="true" runat="server" Text="Branch Name:"></asp:Label>
                <asp:TextBox ID="txtBranchName" runat="server"></asp:TextBox>

                <asp:Label ID="lblAccessType" runat="server" Font-Bold="true" Text="Access Type:"></asp:Label>
                <asp:TextBox ID="txtAccessType" runat="server"></asp:TextBox>

                <asp:Label ID="lblMsg" runat="server" Font-Bold="true" Text="Message:"></asp:Label><br />
                <asp:TextBox ID="txtMsg" runat="server"></asp:TextBox>
                <br />
                <br />
                <div class="send-button wthree agileits">
                    <asp:Button ID="btnOK" BackColor="Lime" Font-Bold="true" ForeColor="Black" runat="server" OnClick="btnOK_Click" Text="OK" />
                    <asp:Button ID="btnOverride" BackColor="Blue" Font-Bold="true" ForeColor="White" runat="server" Text="OVERRIDE" OnClick="btnOverride_Click" />
                </div>
            </div>

            <div class="clear"></div>
        </form>
    </div>

   <%-- <div class="w3lsfooteragileits">
        <p>&copy; 2017 New Way Electronics All Rights Reserved | Design by <a href="http://newwayelectronics.co.in" target="=_blank">NewWayElectronics</a></p>
    </div>--%>


    <!-- Necessary-JavaScript-Files-&-Links -->

    <!-- Default-JavaScript -->
    <script src="assets/assets/js/jquery-1.11.0.min.js"></script>
    <%--<script src="http://code.jquery.com/jquery-1.11.1.min.js"></script>--%>
    <script type="text/javascript" src="js/jquery-3.1.1.js"></script>
    <!-- EndFooter -->
    <!-- JQUERY SCRIPTS -->
    <script src="assets/js/jquery-1.10.2.js"></script>
    <!-- BOOTSTRAP SCRIPTS -->
    <script src="assets/js/bootstrap.min.js"></script>
    <!-- METISMENU SCRIPTS -->
    <script src="assets/js/jquery.metisMenu.js"></script>
    <!-- DataTables -->
    <script src="assets/js/dataTables/jquery.dataTables.js"></script>
    <script src="assets/js/dataTables/dataTables.bootstrap.js"></script>
    <!-- CUSTOM SCRIPTS -->
    <script src="assets/js/custom.js"></script>
    <!-- Date-Picker-JavaScript -->
    <script src="js/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker1").datepicker();
        });
    </script>
    <!-- //Date-Picker-JavaScript -->

    <!-- //Necessary-JavaScript-Files-&-Links -->



</body>
<!-- //Body -->



</html>
