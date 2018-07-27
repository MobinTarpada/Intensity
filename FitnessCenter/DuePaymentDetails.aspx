<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="DuePaymentDetails.aspx.cs" Inherits="FitnessCenter.DuePaymentDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Balance Due Details / Full Paid Details
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="DuePaymentDetails.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>

                <asp:Panel ID="pnlOptions" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Select Option For Member List </label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:DropDownList runat="server" ID="ddlOptions" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlOptions_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select Option</asp:ListItem>
                                                    <asp:ListItem Value="1">Full Paid Member</asp:ListItem>
                                                    <asp:ListItem Value="2">Balance Due Member</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <%----%>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlFullPaid" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Full Paid Members</label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFullSearch" runat="server" placeholder="Searching.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnFullSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnFullSearch_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdFullPaidMember" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdFullPaidMember_PageIndexChanging" OnRowCommand="grdFullPaidMember_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <span><%# Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="Agree#">
                                            <ItemTemplate>
                                                <span><%#Eval("agreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Package Amount" SortExpression="FinalAmount">
                                            <ItemTemplate>
                                                <span><%#Eval("FinalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Paid" SortExpression="PaidAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("PaidAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Balance Due" SortExpression="RemainingAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("RemainingAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Last Payment">
                                            <ItemTemplate>
                                                <span><%# Eval("PaidAmountDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                         <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetails" runat="server" ToolTip="Details" CommandArgument='<%# Eval("agreementNumber") %>' CommandName="DetailPayment"><i class="fa fa-edit"></i></asp:LinkButton>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlDetails" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Total Dues </label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSrchTxt" runat="server" placeholder="Searching.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-8">
                                        <asp:Button ID="btnSrch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSrch_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdMain" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdMain_PageIndexChanging" OnRowCommand="grdMain_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <span><%# Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="Agree#">
                                            <ItemTemplate>
                                                <span><%#Eval("agreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Package Amount" SortExpression="FinalAmount">
                                            <ItemTemplate>
                                                <span><%#Eval("FinalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Paid" SortExpression="PaidAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("PaidAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Balance Due" SortExpression="RemainingAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("RemainingAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Due Date">
                                            <ItemTemplate>
                                                <span><%# Eval("DueAmountDate","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Last Payment">
                                            <ItemTemplate>
                                                <span><%# Eval("PaidAmountDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>

                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetails" runat="server" ToolTip="Details" CommandArgument='<%# Eval("agreementNumber") %>' CommandName="DetailPayment"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("agreementNumber") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("agreementNumber") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
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
                                    <asp:TextBox ID="txtMsgSMS" runat="server" CssClass="form-control" TextMode="MultiLine" ReadOnly="true" Height="100px"></asp:TextBox>
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
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Part Payment Details </label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="col-md-12">
                                <div class="col-md-4">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:TextBox ID="txtSearchText" runat="server" placeholder="Searching.." CssClass="form-control"></asp:TextBox>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-8">
                                    <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdDuePayment" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdDuePayment_PageIndexChanging">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name">
                                            <ItemTemplate>
                                                <span><%# Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="Agree#">
                                            <ItemTemplate>
                                                <span><%#Eval("agreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Package Amount" SortExpression="FinalAmount">
                                            <ItemTemplate>
                                                <span><%#Eval("finalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Paid" SortExpression="PaidAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("amountPaid") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Balance Due" SortExpression="RemainingAmount">
                                            <ItemTemplate>
                                                <span><%# Eval("remainingAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Due Date">
                                            <ItemTemplate>
                                                <span><%# Eval("DueAmountDate","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Payment">
                                            <ItemTemplate>
                                                <span><%# Eval("PaidAmountDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditUser"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteUser" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
