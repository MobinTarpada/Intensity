<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmAssignPTP.aspx.cs" Inherits="FitnessCenter.frmAssignPTP" %>

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
            SetMenuActive("liAssignPTP");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlAssign" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Assign PTP Packages</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmAssignPTP.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Assigned PTP Packages</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtRfidNo" runat="server" placeholder="RFID Number.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtMemberShipNo" runat="server" placeholder="MemberShip Number.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearch" runat="server" placeholder="MemberName.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" style="padding: 0px;">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAssignPackage" runat="server" Text="Assign Package" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAssignPackage_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdAssignedPackages" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdAssignedPackages_PageIndexChanging" OnRowCommand="grdAssignedPackages_RowCommand" OnSorting="grdAssignedPackages_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="FULLNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package Name">
                                            <ItemTemplate>
                                                <span><%#Eval("packageName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Start Date">
                                            <ItemTemplate>
                                                <span><%#Eval("startDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="End Date">
                                            <ItemTemplate>
                                                <span><%#Eval("endDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Session Remaining">
                                            <ItemTemplate>
                                                <span><%#Eval("sessionCount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPTPMember"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailPTPMember"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeletePTPMember" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlEdit" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Assign Package Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Select Member</label>
                                            <asp:DropDownList ID="drpMembers" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpMembers_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtFirstname" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLastName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Date of Birth</label>
                                            <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Contact No</label>
                                            <asp:TextBox ID="txtCntNo" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Expiry Date</label>
                                            <asp:TextBox ID="txtExpDate" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Select PTP Packages</label>
                                            <asp:DropDownList ID="drpPTPPackages" runat="server" CssClass="form-control" OnSelectedIndexChanged="drpPTPPackages_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Valid Days</label>
                                            <asp:TextBox ID="txtDays" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">No Of Sessions</label>
                                            <asp:TextBox ID="txtNoOfSessions" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Fees</label>
                                            <asp:TextBox ID="txtFees" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <asp:Panel runat="server" ID="pnlAssignValues">
                                    <div class="col-md-12">
                                        <h3>Assign Values</h3>
                                    </div>
                                    <div class="col-md-12">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Start Date</label>
                                                <asp:TextBox ID="txtStDate" runat="server" placeholder="StartDate..." CssClass="form-control datePicker pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtStDate_TextChanged"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">End Date</label>
                                                <asp:TextBox ID="txtEndDate" runat="server" placeholder="EndDate..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Sessions Remaining</label>
                                                <asp:TextBox ID="txtSesRem" runat="server" placeholder="SessionRemaining..." CssClass="form-control" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Amount Payable</label>
                                                <asp:TextBox ID="txtAmt" runat="server" placeholder="AmountPayable..." CssClass="form-control" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                </asp:Panel>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="footerBtns">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                        <asp:Button ID="btnPayment" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Payment" OnClick="btnPayment_Click" />
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlDetails" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Session Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-8">
                                        <asp:Button ID="btnAddSession" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Add Session" OnClick="btnAddSession_Click" />
                                        <asp:Button ID="btnDetailCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Back" OnClick="btnDetailCancel_Click" />
                                    </div>
                                </div>
                                <%--<div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Member Name</label>
                                                <asp:Label ID="lblMemberName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Package Name</label>
                                                <asp:Label ID="lblPackName" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Total Sessions</label>
                                                <asp:Label ID="lblSessions" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Fees</label>
                                                <asp:Label ID="lblFees" runat="server" Text="" CssClass="form-control"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>--%>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdTrans" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <span><%#Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package Name">
                                            <ItemTemplate>
                                                <span><%#Eval("packageName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <span><%#Eval("insertDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                </asp:Panel>

                <asp:Panel ID="pnlAddSession" runat="server">
                    <div id='CustomModalPopup1'>
                        <div id='masteroverlay1' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModal1' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal1\").addClass(\"hide\");$(\"#masteroverlay1\").addClass(\"hide\");$(\"#MsgBoxModal1\").fadeOut(300);$(\"#CustomModalPopup1\").remove();return false;'>x</button>
                                <span>Enter RFID Number</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>RFID Number</label>
                                    <asp:TextBox ID="txtRFIDSes" runat="server" CssClass="form-control"></asp:TextBox>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNext" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal1').fadeOut(300); $('#btnNext').next().click(); $('#CustomModalPopup1').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnInsertSession" runat="server" Text="Save" CssClass="dsplNone" OnClick="btnInsertSession_Click"/>
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
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
                                            <asp:RadioButtonList ID="rblPayMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPayMode_SelectedIndexChanged"></asp:RadioButtonList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkPaidRet" Text="IsPaid" runat="server" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlChqDetails" runat="server" Visible="False">
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
                    <div class="clearfix"></div>
                    <div class="footerBtns">
                        <asp:Button ID="btnPymntSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnPymntSave_Click" />
                        <asp:Button ID="btnPymntCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnPymntCancel_Click" />
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlAssign">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
