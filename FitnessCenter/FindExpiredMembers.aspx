<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="FindExpiredMembers.aspx.cs" Inherits="FitnessCenter.FindExpiredMembers" %>

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

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Expired Member's History
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="FindExpiredMembers.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>

                <asp:Panel ID="pnlOptions" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Enter Details For Find Expired Members </label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchText" runat="server" placeholder="Search Text...." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFromDate" runat="server" placeholder="FromDate.." CssClass="form-control datePicker pnl1text-input"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox ID="txtToDate" runat="server" placeholder="ToDate.." CssClass="form-control datePicker pnl1text-input"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Package</label>
                                                <asp:DropDownList ID="ddlSrchPkg" AutoPostBack="true" runat="server" CssClass="form-control pnl1text-input" OnSelectedIndexChanged="ddlSrchPkg_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Scheme</label>
                                                <asp:DropDownList ID="ddlSrchScheme" runat="server" CssClass="form-control pnl1text-input"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Gender</label>
                                                <asp:DropDownList ID="ddlGender" runat="server" CssClass="form-control pnl1text-input">
                                                    <asp:ListItem>Select Gender</asp:ListItem>
                                                    <asp:ListItem>Male</asp:ListItem>
                                                    <asp:ListItem>Female</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox ID="txtSrchAddress" runat="server" placeholder="Address.." CssClass="form-control"></asp:TextBox>
                                            </div>

                                            <div class="col-md-8">
                                                <asp:Button ID="btnFullSearch" runat="server" Text="Search" OnClientClick="return ValidateCustom('pnl1');" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnFullSearch_Click" />
                                            </div>
                                        </div>
                            </div>
                        </div>
                    </div>
                    </div>
                </asp:Panel>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Expired Members</label>
                            </div>
                        </div>

                        <div class="portlet-body">

                            <div class="table-responsive">
                                <asp:GridView ID="grdExpiredMembers" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="20" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdExpiredMembers_PageIndexChanging" OnSorting="grdExpiredMembers_Sorting" OnRowCommand="grdExpiredMembers_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%# Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="MobileNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Gender" SortExpression="Gender">
                                            <ItemTemplate>
                                                <span><%#Eval("gender") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="MembershipNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Package Name" SortExpression="packageName">
                                            <ItemTemplate>
                                                <span><%# Eval("packageName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Scheme Name" SortExpression="schemeName">
                                            <ItemTemplate>
                                                <span><%# Eval("schemeName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Activation Date" SortExpression="activationDate">
                                            <ItemTemplate>
                                                <span><%# Eval("activationDate","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Expiry Date" SortExpression="expiryDate">
                                            <ItemTemplate>
                                                <span><%# Eval("expiryDate","{0:dd/MM/yyyy}") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
