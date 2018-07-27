<%@ Page Title="" Language="C#" Debug="true" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmCareer.aspx.cs" Inherits="FitnessCenter.frmCareer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            SetMenuActive("liCareer");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Career</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmCareer.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>

                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>About Us</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAdd_Click" />
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdCareer" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdCareer_PageIndexChanging" OnRowCommand="grdCareer_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Position">
                                            <ItemTemplate>
                                                <span><%#Eval("positionName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCareer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCareer" />
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
                                <label>Career Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Position Name</label>
                                            <asp:TextBox ID="txtName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Name.."></asp:TextBox>
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
</asp:Content>
