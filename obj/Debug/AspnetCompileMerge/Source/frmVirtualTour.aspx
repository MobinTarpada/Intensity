<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmVirtualTour.aspx.cs" Inherits="FitnessCenter.frmVirtualTour" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:UpdatePanel ID="updtPnlVirtual" runat="server">
        <ContentTemplate>--%>
    <div class="page-content">
        <div class="row">
            <div class="col-md-12">
                <h3 class="page-title">Virtual Tour</h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li>
                        <i class="fa fa-home"></i>
                        <a href="frmVirtualTour.aspx">Home</a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                </ul>
            </div>
        </div>

        <asp:Panel ID="pnlView" runat="server">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <label>Items</label>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:Button ID="btnAdd" runat="server" Text="Add New" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAdd_Click" />
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="grdVirtual" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                            EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                            AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                            AllowSorting="True" OnPageIndexChanging="grdVirtual_PageIndexChanging" OnRowCommand="grdVirtual_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <span><%#Eval("name") %></span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video">
                                    <ItemTemplate>
                                        <span>
                                            <video id="video" runat="server" src='<%#Eval("path") %>' width="200" height="200" controls></video>
                                        </span>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ACTION">
                                    <ItemTemplate>
                                        <div class="gridActionsIcon">
                                            <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditVideo"><i class="fa fa-edit"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                            <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteVideo" />
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
                        <label>Virtual Tour Details</label>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">Name</label>
                                    <asp:TextBox ID="txtName" CssClass="form-control" onchange="RemoveValidate(this);" runat="server" placeholder="Name.."></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">Video</label>
                                    <video id="editVideo" runat="server" width="420" height="315" controls></video>
                                </div>
                            </div>
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">Select Video</label>
                                    <asp:FileUpload ID="fileUpldVideo" runat="server" />
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
    <%-- </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlVirtual">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>--%>
</asp:Content>
