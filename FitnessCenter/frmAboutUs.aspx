<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmAboutUs.aspx.cs" Inherits="FitnessCenter.frmAboutUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <%--<script src="assets/scripts/HtmlEditorExtender.js"></script>--%>
    <style>
        .myDiv {
            visibility: hidden;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            //$('.ajax__html_editor_extender_popupDiv').removeAttr('style');
            //$('.ajax__html_editor_extender_popupDiv').addClass('myDiv');
            $('.ajax__html_editor_extender_popupDiv').css('visibility', 'hidden');
            SetMenuActive("liAboutUs");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="updtPnlAboutUs" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">About Us</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmAboutUs.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>

                <asp:Panel runat="server" ID="pnlView">
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
                                <asp:GridView ID="grdAbout" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdAbout_PageIndexChanging" OnRowCommand="grdAbout_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Heading">
                                            <ItemTemplate>
                                                <span><%#Eval("Heading") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditAbout"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>--%>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteAbout" />
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
                    <div class="portlet box blue" style="height: 600px;">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>About Us Details</label>
                            </div>
                        </div>
                        <div class="portlet-body" style="height: 550px;">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Heading</label>
                                            <asp:TextBox ID="txtHeading" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Heading.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Description</label>
                                            <asp:TextBox ID="txtDescp" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" TextMode="MultiLine" Rows="10" Columns="50"></asp:TextBox>
                                            <ajaxToolkit:HtmlEditorExtender ID="txtDescp_HtmlEditorExtender" runat="server" BehaviorID="txtDescp_HtmlEditorExtender" TargetControlID="txtDescp">
                                                <Toolbar>
                                                    <ajaxToolkit:BackgroundColorSelector />
                                                    <ajaxToolkit:Bold />
                                                    <ajaxToolkit:CleanWord />
                                                    <ajaxToolkit:CreateLink />
                                                    <ajaxToolkit:FontNameSelector />
                                                    <ajaxToolkit:FontSizeSelector />
                                                    <ajaxToolkit:ForeColorSelector />
                                                    <ajaxToolkit:Indent />
                                                    <ajaxToolkit:InsertOrderedList />
                                                    <ajaxToolkit:InsertUnorderedList />
                                                    <ajaxToolkit:Italic />
                                                    <ajaxToolkit:JustifyCenter />
                                                    <ajaxToolkit:JustifyLeft />
                                                    <ajaxToolkit:JustifyFull />
                                                    <ajaxToolkit:JustifyRight />
                                                    <ajaxToolkit:Outdent />
                                                    <ajaxToolkit:Underline />
                                                </Toolbar>
                                            </ajaxToolkit:HtmlEditorExtender>
                                        </div>
                                    </div>
                                    <%--<div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Image</label>
                                            <asp:FileUpload ID="fileUpldImg" runat="server" />
                                            <asp:Image ID="abtUsImg" runat="server" Height="100%" Width="100%" />
                                        </div>
                                    </div>--%>
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlAboutUs">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
