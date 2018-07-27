<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="ManageUserScheme.aspx.cs" Inherits="FitnessCenter.ManageUserScheme" %>


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
            SetMenuActive("liManageUserScheme");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdtPnlUserScheme" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage UserScheme</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="ManageUserScheme.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>

                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>User Schemes</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchText" runat="server" placeholder="Search Package.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchSchmName" runat="server" placeholder="Search Scheme.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAddUserScheme" runat="server" Text="Add UserScheme" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAddUserScheme_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdUserScheme" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdUserScheme_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdUserScheme_Sorting" AllowSorting="true"
                                    OnRowCommand="grdUserScheme_RowCommand" OnRowDataBound ="grdUserScheme_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="PackageName" SortExpression="PackageName">
                                            <ItemTemplate>
                                                <span><%#Eval("packageName")%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="UserScheme Name" SortExpression="UserSchemeName">
                                            <ItemTemplate>
                                                <span><%#Eval("schemeName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="AdditionalExpense" SortExpression="AdditionalExpense">
                                            <ItemTemplate>
                                                <span><%#Eval("additionalExpense") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="isAllowCancelation" SortExpression="isAllowCancelation">
                                            <ItemTemplate>
                                                <span><%#Eval("isAllowCancelation") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%#Eval("ID") %>' CommandName="EditUserScheme"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailUserScheme"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteUserScheme" />
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
                                <label>User Scheme</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Scheme Detail</h3>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">PackageName</label>
                                                <asp:DropDownList ID="ddlPackageS" runat="server" CssClass="form-control pnl1text-input customDropdown" onchange="RemoveValidate(this);" AutoPostBack="True" OnSelectedIndexChanged="ddlPackageS_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Package Amount</label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblJoin" runat="server" CssClass="fntWeightBold" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblAdmin" runat="server" CssClass="fntWeightBold" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblMember" runat="server" CssClass="fntWeightBold" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblPTP" runat="server" CssClass="fntWeightBold" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSerTax" runat="server" CssClass="fntWeightBold" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">UserScheme Name</label>
                                                <asp:TextBox ID="txtUserschemeName" runat="server" placeholder="UserSchemeName.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Joining Fee</label>
                                                <asp:TextBox ID="txtJoinFee" runat="server" placeholder="Joining Fee.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Admin Fee</label>
                                                <asp:TextBox ID="txtAdminFee" runat="server" placeholder="Admin Fee.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Membership Fee</label>
                                                <asp:TextBox ID="txtMemFee" runat="server" placeholder="Membership Fee.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Personal Training Fee</label>
                                                <asp:TextBox ID="txtPersTraining" runat="server" placeholder="Personal Training Fee.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Service Tax in Percentage</label>
                                                <asp:TextBox ID="txtService" runat="server" placeholder="Service Tax.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtService_TextChanged"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Total Amount</label>
                                                <asp:TextBox ID="txtTotAmt" runat="server" placeholder="Total Amount.." CssClass="form-control pnl1text-input" ReadOnly="true" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <%--<label  class="fntWeightBold">Additional Expense</label>--%>
                                                <asp:TextBox ID="txtAdditionalExpense" Visible="false" runat="server" placeholder="Additional Expense.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Start Date</label>
                                                <asp:TextBox ID="txtStrDate" runat="server" placeholder="Start Date.." CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Start Time</label>
                                                <asp:DropDownList ID="ddlStartTime" runat="server" CssClass="form-control pnl1text-input customDropdown">
                                                    <asp:ListItem>Full Access</asp:ListItem>
                                                    <asp:ListItem>01:00 AM</asp:ListItem>
                                                    <asp:ListItem>02:00 AM</asp:ListItem>
                                                    <asp:ListItem>03:00 AM</asp:ListItem>
                                                    <asp:ListItem>04:00 AM</asp:ListItem>
                                                    <asp:ListItem>05:00 AM</asp:ListItem>
                                                    <asp:ListItem>06:00 AM</asp:ListItem>
                                                    <asp:ListItem>07:00AM</asp:ListItem>
                                                    <asp:ListItem>08:00 AM</asp:ListItem>
                                                    <asp:ListItem>09:00 AM</asp:ListItem>
                                                    <asp:ListItem>10:00 AM</asp:ListItem>
                                                    <asp:ListItem>11:00 AM</asp:ListItem>
                                                    <asp:ListItem>12:00 AM</asp:ListItem>
                                                    <asp:ListItem>01:00 PM</asp:ListItem>
                                                    <asp:ListItem>02:00 PM</asp:ListItem>
                                                    <asp:ListItem>03:00 PM</asp:ListItem>
                                                    <asp:ListItem>04:00 PM</asp:ListItem>
                                                    <asp:ListItem>05:00 PM</asp:ListItem>
                                                    <asp:ListItem>06:00 PM</asp:ListItem>
                                                    <asp:ListItem>07:00 PM</asp:ListItem>
                                                    <asp:ListItem>08:00 PM</asp:ListItem>
                                                    <asp:ListItem>09:00 PM</asp:ListItem>
                                                    <asp:ListItem>10:00 PM</asp:ListItem>
                                                    <asp:ListItem>11:00 PM</asp:ListItem>
                                                    <asp:ListItem>12:00 PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">End Date</label>
                                                <asp:TextBox ID="txtEndDate" runat="server" placeholder="End Date.." CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">End Time</label>
                                                <asp:DropDownList ID="ddlEndTime" runat="server" CssClass="form-control pnl1text-input customDropdown">
                                                    <asp:ListItem>Full Access</asp:ListItem>
                                                    <asp:ListItem>01:00 AM</asp:ListItem>
                                                    <asp:ListItem>02:00 AM</asp:ListItem>
                                                    <asp:ListItem>03:00 AM</asp:ListItem>
                                                    <asp:ListItem>04:00 AM</asp:ListItem>
                                                    <asp:ListItem>05:00 AM</asp:ListItem>
                                                    <asp:ListItem>06:00 AM</asp:ListItem>
                                                    <asp:ListItem>07:00AM</asp:ListItem>
                                                    <asp:ListItem>08:00 AM</asp:ListItem>
                                                    <asp:ListItem>09:00 AM</asp:ListItem>
                                                    <asp:ListItem>10:00 AM</asp:ListItem>
                                                    <asp:ListItem>11:00 AM</asp:ListItem>
                                                    <asp:ListItem>12:00 AM</asp:ListItem>
                                                    <asp:ListItem>01:00 PM</asp:ListItem>
                                                    <asp:ListItem>02:00 PM</asp:ListItem>
                                                    <asp:ListItem>03:00 PM</asp:ListItem>
                                                    <asp:ListItem>04:00 PM</asp:ListItem>
                                                    <asp:ListItem>05:00 PM</asp:ListItem>
                                                    <asp:ListItem>06:00 PM</asp:ListItem>
                                                    <asp:ListItem>07:00 PM</asp:ListItem>
                                                    <asp:ListItem>08:00 PM</asp:ListItem>
                                                    <asp:ListItem>09:00 PM</asp:ListItem>
                                                    <asp:ListItem>10:00 PM</asp:ListItem>
                                                    <asp:ListItem>11:00 PM</asp:ListItem>
                                                    <asp:ListItem>12:00 PM</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Upgradation Days</label>
                                                <asp:TextBox ID="txtUpgrdDays" runat="server" placeholder="Upgradation Days..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Downgradation Days</label>
                                                <asp:TextBox ID="txtDwnGrdDays" runat="server" placeholder="Downgradation Days..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:CheckBox ID="chkAllowCancelation" Text="AllowCancelation" runat="server" AutoPostBack="True" OnCheckedChanged="chkAllowCancelation_CheckedChanged" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlCancellation">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>Cancellation</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-12">
                                                <h3>Cancellation Detail</h3>
                                            </div>
                                            <div class="col-md-12">
                                                <div class="col-md-6">
                                                    <div class="form-body">
                                                        <div class="form-group">
                                                            <label class="fntWeightBold">Cancellation Days</label>
                                                            <asp:TextBox ID="txtCanclDays" runat="server" placeholder="Cancellation Days..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkJoining" Text="Joining Fees" runat="server" />
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkAdmin" Text="Admin Fees" runat="server" />
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkMembership" Text="Membership Fees" runat="server" />
                                                        </div>
                                                        <div class="form-group">
                                                            <asp:CheckBox ID="chkPTP" Text="Personal Training Fees" runat="server" />
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
                        <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                        <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDetail" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Userscheme Transaction Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package Name</label>
                                            <asp:DropDownList ID="ddlPckgName" runat="server" CssClass="form-control" onchange="RemoveValidate(this);" Enabled="False"></asp:DropDownList>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div class="col-md-12">
                                    <div class="col-md-6">

                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:Label ID="lblJoinFee" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblAdminFee" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblMembrFee" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblPrsnltrngFee" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSrvcTax" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="clearfix"></div>

                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Scheme Name</label>
                                                <asp:TextBox ID="txtSchemeName" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSchJoin" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSchAdmin" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSchMem" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSchPers" runat="server" Text=""></asp:Label>
                                            </div>
                                            <div class="form-group">
                                                <asp:Label ID="lblSchService" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlTransactions" runat="server">
                                        <div class="col-md-12">
                                            <asp:Panel ID="pnlTransView" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>UserScheme Transactions</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-12">
                                                                <asp:Button ID="btnAddTransactions" runat="server" Text="Add Transaction" CssClass="btn btn-primary pull-right mrgBottom10" OnClick="btnAddTransactions_Click" />
                                                            </div>
                                                        </div>
                                                        <div class="table-responsive">
                                                            <asp:GridView ID="grdUserSchemeTrans" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                                                EmptyDataText="No Record Found..!" AutoGenerateColumns="false" OnPageIndexChanging="grdUserSchemeTrans_PageIndexChanging" OnRowCommand="grdUserSchemeTrans_RowCommand">
                                                                <Columns>
                                                                    <asp:TemplateField HeaderText="User Type">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("UserTypeMaster.type") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Joining Fees">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("joiningFee") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Admin Fees">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("adminFee") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Membership Fees">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("membershipFee") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Personal Training Pack">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("personalTrainingPack") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField HeaderText="Service Tax">
                                                                        <ItemTemplate>
                                                                            <span><%#Eval("serviceTaxInPercentage") %></span>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                    <asp:TemplateField>
                                                                        <ItemTemplate>
                                                                            <div class="gridActionsIcon">
                                                                                <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditUserSchemeTrans"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteUserSchemeTrans" />
                                                                            </div>
                                                                        </ItemTemplate>
                                                                    </asp:TemplateField>
                                                                </Columns>
                                                            </asp:GridView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlTransEdit" runat="server">
                                                <div class="portlet box blue">
                                                    <div class="portlet-title">
                                                        <div class="caption">
                                                            <label>User Scheme Transactions</label>
                                                        </div>
                                                    </div>
                                                    <div class="portlet-body">
                                                        <div class="row">
                                                            <div class="col-md-6">
                                                                <div class="form-body">
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">UserType</label>
                                                                        <asp:DropDownList ID="ddlUsers" runat="server" CssClass="form-control pnl1text-input customDropdown" onchange="RemoveValidate(this);"></asp:DropDownList>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Joining Fee</label>
                                                                        <asp:TextBox ID="txtJFee" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Admin Fee</label>
                                                                        <asp:TextBox ID="txtAFee" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Membership Fee</label>
                                                                        <asp:TextBox ID="txtMmbrFee" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Personal Traning Fee</label>
                                                                        <asp:TextBox ID="txtPTFee" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">ServiceTax</label>
                                                                        <asp:TextBox ID="txtSTax" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtSTax_TextChanged"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">Total Amount</label>
                                                                        <asp:TextBox ID="txtTAmt" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="true"></asp:TextBox>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                            <div class="clearfix"></div>
                                                            <div class="footerBtns">
                                                                <asp:Button ID="btnSaveUserSchemeDetail" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" Text="Save" OnClick="btnSaveUserSchemeDetail_Click" OnClientClick="return ValidateCustom('pnl1');" />
                                                                <asp:Button ID="btnBack" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Back" OnClick="btnBack_Click" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </asp:Panel>
                                        </div>
                                    </asp:Panel>
                                </div>
                                <div class="clearfix"></div>
                                <div class="footerBtns">
                                    <asp:Button ID="btnDetailBack" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Back" OnClick="btnDetailBack_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
