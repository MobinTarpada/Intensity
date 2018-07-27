<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageComplain.aspx.cs" Inherits="FitnessCenter.frmManageComplain" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:UpdatePanel ID="UpdtPnlManageComplain" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Complain
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
                                <label>Complain</label>
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
                                        <asp:Button ID="btnAddComplain" runat="server" Text="Add Complain" OnClick="btnAddComplain_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdComplain" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="true" OnRowCommand="grdComplain_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member NAME">
                                            <ItemTemplate>
                                                <span><%#Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Complain Code">
                                            <ItemTemplate>
                                                <span><%#Eval("ComplainCode") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Complain">
                                            <ItemTemplate>
                                                <span><%# Eval("ComplainMessage") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Feedback">
                                            <ItemTemplate>
                                                <span><%# Eval ("Feedback") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status">
                                            <ItemTemplate>
                                                <span><%#Eval ("Status") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditComplain"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <%--<asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("UserId") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteClub" />--%>
                                                    <asp:LinkButton ID="lnkBtnFeedback" runat="server" ToolTip="Feedback" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Feedback','Are you sure you want to Feedback this record?',this.id);return false;"><i class="fa fa-comments"></i></asp:LinkButton>
                                                    <asp:Button ID="btnFeedback" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="Feedback" />
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
                                <span>Write Feedback</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Status</label>
                                    <asp:DropDownList ID="ddlStatus" runat="server" CssClass="form-control">
                                        <asp:ListItem Value="1">Pending</asp:ListItem>
                                        <asp:ListItem Value="2">Complete</asp:ListItem>
                                    </asp:DropDownList>
                                    <asp:TextBox runat="server" CssClass="form-control pnl1text-input" ID="txtFeedback"> </asp:TextBox>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNext" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#btnNext').next().click(); $('#CustomModalPopup1').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnFeedback" runat="server" Text="Save" CssClass="dsplNone" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnFeedback_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlEdit" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Complain</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Complain Detail</h3>
                                </div>
                                <div class="col-md-12">
                                    <div class="col-md-6">

                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Put Your Card Here</label>
                                                <asp:TextBox ID="txtRfidCard" OnTextChanged="txtRfidCard_TextChanged" runat="server" CssClass="form-control pnl1text-input" AutoPostBack="True"></asp:TextBox>
                                            </div>

                                        </div>
                                    </div>

                                </div>
                                <asp:Panel runat="server" ID="pnlMsg" Visible="false">
                                    <div class="col-md-12">
                                        <div class="col-md-6">

                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Complain Code</label>
                                                    <asp:TextBox ID="txtComplainCode" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Complain Message</label>
                                                    <asp:TextBox ID="txtComplainMsg" runat="server" placeholder="ComplainMessage.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>

                                            </div>
                                        </div>

                                        <div class="clearfix"></div>
                                        <div class="footerBtns">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text="Save" />
                                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancel_Click" Text="Cancel" />
                                        </div>
                                    </div>
                                </asp:Panel>

                            </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="UpdtPnlManageComplain">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
