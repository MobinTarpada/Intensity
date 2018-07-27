<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmPayment.aspx.cs" Inherits="FitnessCenter.frmPayment" %>

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
        }
        SetMenuActive("liPayment");
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlPayment" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Payment</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="#">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="col-md-6">
                    <div class="form-body">
                        <div class="form-group">
                            <label class="fntWeightBold">Payment Type</label>
                            <asp:DropDownList ID="drpPaymentType" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpPaymentType_SelectedIndexChanged">
                                <asp:ListItem Value="-1">Select Payment Type</asp:ListItem>
                                <asp:ListItem Value="1">Membership</asp:ListItem>
                                <asp:ListItem Value="2">PT Package</asp:ListItem>
                                <asp:ListItem Value="3">Towel Package</asp:ListItem>
                                <asp:ListItem Value="4">POS Products</asp:ListItem>
                                <asp:ListItem Value="5">Juicebox Recharge</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlScanRfid">
                    <div class="col-md-12">
                        <div class="form-body">
                            <div class="form-group">
                                <label class="fntWeightBold" runat="server" id="rfid">Scan RFID Number</label>
                                <%--<asp:CheckBox ID="chkAgreement" runat="server" AutoPostBack="true" Text="Enter Agreement Number" OnCheckedChanged="chkAgreement_CheckedChanged" />--%>
                                <asp:TextBox ID="txtRfid" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtRfid_TextChanged"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
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
                                </div>

                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlPayment" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Payment Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Pay By</h3>
                                </div>
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Payment Mode</label>
                                            <asp:RadioButtonList ID="rblPayMode" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rblPayMode_SelectedIndexChanged">
                                                <asp:ListItem Value="1">CASH</asp:ListItem>
                                                <asp:ListItem Value="2">CHEQUE</asp:ListItem>
                                                <asp:ListItem Value="3">CARD</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlCashPayment" runat="server">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>Payment</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Cash Details</h3>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <label class="fntWeightBold">Bill Amount</label>
                                                    <asp:TextBox ID="txtBillAmount" runat="server" placeholder="BillAmount..." CssClass="form-control" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <label class="fntWeightBold">AmountPaid</label>
                                                    <asp:TextBox ID="txtAmountPaid" runat="server" placeholder="AmountPaid..." CssClass="form-control" onchange="RemoveValidate(this);" OnTextChanged="txtAmountPaid_TextChanged" AutoPostBack="True"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <label class="fntWeightBold">Remaining Amount</label>
                                                    <asp:TextBox ID="txtRemainingAmount" runat="server" ReadOnly="true" placeholder="Remaining Amount..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <label class="fntWeightBold">DueAmountDate</label>
                                                    <asp:TextBox ID="txtDueAmount" runat="server" placeholder="DueAmountDate..." CssClass="form-control datePicker" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <asp:CheckBox ID="chkIsPaid" runat="server" Text="IsPaid" AutoPostBack="True" OnCheckedChanged="chkIsPaid_CheckedChanged" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlChequePayment" runat="server">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>Payment</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Cheque Details</h3>
                                            </div>
                                            <div class="col-lg-12">
                                                <div class="col-lg-6">
                                                    <label class="fntWeightBold">ChequeNumber</label>
                                                    <asp:TextBox ID="txtChkNo" runat="server" plasceholder="ChequeNumber..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <label class="fntWeightBold">BankName</label>
                                                    <asp:TextBox ID="txtBankName" runat="server" placeholder="BankName..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>

                                                    <label class="fntWeightBold">BranchName & Address</label>
                                                    <asp:TextBox ID="txtBranchDetails" runat="server" placeholder="BranchName & Address..." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>

                                                    <label class="fntWeightBold">Date</label>
                                                    <asp:TextBox ID="txtChkDate" runat="server" placeholder="Date..." CssClass="form-control datePicker" onchange="RemoveValidate(this);"></asp:TextBox>

                                                    <div class="col-lg-12">
                                                        <div class="col-lg-6">
                                                            <label class="fntWeightBold">Bill Amount</label>
                                                            <asp:TextBox ID="txtChqBillAmt" runat="server" placeholder="BillAmount..." CssClass="form-control" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label class="fntWeightBold">AmountPaid</label>
                                                            <asp:TextBox ID="txtChqAmountPaid" runat="server" placeholder="AmountPaid..." CssClass="form-control" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtChqAmountPaid_TextChanged"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label class="fntWeightBold">Remaining Amount</label>
                                                            <asp:TextBox ID="txtChqRemaiAmt" runat="server" ReadOnly="true" placeholder="Remaining Amount..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                        </div>
                                                        <div class="col-lg-6">
                                                            <label class="fntWeightBold">DueAmountDate</label>
                                                            <asp:TextBox ID="txtChqDueAmount" runat="server" placeholder="DueAmountDate..." CssClass="form-control datePicker" onchange="RemoveValidate(this);"></asp:TextBox>
                                                        </div>
                                                        <asp:CheckBox ID="chkChqPaid" runat="server" Text="IsPaid" AutoPostBack="True" OnCheckedChanged="chkIsPaid_CheckedChanged" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlRfidNo" runat="server" Visible="False">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>RFID Number</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Allot RFID Number</h3>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <div class="form-body">
                                                        <div class="form-group">
                                                            <label class="fntWeightBold">RFID No</label>
                                                            <asp:TextBox ID="txtRFIDNo" runat="server" placeholder="RFID Number..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
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
                    <div class="footerBtns">
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Submit" OnClick="btnSubmit_Click" />
                        <asp:Button ID="Backbutton" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="Backbutton_Click" />
                    </div>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlPayment">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
