<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="StaffActivity.aspx.cs" Inherits="FitnessCenter.StaffActivity" %>
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

     <asp:UpdatePanel ID="updtPnlManageStaff" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Staff Activity
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="StaffActivity.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Staff Activity</label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFromDate" runat="server" placeholder="FromDate.." CssClass="form-control datePicker"></asp:TextBox>
                                            </div>
                                             <div class="form-group">
                                                <asp:TextBox ID="txtToDate" runat="server" placeholder="ToDate.." CssClass="form-control datePicker"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                 <asp:DropDownList ID="ddlUsers" AutoPostBack="true" OnSelectedIndexChanged="ddlUsers_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                 <asp:DropDownList ID="ddlStatus" AutoPostBack="true" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />

                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:Label ID="count" runat="server"></asp:Label>
                                <asp:GridView ID="grdStaffActivity" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                     AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                     AllowSorting="true" OnPageIndexChanging="grdStaffActivity_PageIndexChanging" OnSorting="grdStaffActivity_Sorting">
                                    <Columns>
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
                                        <asp:TemplateField HeaderText="MOBILE NUMBER" SortExpression="MOBILENU">
                                            <ItemTemplate>
                                                <span><%# Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="USER NAME" SortExpression="USERNAME">
                                            <ItemTemplate>
                                                <span><%# Eval("userName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LeadStatus">
                                            <ItemTemplate>
                                                 <span><%# Eval("status") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      <%--  <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="grdStaffActivity">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditActivity"><i class="fa fa-edit"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%--<asp:Panel ID="pnlEdit" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>User</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">First Name</label>
                                            <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Last Name</label>
                                            <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Role</label>
                                            <asp:DropDownList ID="ddlRole" runat="server" CssClass="form-control pnl1text-input customDropdown" onchange="RemoveValidate(this);" AutoPostBack="True"></asp:DropDownList>
                                            <asp:Label ID="msg" runat="server" ForeColor="Red" CssClass="fntWeightBold"></asp:Label>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Mobile Number</label>
                                            <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="Mobile Number..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Username</label>
                                            <asp:TextBox ID="txtUsername" runat="server" placeholder="User Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                        </div>
                                        <div>
                                            <label class="fntWeightBold">PassWord</label>
                                            <asp:TextBox ID="txtPassword" runat="server" Placeholder="Password.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" TextMode="Password" AutoPostBack="True"></asp:TextBox>
                                        </div>

                                        <div class="form-group">
                                            <label class="fntWeightBold">Email</label>
                                            <asp:TextBox ID="txtEmail" runat="server" placeholder="Email.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Address</label>
                                            <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" placeholder="Address..." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                        </div>
                                        <div class="form-group">
                                            <label class="fntWeightBold">Status</label>
                                            <asp:CheckBox ID="chkIsActive" runat="server" />

                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-body">
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div>
                                <h3>Permissions</h3>
                            </div>
                            <div class="col-md-12">
                                <asp:GridView ID="grdManagePermissions" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false">
                                    <Columns>

                                        <asp:TemplateField HeaderText="PAGE NAME">
                                            <ItemTemplate>
                                                <span><%#Eval("pageName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="PERMISSION">
                                            <ItemTemplate>
                                                <asp:HiddenField ID="hdnFldPageId" runat="server" Value='<%#Eval("ID") %>' />
                                                <asp:CheckBox ID="chkPermissions" runat="server" AutoPostBack="true" OnCheckedChanged="chkPermissions_CheckedChanged" Checked='<%#Eval("isPermission").ToString() == "TRUE" ? true : false %>' />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                                <asp:CheckBox Text="SelectAll" ID="chkboxSelectAll" runat="server" AutoPostBack="true" OnCheckedChanged="chkboxSelectAll_CheckedChanged" />
                                            </HeaderTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>

                            <div class="clearfix"></div>
                            <div class="footerBtns">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text="Save" />
                                <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancel_Click" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>--%>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
