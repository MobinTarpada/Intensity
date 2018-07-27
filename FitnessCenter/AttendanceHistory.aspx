<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="AttendanceHistory.aspx.cs" Inherits="FitnessCenter.AttendanceHistory" %>

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
                        <h3 class="page-title">Present / Absennt Member's History
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="AttendanceHistory.aspx">Home </a>
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
                                                <asp:DropDownList runat="server" ID="ddlUsr" CssClass="form-control">

                                                    <asp:ListItem Value="1" Selected="True">Member</asp:ListItem>
                                                    <asp:ListItem Value="2">Employee</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <asp:DropDownList runat="server" ID="ddlOptions" CssClass="form-control">
                                                    <asp:ListItem Value="0">Select Option</asp:ListItem>
                                                    <asp:ListItem Value="1">Present Member</asp:ListItem>
                                                    <asp:ListItem Value="2">Absent Member</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchText" runat="server" placeholder="Search.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <asp:TextBox ID="txtFromDate" runat="server" placeholder="FromDate.." CssClass="form-control datePicker pnl1text-input"></asp:TextBox>
                                            </div>

                                            <div class="form-group">
                                                <asp:TextBox ID="txtToDate" runat="server" placeholder="ToDate.." CssClass="form-control datePicker pnl1text-input"></asp:TextBox>
                                            </div>


                                            <div class="col-md-8">
                                                <asp:Button ID="btnFullSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnFullSearch_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                </asp:Panel>
                <asp:Panel ID="pnlPresent" runat="server" Visible="false">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Present Members</label>
                            </div>
                        </div>

                        <div class="portlet-body">

                            <div class="table-responsive">
                                <asp:GridView ID="grdPresentMembers" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination" AllowSorting="true" 
                                    OnPageIndexChanging="grdPresentMembers_PageIndexChanging1" OnSorting="grdPresentMembers_Sorting" 
                                    OnRowCommand="grdPresentMembers_RowCommand" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%# Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="AgreementNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("AgreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="membershipUniqueId">
                                            <ItemTemplate>
                                                <span><%#Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="mobileNumber">
                                            <ItemTemplate>
                                                <span><%# Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Check In Date" SortExpression="lastCheckInDate">
                                            <ItemTemplate>

                                                <%--<span><%# Eval("lastCheckInDate ","{0:dd/MM/yyyy}") %></span>--%>
                                                <span><%# Eval("lastDate ") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetails" runat="server" ToolTip="Details" CommandArgument='<%# Eval("memberId") %>' CommandName="DetailPresent"><i class="fa fa-list"></i></asp:LinkButton>
                                                    

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlPresentById" runat="server" Visible="false">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Present Members History</label>
                            </div>
                        </div>

                        <div class="portlet-body">

                            <div class="table-responsive">
                                <asp:GridView ID="grdPresentById" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdPresentById_PageIndexChanging" OnRowCommand="grdPresentById_RowCommand" OnRowDataBound="grdPresentById_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%# Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="AgreementNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("AgreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="membershipUniqueId">
                                            <ItemTemplate>
                                                <span><%#Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="mobileNumber">
                                            <ItemTemplate>
                                                <span><%# Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Check In Date" SortExpression="lastCheckInDate">
                                            <ItemTemplate>

                                                <%--<span><%# Eval("lastCheckInDate ","{0:dd/MM/yyyy}") %></span>--%>
                                                <span><%# Eval("lastDate ") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">

                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPresent"><i class="fa fa-edit"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <%--<asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetails" runat="server" ToolTip="Details" CommandArgument='<%# Eval("agreementNumber") %>' CommandName="DetailPayment"><i class="fa fa-edit"></i></asp:LinkButton>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>




                <asp:Panel ID="pnlAbsent" runat="server" Visible="false">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Absent Members</label>
                            </div>
                        </div>
                        <asp:Button runat ="server" ID="btnPdf" Text="Convert To PDF" CssClass="btn btn-primary" OnClick="btnPdf_Click" />
                        <asp:Button runat ="server" ID="btnExcel" Text="Convert To EXCEL" CssClass="btn btn-primary" OnClick="btnExcel_Click" />
                        <div class="portlet-body">
                            <div class="table-responsive">
                                <asp:GridView ID="grdAbsentMembers" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination" AllowSorting="true" 
                                    OnPageIndexChanging="grdAbsentMembers_PageIndexChanging" OnRowCommand="grdAbsentMembers_RowCommand" >
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%# Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="AgreementNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("AgreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="membershipUniqueId">
                                            <ItemTemplate>
                                                <span><%#Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="mobileNumber">
                                            <ItemTemplate>
                                                <span><%# Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Check In Date" SortExpression="lastCheckInDate">
                                            <ItemTemplate>
                                                <span><%# Eval("lastDate ") %></span>
                                                <%--<span><%# Eval("lastCheckInDate","{0:dd/MM/yyyy}") %></span>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetails" runat="server" ToolTip="Details" CommandArgument='<%# Eval("memberId") %>' CommandName="DetailAbsent"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnExcel" runat="server" ToolTip="Excel" CommandArgument='<%# Eval("memberId") %>' CommandName="ExcelAbsent"><i class="fa fa-file-text"></i></asp:LinkButton>

                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>


                <asp:Panel ID="pnlAbsentById" runat="server" Visible="false">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Absent Members History</label>
                            </div>
                        </div>

                        <div class="portlet-body">

                            <div class="table-responsive">
                                <asp:GridView ID="grdAbsentbyId" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination" AllowSorting="true" OnPageIndexChanging="grdAbsentbyId_PageIndexChanging" OnRowCommand="grdAbsentbyId_RowCommand" OnRowDataBound="grdAbsentbyId_RowDataBound">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%# Eval("MemberName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement No" SortExpression="AgreementNumber">
                                            <ItemTemplate>
                                                <span><%#Eval("AgreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="membershipUniqueId">
                                            <ItemTemplate>
                                                <span><%#Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile Number" SortExpression="mobileNumber">
                                            <ItemTemplate>
                                                <span><%# Eval("mobileNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Last Check In Date" SortExpression="lastCheckInDate">
                                            <ItemTemplate>

                                                <%--<span><%# Eval("lastCheckInDate ","{0:dd/MM/yyyy}") %></span>--%>
                                                <span><%# Eval("lastDate ") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">

                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditPresent"><i class="fa fa-edit"></i></asp:LinkButton>
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>
                <%-- <asp:Panel ID="pnlDetails" runat="server">
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
                                        </asp:TemplateField>

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

                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditUser"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteUser" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>--%>
            </div>
        </ContentTemplate>
        <Triggers>
            <asp:PostBackTrigger ControlID="btnPdf" />
            
        </Triggers>
    </asp:UpdatePanel>
     <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="UpdatePanel1">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
