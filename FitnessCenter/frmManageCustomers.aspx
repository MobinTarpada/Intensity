<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageCustomers.aspx.cs" Inherits="FitnessCenter.frmManageCustomers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
            SetMenuActive("liManageCustomers");
        }
        function ShowFees(title, joinFee, adminFee, memberFee, PTP) {

            $("body").append("<div id='CustomModalPopup'>" +
                                "<div id='masteroverlay' class='web_dialog_overlay hide'></div>" +
                                    "<div id='MsgBoxModal' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel'" +
                                        "aria-hidden='true'>" +
                                    "<div class='wdoHeader'>" +
                                        "<button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal\").addClass(\"hide\");$(\"#masteroverlay\").addClass(\"hide\");$(\"#MsgBoxModal\").fadeOut(300);$(\"#CustomModalPopup\").remove();return false;'>x</button>" +
                                        "<span> " + String(title) + "</span>" +
                                    "</div>" +
                                    "<div class='modal-body'>" +
                                        "<p><label class='fntWeightBold'>Joining Fees</label><input type='text' value='" + joinFee + "' class='form-control' readonly='true' id='joinFee'/>" +
                                        "<label class='fntWeightBold'>Admin Fees</label><input type='text' value='" + adminFee + "' class='form-control' readonly='true' id='adminFee'/>" +
                                       "<label class='fntWeightBold'>Membership Fees</label><input type='text' value='" + memberFee + "' class='form-control' readonly='true' id='memberFee'/>" +
                                       "<label class='fntWeightBold'>Personal Training Pack</label><input type='text' value='" + PTP + "' class='form-control' readonly='true' id='PTP'/></p>" +
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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlCust" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Customers</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmManageCustomers.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlView">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Members</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchRfidNo" runat="server" placeholder="RFID No.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchMembershipNo" runat="server" placeholder="Membership No.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchFName" runat="server" placeholder="First Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchLastName" runat="server" placeholder="Last Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchMobileNo" runat="server" placeholder="Mobile No.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchDateOfBirth" runat="server" placeholder="Date of Birth.." CssClass="form-control datePicker"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Package</label>
                                                <asp:DropDownList ID="ddlSrchPkg" AutoPostBack="true" runat="server" CssClass="form-control pnl1text-input" OnSelectedIndexChanged="ddlSrchPkg_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Scheme</label>
                                                <asp:DropDownList ID="ddlSrchScheme" runat="server" CssClass="form-control pnl1text-input"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-2" style="padding: 0px;">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdMembers" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdMembers_PageIndexChanging" OnRowCommand="grdMembers_RowCommand" OnSorting="grdMembers_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="First Name" SortExpression="FIRSTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Name" SortExpression="LASTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("lastName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact">
                                            <ItemTemplate>
                                                <span><%# Eval("mobilenumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date of Birth">
                                            <ItemTemplate>
                                                <span><%# Eval("dateofbirth","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme">
                                            <ItemTemplate>
                                                <span><%# Eval("schemeName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCustomer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCustomer" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                    <asp:LinkButton ID="lnkBtnTransfer" runat="server" ToolTip="Transfer" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Transfer','Are you sure you want to Transfer this record?',this.id);return false;"><i class="fa fa-exchange"></i></asp:LinkButton>
                                                    <asp:Button ID="btnTransfer" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="TransferLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlTransfer" runat="server">
                    <div id='CustomModalPopup1'>
                        <div id='masteroverlay1' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModal1' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal1\").addClass(\"hide\");$(\"#masteroverlay1\").addClass(\"hide\");$(\"#MsgBoxModal1\").fadeOut(300);$(\"#CustomModalPopup1\").remove();return false;'>x</button>
                                <span>Transfer Memberships</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Transfer To</label>
                                    <asp:DropDownList ID="drpTransferMember" runat="server" CssClass="form-control"></asp:DropDownList>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNext" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNext').next().click(); $('#CustomModalPopup1').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnTransferLeads" OnClick="btnTransferLeads_Click" runat="server" Text="Save" CssClass="dsplNone" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlSms" runat="server">
                    <div id='CustomModalPopup5'>
                        <div id='masteroverlay5' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModal5' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal5\").addClass(\"hide\");$(\"#masteroverlay5\").addClass(\"hide\");$(\"#MsgBoxModal5\").fadeOut(300);$(\"#CustomModalPopup5\").remove();return false;'>x</button>
                                <span>SMS Promotion</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>SMS To</label>
                                    <asp:TextBox ID="txtSmS" ReadOnly="true" runat="server" CssClass="form-control "></asp:TextBox>
                                    <%--<label class='fntWeightBold'>Attachment</label>
                                    <asp:FileUpload ID="fileSMS" runat="server" />--%>
                                    <label class='fntWeightBold'>Message</label>
                                    <asp:TextBox ID="txtMsgSMS" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="True" Height="100px"></asp:TextBox>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNxtSms" value='Send' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay5').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNxtSms').next().click(); $('#CustomModalPopup5').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnSMS" runat="server" Text="Send SMS" CssClass="dsplNone" OnClick="btnSMS_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay5').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup5').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Member Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtFirstName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLastName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Contact Number</label>
                                            <asp:TextBox ID="txtContact" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Date of Birth</label>
                                            <asp:TextBox ID="txtDOB" CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Agreement Number</label>
                                            <asp:TextBox ID="txtagrNumber" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Membership Number</label>
                                            <asp:TextBox ID="txtMembershipNo" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package</label>
                                            <asp:DropDownList ID="drpCurPack" runat="server" CssClass="form-control pnl1text-input" Enabled="False"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Scheme</label>
                                            <asp:DropDownList ID="drpSchemes" runat="server" CssClass="form-control pnl1text-input" Enabled="False"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Activation Date</label>
                                            <asp:TextBox ID="txtActDate" runat="server" CssClass="form-control pnl1text-input" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Expiry Date</label>
                                            <asp:TextBox ID="txtExpDate" runat="server" CssClass="form-control pnl1text-input" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package Amount</label>
                                            <asp:TextBox ID="txtPaidAmt" runat="server" CssClass="form-control pnl1text-input" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Select Option</label>
                                            <asp:DropDownList ID="drpOptions" runat="server" CssClass="form-control pnl1text-input" OnSelectedIndexChanged="drpOptions_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem>Select Option</asp:ListItem>
                                                <asp:ListItem>Cancellation</asp:ListItem>
                                                <asp:ListItem>Downgradation</asp:ListItem>
                                                <asp:ListItem>Upgradation</asp:ListItem>
                                                <asp:ListItem>Freeze</asp:ListItem>
                                                <asp:ListItem>Renew</asp:ListItem>
                                                <asp:ListItem>Asign RFID Card</asp:ListItem>
                                                <asp:ListItem>Un Freeze</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlCancel" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Cancellation</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Paid Amount</label>
                                                <asp:TextBox ID="txtCancPaidAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Balance Due</label>
                                                <asp:TextBox ID="txtCancBalanceDue" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Service Tax / GST </label>
                                                <asp:TextBox ID="txtCancGst" AutoPostBack="true" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Startup / Joining Fees </label>
                                                <asp:TextBox ID="txtCancStartup" CssClass="form-control" AutoPostBack="true" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Membership</label>
                                                <asp:TextBox ID="txtCancMember" AutoPostBack="true" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Return Amount</label>
                                                <asp:TextBox ID="txtReturnAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true" OnTextChanged="txtReturnAmt_TextChanged" AutoPostBack="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:Button ID="btnShowFees" runat="server" Text="Show Fees" CssClass="btn btn-primary pull-right mrgTop25" OnClick="btnShowFees_Click" />
                                                <asp:HiddenField ID="hfJoinFee" runat="server" />
                                                <asp:HiddenField ID="hfAdminFee" runat="server" />
                                                <asp:HiddenField ID="hfMemberFee" runat="server" />
                                                <asp:HiddenField ID="hfPTP" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDowngrade" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Downgrade</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Packages and Schemes</h3>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Paid Amount</label>
                                            <asp:TextBox ID="txtDownPaidAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Balance Due</label>
                                            <asp:TextBox ID="txtDownBalDue" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package Types</label>
                                            <asp:DropDownList ID="drpPackages" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpPackages_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Scheme Types</label>
                                            <asp:DropDownList ID="drpSchemesDwn" runat="server" CssClass="form-control" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="drpSchemesDwn_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <h3>Final Amount</h3>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label class="fntWeightBold">Selected Scheme Amount</label>
                                        <asp:TextBox ID="txtSelSchAmt" placeholder="Scheme Amount.." CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="btnDwnShowFees" runat="server" Text="Show Fees" CssClass="btn btn-primary pull-right mrgTop25" OnClick="btnDwnShowFees_Click" Enabled="False" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Difference Amount</label>
                                            <asp:TextBox ID="txtDiffAmt" placeholder="Difference Amount.." CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Return Amount</label>
                                            <asp:TextBox ID="txtDwnPaidAmt" runat="server" AutoPostBack="True" CssClass="form-control " onchange="RemoveValidate(this);" OnTextChanged="txtDwnPaidAmt_TextChanged" placeholder="Paid Amount.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Remaining Amount</label>

                                            <asp:TextBox ID="txtDwnRemAmt" placeholder="Remaining Amount.." CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlUpgrade" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Upgrade</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Packages and Schemes</h3>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package Types</label>
                                            <asp:DropDownList ID="drpUpPack" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpUpPack_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Scheme Types</label>
                                            <asp:DropDownList ID="drpUpSchemes" runat="server" CssClass="form-control" Enabled="False" AutoPostBack="True" OnSelectedIndexChanged="drpUpSchemes_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">
                                    <h3>Final Amount</h3>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <label class="fntWeightBold">Selected Scheme Amount</label>
                                        <asp:TextBox ID="txtUpSelScheme" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                    </div>
                                    <div class="col-md-4">
                                        <asp:Button ID="btnUpShowFees" runat="server" Text="Show Fees" CssClass="btn btn-primary pull-right mrgTop25" Enabled="False" OnClick="btnUpShowFees_Click" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Difference Amount</label>
                                            <asp:TextBox ID="txtUpDiffAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Paid Amount</label>
                                            <asp:TextBox ID="txtUpPaidAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtUpPaidAmt_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Remaining Amount</label>
                                            <asp:TextBox ID="txtUpRemAmt" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Due Amount Date</label>
                                            <asp:TextBox ID="txtDueDate" CssClass="form-control datePicker" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlTime" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Freeze</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Additional Expenses</label>
                                            <asp:TextBox ID="txtAddExp" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Days</label>
                                            <asp:TextBox ID="txtDays" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Start Date</label>
                                            <asp:TextBox ID="txtStDate" CssClass="form-control datePicker" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtStDate_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">End Date</label>
                                            <asp:TextBox ID="txtEndDate" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">New Expiry Date</label>
                                            <asp:TextBox ID="txtNewExpDate" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlUnFreeze" runat="server">

                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Un Freeze</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Freeze Date</label>
                                            <asp:TextBox ID="txtUfrzDate" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Freeze End Date</label>
                                            <asp:TextBox ID="txtUFEndDate" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Remaining Days</label>
                                            <asp:TextBox ID="txtUFRemainingDays" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <%--<div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">End Date</label>
                                            <asp:TextBox ID="TextBox4" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">New Expiry Date</label>
                                            <asp:TextBox ID="TextBox5" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>--%>
                                </div>
                                <div class="footerBtns">
                                    <asp:Button ID="btnUnFreeze" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Un Freeze" OnClick="btnUnFreeze_Click" />
                                    <asp:Button ID="btnUCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnUCancel_Click" />
                                </div>
                            </div>
                        </div>
                    </div>

                </asp:Panel>
                <asp:Panel ID="pnlPayment" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Payment</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Payment Mode</label>
                                            <asp:RadioButtonList ID="rblPayMode" runat="server" OnSelectedIndexChanged="rblPayMode_SelectedIndexChanged" AutoPostBack="True"></asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkPaidRet" Text="IsPaid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlChqDetails" runat="server">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>Cheque Details</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Cheque Detail</h3>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <div class="form-body">
                                                        <div class="form-group">
                                                            <label class="fntWeightBold">Cheque Number</label>
                                                            <asp:TextBox ID="txtChqNo" placeholder="Cheque Number..." CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="form-body">
                                                        <div class="form-group">
                                                            <label class="fntWeightBold">Cheque Date</label>
                                                            <asp:TextBox ID="txtChqDate" placeholder="Cheque Date..." CssClass="form-control datePicker" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                        </div>
                                                        <div class="form-body">
                                                            <div class="form-group">
                                                                <label class="fntWeightBold">Bank Name</label>
                                                                <asp:TextBox ID="txtBankName" placeholder="Bank Name..." CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                        <div class="form-body">
                                                            <div class="form-group">
                                                                <label class="fntWeightBold">Branch Details</label>
                                                                <asp:TextBox ID="txtBranchDetails" placeholder="Branch Details..." CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>

                </asp:Panel>
                <asp:Panel ID="pnlRenew" runat="server">
                    <asp:Panel ID="pnlDetail" runat="server">
                        <div class="portlet box blue">
                            <div class="caption">
                                <div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Membership Number</label>
                                                <asp:TextBox ID="txtMembrNmbr" runat="server" CssClass="form-control" ReadOnly="true" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Agreement Number</label>
                                                <asp:TextBox ID="txtAgreementNumber" CssClass="form-control" ReadOnly="true" runat="server" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>

                                </div>
                                <div>
                                    <label style="margin-left: 3%" class="fntWeightBold">KINDLY FILL IT CORRECT WE WILL USE YOU BELOW INFORMATION TO MANAGE YOUR MEMBERSHIP</label>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Package</label>
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-12">
                                <h3>Membership Details</h3>
                            </div>
                            <div class="col-md-4">

                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Package Types</label>
                                        <asp:DropDownList ID="ddlPkgtype" CssClass="form-control pnl1text-input" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlPkgtype_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Scheme Types</label>
                                        <asp:DropDownList ID="ddlSchemeType" AutoPostBack="true" CssClass="form-control pnl1text-input" runat="server" OnSelectedIndexChanged="ddlSchemeType_SelectedIndexChanged"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Joining Fees</label>
                                        <asp:TextBox ID="txtSchJoin" CssClass="form-control pnl1text-input" placeholder="JoiningFee" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Admin Fees</label>
                                        <asp:TextBox ID="txtSchAdmin" CssClass="form-control pnl1text-input" placeholder="AdminFee" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Membership Fees</label>
                                        <asp:TextBox ID="txtSchMem" CssClass="form-control pnl1text-input" placeholder="MembershipFee" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Personal Training Pack</label>
                                        <asp:TextBox ID="txtSchPTP" CssClass="form-control pnl1text-input" placeholder="PersonalTrainingPack" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Service Tax</label>
                                        <asp:TextBox ID="txtSchSerTax" runat="server" placeholder="Service Tax" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Total Amount</label>
                                        <asp:TextBox ID="txtSchTotAmt" CssClass="form-control pnl1text-input" placeholder="TotalAmount" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                            </div>

                            <asp:Panel runat="server" ID="pnlActPayment">
                                <div class="col-md-4">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Actual Amount</label>
                                            <asp:Label ID="lblSchName" runat="server" CssClass="fntWeightBold form-control"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Joining Fees</label>
                                            <asp:TextBox ID="txtActJoin" CssClass="form-control pnl1text-input" placeholder="JoiningFee" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtActJoin_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Admin Fees</label>
                                            <asp:TextBox ID="txtActAdmin" CssClass="form-control pnl1text-input" placeholder="AdminFee" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtActAdmin_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Membership Fees</label>
                                            <asp:TextBox ID="txtActMem" CssClass="form-control pnl1text-input" placeholder="MembershipFee" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtActMem_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Personal Training Pack</label>
                                            <asp:TextBox ID="txtActPTP" CssClass="form-control pnl1text-input" placeholder="PersonalTrainingPack" onchange="RemoveValidate(this);" runat="server" AutoPostBack="True" OnTextChanged="txtActPTP_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Service Tax</label>
                                            <asp:TextBox ID="txtActSerTax" runat="server" placeholder="Service Tax" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtActSerTax_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Total Amount</label>
                                            <asp:TextBox ID="txtActTotAmt" CssClass="form-control pnl1text-input" placeholder="TotalAmount" onchange="RemoveValidate(this);" ReadOnly="True" runat="server"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <div class="col-md-12">
                                <h3>Final Amount</h3>
                            </div>

                            <div class="col-md-12">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">AMT. PayAble</label>
                                        <asp:TextBox ID="txtAmtPyb" runat="server" placeholder="AMT. PayAble..." CssClass="form-control" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="clearfix"></div>

                        </div>
                    </div>
                    <asp:Panel ID="pnlJoinDetails" runat="server">
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <label>Joining</label>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3>Joining Details</h3>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Activation Date</label>
                                                    <asp:TextBox ID="txtADate" runat="server" placeholder="Activation Date..." CssClass="form-control datePicker" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtADate_TextChanged"></asp:TextBox>

                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Expire Date</label>
                                                    <asp:TextBox ID="txtEDate" runat="server" placeholder="Expire Date..." CssClass="form-control " onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>

                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>


                </asp:Panel>
                <div class="clearfix"></div>
                <div class="footerBtns">
                    <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                    <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                </div>
                <asp:Panel ID="pnlAsignCard" runat="server">

                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Asign New RFID Card</label>
                            </div>
                        </div>
                    </div>
                    <div class="portlet-body">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">RFID Card Number</label>
                                        <asp:TextBox ID="txtAsignRFID" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-2" style="padding: 0px;">
                                    <asp:Button ID="btAsignRFID" runat="server" Text="Asign RFID Card" CssClass="btn btn-primary pull-center mrgTop20" OnClientClick="return ValidateCustom('pnl1');" OnClick="btAsignRFID_Click" />
                                </div>
                            </div>
                        </div>

                    </div>
                </asp:Panel>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlCust">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
