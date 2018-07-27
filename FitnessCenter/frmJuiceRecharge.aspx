<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmJuiceRecharge.aspx.cs" Inherits="FitnessCenter.JuiceRecharge" %>

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
            SetMenuActive("liJuiceRecharge");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlJuice" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Juice Recharges</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmJuiceRecharge.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-12">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="fntWeightBold">Scan RFID Number</label>
                            <asp:TextBox ID="txtRfid" runat="server" placeholder="RFID Number.." CssClass="form-control" AutoPostBack="True" OnTextChanged="txtRfid_TextChanged"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Member Recharge Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Date Of Birth</label>
                                                <asp:TextBox ID="txtDateOfBirth" runat="server" placeholder="Date Of Birth.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Contact Number</label>
                                                <asp:TextBox ID="txtContactNo" runat="server" placeholder="Contact Number.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnAddRecharge" runat="server" Text="Recharge" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAddRecharge_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdRecharge" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" runat="server">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Prepaid Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("rechargeAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valid Days">
                                            <ItemTemplate>
                                                <span><%#Eval("validDays") %></span>
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
                                        <asp:TemplateField HeaderText="Is Paid">
                                            <ItemTemplate>
                                                <span><%#Eval("isPaid") %></span>
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
                                <label>Recharge Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Previous Amount</label>
                                            <asp:TextBox ID="txtPrevAmt" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Previous Amount.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:CheckBox ID="chkIsForwarded" runat="server" Text="Carry Forward" AutoPostBack="True" OnCheckedChanged="chkIsForwarded_CheckedChanged" />
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Prepaid Amount</label>
                                            <asp:TextBox ID="txtAmount" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Prepaid Amount.." AutoPostBack="True" OnTextChanged="txtAmount_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Total Amount</label>
                                            <asp:TextBox ID="txtTotalAmt" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Total Amount.." ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Valid Days</label>
                                            <asp:TextBox ID="txtDays" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Valid Days.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Start Date</label>
                                            <asp:TextBox ID="txtStDate" CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);" runat="server" placeholder="Start Date.." AutoPostBack="True" OnTextChanged="txtStDate_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">End Date</label>
                                            <asp:TextBox ID="txtEndDate" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="End Date.." ReadOnly="true"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Discount (in %)</label>
                                            <asp:TextBox ID="txtDiscount" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Discount.." AutoPostBack="True" OnTextChanged="txtDiscount_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Final Amount</label>
                                            <asp:TextBox ID="txtFinalAmt" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Final Amount.." ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="clearfix"></div>
                    <div class="footerBtns">
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlJuice">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
