<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmProductSales.aspx.cs" Inherits="FitnessCenter.frmProductSales" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            SetMenuActive("liProductSales");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlSales" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Product Sales</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmProductSales.aspx">Home</a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Sales</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchName" runat="server" placeholder="Member Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchRfid" runat="server" placeholder="RFID Number.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnSalesItems" runat="server" Text="Sales Items" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnSalesItems_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdSales" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdSales_PageIndexChanging" OnRowCommand="grdSales_RowCommand" OnSorting="grdSales_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="FULLNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("FullName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("totalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Amount Paid">
                                            <ItemTemplate>
                                                <span><%#Eval("isPaid") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("memberId") %>' CommandName="DetailSales"><i class="fa fa-file"></i></asp:LinkButton>
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
                                <label>Sales Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Scan RFID Number</label>
                                            <asp:TextBox ID="txtRfid" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtRfid_TextChanged"></asp:TextBox>
                                        </div>
                                    </div>
                                    <asp:Panel runat="server" ID="pnlMember">
                                        <div class="col-md-12">
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Member Name</label>
                                                    <asp:TextBox ID="txtMemName" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Contact No</label>
                                                    <asp:TextBox ID="txtMemCnt" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Date of Birth</label>
                                                    <asp:TextBox ID="txtMemDOB" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Select Item</label>
                                            <asp:DropDownList ID="drpItems" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpItems_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item MRP</label>
                                            <asp:TextBox ID="txtMRP" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" placeholder="Item MRP.." ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item Quantity</label>
                                            <asp:TextBox ID="txtQty" runat="server" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" placeholder="Item Quantity.." ReadOnly="True"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <asp:Button ID="btnAddItem" runat="server" Text="Add Item" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnAddItem_Click" />
                                            <asp:Button ID="btnFinish" runat="server" Text="Finish" CssClass="btn btn-primary mrgTop10" OnClick="btnFinish_Click" />
                                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="btn pull-right mrgTop10" OnClick="btnCancel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdTempSales" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnRowCommand="grdTempSales_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Item Name">
                                            <ItemTemplate>
                                                <span><%#Eval("ItemMaster.name") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <span><%#Eval("quantity") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("amount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("totalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("itemId") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("itemId") %>' CssClass="dsplNone" CommandName="DeleteItem" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="form-body">
                                <div class="form-group">
                                    <asp:Label ID="lblTotal" runat="server" Text="" CssClass="fntWeightBold"></asp:Label>
                                </div>
                            </div>
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">Discount in %</label>
                                    <asp:TextBox ID="txtDis" runat="server" CssClass="form-control" AutoPostBack="True" OnTextChanged="txtDis_TextChanged"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">Final Amount</label>
                                    <asp:TextBox ID="txtFinalAmt" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlDetails" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Member Sales Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:Label ID="lblMemberName" runat="server" Text="" CssClass="fntWeightBold"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnBack" runat="server" Text="Back" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnBack_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdDetails" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Date">
                                            <ItemTemplate>
                                                <span><%#Eval("insertDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Item Name">
                                            <ItemTemplate>
                                                <span><%#Eval("ItemMaster.name") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Quantity">
                                            <ItemTemplate>
                                                <span><%#Eval("quantity") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("amount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Amount">
                                            <ItemTemplate>
                                                <span><%#Eval("totalAmount") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlSales">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
