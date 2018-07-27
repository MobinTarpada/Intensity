<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeBehind="DailyTask.aspx.cs" Inherits="FitnessCenter.DailyTask" %>

<%--<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
        select option:hover, select option:focus, select option:active {
            background-color: red !important;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            $(".datePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2100',
                dateFormat: "dd/mm/yy"

            });
            $(".datetime").datetimepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd/mm/yy",
                controlType: 'select',
                oneLine: true,
                timeFormat: 'hh:mm TT'

            });
            SetMenuActive("liManageLeads");
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Daily Task </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmManageLead.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlDetail" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Today's Task Detail</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Lead Type</label>
                                            <asp:DropDownList ID="ddlLeadType" runat="server" CssClass="form-control" onchange="RemoveValidate(this);"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Lead Status</label>
                                            <asp:DropDownList ID="ddlLeadStatus" runat="server" CssClass="form-control" onchange="RemoveValidate(this);"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtLblFirstName" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLblLastName" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Contact Number</label>
                                            <asp:TextBox ID="txtLblConNo" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlAppointment" runat="server">
                                    <div class="col-md-12">
                                        <asp:Panel ID="pnlAppointmentView" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Appointmets</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <%--<div class="col-md-12">
                                                            <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" OnClick="btnAddAppointment_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                        </div>
                                                    </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grdLeadAppointment" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AutoGenerateColumns="false">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="APPOINTMENT DATE">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToDateTime(Eval("appointmentDate")).ToString("dd-MMM-yyyy hh:mm tt") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Attended?">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToBoolean(Eval("isAttendAppointment")) == true ? "YES" : "NO" %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditAppointment"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteAppointment" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                        </asp:Panel>

                                    <%--    <asp:Panel ID="pnlAppointmentEdit" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Appointmets</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Appointment Date</label>
                                                                    <asp:TextBox ID="txtAppointmentDate" runat="server" placeholder="Appointment Date.." CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="checkbox">
                                                                        <asp:CheckBox ID="chkppointmentAttended" runat="server" Style="margin-left: 0px;" />
                                                                        <label for="chkBxRememberMe">Appointment Attended?</label>
                                                                    </label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Remarks</label>
                                                                    <asp:TextBox ID="txtReasonForNotAttend" runat="server" placeholder="Reasons.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                        <%--<div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadAppointment" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlA');" OnClick="btnSaveLeadAppointment_Click" Text="Save" />
                                                            <asp:Button ID="btnCancelLeadAppointment" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancelLeadAppointment_Click" Text="Cancel" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlFollowup" runat="server">
                                    <div class="col-md-12">
                                        <asp:Panel ID="pnlFollowupView" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Followup</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <%--<div class="col-md-12">
                                                            <asp:Button ID="AddFollowup" runat="server" Text="Add Followup" CssClass="btn btn-primary pull-right mrgBottom10" OnClick="AddFollowup_Click" />
                                                        </div>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdLeadFollowup" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                            EmptyDataText="No Record Found..!" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Followup DATE">
                                                                    <ItemTemplate>
                                                                        <span><%#Convert.ToDateTime(Eval("followupDateTime")).ToString("dd-MMM-yyyy hh:mm tt") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Remarks">
                                                                    <ItemTemplate>
                                                                        <span><%#(Eval("Remarks"))  %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="gridActionsIcon">
                                                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditFollowup"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteFollowup" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                        <%--<asp:Panel ID="pnlFollowupEdit" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Followups</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Followup Date And Time</label>
                                                                    <asp:TextBox ID="txtFollowupDate" runat="server" placeholder="Followup Date.." CssClass="form-control pnltext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Remarks</label>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks.." CssClass="form-control pnltext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>
                                                         <div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadFollowup" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlB');" Text="Save" OnClick="btnSaveLeadFollowup_Click" />
                                                            <asp:Button ID="btnCancelLeadFollowup" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancelLeadFollowup_Click" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlPresentation" runat="server">
                                    <div class="col-md-12">
                                        <asp:Panel ID="pnlPresentationView" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Presentation</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <%--<div class="col-md-12">
                                                            <asp:Button ID="btnAddPresentation" runat="server" Text="Add Presentation" OnClick="btnAddPresentation_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                        </div>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdLeadPresentation" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                            EmptyDataText="No Record Found..!" AutoGenerateColumns="false">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Presentation DATE">
                                                                    <ItemTemplate>
                                                                        <span><%#Convert.ToDateTime(Eval("PresentationDate")).ToString("dd-MMM-yyyy") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="Attended?">
                                                                    <ItemTemplate>
                                                                        <span><%#Convert.ToBoolean(Eval("isAttendPresentation")) == true ? "YES" : "NO" %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField>
                                                                    <ItemTemplate>
                                                                        <div class="gridActionsIcon">
                                                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPresentation"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                            <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeletePresentation" />
                                                                        </div>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>

                                        <%--<asp:Panel ID="pnlPresentationEdit" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>Presentations</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="checkbox">
                                                                        <asp:CheckBox ID="chkPresentationAttend" runat="server" Style="margin-left: 0px;" />
                                                                        <label for="chkPresentationAttend">Presentation Attended?</label>
                                                                    </label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Remarks</label>
                                                                    <asp:TextBox ID="txtReasonsForNotAttendPresentation" runat="server" placeholder="Reasons.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>

                                                        <%--<div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadPresentation" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlB');" OnClick="btnSaveLeadPresentation_Click" Text="Save" />
                                                            <asp:Button ID="btnCancelLeadPresentation" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancelLeadPresentation_Click" Text="Cancel" />
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlLeadProcess" runat="server">
                                    <div class="col-md-12">
                                        <div class="portlet box blue">
                                            <div class="portlet-title">
                                                <div class="caption">
                                                    <label>History</label>
                                                </div>
                                            </div>
                                            <div class="portlet-body">
                                                <div class="table-responsive">
                                                    <asp:GridView ID="grdLeadHistory" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="false">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="PREVIOUS STATUS">
                                                                <ItemTemplate>
                                                                    <span><%#Eval("LeadStatusMaster1.status") %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="CURRANT STATUS">
                                                                <ItemTemplate>
                                                                    <span><%#Eval("LeadStatusMaster.status") %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="DATE TIME">
                                                                <ItemTemplate>
                                                                    <span><%#Convert.ToDateTime(Eval("insertDate")).ToString("dd-MMM-yyyy hh:mm tt") %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>


                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <%--<div class="footerBtns">
                                    <asp:Button ID="btnSaveLeadDetail" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClick="btnSaveLeadDetail_Click" Text="Save" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>--%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        function pageLoad() {
            $(".datePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2100',
                dateFormat: "dd-mm-yy"

            });
            $(".datetime").datetimepicker({
                changeMonth: true,
                changeYear: true,
                dateFormat: "dd-mm-yy",
                controlType: 'select',
                oneLine: true,
                timeFormat: 'hh:mm TT'

            });
            SetMenuActive("liManageLeads");
        }
    </script>
    <meta charset="utf-8" />
    <title>Fitness Management</title>
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta content="width=device-width, initial-scale=1" name="viewport" />
    <meta content="" name="description" />
    <meta content="" name="author" />
    <!-- BEGIN GLOBAL MANDATORY STYLES -->
    <link href="http://fonts.googleapis.com/css?family=Open+Sans:400,300,600,700&subset=all" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/bootstrap/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/uniform/css/uniform.default.css" rel="stylesheet" type="text/css" />
    <!-- END GLOBAL MANDATORY STYLES -->
    <!-- BEGIN PAGE LEVEL PLUGIN STYLES -->
    <link href="assets/plugins/gritter/css/jquery.gritter.css" rel="stylesheet" type="text/css" />
    <%-- <link href="assets/plugins/bootstrap-daterangepicker/daterangepicker-bs3.css" rel="stylesheet" type="text/css" />--%>
    <link href="assets/plugins/fullcalendar/fullcalendar/fullcalendar.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jqvmap/jqvmap/jqvmap.css" rel="stylesheet" type="text/css" />
    <link href="assets/plugins/jquery-easy-pie-chart/jquery.easy-pie-chart.css" rel="stylesheet" type="text/css" />
    <!-- END PAGE LEVEL PLUGIN STYLES -->
    <!-- BEGIN THEME STYLES -->
    <link href="assets/css/style-metronic.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/style-responsive.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/plugins.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/pages/tasks.css" rel="stylesheet" type="text/css" />
    <link href="assets/css/themes/default.css" rel="stylesheet" type="text/css" id="style_color" />
    <link href="assets/css/print.css" rel="stylesheet" type="text/css" media="print" />
    <%--    <link href="assets/plugins/bootstrap-datepicker/css/datepicker.css" rel="stylesheet" />--%>

    <!-- END THEME STYLES -->
    <link rel="shortcut icon" href="favicon.ico" />

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
    <script>
     
    </script>

    <%-- <asp:ContentPlaceHolder ID="head" runat="server">
    </asp:ContentPlaceHolder>--%>
