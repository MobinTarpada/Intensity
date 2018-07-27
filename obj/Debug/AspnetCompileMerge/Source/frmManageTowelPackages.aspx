<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageTowelPackages.aspx.cs" Inherits="FitnessCenter.frmManageTowelPackages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function pageLoad() {
            SetMenuActive("liTowelPackages");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlTowel" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Towel Packages</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmManageTowelPackages.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Towel Packages</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearch" runat="server" placeholder="PackageName.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAddPackage" runat="server" Text="Add Package" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAddPackage_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdPackages" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdPackages_PageIndexChanging" OnRowCommand="grdPackages_RowCommand" OnSorting="grdPackages_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Package Name" SortExpression="PACKAGENAME">
                                            <ItemTemplate>
                                                <span><%#Eval("packageName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Fees">
                                            <ItemTemplate>
                                                <span><%#Eval("amount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Valid Days">
                                            <ItemTemplate>
                                                <span><%#Eval("numberOfDays") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Hiring Time">
                                            <ItemTemplate>
                                                <span><%#Eval("hiringTime") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPackage"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeletePackage" />
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
                                <label>Package Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Deposit Amount</label>
                                            <asp:TextBox ID="txtDepositAmt" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Deposit Amount..."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Package Name</label>
                                            <asp:TextBox ID="txtPackageName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Package Name..."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Fees</label>
                                            <asp:TextBox ID="txtFees" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Fees..."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Days</label>
                                            <asp:TextBox ID="txtDays" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="No of Days..."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Hiring Time</label>
                                            <asp:TextBox ID="txtHiringTime" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Hiring Time..."></asp:TextBox>
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
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlTowel">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
