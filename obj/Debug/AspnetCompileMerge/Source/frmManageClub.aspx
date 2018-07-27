<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageClub.aspx.cs" Inherits="FitnessCenter.frmManageClub" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            SetMenuActive("liManageClubs");
        });
        function ShowPasswordEntered() {
            var passString = document.GetUserByID("txtPassword").value;
            alert(passString);
        }</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="UpdtPnlManageClub" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Club
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmManageClub.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Club</label>
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
                                        <asp:Button ID="btnAddClub" runat="server" Text="Add Club" OnClick="btnAddClub_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdClubs" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdClubs_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdClubs_Sorting" AllowSorting="true"
                                    OnRowCommand="grdClubs_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="CLUB NAME" SortExpression="CLUBNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("clubName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CLUB ADMIN FIRST NAME" SortExpression="FIRSTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CLUB ADMIN LAST NAME" SortExpression="LASTNAME">
                                            <ItemTemplate>
                                                <span><%# Eval("lastName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                                <span><%# Eval ("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Address" SortExpression="Address">
                                            <ItemTemplate>
                                                <span><%#Eval ("address") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EMAIL" SortExpression="EMAIL">
                                            <ItemTemplate>
                                                <span><%# Eval("email") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                            <ItemTemplate>
                                               <span><%#Convert.ToBoolean(Eval("isActive")) == true ? "Active" : "InActive"  %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("UserId") %>' CommandName="EditClub"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("UserId") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteClub" />
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
                                <label>Club</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Club Detail</h3>
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-6">

                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">ClubName</label>
                                                <asp:TextBox ID="txtClubName" runat="server" placeholder="Club Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">First Name</label>
                                                <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Last Name</label>
                                                <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div>
                                                <label class="fntWeightBold">MobileNumber</label>
                                                <asp:TextBox ID="txtMobileNumber" runat="server" placeholder="Mobile Number....." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Email</label>
                                                <asp:TextBox ID="txtEmail" runat="server" placeholder="Email.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">UserName</label>
                                                <asp:TextBox ID="txtUserName" runat="server" placeholder="User Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Password</label>
                                                <asp:TextBox ID="txtPassword" runat="server" placeholder="Password.." CssClass="form-control pnl1text-input" TextMode="Password" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div>
                                                <label class="fntWeightBold">Address</label>
                                                <asp:TextBox ID="txtAdress" runat="server" placeholder="Address....." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Status</label>
                                                <asp:CheckBox ID="chkIsActive" runat="server" />
                                            </div>
                                        </div>
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
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="updtPnlManageClub">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
