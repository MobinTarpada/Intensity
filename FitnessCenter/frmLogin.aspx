<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="frmLogin.aspx.cs" Inherits="FitnessCenter.frmLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Fitness Management | Login </title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1.0" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />

    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/plugins/bootstrap/css/bootstrap.css" rel="stylesheet" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" />
    <!-- END GLOBAL MANDATORY STYLES -->

    <!-- BEGIN PAGE LEVEL STYLES -->
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2.css" />
    <link rel="stylesheet" type="text/css" href="assets/plugins/select2/select2-metronic.css" />
    <!-- END PAGE LEVEL SCRIPTS -->
    <!-- BEGIN THEME STYLES -->
    <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/css/pages/login.css" rel="stylesheet" type="text/css" />
    <!-- END THEME STYLES -->

    <!-- Custom STYLES -->
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/CustomPopupStyle.css" rel="stylesheet" />
    <link href="assets/css/validationEngine.jquery.css" rel="stylesheet" />


    <!--[if lt IE 9]>
	<script src="assets/plugins/respond.min.js"></script>
	<script src="assets/plugins/excanvas.min.js"></script> 
	<![endif]-->
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="assets/plugins/jquery-validation/dist/jquery.validate.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="assets/plugins/select2/select2.min.js"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/scripts/core/app.js" type="text/javascript"></script>
    <script src="assets/scripts/custom/login.js" type="text/javascript"></script>
    <script src="assets/scripts/CustomPopup.js"></script>
    <script src="assets/scripts/CustomValidation.js"></script>
    <script src="assets/scripts/CustomScripts.js"></script>
    <!-- END PAGE LEVEL SCRIPTS -->
    <%--<script>
        jQuery(document).ready(function () {
            App.init();
            Login.init();
        });
	</script>--%>
    <style>
        .copyright {
            float: none;
        }
    </style>
</head>
<!-- BEGIN BODY -->
<body class="login">
    <!-- BEGIN LOGO -->
    <form class="login" runat="server">
        <div class="logo">
            <a href="Default.aspx">
                <img src="assets/img/CompanyLogoWhite.png" alt="" height="126" width="360" /></a>
            <%--<asp:ImageButton ID="imgLogo" runat="server" src="assets/img/CompanyLogoWhite.png" alt="" Height="126" Width="360" OnClick="imgLogo_Click" />--%>
        </div>
        <%--</form>--%>
        <!-- END LOGO -->
        <!-- BEGIN LOGIN -->
        <div class="content">
            <!-- BEGIN LOGIN FORM -->
            <%--<form class="login-form" runat="server">--%>
            <h3 class="form-title">Login to your account</h3>
            <div id="dvError" runat="server" visible="false" class="alert alert-danger">
                <button class="close" data-close="alert"></button>
                <asp:Label ID="lblErrorMsg" runat="server" Text="Username or Password Incorrect..!" ForeColor="Red"></asp:Label>
            </div>
            <%-- <div>
                <lable class="fntWeightBold">Select UserType</lable>
                <asp:DropDownList ID="ddlUserType" CssClass="form-control" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlUserType_SelectedIndexChanged">
                    <asp:ListItem Value="1" Selected="True">User</asp:ListItem>
                    <asp:ListItem Value="2">Member</asp:ListItem>
                </asp:DropDownList>

            </div>--%>
            <br />
            <br />
            <asp:Panel ID="pnlLogin" runat="server" DefaultButton="lnkBtnLogin">
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">Username</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox ID="txtUsername" runat="server" placeholder="Username" CssClass="form-control placeholder-no-fix pnl1text-input" onchange="RemoveValidate(this);" AutoCompleteType="None"></asp:TextBox>
                    </div>
                </div>
                <div class="form-group">
                    <label class="control-label visible-ie8 visible-ie9">Password</label>
                    <div class="input-icon">
                        <i class="fa fa-lock"></i>
                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control placeholder-no-fix pnl1text-input" TextMode="Password" onchange="RemoveValidate(this);" placeholder="Password"></asp:TextBox>
                    </div>
                </div>

                <%--<div class="create-account">
                <p>
                    Don't have an account yet ?&nbsp;
                   
                    <a href="/frmRegistration.aspx" id="register-btn">Create an account
				</a>
                </p>
            </div>--%>
            </asp:Panel>

            <%--  <asp:Panel ID="pnlMemberLogin" Visible="false" runat="server" DefaultButton="lnkBtnLogin">
                <div class="form-group">
                    <!--ie8, ie9 does not support html5 placeholder, so we just show field title for that-->
                    <label class="control-label visible-ie8 visible-ie9">MembershipId</label>
                    <div class="input-icon">
                        <i class="fa fa-user"></i>
                        <asp:TextBox ID="txtMemberid" runat="server" placeholder="MembershipId" CssClass="form-control placeholder-no-fix pnl1text-input" onchange="RemoveValidate(this);" AutoCompleteType="None"></asp:TextBox>
                    </div>
                </div>

                <div class="create-account">
                <p>
                    Don't have an account yet ?&nbsp;
                   
                    <a href="/frmRegistration.aspx" id="register-btn">Create an account
				</a>
                </p>
            </div>
            </asp:Panel>--%>
            <div>
                <label class="checkbox">
                    <asp:CheckBox ID="chkBxRememberMe" runat="server" />
                    <label for="chkBxRememberMe">Remember me</label>
                </label>
                <div class="login">
                    <asp:LinkButton ID="lnkBtnLogin" OnClientClick="return ValidateCustom('pnl1');" OnClick="lnkBtnLogin_Click" runat="server" CssClass="btn green pull-right">Login<i class="m-icon-swapright m-icon-white mrgTop5" style="margin-left:2px;"></i></asp:LinkButton>
                
                    <%--<asp:LinkButton ID="lnkBtnSignup" OnClick="lnkBtnSignup_Click" runat="server" CssClass="btn green pull-left">Register<i class="m-icon-swapright m-icon-white mrgTop5" style="margin-left:2px;"></i></asp:LinkButton>--%>
                </div>
            </div>
            <div class="forget-password">
                <div class="forget-password">

                    <p>
                        <a href="/frmForgotPassword.aspx" id="forget-password">Forgot your password ?</a>
                    </p>
                </div>
            </div>
        </div>
    </form>

    <!-- END LOGIN FORM -->


    <div class="copyright">
        2015 &copy; <a href="newwayelectronics.co.in">New Way Electronics</a>
    </div>
</body>
</html>