</head>
<body class="page-header-fixed">
    <form id="frmFitnessManagement" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="true"></asp:ScriptManager>
        <div class="header navbar navbar-fixed-top">
            <!-- BEGIN TOP NAVIGATION BAR -->
            <div class="header-inner">
                <!-- BEGIN LOGO -->
                <img src="assets/img/logo 80.png" alt="Logo" height="36" style="margin-left: 10px; margin-top: 5px;" />
                <!-- END LOGO -->
                <!-- BEGIN RESPONSIVE MENU TOGGLER -->
                <a href="javascript:;" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-collapse">
                    <img src="assets/img/menu-toggler.png" alt="" />
                </a>
                <!-- END RESPONSIVE MENU TOGGLER -->
                <!-- BEGIN TOP NAVIGATION MENU -->
                <ul class="nav navbar-nav pull-right">
                    <!-- BEGIN USER LOGIN DROPDOWN -->
                    <li class="dropdown user">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown" data-hover="dropdown" data-close-others="true">
                            <asp:Image ID="imgProfileImage" AlternateText="Profile Image" runat="server" Height="32px" Width="50px" />
                            <asp:Label ID="lblUserName" runat="server" Text="Username" CssClass="username"></asp:Label>
                            <i class="fa fa-angle-down"></i>
                        </a>
                        <ul class="dropdown-menu">
                            <li id="liProfileView" runat="server">
                                <asp:LinkButton ID="lnkBtnProfile" runat="server" OnClick="lnkBtnProfile_Click"><i class="fa fa-user"></i>My Profile</asp:LinkButton>
                            </li>
                            <li id="liDivider" class="divider" runat="server"></li>
                            <li>
                                <asp:LinkButton ID="lnkBtnLogOut" runat="server" OnClick="lnkBtnLogOut_Click"><i class="fa fa-key"></i>Log Out</asp:LinkButton>
                            </li>
                        </ul>
                    </li>
                    <!-- END USER LOGIN DROPDOWN -->
                </ul>
                <!-- END TOP NAVIGATION MENU -->
            </div>
            <!-- END TOP NAVIGATION BAR -->
        </div>
        <div class="clearfix">
        </div>
        <!-- BEGIN CONTAINER -->
        <div class="page-container">
            <!-- BEGIN SIDEBAR -->
            <div class="page-sidebar-wrapper">
                <div class="page-sidebar navbar-collapse collapse">
                    <!-- add "navbar-no-scroll" class to disable the scrolling of the sidebar menu -->
                    <!-- BEGIN SIDEBAR MENU -->
                    <ul class="page-sidebar-menu" data-auto-scroll="true" data-slide-speed="200">
                        <li class="sidebar-toggler-wrapper">
                            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                            <div class="sidebar-toggler hidden-phone">
                            </div>
                            <!-- BEGIN SIDEBAR TOGGLER BUTTON -->
                        </li>

                        <%--<asp:Literal ID="ltrAdminLi" runat="server"></asp:Literal>
                        <asp:Literal ID="ltrMenuLi" runat="server"></asp:Literal>--%>
                        <%-- <asp:ImageButton ID="ImageButton1" runat="server" Height="17px" ImageUrl="~/assets/img/calendar-icon.png" Width="21px" CausesValidation="False" />--%>
                        <asp:Calendar ID="Calendar1" runat="server"
                            BackColor="lightgray" BorderColor="Red" CellPadding="1" DayNameFormat="Shortest"
                            Font-Names="Verdana" Font-Size="8pt" ForeColor="red" Height="200px"
                            Width="225px" OnSelectionChanged="Calendar1_SelectionChanged">
                            <SelectedDayStyle BackColor="#009999" Font-Bold="True" ForeColor="Yellow" />
                            <TodayDayStyle BackColor="#99CCCC" ForeColor="White" />
                            <SelectorStyle BackColor="White" ForeColor="#336666" />
                            <WeekendDayStyle BackColor="black" />
                            <OtherMonthDayStyle ForeColor="#999999" />
                            <NextPrevStyle Font-Size="8pt" ForeColor="Black" />
                            <DayHeaderStyle BackColor="red" ForeColor="Black" Height="1px" />
                            <TitleStyle BackColor="Black" BorderColor="Black"
                                BorderWidth="2px" Font-Bold="True"
                                Font-Size="10pt" ForeColor="red" Height="25px" />
                        </asp:Calendar>
                    </ul>
                    <!-- END SIDEBAR MENU -->
                </div>
            </div>
            <!-- END SIDEBAR -->
            <!-- BEGIN CONTENT -->
            <div class="page-content-wrapper">
                <%-- <asp:ContentPlaceHolder ID="ContentPlaceHolder1" runat="server">--%>
                <div class="page-content">
                    <div class="row">
                        <div class="col-md-12">
                            <h3 class="page-title">Manage Daily Task </h3>
                            <ul class="page-breadcrumb breadcrumb">
                                <li><i class="fa fa-home"></i>
                                    <a href="frmManageLead.aspx">Home </a>
                                    <i class="fa fa-angle-right"></i>
                                </li>
                            </ul>
                        </div>
                    </div>
                    <asp:Panel ID="pnlDetail" runat="server">
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <label>Today's Task Detail</label>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Search MemberName</label>
                                                <asp:TextBox ID="txtSearchName" runat="server" CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary" Text="Search" OnClientClick="RemoveAllValidation();" OnClick="btnSearch_Click" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                    <%-- <div class="col-md-6">
                                       <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Lead Status</label>
                                                <asp:DropDownList ID="ddlLeadStatus" runat="server" CssClass="form-control" onchange="RemoveValidate(this);"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>--%>

                                    <%--<div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">

                                                <label class="fntWeightBold">First Name</label>
                                                <asp:TextBox ID="txtLblFirstName" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">

                                                <label class="fntWeightBold">Last Name</label>
                                                <asp:TextBox ID="txtLblLastName" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">

                                                <label class="fntWeightBold">Contact Number</label>
                                                <asp:TextBox ID="txtLblConNo" runat="server" CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>--%>
                                    <div class="clearfix"></div>
                                    <asp:Panel ID="pnlAppointment" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlAppointmentView" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Appointmets</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <%--<div class="col-md-12">
                                                                <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" OnClick="btnAddAppointment_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                            </div>--%>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView DataKeyNames="ID" ID="grdLeadAppointment" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" OnPageIndexChanging="grdLeadAppointment_PageIndexChanging" OnRowCancelingEdit="grdLeadAppointment_RowCancelingEdit" OnRowEditing="grdLeadAppointment_RowEditing" OnRowUpdating="grdLeadAppointment_RowUpdating">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="FirstName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("firstName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LastName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("lastName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MobileNumber">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("mobileNumber"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="APPOINTMENT DATE">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("appointmentDate","{0:dd/MM/yyyy hh:mm tt}") %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="appointDate" CssClass="datetime " Text='<%# Eval("appointmentDate","{0:dd/MM/yyyy hh:mm tt}") %>' runat="server"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("reasonForNotAttend"))  %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtAppointRemarks" runat="server" Text='<%# Eval("reasonForNotAttend") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="USER NAME" SortExpression="USERNAME">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("UserName") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField HeaderText="Action" ControlStyle-ForeColor="Black" ShowEditButton="True" ShowHeader="True">
                                                                        <ControlStyle Font-Bold="True" ForeColor="Black" />
                                                                    </asp:CommandField>
                                                                    <%--<asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                               <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditAppointment"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteAppointment" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                            <%--  <asp:Panel ID="pnlAppointmentEdit" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Appointmets</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-body">
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Appointment Date</label>
                                                                        <asp:TextBox ID="txtAppointmentDate" runat="server" placeholder="Appointment Date.." CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="checkbox">
                                                                            <asp:CheckBox ID="chkppointmentAttended" runat="server" Style="margin-left: 0px;" />
                                                                            <label for="chkBxRememberMe">Appointment Attended?</label>
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Remarks</label>
                                                                        <asp:TextBox ID="txtReasonForNotAttend" runat="server" placeholder="Reasons.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                            <div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadAppointment" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlA');" OnClick="btnSaveLeadAppointment_Click" Text="Save" />
                                                            <asp:Button ID="btnCancelLeadAppointment" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancelLeadAppointment_Click" Text="Cancel" />
                                                        </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>--%>
                                        </div>
                                    </asp:Panel>
                                    <div class="clearfix"></div>

                                    <asp:Panel ID="pnlFollowup" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlFollowupView" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Followup</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView DataKeyNames="ID" ID="grdLeadFollowup" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="grdLeadFollowup_PageIndexChanging" OnRowCancelingEdit="grdLeadFollowup_RowCancelingEdit" OnRowEditing="grdLeadFollowup_RowEditing" OnRowUpdating="grdLeadFollowup_RowUpdating">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="FirstName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("firstName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LastName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("lastName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MobileNumber">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("mobileNumber"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Followup DATE">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToDateTime(Eval("followupDateTime")).ToString("dd-MM-yyyy hh:mm tt") %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="followupDate" CssClass="datetime " Text='<%# Eval("followupDateTime","{0:dd/MM/yyyy hh:mm tt}") %>' runat="server"></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("Remarks"))  %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtFolowupRemarks" runat="server" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField HeaderText="Action" ControlStyle-ForeColor="Black" ShowEditButton="True" ShowHeader="True">
                                                                        <ControlStyle Font-Bold="True" ForeColor="Black" />
                                                                    </asp:CommandField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                            <%-- <asp:Panel ID="pnlFollowupEdit" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Followups</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-body">
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Followup Date And Time</label>
                                                                        <asp:TextBox ID="txtFollowupDate" runat="server" placeholder="Followup Date.." CssClass="form-control pnltext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Remarks</label>
                                                                        <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks.." CssClass="form-control pnltext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="clearfix"></div>
                                                             <div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadFollowup" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlB');" Text="Save" OnClick="btnSaveLeadFollowup_Click" />
                                                            <asp:Button ID="btnCancelLeadFollowup" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancelLeadFollowup_Click" />
                                                        </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>--%>
                                        </div>
                                    </asp:Panel>
                                    <div class="clearfix"></div>

                                    <asp:Panel ID="pnlBirthDay" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlSubBirthDay" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>BirthDay</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grdBirhtDay" DataKeyNames="ID" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AllowPaging="True" PageSize="5" AutoGenerateColumns="False" OnPageIndexChanging="grdBirhtDay_PageIndexChanging" OnRowEditing="grdBirhtDay_RowEditing" OnRowCancelingEdit="grdBirhtDay_RowCancelingEdit" OnRowUpdating="grdBirhtDay_RowUpdating">
                                                                <Columns>

                                                                    <asp:TemplateField HeaderText="FirstName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("firstName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LastName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("lastName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MobileNumber">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("mobileNumber"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Birth Date">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToDateTime(Eval("dateOfBirth")).ToString("dd-MM-yyyy") %></span>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("BirthDayRemarks")) %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtBirthDayRemarks" runat="server" Text='<%# Eval("BirthDayRemarks") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditFollowup"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteFollowup" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                    <asp:CommandField HeaderText="Action" ControlStyle-ForeColor="Black" ShowEditButton="True" ShowHeader="True" />
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                        </div>
                                    </asp:Panel>

                                    <asp:Panel ID="pnlAnniversary" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlSubAnniversary" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Anniversary</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView DataKeyNames="ID" ID="grdAnniversary" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" OnPageIndexChanging="grdAnniversary_PageIndexChanging" OnRowCancelingEdit="grdAnniversary_RowCancelingEdit" OnRowEditing="grdAnniversary_RowEditing" OnRowUpdating="grdAnniversary_RowUpdating">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="FirstName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("firstName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LastName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("lastName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MobileNumber">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("mobileNumber"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Anniversary Date">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToDateTime(Eval("anniversaryDate")).ToString("dd-MM-yyyy") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("AnniversaryRemarks"))  %></span>
                                                                        </ItemTemplate>
                                                                        <EditItemTemplate>
                                                                            <asp:TextBox ID="txtAnniversaryRemarks" runat="server" Text='<%# Eval("AnniversaryRemarks") %>'></asp:TextBox>
                                                                        </EditItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:CommandField HeaderText="Action" ControlStyle-ForeColor="Black" ShowEditButton="True" ShowHeader="True" />
                                                                    <%-- <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditFollowup"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteFollowup" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>--%>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                        </div>
                                    </asp:Panel>

                                    <%-- <asp:Panel ID="pnlPresentation" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlPresentationView" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>BirthDay Wishes</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <%--<div class="col-md-12">
                                                            <asp:Button ID="btnAddPresentation" runat="server" Text="Add Presentation" OnClick="btnAddPresentation_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                        </div>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grdLeadPresentation" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                EmptyDataText="No Record Found..!" AllowPaging="true" PageSize="5" AutoGenerateColumns="false" OnPageIndexChanging="grdLeadPresentation_PageIndexChanging">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="FirstName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("firstName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="LastName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("lastName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="MobileNumber">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("mobileNumber"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Presentation DATE">
                                                                        <ItemTemplate>
                                                                            <span><%#Convert.ToDateTime(Eval("presentationDate")).ToString("dd-MM-yyyy") %></span>
                                                                        </ItemTemplate>

                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Remarks">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("reasonsForNotAttend"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="UserName">
                                                                        <ItemTemplate>
                                                                            <span><%#(Eval("UserName"))  %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <%-- <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPresentation"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeletePresentation" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>

                                            <%--                                            <asp:Panel ID="pnlPresentationEdit" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>Presentations</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-body">
                                                                    <div class="form-group">
                                                                        <label class="checkbox">
                                                                            <asp:CheckBox ID="chkPresentationAttend" runat="server" Style="margin-left: 0px;" />
                                                                            <label for="chkPresentationAttend">Presentation Attended?</label>
                                                                        </label>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Remarks</label>
                                                                        <asp:TextBox ID="txtReasonsForNotAttendPresentation" runat="server" placeholder="Reasons.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>

                                                            <div class="clearfix"></div>

                                                            <div class="footerBtns">
                                                                <asp:Button ID="btnSaveLeadPresentation" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlB');" OnClick="btnSaveLeadPresentation_Click" Text="Save" />
                                                                <asp:Button ID="btnCancelLeadPresentation" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancelLeadPresentation_Click" Text="Cancel" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </asp:Panel>
                                    <div class="clearfix"></div>
                                    <asp:Panel ID="pnlLeadProcess" runat="server">
                                        <div class="col-md-12">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>History</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdLeadHistory" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                            EmptyDataText="No Record Found..!" AllowPaging="true" PageSize="5" PagerStyle-CssClass="CustomPagination" AutoGenerateColumns="false" 
                                                            OnPageIndexChanging="grdLeadHistory_PageIndexChanging">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="FIRST NAME">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("firstName") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="LAST NAME">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("lastName") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="PREVIOUS STATUS">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("PreviousStatus") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="CURRANT STATUS">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("CurrentStatus") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:TemplateField HeaderText="DATE TIME">
                                                                    <ItemTemplate>
                                                                        <span><%#Convert.ToDateTime(Eval("insertDate")).ToString("dd-MM-yyyy") %></span>
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                            </Columns>
                                                        </asp:GridView>
                                                    </div>


                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    --%>
                                    <div class="clearfix"></div>
                                    <%-- <div class="footerBtns">
                                    <asp:Button ID="btnSaveLeadDetail" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClick="btnSaveLeadDetail_Click" Text="Save" />
                                   </div>--%>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                </div>
                <%--</asp:ContentPlaceHolder>--%>
            </div>
        </div>
        <!-- END CONTENT -->
    </form>
</body>
</html>
