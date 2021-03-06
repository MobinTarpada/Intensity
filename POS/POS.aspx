﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="POS.aspx.cs" Inherits="FitnessCenter.POS" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="assets/css/custom.css" rel="stylesheet" />
    <!-- Custom STYLES -->
    <link href="assets/css/custom.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/CustomPopupStyle.css" rel="stylesheet" />
    <link href="assets/css/validationEngine.jquery.css" rel="stylesheet" />


    <!-- BEGIN JAVASCRIPTS(Load javascripts at bottom, this will reduce page load time) -->
    <!-- BEGIN CORE PLUGINS -->
    <!--[if lt IE 9]>
<script src="assets/plugins/respond.min.js"></script>
<script src="assets/plugins/excanvas.min.js"></script> 
<![endif]-->
    <script src="assets/plugins/jquery-1.10.2.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-migrate-1.2.1.min.js" type="text/javascript"></script>
    <script src="assets/scripts/jquery-1.10.2-ui.js"></script>
    <!-- IMPORTANT! Load jquery-ui-1.10.3.custom.min.js before bootstrap.min.js to fix bootstrap tooltip conflict with jquery ui tooltip -->
    <script src="assets/plugins/jquery-ui/jquery-ui-1.10.3.custom.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap/js/bootstrap.min.js" type="text/javascript"></script>
    <%--    <script src="assets/plugins/bootstrap-datepicker/js/bootstrap-datepicker.js"></script>--%>
    <script src="assets/plugins/bootstrap-hover-dropdown/bootstrap-hover-dropdown.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-slimscroll/jquery.slimscroll.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.blockui.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.cokie.min.js" type="text/javascript"></script>
    <script src="assets/plugins/uniform/jquery.uniform.min.js" type="text/javascript"></script>
    <!-- END CORE PLUGINS -->
    <!-- BEGIN PAGE LEVEL PLUGINS -->
    <script src="assets/plugins/jqvmap/jqvmap/jquery.vmap.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.russia.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.world.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.europe.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.germany.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/maps/jquery.vmap.usa.js" type="text/javascript"></script>
    <script src="assets/plugins/jqvmap/jqvmap/data/jquery.vmap.sampledata.js" type="text/javascript"></script>
    <script src="assets/plugins/flot/jquery.flot.min.js" type="text/javascript"></script>
    <script src="assets/plugins/flot/jquery.flot.resize.min.js" type="text/javascript"></script>
    <script src="assets/plugins/flot/jquery.flot.categories.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery.pulsate.min.js" type="text/javascript"></script>
    <%-- <script src="assets/plugins/bootstrap-daterangepicker/moment.min.js" type="text/javascript"></script>
    <script src="assets/plugins/bootstrap-daterangepicker/daterangepicker.js" type="text/javascript"></script>--%>
    <script src="assets/plugins/gritter/js/jquery.gritter.js" type="text/javascript"></script>
    <!-- IMPORTANT! fullcalendar depends on jquery-ui-1.10.3.custom.min.js for drag & drop support -->
    <%--  <script src="assets/plugins/fullcalendar/fullcalendar/fullcalendar.min.js" type="text/javascript"></script>
    <script src="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.js" type="text/javascript"></script>--%>
    <script src="assets/plugins/jquery.sparkline.min.js" type="text/javascript"></script>
    <!-- END PAGE LEVEL PLUGINS -->
    <!-- BEGIN PAGE LEVEL SCRIPTS -->
    <script src="assets/scripts/core/app.js" type="text/javascript"></script>
    <script src="assets/scripts/custom/index.js" type="text/javascript"></script>
    <script src="assets/scripts/custom/tasks.js" type="text/javascript"></script>

    <!-- Custom SCRIPTS -->
    <script src="assets/scripts/CustomPopup.js"></script>
    <script src="assets/scripts/CustomValidation.js"></script>
    <script src="assets/scripts/CustomScripts.js"></script>
    <script src="assets/scripts/jquery-ui-timepicker-addon.js"></script>
    <link href="assets/css/jquery-1.10.2-ui.css" rel="stylesheet" />
    <%--  <link href="assets/scripts/jquery-ui-timepicker-addon.css" rel="stylesheet" />--%>
    <%-- <script src="assets/scripts/custom/components-pickers.js"></script>--%>
    <!-- END PAGE LEVEL SCRIPTS -->

