<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="FitnessCenter.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    
    <script src="assets/plugins/jquery-1.10.2.min.js"></script>
    <script src="assets/scripts/jquery-1.10.2-ui.js"></script>
    <script src="assets/scripts/jquery-ui-timepicker-addon.js"></script>
    <link href="assets/css/jquery-1.10.2-ui.css" rel="stylesheet" />
    <%--<link href="assets/scripts/jquery-ui-timepicker-addon.css" rel="stylesheet" />--%>


    <script type="text/javascript">
        $(document).ready(function () {
            $(".time").datetimepicker();
        });
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:TextBox ID="txtTimepicker" runat="server" CssClass="time"></asp:TextBox>
    </div>
    </form>
</body>
</html>
