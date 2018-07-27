<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="PackageNSchemeAnalysis.aspx.cs" Inherits="FitnessCenter.PackageNSchemeAnalysis" %>

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

    <asp:UpdatePanel ID="updtPnlPckgnScm" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Package And Scheme Analysis</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmManageCustomers.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel runat="server" ID="pnlView">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Members</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div id="option" class="col-md-8" style=" padding: 5px;">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Select Type</label>
                                            <asp:RadioButtonList CssClass="form-control" ID="rdoType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="rdoType_SelectedIndexChanged" RepeatDirection="Horizontal">
                                                <asp:ListItem Value="1" >Upgrade&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="2">Downgrade&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="3">Cancelation&nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                                <asp:ListItem Value="4">Freeze</asp:ListItem>
                                            </asp:RadioButtonList>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-12">

                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Package</label>
                                                <asp:DropDownList ID="ddlSrchPkg" AutoPostBack="true" runat="server" CssClass="form-control pnl1text-input" OnSelectedIndexChanged="ddlSrchPkg_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-4" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Scheme</label>
                                                <asp:DropDownList ID="ddlSrchScheme" runat="server" CssClass="form-control pnl1text-input"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>


                                    <div class="col-md-2" style="padding: 0px; margin: 28px">

                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnSearch_Click" />
                                    </div>
                                    <div class="col-md-2" style="padding: 0px; margin: 28px">

                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary pull-right mrgTop10" OnClientClick="PrintGridData();" />
                                    </div>
                                </div>
                            </div>
                            <div>
                                <asp:Label ID="lblMsg" CssClass="fntWeightBold" runat="server"></asp:Label>
                            </div>
                            <div class="clearfix"></div>
                            <asp:Panel Visible="true" runat="server" ID="pnlGrd">
                                <div class="table-responsive">

                                    <asp:GridView ID="grdPkgNScmReport" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                        AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                        AllowSorting="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MemberName">
                                                <ItemTemplate>
                                                    <span><%# Eval("MemberName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Package Name" SortExpression="packageName">
                                                <ItemTemplate>
                                                    <span><%#Eval("packageName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Scheme Name" SortExpression="schemeName">
                                                <ItemTemplate>
                                                    <span><%#Eval("schemeName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCustomer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCustomer" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <asp:Panel Visible="false" runat="server" ID="pnldownGrd">
                                <div class="table-responsive">
                                    <div>


                                        <div class="clearfix"></div>
                                    </div>
                                    <asp:GridView ID="grdDownGrd" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                        AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                        AllowSorting="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MemberName">
                                                <ItemTemplate>
                                                    <span><%# Eval("MemberName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Package Name" SortExpression="packageName">
                                                <ItemTemplate>
                                                    <span><%#Eval("packageName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Scheme Name" SortExpression="schemeName">
                                                <ItemTemplate>
                                                    <span><%#Eval("schemeName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCustomer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCustomer" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                            <asp:Panel Visible="false" runat="server" ID="pnlCancel">
                                <div class="table-responsive">
                                    <div>


                                        <div class="clearfix"></div>
                                    </div>
                                    <asp:GridView ID="grdCancel" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                        AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                        AllowSorting="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MemberName">
                                                <ItemTemplate>
                                                    <span><%# Eval("MemberName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Package Name" SortExpression="packageName">
                                                <ItemTemplate>
                                                    <span><%#Eval("packageName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Scheme Name" SortExpression="schemeName">
                                                <ItemTemplate>
                                                    <span><%#Eval("schemeName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCustomer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCustomer" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>

                             <asp:Panel Visible="false" runat="server" ID="pnlFreeze">
                                <div class="table-responsive">
                                    <div>


                                        <div class="clearfix"></div>
                                    </div>
                                    <asp:GridView ID="grdFreeze" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                        AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                        AllowSorting="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="MemberName">
                                                <ItemTemplate>
                                                    <span><%# Eval("MemberName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Package Name" SortExpression="packageName">
                                                <ItemTemplate>
                                                    <span><%#Eval("packageName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Scheme Name" SortExpression="schemeName">
                                                <ItemTemplate>
                                                    <span><%#Eval("schemeName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Date">
                                                <ItemTemplate>
                                                    <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <%--<asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditCustomer"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailCustomer"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteCustomer" />
                                                    <asp:LinkButton ID="lnkBtnSMS" runat="server" ToolTip="Email" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('SMS','Are you sure you want to SMS this record?',this.id);return false;"><i class="fa fa-comment-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnSMS" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="SMSLead" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <script>
        function CallPrint() {
            $('#btnSearch').hide();
            $('#btnPrint').hide();
            document.getElementById('option').style = "display:none";
            var printContent = document.getElementById('<%= pnlGrd.ClientID %>');
            var printWindow = window.open("", "Print Panel", 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
        function PrintGridData() {
            $('#btnSearch').hide();
            $('#btnPrint').hide();
            document.getElementById('option').style = "display:none";
            window.print('grdPkgNScmReport');
           <%-- var prtGrid = document.getElementById('<%=grdPkgNScmReport.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1900,height=1300,tollbar=10,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);--%>
            //prtwin.document.close();
            //prtwin.focus();
            //prtwin.print();
            //prtwin.close();
        }
    </script>

    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlPckgnScm">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>

</asp:Content>
