<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmNewManageLead.aspx.cs" Inherits="FitnessCenter.frmNewManageLead" %>
<%--hi--%>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
    <asp:UpdatePanel ID="updtPnlManageLead" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Lead </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmManageLead.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" DefaultButton="btnSearch" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Lead</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div runat="server" id="HeadBtn" class="row">
                                <div class="col-md-12 mrgBottom10">
                                    <asp:Button ID="btnAddLead" runat="server" Text="Add Lead" OnClick="btnAddLead_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    <%--              </div>
                                <div class="col-md-12 mrgBottom10">--%>
                                    <asp:Button ID="btnExcel" runat="server" Text="Add Excel" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnExcel_Click" />
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchText" runat="server" placeholder="First Name.." CssClass="form-control"></asp:TextBox>
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
                                                <%-- <ajaxToolkit:FilteredTextBoxExtender ID="txtSearchMobileNo_FilteredTextBoxExtender" runat="server" BehaviorID="txtSearchMobileNo_FilteredTextBoxExtender" TargetControlID="txtSearchMobileNo" FilterType="Numbers" />--%>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlSearchLeadStatus" CssClass="form-control" runat="server"></asp:DropDownList>
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
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdLead" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdLead_PageIndexChanging" AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdLead_Sorting" AllowSorting="true"
                                    OnRowCommand="grdLead_RowCommand" OnRowDataBound="grdLead_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FIRST NAME" SortExpression="Delete All">
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="chkDeleteAll" runat="server" AutoPostBack="True" OnCheckedChanged="chkDeleteAll_CheckedChanged" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hfLeadId" runat="server" Value='<%#Eval("ID") %>' />
                                                <asp:CheckBox ID="chkDelete" runat="server" AutoPostBack="True" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FIRST NAME" SortExpression="FIRSTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="LAST NAME" SortExpression="LASTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("lastName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MOBILE NUMBER" SortExpression="MOBILENUMBER">
                                            <ItemTemplate>
                                                <span><%# Eval("mobilenumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="DATE OF BIRTH" SortExpression="DOB">
                                            <ItemTemplate>
                                                <span><%#Eval("dateOfBirth","{0:dd/MM/yyyy}")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Executive Name">
                                            <ItemTemplate>
                                                <span><%# Eval("User.UserName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LEAD TYPE">
                                            <ItemTemplate>
                                                <span><%# Eval("LeadTypeMaster.LeadTypeName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LEAD STATUS">
                                            <ItemTemplate>
                                                <span><%# Eval("LeadStatusMaster.StatusName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditLead"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailLead"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnTransfer" runat="server" ToolTip="Transfer" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Transfer','Are you sure you want to Transfer this record?',this.id);return false;"><i class="fa fa-exchange"></i></asp:LinkButton>
                                                    <asp:Button ID="btnTransfer" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="TransferLead" />
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteLead" />
                                                    <asp:LinkButton ID="lnkBtnEmail" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Email','Are you sure you want to Email this record?',this.id);return false;"><i class="fa fa-envelope"></i></asp:LinkButton>
                                                    <asp:Button ID="btnEmail" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="EmailLead" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="SMS" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-2" style="padding: 0px;">
                                <asp:Button ID="btnConfirmDelete" runat="server" Text="Delete Selected" CssClass="btn btn-primary pull-right mrgTop10" OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete selected record?',this.id);return false;" />
                                <asp:Button ID="btnDeleteSelected" runat="server" Text="" CssClass="dsplNone" OnClick="btnDeleteSelected_Click" />
                                <asp:Button ID="btnConfirmTransfer" runat="server" Text="Transfer Selected" CssClass="btn btn-primary pull-right mrgTop10" OnClientClick="DeleteConfirmPopupFromGrid('Transfer','Are you sure you want to Transfer this record?',this.id);return false;" />
                                <asp:Button ID="btnTransferSelected" runat="server" Text="" CssClass="dsplNone" OnClick="btnTransferSelected_Click" />
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
                                <span>Transfer Leads</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Transfer To</label>
                                    <asp:DropDownList ID="drpTransferUser" runat="server" CssClass="form-control"></asp:DropDownList>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNext" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNext').next().click(); $('#CustomModalPopup1').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnTransferLeads" runat="server" Text="Save" CssClass="dsplNone" OnClick="btnTransferLeads_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEmail" runat="server">
                    <div id='CustomModalPopup4'>
                        <div id='masteroverlay4' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModal4' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal4\").addClass(\"hide\");$(\"#masteroverlay4\").addClass(\"hide\");$(\"#MsgBoxModal4\").fadeOut(300);$(\"#CustomModalPopup4\").remove();return false;'>x</button>
                                <span>Email Promotion</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Email To</label>
                                    <asp:TextBox ID="txtPromoEmail" ReadOnly="true" runat="server" CssClass="form-control"></asp:TextBox>
                                    <label class='fntWeightBold'>Attachment</label>
                                    <asp:FileUpload ID="fileUploader" runat="server" />
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNxt" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay4').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNxt').next().click(); $('#CustomModalPopup4').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnEmail" runat="server" Text="Send Email" CssClass="dsplNone" OnClick="btnEmail_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay4').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup4').remove(); return false;" />
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
                                    <asp:TextBox ID="txtMsgSMS" runat="server" CssClass="form-control" TextMode="MultiLine"></asp:TextBox>
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
                <asp:Panel ID="pnlTransferAll" runat="server">
                    <div id='CustomModelPopup3'>
                        <div id='masteroverlay3' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModel3' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModel3\").addClass(\"hide\");$(\"#masteroverlay3\").addClass(\"hide\");$(\"#MsgBoxModel3\").fadeOut(300);$(\"#CustomModelPopup3\").remove();return false;'>x</button>
                                <span>Transfer Lead</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Transfer To</label>
                                    <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control"></asp:DropDownList>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnfrwrd" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay3').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnfrwrd').next().click(); $('#CustomModelPopup3').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnTransferMultipleLeads" runat="server" Text="SaveAll" CssClass="dsplNone" OnClick="btnTransferLeadsAll_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay3').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModelPopup3').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server" DefaultButton="btnSave">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Lead</label>
                            </div>
                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Lead Type</label>
                                            <asp:DropDownList ID="ddlLeadTypeAdd" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlLeadTypeAdd_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                        <asp:Panel ID="pnlRefferal" runat="server">
                                            <label class="fntWeightBold">Member Register No.</label>
                                            <asp:TextBox ID="txtMmbrReg" runat="server" placeholder="Member Register No..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtMmbrReg_TextChanged"></asp:TextBox>

                                            <label class="fntWeightBold">Member Name</label>
                                            <asp:TextBox ID="txtMmbrname" runat="server" placeholder="MemberName..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            <label class="fntWeightBold">Member Contact</label>
                                            <asp:TextBox ID="txtMemberContact" runat="server" placeholder="MemberContact..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            <label class="fntWeightBold">Relationship With Member</label>
                                            <asp:TextBox ID="txtRelation" runat="server" placeholder="Relationship With Member..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </asp:Panel>

                                        <div class="form-group">
                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Gender</label>
                                            <asp:RadioButtonList ID="rdoGender" runat="server" RepeatDirection="Horizontal" placeholder="Gender.." CssClass="form-control">
                                                <asp:ListItem Value="Male" Selected="True">Male</asp:ListItem>
                                                <asp:ListItem Value="Female">Female</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Date OF BIRTH</label>
                                            <asp:TextBox ID="txtDOB" runat="server" placeholder="Date Of Birth.." CssClass="form-control datePicker" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtDOB_TextChanged"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Address</label>
                                            <asp:TextBox ID="txtAddress" runat="server" placeholder="Address.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">City</label>
                                            <asp:TextBox ID="txtCity" runat="server" placeholder="City.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">PinCode</label>
                                            <asp:TextBox ID="txtPin" runat="server" placeholder="PinCode.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">BestTimeToCall</label>
                                            <asp:DropDownList ID="ddlBestTimeToCall" runat="server" placeholder="BestTimeToCall.." CssClass="form-control" onchange="RemoveValidate(this);">
                                                <asp:ListItem Value="1">Morning</asp:ListItem>
                                                <asp:ListItem Value="2">Afternoon</asp:ListItem>
                                                <asp:ListItem Value="3">Evening</asp:ListItem>
                                                <asp:ListItem Value="4">AnyTime</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">ResponseType</label>
                                            <asp:DropDownList ID="ddlResponseType" runat="server" placeholder="ResponseType.." CssClass="form-control" onchange="RemoveValidate(this);">
                                                <asp:ListItem Value="1">CALL</asp:ListItem>
                                                <asp:ListItem Value="2">SMS</asp:ListItem>
                                                <asp:ListItem Value="3">EMAIL</asp:ListItem>
                                                <asp:ListItem Value="4">All</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">MaritalStatus</label>
                                            <asp:DropDownList ID="ddlMaritalStatus" runat="server" AutoPostBack="true" placeholder="ResponseType.." OnSelectedIndexChanged="ddlMaritalStatus_SelectedIndexChanged" CssClass="form-control" onchange="RemoveValidate(this);">
                                                <asp:ListItem>Single</asp:ListItem>
                                                <asp:ListItem>Married</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                        <asp:Panel ID="panelAnniversaryDate" runat="server" Visible="false">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Anniversary Date</label>
                                                <asp:TextBox ID="txtAnniversaryDate" runat="server" placeholder="Anniversary Date.." CssClass="form-control datePicker" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Occupation</label>
                                            <asp:TextBox ID="txtOccupation" runat="server" placeholder="Occupation.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Employer/Company</label>
                                            <asp:TextBox ID="txtEmployee" runat="server" placeholder="Employee.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Email</label>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">MobileNumber</label>
                                            <asp:TextBox ID="txtMobile" runat="server" placeholder="MobileNumber.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">OtherContactNumber</label>
                                            <asp:TextBox ID="txtOtherContact" runat="server" placeholder="OtherContactNumber.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>

                                <asp:UpdatePanel ID="updtpnl1" runat="server">
                                    <ContentTemplate>
                                        <div class="clearfix"></div>
                                        <div class="col-md-12" style="margin-bottom: 10px;">
                                            <h3>Questions</h3>
                                        </div>
                                        <div class="col-md-12">
                                            <asp:ListView ID="lstQuestions" runat="server" OnItemDataBound="lstQuestions_ItemDataBound">
                                                <ItemTemplate>
                                                    <div>
                                                        <asp:Label ID="lblQuestionText" runat="server" Style="font-weight: bold;" Text='<%# "*" +   Eval("questions") %>'></asp:Label>
                                                        <asp:HiddenField ID="hdnFldQuestionTypeId" runat="server" Value='<%#Eval("questionTypeId") %>' />
                                                        <asp:HiddenField ID="hdnFldSelfQuestionID" runat="server" Value='<%#Eval("QuestionId") %>' />
                                                        <asp:HiddenField ID="hdnfldqestionOptionID" runat="server" Value='<%#Eval("OptionId") %>' />
                                                        <asp:HiddenField ID="hdnFldQuestionId" runat="server" Value='<%#Eval("ID") %>' />
                                                        <asp:HiddenField ID="hdnFldSuperQuestionId" runat="server" Value='<%#Eval("SuperQuestionId") %>' />
                                                        <div class="clearfix"></div>
                                                        <div class="mrgTop10">
                                                            <div class="form-body">
                                                                <asp:Panel ID="pnlSingleType" runat="server">
                                                                    <div class="form-group">
                                                                        <asp:TextBox ID="txtQuestionAnswer" runat="server" CssClass="form-control"></asp:TextBox>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlMultipleTypeRadio" runat="server">
                                                                    <div class="col-md-12">
                                                                        <div class="form-group">
                                                                            <asp:RadioButtonList ID="lstQuestionSingleOption" CssClass="col-lg-12 radio-list" runat="server" AutoPostBack="True"
                                                                                OnSelectedIndexChanged="lstQuestionSingleOption_SelectedIndexChanged"
                                                                                OnItemDataBound="lstQuestionSingleOption_ItemDataBound" RepeatColumns="10">
                                                                            </asp:RadioButtonList>
                                                                        </div>
                                                                    </div>
                                                                </asp:Panel>
                                                                <asp:Panel ID="pnlMultipleType" runat="server">
                                                                    <div class="col-md-12">
                                                                        <asp:ListView ID="lstQuestionOptions" runat="server" OnItemDataBound="lstQuestionOptions_ItemDataBound">
                                                                            <ItemTemplate>
                                                                                <div class="col-md-3">
                                                                                    <div class="form-group">
                                                                                        <asp:HiddenField ID="hdnFldOptionId" runat="server" Value='<%#Eval("ID") %>' />
                                                                                        <label class="checkbox">
                                                                                            <asp:CheckBox ID="chkOptions" runat="server" Style="margin-left: 0px;" />
                                                                                            <label for="chkOptions"><%#Eval("options") %></label>
                                                                                        </label>
                                                                                    </div>
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:ListView>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:ListView>
                                        </div>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtpnl1">
                                    <ProgressTemplate>
                                        <div class="ajax-loading">
                                            <div></div>
                                        </div>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                                <p></p>
                                <asp:Panel ID="pnlAction" runat="server">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Set Your Schedule From Here</label>
                                            <asp:DropDownList ID="ddlAction" CssClass="form-control pnl1text-input" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlAction_SelectedIndexChanged">
                                                <asp:ListItem Value="0">Select Your Action</asp:ListItem>
                                                <asp:ListItem Value="4">Followup</asp:ListItem>
                                                <asp:ListItem Value="2">Appoinments</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlEditAppoinments" runat="server">
                                        <div class="col-md-6">

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
                                                                    <asp:TextBox ID="txtaDate" runat="server" placeholder="Appointment Date.." CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Appointment    Remarks</label>
                                                                    <asp:TextBox ID="txtApointRemarks" runat="server" placeholder="Appointment Remarks.." CssClass="form-control pnlAtext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                                <%--<div class="form-group">
                                                                <label class="checkbox">
                                                                    <asp:CheckBox ID="chkAttend" runat="server" Style="margin-left: 0px;" />
                                                                    <label for="chkBxRememberMe">Appointment Attended?</label>
                                                                </label>
                                                            </div>
                                                            <div class="form-group">
                                                                <label class="fntWeightBold">Reasons for not Attend</label>
                                                                <asp:TextBox ID="txtrsn" runat="server" placeholder="Reasons.." CssClass="form-control" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                                            </div>--%>
                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <asp:Panel ID="pnlEditFollowup" runat="server">
                                        <div class="col-md-6">

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
                                                                    <label class="fntWeightBold">Followups Date</label>
                                                                    <asp:TextBox ID="txtFDate" runat="server" placeholder="Followups Date.." CssClass="form-control pnlAtext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>

                                                                </div>
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">Followups Remarks</label>
                                                                    <asp:TextBox ID="txtFolloupRemarks" runat="server" placeholder="Followups Remarks.." CssClass="form-control pnlAtext-input" onchange="RemoveValidate(this);"></asp:TextBox>

                                                                </div>

                                                            </div>
                                                        </div>
                                                        <div class="clearfix"></div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <div class="footerBtns">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text="Save" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancel_Click" Text="Cancel" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDetail" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Lead Detail</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">

                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtLblFirstName" runat="server" CssClass="form-control pnlAtext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLblLastName" runat="server" CssClass="form-control pnlAtext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Contact Number</label>
                                            <asp:TextBox ID="txtLblConNo" runat="server" CssClass="form-control pnlAtext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-body">
                                        <div class="form-group">

                                            <label class="fntWeightBold">Lead Status</label>
                                            <asp:DropDownList ID="ddlLeadStatus" runat="server" CssClass="form-control" onchange="RemoveValidate(this);" OnSelectedIndexChanged="ddlLeadStatus_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <%--<asp:Panel ID="pnlAppointment" runat="server">
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
                                                        <div class="col-md-12">
                                                            <asp:Button ID="btnAddAppointment" runat="server" Text="Add Appointment" OnClick="btnAddAppointment_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                        </div>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdLeadAppointment" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                            EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                                            OnRowCommand="grdLeadAppointment_RowCommand">
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
                                                                <asp:TemplateField HeaderText="Remarks">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("reasonForNotAttend") %></span>
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

                                        <asp:Panel ID="pnlAppointmentEdit" runat="server">
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
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                --%>
                                <asp:Panel ID="pnlFollowup" runat="server">
                                    <div class="col-md-12">
                                        <asp:Panel ID="pnlFollowupEdit" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <asp:Label runat="server" ID="lblHeading"></asp:Label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold"> Date And Time</label>
                                                                    <asp:TextBox ID="txtDateNTime" runat="server" placeholder="Date And Time.." CssClass="form-control pnltext-input datetime" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                                </div>
                                                        </div>    
                                                        <div class="col-md-4">
                                                            <div class="form-body">
                                                               <div class="form-group">
                                                                    <label class="fntWeightBold">Remarks</label>
                                                                    <asp:TextBox ID="txtRemarks" runat="server" placeholder="Remarks.." CssClass="form-control pnltext-input " onchange="RemoveValidate(this);"></asp:TextBox>
                                                                </div>
                                                            </div>
                                                        </div>

                                                        <div class="clearfix"></div>

                                                        <%--<div class="footerBtns">
                                                            <asp:Button ID="btnSaveLeadFollowup" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlB');" Text="Save" OnClick="btnSaveLeadFollowup_Click" />
                                                            <asp:Button ID="btnCancelLeadFollowup" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancelLeadFollowup_Click" />
                                                        </div>--%>
                                            </div>
                                            </div>
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </asp:Panel>
                                <%--<div class="clearfix"></div>
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
                                                        <div class="col-md-12">
                                                            <asp:Button ID="btnAddPresentation" runat="server" Text="Add Presentation" OnClick="btnAddPresentation_Click" CssClass="btn btn-primary pull-right mrgBottom10" />
                                                        </div>
                                                    </div>
                                                    <div class="table-responsive">
                                                        <asp:GridView ID="grdLeadPresentation" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                            EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                                            OnRowCommand="grdLeadPresentation_RowCommand">
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
                                                                <asp:TemplateField HeaderText="Remarks">
                                                                    <ItemTemplate>
                                                                        <span><%#Eval("reasonsForNotAttend") %></span>
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

                                        <asp:Panel ID="pnlPresentationEdit" runat="server">
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
                                --%>
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
                                                            <asp:TemplateField HeaderText="DATE TIME">
                                                                <ItemTemplate>
                                                                    <span><%#Convert.ToDateTime(Eval("insertDate")).ToString("dd-MMM-yyyy hh:mm tt") %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="STATUS">
                                                                <ItemTemplate>
                                                                    <span><%#Eval("LeadStatusMaster1.StatusName") %></span>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="REMARKS">
                                                                <ItemTemplate>
                                                                    <span><%#Eval("Remarks") %></span>
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
                                <div class="footerBtns">
                                    <asp:Button ID="btnSaveLeadDetail" runat="server" OnClick="btnSaveLeadDetail_Click" CssClass="btn blue pull-right mrgRight10 mrgLeft5" Text="Save" />
                                    <%--//OnClick="btnSaveLeadDetail_Click"--%>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>


            <asp:Panel ID="pnlExcel" runat="server">
                <div id='CustomModalPopup2'>
                    <div id='masteroverlay2' class='web_dialog_overlay hide'></div>
                    <div id='MsgBoxModal2' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                        <div class='wdoHeader'>
                            <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick="$('#MsgBoxModal2').addClass('hide');$('#masteroverlay2').addClass('hide');$('#MsgBoxModal2').fadeOut(300);$('#CustomModalPopup2').remove(); return false;">x</button>
                            <span>Please Select Excel File</span>
                        </div>
                        <div class='modal-body'>
                            <p>
                                <asp:FileUpload ID="fileuploadExcel" runat="server" />
                            </p>
                        </div>
                        <div class='wdoFooter' align='center'>
                            <input type='button' id="btnNext1" value='OK' onclick="$('#masteroverlay2').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNext1').next().click(); $('#CustomModalPopup2').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                            <asp:Button ID="btnImport" runat="server" CssClass="dsplNone" Text="" OnClick="btnImport_Click" />
                            <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#masteroverlay2').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup2').remove(); return false;" />
                        </div>
                    </div>
                </div>
            </asp:Panel>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnImport" />
            <asp:PostBackTrigger ControlID="btnEmail" />
        </Triggers>
    </asp:UpdatePanel>
    <script type="text/javascript">

        function chk() {
            return false;
        }
    </script>

    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="updtPnlManageLead">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
