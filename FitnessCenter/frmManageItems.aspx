<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageItems.aspx.cs" Inherits="FitnessCenter.frmManageGroups" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .addGroup {
            margin-top: -35px;
            margin-right: -110px;
        }
    </style>
    <script type="text/javascript">
        function pageLoad() {
            SetMenuActive("liManageItems");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updtPnlGroups" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Items</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li>
                                <i class="fa fa-home"></i>
                                <a href="frmManageItems.aspx">Home</a>
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
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchName" runat="server" placeholder="Item Name.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-3">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <asp:TextBox ID="txtSearchCode" runat="server" placeholder="Item Code.." CssClass="form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAddItems" runat="server" Text="Add Items" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnAddItems_Click" />
                                        <asp:Button ID="btnAddJuiceItems" runat="server" Text="Add Juice Items" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnAddJuiceItems_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdItems" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="False"
                                    AllowPaging="True" PagerStyle-CssClass="CustomPagination"
                                    AllowSorting="True" OnPageIndexChanging="grdItems_PageIndexChanging" OnRowCommand="grdItems_RowCommand" OnSorting="grdItems_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Name" SortExpression="ITEMNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("name") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Code" SortExpression="CODE">
                                            <ItemTemplate>
                                                <span><%#Eval("code") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="GroupName">
                                            <ItemTemplate>
                                                <span><%#Eval("GroupName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="MRP">
                                            <ItemTemplate>
                                                <span><%#Eval("mrp") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Inventory">
                                            <ItemTemplate>
                                                <span><%#Eval("Inventory") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actions">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditItem"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteItem" />
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
                                <label>Item Details</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item Name</label>
                                            <asp:TextBox ID="txtName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Item Name.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item Code</label>
                                            <asp:TextBox ID="txtCode" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Item Code.."></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold" runat="server" id="grp">Item Group</label>
                                            <asp:DropDownList ID="drpGroups" runat="server" CssClass="form-control"></asp:DropDownList>
                                            <asp:Button ID="btnAddGroup" runat="server" Text="Add Group" CssClass="btn btn-primary pull-right addGroup" OnClick="btnAddGroup_Click" />
                                        </div>
                                    </div>
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item MRP</label>
                                            <asp:TextBox ID="txtMrp" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Item MRP.."></asp:TextBox>
                                        </div>
                                    </div>
                                     <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">Item QTY</label>
                                            <asp:TextBox ID="txtQty" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" placeholder="Item MRP.."></asp:TextBox>
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

                <asp:Panel ID="pnlGroup" runat="server">
                    <div id='CustomModalPopup1'>
                        <div id='masteroverlay1' class='web_dialog_overlay hide'></div>
                        <div id='MsgBoxModal1' class='wdoMain hide' tabindex='-1' role='dialog' aria-labelledby='myModalLabel' aria-hidden='true'>
                            <div class='wdoHeader'>
                                <button type='button' class='close' data-dismiss='modalGG' aria-hidden='true' onclick='$(\"#MsgBoxModal1\").addClass(\"hide\");$(\"#masteroverlay1\").addClass(\"hide\");$(\"#MsgBoxModal1\").fadeOut(300);$(\"#CustomModalPopup1\").remove();return false;'>x</button>
                                <span>Add Groups</span>
                            </div>
                            <div class='modal-body'>
                                <p>
                                    <label class='fntWeightBold'>Group Code</label>
                                    <asp:TextBox ID="txtGrpCode" runat="server" CssClass="form-control"></asp:TextBox>
                                    <label class='fntWeightBold'>Group Name</label>
                                    <asp:TextBox ID="txtGrpName" runat="server" CssClass="form-control"></asp:TextBox>
                                </p>
                            </div>
                            <div class='wdoFooter' align='center'>
                                <input type='button' id="btnNext" value='OK' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal1').fadeOut(300); $('#btnNext').next().click(); $('#CustomModalPopup1').remove(); return true;" class='delete-popup-button btn btn-primary modalbtn mrgLeft10 pull-left' />
                                <asp:Button ID="btnInsertGroup" runat="server" Text="Save" CssClass="dsplNone" OnClick="btnInsertGroup_Click" />
                                <input type='button' value='Cancel' class='btn btn-warning modalbtn mrgLeft10 login pull-left' onclick="$('#ConfirmationModal').addClass('hide'); $('#masteroverlay1').addClass('hide'); $('#ConfirmationModal').fadeOut(300); $('#CustomModalPopup1').remove(); return false;" />
                            </div>
                        </div>
                    </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="updtPnlGroups">
        <ProgressTemplate>
            <div class="ajax-loading">
                <div></div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
