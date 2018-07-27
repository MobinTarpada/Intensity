<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="ManageMemberShip.aspx.cs" Inherits="FitnessCenter.ManageMemberShip" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script type="text/javascript" src="http://jqueryjs.googlecode.com/files/jquery-1.3.1.min.js"> </script>--%>
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
            SetMenuActive("liManageMembership");
        }
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
        //function PrintElem(elem) {
        //    Popup($(elem).html());
        //}

        //function Popup(data) {
        //    var mywindow = window.open('', 'my div', 'height=400,width=600');
        //    mywindow.document.write('<html><head><title>my div</title>');
        //    /*optional stylesheet*/ //mywindow.document.write('<link rel="stylesheet" href="main.css" type="text/css" />');
        //    mywindow.document.write('</head><body >');
        //    mywindow.document.write(data);
        //    mywindow.document.write('</body></html>');

        //    mywindow.document.close(); // necessary for IE >= 10
        //    mywindow.focus(); // necessary for IE >= 10

        //    mywindow.print();
        //    mywindow.close();

        //    return true;
        //}
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlManageMemberShip" runat="server">
        <ContentTemplate>
            <div id="mydiv" class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Membership</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="ManageMembership.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
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
                                            <label class="fntWeightBold">Branch Name</label>
                                            <asp:TextBox ID="txtBranchName" runat="server" CssClass="form-control" ReadOnly="true" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Consultant</label>
                                            <asp:TextBox ID="txtConsultant" runat="server" CssClass="form-control" ReadOnly="true" onchange="RemoveValidate(this);"></asp:TextBox>
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
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>LeadSales Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <%--<div class="col-md-3" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchRfidNumber" runat="server" placeholder="RFID.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>--%>
                                    <div class="col-md-3" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchAgreementNo" runat="server" placeholder="AgreementNumber.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchFirstName" runat="server" placeholder="FirstName.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchLastName" runat="server" placeholder="LastName.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchMobileNo" runat="server" placeholder="MobileNumber.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary mrgLeft5 mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdMembership" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="true" OnPageIndexChanging="grdMembership_PageIndexChanging" OnRowCommand="grdMembership_RowCommand" OnRowDataBound="grdMembership_RowDataBound" OnSorting="grdMembership_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FirstName" SortExpression="FirstName">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LastName" SortExpression="LastName">
                                            <ItemTemplate>
                                                <span><%#Eval("lastName")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="AgreementNumber" SortExpression="AgreementNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("agreementNumber")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MobileNumber" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("mobileNumber")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%#Eval("ID") %>' CommandName="EditMember"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteMember" />
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
                                <asp:Button ID="btnTransferLeads" OnClick="btnTransferLeads_Click" runat="server" Text="Save" CssClass="dsplNone"  />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Membership</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Personal Details</h3>
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-6">

                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">TITLE</label>
                                                <%--<asp:TextBox ID="txtTITLE" runat="server" placeholder="TITLE..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>--%>
                                                <asp:DropDownList ID="ddlTitle" CssClass="form-control" runat="server" AutoPostBack="True">
                                                    <asp:ListItem Value="1">MR</asp:ListItem>
                                                    <asp:ListItem Value="2">MRS</asp:ListItem>
                                                    <asp:ListItem Value="3">MS</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Gender</label>
                                                <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" CssClass="form-control">
                                                    <asp:ListItem Value="Male" Selected="True">Male</asp:ListItem>
                                                    <asp:ListItem Value="Female">Female</asp:ListItem>
                                                </asp:RadioButtonList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Date Of Birth</label>
                                                <asp:TextBox ID="txtDOB" runat="server" CssClass="form-control datePicker pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                <asp:Button ID="btnCheckGuardian" runat="server" CssClass="btn btn-primary" Text="CheckGuardian" OnClick="btnCheckGuardian_Click" />
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">FirstName</label>
                                                <asp:TextBox ID="txtFName" runat="server" placeholder="...FirstName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">LastName</label>
                                                <asp:TextBox ID="txtLName" runat="server" placeholder="...LastName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Address</label>
                                                <asp:TextBox ID="txtAddress" runat="server" placeholder="Address..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">City</label>
                                                <asp:TextBox ID="txtCity" runat="server" placeholder="City..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Pincode</label>
                                                <asp:TextBox ID="txtPincode" runat="server" placeholder="Pincode..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">MobileNumber</label>
                                                <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="MobileNumber..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">OtherContact</label>
                                                <asp:TextBox ID="txtOtherContact" runat="server" placeholder="OtherContact..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                <label>***Don’t forget to fill email id for your intensity lifestyle network benefites and the great news is IT'S FREE***</label>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Emergency Contact Name</label>
                                                <asp:TextBox ID="txtEmrgncyCntcNm" runat="server" placeholder="Emergency Contact Name..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Emergency Contact Number</label>
                                                <asp:TextBox ID="txtEmergencyContact" runat="server" placeholder="Emergency Contact Number..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>

                                </div>
                            </div>
                        </div>
                    </div>
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
                                <%-- <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">JoiningFee</label>
                                        <asp:TextBox ID="txtJoiningFee" runat="server" placeholder="JoiningFee" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">AdminFee</label>
                                        <asp:TextBox ID="txtAdminFee" runat="server" placeholder="AdminFee" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">MembershipFee</label>
                                        <asp:TextBox ID="txtMembershipFee" runat="server" placeholder="MembershipFee" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">PersonalTrainingPack</label>
                                        <asp:TextBox ID="txtPersonalTrainingPack" runat="server" placeholder="PersonalTrainingPack" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">Service Tax</label>
                                        <asp:TextBox ID="txtSerTax" runat="server" placeholder="Service Tax" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="form-body">
                                    <div class="form-group">
                                        <label class="fntWeightBold">TotalAmount</label>
                                        <asp:TextBox ID="txtTotalAmount" runat="server" placeholder="TotalAmount" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>--%>
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
                                                    <label class="fntWeightBold">Joining Date</label>
                                                    <asp:TextBox ID="txtJDate" runat="server" placeholder="Joining Date..." CssClass="form-control datePicker" onchange="RemoveValidate(this);"></asp:TextBox>

                                                </div>
                                            </div>
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

                    <asp:Panel ID="pnlAgrement" runat="server">
                        <div class="col-md-12">
                            <div class="col-md-12">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <label class="fntWeightBold">***Acknowledgemant applicable to all members/memberships***</label>
                                        </div>
                                        <div>
                                            <label>
                                                This is 1/3/12 months membership agreement. I understand that unlase I provide written notice of termination 
                                            of my membership contract prior to the end of the minimum term, I will still liable for membership fees for the 
                                            period after I provide written notice of termination to Intensity Beyond Fitness. I understand that Intensity 
                                            Beyond Fitness must respond to its receipt ofa written notice with in 7 days.
                                            </label>
                                        </div>
                                    </div>
                                    <%-- <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>--%>
                                    <%-- <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-12">
                                <div class="form-body">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <%-- <label class="fntWeightBold">Signature</label>
                                            <asp:TextBox ID="txtSgntur" runat="server" CssClass="form-control"></asp:TextBox>--%>
                                        </div>
                                        <div>
                                            <label>
                                                I have received and had opportunity to read the membership Terms & Conditions. 
                                               It is important that you read and understand these because they will apply to 
                                               this membership agreement. Only accept this if you wish to bound by the terms 
                                               and conditions. Where member is a minor, this contract must be sign by the member 
                                               and their parents/guadians who promises and agrees by signing that they are authorised 
                                               to enter into this membership agreement on behalf of the minor and remains responsible 
                                               for the full performance by the minor of all terms & conditions set out in it.
                                            </label>
                                        </div>
                                    </div>
                                    <%-- <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>--%>
                                    <%-- <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>--%>
                                </div>
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="col-md-12">
                                <div class="form-body">
                                    <div class="row">
                                        <div>
                                            <label>
                                                We use the contact details you have provided above to contact you about your mebership. 
                                                We may also contact you from time to time with information about fitnessand wellness, 
                                                promotions, special offers and other materials about INTENSITY BEYOND FITNESS services 
                                                and products (including INTENSITY LIFESTYLE NETWORK partners). We will not provide your 
                                                personal informations or contact details to third parties. You can indicate below those
                                                 means by which you DO NOT wish to receive information regarding special offer. You can 
                                                change your mind at any time about receiving marketing materials by letting us know.
                                            </label>
                                        </div>
                                        <div class="form-body">
                                            <div class="form-group">
                                            </div>
                                        </div>
                                        <div>
                                            <asp:CheckBoxList ID="chkbox1" runat="server" AutoPostBack="True" RepeatColumns="3" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1">SMS/MMS</asp:ListItem>
                                                <asp:ListItem Value="2">EMAIL</asp:ListItem>
                                                <asp:ListItem Value="3">MOBILE / TELEPHONE</asp:ListItem>
                                            </asp:CheckBoxList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlGuardian" runat="server">
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <label>Guardin</label>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3>Guardin Details(under 18 Only)</h3>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-6">

                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Name Of Guardian</label>
                                                    <asp:TextBox ID="txtGuardianName" runat="server" placeholder="GuardianName..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Relationship Of Guardian</label>
                                                    <asp:TextBox ID="txtRelationshipOfGuardian" runat="server" placeholder="RelationshipOfGuardian..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <%--<div class="form-body" style="visibility: hidden;">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">GuardianSignature</label>
                                                    <asp:TextBox ID="txtGuardianSignature" runat="server" placeholder="GuardianSignature..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>--%>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <asp:Panel ID="pnlCorporate" runat="server">
                        <div class="portlet box blue">
                            <div class="portlet-title">
                                <div class="caption">
                                    <label>CorporateLeads</label>
                                </div>
                            </div>
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3>Corporate Leads Details</h3>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-6">

                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">CorporateId</label>
                                                    <asp:TextBox ID="txtCorporateId" runat="server" placeholder="CorporateId..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Company Name</label>
                                                    <asp:TextBox ID="txtCompanyName" runat="server" placeholder="Company Name..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">**ID MUST PROVIDE TO APPROVE CORPORATE DEAL**</label>
                                                    <label class="fntWeightBold">|CompanyLetter| |CompanyId| |PaySlip| </label>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </asp:Panel>
                    <div class="clearfix"></div>
                    <div class="footerBtns">
                        <asp:button id="btnSave" runat="server" cssclass="btn blue pull-right mrgRight10 mrgLeft5" onclientclick="return ValidateCustom('pnl1');" xmlns:asp="#unknown" text="Save" onclick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                        <%-- <input type="button" value="Print Div" onclick="PrintElem('#mydiv')" />--%>
                        <%--<asp:button id="btnPrint" runat="server" cssclass="btn blue pull-right mrgLeft5" onclientclick="return ValidateCustom('pnl1');" xmlns:asp="#unknown" text="Print" onclick="PrintElem('#mydiv')" />--%>
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
                                            <asp:RadioButtonList ID="rdoPayBy" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoPayBy_SelectedIndexChanged">
                                                <asp:ListItem Value="1">CASH</asp:ListItem>
                                                <asp:ListItem Value="2">CHEQUE</asp:ListItem>
                                                <asp:ListItem Value="3">CREDIT CARD</asp:ListItem>
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

                                                    <%--<ajaxToolkit:CalendarExtender ID="txtChkDate_CalendarExtender" runat="server" Format="dd/MM/yyyy" BehaviorID="txtChkDate_CalendarExtender" TargetControlID="txtChkDate" />--%>

                                                    <label class="fntWeightBold">BillAmount</label>
                                                    <asp:TextBox ID="txtAmount" runat="server" placeholder="BillAmount..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    <asp:CheckBox ID="chkChqPaid" runat="server" Text="IsPaid" AutoPostBack="True" OnCheckedChanged="chkIsPaid_CheckedChanged" />
                                                    <%--<asp:Button ID="btnChqSubmit" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Submit" OnClick="btnSubmit_Click" />--%>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                            <asp:Panel ID="pnlRfidNo" runat="server">
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
                        <asp:Button ID="btnSubmit" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1'); SetTarget();" Text="Submit" OnClick="btnSubmit_Click" />
                        <%--<asp:Button ID="NextButton" CssClass="btn blue pull-right mrgRight10 mrgLeft5" runat="server" Text="NEXT" OnClick="NextButton_Click" />--%>
                        <asp:Button ID="Backbutton" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Back" OnClick="Backbutton_Click" />
                    </div>


                </asp:Panel>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="updtPnlManageMemberShip">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

    <script type="text/javascript">
        function SetTarget() {
            document.forms[0].target = "_blank";
        }
    </script>
</asp:Content>