</head>
<body class="bodyMain">
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div class="container">
                    <div class="left">
                        <table>
                            <tr>
                                <td>#
                                </td>
                                <td>
                                    <label>ITEM</label>
                                </td>
                                <td>
                                    <label>QTY</label>
                                </td>
                                <td>
                                    <label>RATE</label>
                                </td>
                                <td>
                                    <label>AMOUNT</label>
                                </td>

                            </tr>
                            <tr>
                                <td style="overflow-x: auto">1</td>
                                <td style="overflow-x: auto">
                                    <asp:TextBox ID="txtItem1" ReadOnly="true" CssClass="TextBox form-control" runat="server" TextMode="MultiLine"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty1" CssClass="TextBox" runat="server" AutoPostBack="True" OnTextChanged="txtQty1_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate1" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount1" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>2</td>
                                <td>
                                    <asp:TextBox ID="txtItem2" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty2" CssClass="TextBox" runat="server" AutoPostBack="True" OnTextChanged="txtQTY2_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate2" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount2" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>3</td>
                                <td>
                                    <asp:TextBox ID="txtItem3" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty3" CssClass="TextBox" runat="server" AutoPostBack="True" OnTextChanged="txtQty3_TextChanged"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate3" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount3" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>4</td>
                                <td>
                                    <asp:TextBox ID="txtItem4" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty4" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate4" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount4" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>5</td>
                                <td>
                                    <asp:TextBox ID="txtItem5" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty5" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate5" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount5" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>6 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItem6" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty6" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate6" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount6" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>7 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItem7" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty7" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate7" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount7" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>8 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItem8" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty8" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate8" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount8" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>9 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtItem9" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtQty9" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtRate9" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="txtAmount9" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>10 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox25" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox26" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox27" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox28" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>

                            <tr>
                                <td>11 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox29" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox30" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox31" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox32" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>12</td>
                                <td>
                                    <asp:TextBox ID="TextBox33" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox34" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox35" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox36" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>13</td>
                                <td>
                                    <asp:TextBox ID="TextBox37" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox38" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox39" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox40" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>14 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox41" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox42" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox43" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox44" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>15 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox45" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox46" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox47" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox48" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>16 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox49" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox50" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox51" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox52" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>17</td>
                                <td>
                                    <asp:TextBox ID="TextBox53" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox54" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox55" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox56" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>18 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox57" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox58" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox59" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox60" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>19 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox61" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox62" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox63" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox64" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>20 
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox65" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox66" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox67" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox68" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>

                            </tr>
                            <tr>
                                <td>TOTAL </td>
                                <td>
                                    <asp:TextBox ID="txtTotal" runat="server" CssClass="TextBox" ReadOnly="true"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>RECEIVED 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtReceived" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>CHANGE 
                                </td>
                                <td>
                                    <asp:TextBox ID="txtChange" ReadOnly="true" CssClass="TextBox" runat="server"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        <div style="height: 100%; width: 374px;">
                            <asp:Button Class="BtnCalC" ID="btn1" runat="server" Text="1" OnClick="btn1_Click" />
                            <asp:Button Class="BtnCalC" ID="btn2" runat="server" Text="2" OnClick="btn2_Click" />
                            <asp:Button Class="BtnCalC" ID="btn3" runat="server" Text="3" OnClick="btn3_Click" />
                            <asp:Button Class="BtnCalC" ID="btn4" runat="server" Text="4" OnClick="btn4_Click" />
                            <asp:Button Class="BtnCalC" ID="btn5" runat="server" Text="5" OnClick="btn5_Click" />

                        </div>
                        <div style="height: 100%; width: 382px;">
                            <asp:Button Class="BtnCalC" ID="btn6" runat="server" Text="6" OnClick="btn6_Click" />
                            <asp:Button Class="BtnCalC" ID="btn7" runat="server" Text="7" OnClick="btn7_Click" />
                            <asp:Button Class="BtnCalC" ID="btn8" runat="server" Text="8" OnClick="btn8_Click" />
                            <asp:Button Class="BtnCalC" ID="btn9" runat="server" Text="9" OnClick="btn9_Click" />
                            <asp:Button Class="BtnCalC" ID="btn0" runat="server" Text="0" OnClick="btn0_Click" />

                        </div>
                        <div>
                            <asp:Button Class="BtnCalC" ID="btnErase" runat="server" Text="Cancel" OnClick="btnErase_Click" />
                            <asp:Button Class="BtnCalC" ID="btnEnter" runat="server" Text="Enter" OnClick="btnEnter_Click" />
                        </div>
                    </div>
                    <div class="Group">
                        <asp:Panel runat="server" ID="pnlGroups">
                        </asp:Panel>
                    </div>

                    <%--<div style="width:10px">
                        <asp:ImageButton CssClass="Image" ID="btnUp" ImageUrl="~/assets/img/arrow-up.png" runat="server" />
                    </div>
                    <div style="width:10px">
                        <asp:ImageButton CssClass="Image" ID="btnDown" ImageUrl="~/assets/img/arrow-down.png" runat="server" />
                    </div>--%>
                    <div class="right">
                        <asp:Panel runat="server" ID="pnlItems">
                        </asp:Panel>
                    </div>

                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
