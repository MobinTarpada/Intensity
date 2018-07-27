<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageUsers.aspx.cs" Inherits="FitnessCenter.frmManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //function PageLoad() {
        //    SetMenuActive("liManageUsers");
        //}
        $(document).ready(function () {
            SetMenuActive("liManageUsers");

        });

        function ShowPasswordEntered() {
            var passString = document.GetUserByID("txtPassword").value;
            alert(passString);
        }
    </script>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlManageUsers" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Users
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="/frmManageUsers.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>User</label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchText" runat="server" placeholder="Searching.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary mrgLeft5 mrgTop10" />
                                        <asp:Button ID="btnAddLead" runat="server" Text="Add User" OnClick="btnAddUser_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdUsers" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdUsers_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdUsers_Sorting" AllowSorting="true"
                                    OnRowCommand="grdUsers_RowCommand">
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
                                        <asp:TemplateField HeaderText="USER NAME" SortExpression="USERNAME">
                                            <ItemTemplate>
                                                <span><%# Eval("userName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EMAIL" SortExpression="EMAIL">
                                            <ItemTemplate>
                                                <span><%# Eval("email") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="USER TYPE">
                                            <ItemTemplate>
                                                <span><%# Eval("UserTypeMaster.type") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <span><%#Convert.ToBoolean(Eval("isActive")) == true ? "Active" : "InActive"  %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditUser"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteUser" />
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
                                            <asp:TextBox ID="txtUsername" runat="server" placeholder="User Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
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
                                <%--<div class="col-md-6">
                                    <div class="form-body">
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <div>--%>
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
               </asp:Panel>
                         </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
