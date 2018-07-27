<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="FindReferralsMember.aspx.cs" Inherits="FitnessCenter.FindReferralsMember" %>

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

    <asp:UpdatePanel ID="updtPnlPckgnScm" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Referrals Member Report</h3>
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
                                <label>Referrels Members</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">

                                    <div class="col-md-2" style="padding: 0px;">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Members</label>
                                                <asp:DropDownList ID="ddlSrchMember" runat="server" CssClass="form-control pnl1text-input" OnSelectedIndexChanged="ddlSrchMember_SelectedIndexChanged" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>


                                    <%-- <div class="col-md-2" style="padding: 0px; margin: 28px">

                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnSearch_Click" />
                                    </div>--%>
                                    <div class="col-md-2" style="padding: 0px; margin: 28px">

                                        <asp:Button ID="btnPrint" runat="server" Text="Print" CssClass="btn btn-primary pull-right mrgTop10" OnClientClick="PrintGridData();" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel runat="server" ID="pnlGrd">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdFindReferrals" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                        AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                        AllowSorting="True" PageSize="100">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Member Name">
                                                <ItemTemplate>
                                                    <span><%#Eval("firstName")%> <%#Eval("lastName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile Number">
                                                <ItemTemplate>
                                                    <span><%# Eval("mobilenumber") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email">
                                                <ItemTemplate>
                                                    <span><%#Eval("Email") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Lead Date">
                                                <ItemTemplate>
                                                    <span><%# Eval("insertDate","{0:dd/MM/yyyy}") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
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
            var printContent = document.getElementById('<%= pnlGrd.ClientID %>');
            var printWindow = window.open("", "Print Panel", 'left=50000,top=50000,width=0,height=0');
            printWindow.document.write(printContent.innerHTML);
            printWindow.document.close();
            printWindow.focus();
            printWindow.print();
            printWindow.close();
        }
        function PrintGridData() {
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
