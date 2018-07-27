<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="FitnessCenter.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <!-- BOOTSTRAP STYLES-->
    <link href="assets/css/bootstrap.css" rel="stylesheet" />
    <!-- FONTAWESOME STYLES-->
    <link href="assets/css/font-awesome.css" rel="stylesheet" />
    <!-- CUSTOM STYLES-->
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- DataTables -->
    <link href="assets/js/dataTables/dataTables.bootstrap.css" rel="stylesheet" />
    <!-- GOOGLE FONTS-->
    <link href='http://fonts.googleapis.com/css?family=Open+Sans' rel='stylesheet' type='text/css' />
    <!-- Validation -->
    <link href="assets/css/ValidationEngine.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">

        <div class="table-responsive">
            <div style="float: right">
                <asp:Button ID="Button1" CssClass="btn1" runat="server" Text="Button" />
            </div>
            <div style="float: right; padding-right: 20px">
                <asp:Button ID="Button3" CssClass="btn1" runat="server" Text="Button" />
            </div>
            <div style="float: left">
                <asp:Button ID="Button2" CssClass="btn1" runat="server" Text="Button" />
            </div>
        </div>
    </form>
</body>
</html>
