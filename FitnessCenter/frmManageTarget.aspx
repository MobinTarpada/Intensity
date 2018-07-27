<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageTarget.aspx.cs" Inherits="FitnessCenter.frmManageTarget" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

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
            SetMenuActive("liManageTargets");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel ID="updtPnlManageTarget" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Target
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmManageTarget.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlTargetHeader" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Target Header</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div>
                                <asp:Button ID="btnAddNewTarget" runat="server" CssClass="btn btn-primary pull-right mrgBottom10" Text="Add New Target" OnClick="btnAddNewTarget_Click" />
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdTargetHeaders" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdTargetHeaders_PageIndexChanging" AllowPaging="true" PageSize="25" PagerStyle-CssClass="CustomPagination"
                                    OnRowCommand="grdTargetHeaders_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="USER NAME">
                                            <ItemTemplate>
                                                <span><%#Eval("FULLNAME") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User TYPE">
                                            <ItemTemplate>
                                                <span><%#Eval("ROLE") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TOTAL TARGET">
                                            <ItemTemplate>
                                                <span><%#Eval("TARGETCNT") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="TARGETACHIEVED">
                                            <ItemTemplate>
                                                <span><%#Eval("TARGETACHIEVED") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("UserId") %>' CommandName="EditTargetHeader"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("UserId") %>' CssClass="dsplNone" CommandName="DeleteTargetHeder" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                        </div>
                </asp:Panel>

                <asp:Panel ID="pnlTargetBody" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>User Targets</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-6" style="padding: 0;">
                                        <div class="form-body" style="padding: 0;">
                                            <div class="form-group">
                                                <asp:DropDownList ID="ddlUser" runat="server" CssClass="form-control  customDropdown" onchange="RemoveValidate(this);" AutoPostBack="True" OnSelectedIndexChanged="ddlRole_SelectedIndexChanged"></asp:DropDownList>
                                                <asp:Label ID="lblMsg" runat="server" CssClass="form-control" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6" style="padding: 0;">
                                        <asp:Button ID="btnBack" runat="server" Text="Back" OnClick="btnBack_Click" CssClass="btn btn-primary pull-right mrgLeft10" />
                                        <asp:Button ID="btnAddTarget" runat="server" Text="Add Target" OnClick="btnAddTarget_Click" CssClass="btn btn-primary pull-right" />
                                        <asp:Button ID="btnContinue" runat="server" ClientIDMode="Static" Style="display: none;" OnClick="btnContinue_Click" />
                                    </div>
                                </div>
                            </div>
                            <asp:Panel ID="pnlView" runat="server">
                                <div class="table-responsive">
                                    <asp:GridView ID="grdTarget" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                        EmptyDataText="No Record Found..!" AutoGenerateColumns="false" OnRowDataBound="grdTarget_RowDataBound"
                                        OnPageIndexChanging="grdTarget_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                        OnSorting="grdTarget_Sorting" AllowSorting="true"
                                        OnRowCommand="grdTarget_RowCommand">
                                        <Columns>
                                            <asp:TemplateField HeaderText="FROM DATE">
                                                <ItemTemplate>
                                                    <span><%#Convert.ToDateTime(Eval("fromDate")).ToString("dd-MMM-yyyy") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="TO DATE">
                                                <ItemTemplate>
                                                    <span><%# Convert.ToDateTime(Eval("toDate")).ToString("dd-MMM-yyyy") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="LEAD TYPE">
                                                <ItemTemplate>
                                                    <asp:HiddenField ID="hdnFldLeadTypeId" runat="server" Value='<%#Eval("leadTypeId") %>' />
                                                    <span><%# Eval("LeadTypeName") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="TARGET">
                                                <ItemTemplate>
                                                    <span><%# Eval("cnt") %></span>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Achieved Target">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAchievedTarget" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField>
                                                <ItemTemplate>
                                                    <div class="gridActionsIcon">
                                                        <%-- <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditTarget"><i class="fa fa-edit"></i></asp:LinkButton>--%>
                                                        <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("leadTypeId") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                        <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("leadTypeId") %>' CssClass="dsplNone" CommandName="DeleteTarget" />
                                                    </div>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                            </asp:Panel>
                            <asp:Panel ID="pnlEdit" runat="server">
                                <div class="portlet box blue">
                                    <div class="portlet-title">
                                        <div class="caption">
                                            <label>User Target</label>
                                        </div>
                                    </div>
                                    <div class="portlet-body">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <h3>User Target Detail</h3>
                                                <div class="form-body">
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">FROM DATE</label>
                                                        <asp:TextBox ID="txtFromDate" runat="server" placeholder="FROM DATE.." CssClass="form-control datePicker pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">TO DATE</label>
                                                        <asp:TextBox ID="txtToDate" runat="server" placeholder="TO DATE.." CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);" AutoPostBack="True" OnTextChanged="txtToDate_TextChanged"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Lead Type</label>
                                                        <asp:DropDownList ID="ddlLead" runat="server" CssClass="form-control pnl1text-input customDropdown"></asp:DropDownList>
                                                        <asp:Label ID="lblErrorMsg" runat="server" CssClass="form-control" ForeColor="Red"></asp:Label>
                                                    </div>

                                                    <div class="form-group">
                                                        <label class="fntWeightBold">TARGET</label>
                                                        <asp:TextBox ID="txtTarget" runat="server" placeholder="TARGET.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>

                                            <div class="clearfix"></div>
                                            <div class="footerBtns">
                                                <%--<asp:LinkButton ID="lnkbtnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click">Save</asp:LinkButton>--%>
                                                <asp:Button ID="btnSave" runat="server"  CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text ="Save"  />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancel_Click" Text="Cancel" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </asp:Panel>
                        </div>
                    </div>
                </asp:Panel>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="updtPnlManageTarget">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
