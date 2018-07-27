<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmManageExercise.aspx.cs" Inherits="FitnessCenter.frmManageExercise" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            SetMenuActive("liManageExercise");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdtPnlManageClub" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Manage Exercise
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmManageExercise.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Exercises</label>
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
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnSearch_Click" />
                                        <asp:Button ID="btnAddExercise" runat="server" Text="Add Exercise" OnClick="btnAddExercise_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdExercise" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdExercise_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    OnRowCommand="grdExercise_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="EXERCISE NAME">
                                            <ItemTemplate>
                                                <span><%#Eval("exerciseName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EXERCISE TYPE">
                                            <ItemTemplate>
                                                <span><%# Convert.ToString(Eval("exerciseTypeId")) == "1" ? "Arobic Exercise" : "Non-Arobic Exercise" %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="BODY TYPE">
                                            <ItemTemplate>
                                                <span><%# Convert.ToString(Eval("bodyTypeId")) == "1" ? "Ectomorph" : Convert.ToString(Eval("bodyTypeId")) == "2" ? "Endomorph" : "Mesomorph"%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="is PersonalTrainingPack Allow" SortExpression="PTP">
                                            <ItemTemplate>
                                                <span><%# Eval ("isPersonalTrainingPackAllow") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditExercise"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteExercise" />
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
                                <label>Exercise</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <h3>Exercise Detail</h3>
                                </div>

                                <div class="col-md-12">
                                    <div class="col-md-6">
                                        <div class="form-body">
                                            <div class="form-group">
                                                <label class="fntWeightBold">ExerciseName</label>
                                                <asp:TextBox ID="txtExerciseName" runat="server" placeholder="Exercise Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                            </div>
                                            <div>
                                                <label class="fntWeightBold">Body Type</label>
                                                <asp:DropDownList ID="ddlBodyType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="1">Ectomorph</asp:ListItem>
                                                    <asp:ListItem Value="2">Endomorph</asp:ListItem>
                                                    <asp:ListItem Value="3">Mesomorph</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div>
                                                <label class="fntWeightBold">Exercise Type</label>
                                                <asp:DropDownList ID="ddlExerciseType" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlExerciseType_SelectedIndexChanged">
                                                    <asp:ListItem Value="0">Select ExerciseType</asp:ListItem>
                                                    <asp:ListItem Value="1">Arobic Exercise</asp:ListItem>
                                                    <asp:ListItem Value="2">Non-ArobicExercise</asp:ListItem>

                                                </asp:DropDownList>
                                            </div>
                                            <div>
                                                <label class="fntWeightBold">PTP?</label>
                                                <asp:CheckBox ID="chkIsPTP" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <asp:Panel ID="pnlArobic" runat="server">
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3>Arobic Exrcise</h3>
                                    </div>

                                    <div class="col-md-12">
                                        <div class="col-md-6">
                                            <div class="form-body">
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Duration</label>
                                                    <asp:TextBox ID="txtDuration" runat="server" placeholder="Duration.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="fntWeightBold">RPM</label>
                                                    <asp:TextBox ID="txtRPM" runat="server" placeholder="RPM.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Resistence</label>
                                                    <asp:TextBox ID="txtResistence" runat="server" placeholder="Resistence.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Calories</label>
                                                    <asp:TextBox ID="txtCalories" runat="server" placeholder="Calories.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                                <div class="form-group">
                                                    <label class="fntWeightBold">Distance</label>
                                                    <asp:TextBox ID="txtDistance" runat="server" placeholder="Distance.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </asp:Panel>
                        <asp:Panel ID="pnlNonArobic" runat="server">
                            <div class="portlet-body">
                                <div class="row">
                                    <div class="col-md-12">
                                        <h3>Non-Arobic Exrcise</h3>
                                    </div>
                                    <asp:Panel ID="pnlNonArobicView" runat="server">
                                        <div class="col-md-12">
                                            <div class="row">
                                                <div class="col-md-12">
                                                    <asp:Button ID="btnNonArobicExercise" runat="server" Text="Add NonArobic Exercise" OnClick="btnNonArobicExercise_Click" CssClass="btn btn-primary pull-right mrgTop10" />
                                                </div>
                                            </div>
                                            <div class="table-responsive">
                                                <asp:GridView ID="grdLevelSets" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                                    OnRowCommand="grdLevelSets_RowCommand">
                                                    <Columns>
                                                        <asp:TemplateField HeaderText="Level">
                                                            <ItemTemplate>
                                                                <span>
                                                                    <%#Eval("levelId") %>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Set1">
                                                            <ItemTemplate>
                                                                <span>
                                                                    <%#Eval("set1") %>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="Set2">
                                                            <ItemTemplate>
                                                                <span>
                                                                    <%#Eval("set2") %>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Set3">
                                                            <ItemTemplate>
                                                                <span>
                                                                    <%#Eval("set3") %>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="Set4">
                                                            <ItemTemplate>
                                                                <span>
                                                                    <%#Eval("set4") %>
                                                                </span>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="ACTION">
                                                            <ItemTemplate>
                                                                <div class="gridActionsIcon">
                                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("levelId") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("levelId") %>' CssClass="dsplNone" CommandName="DeleteLevel" />
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                    </asp:Panel>
                                    <div class="clearfix"></div>
                                    <asp:Panel ID="pnlNonArobicEdit" runat="server">
                                        <div class="col-md-12">
                                            <div class="col-md-6">
                                                <div class="form-body">
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Body Type</label>
                                                        <asp:DropDownList ID="ddlLevels" runat="server" CssClass="form-control" AutoPostBack="True">
                                                            <asp:ListItem Value="1">Level 1</asp:ListItem>
                                                            <asp:ListItem Value="2">Level 2</asp:ListItem>
                                                            <asp:ListItem Value="3">Level 3</asp:ListItem>
                                                            <asp:ListItem Value="4">Level 4</asp:ListItem>
                                                        </asp:DropDownList>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Set1</label>
                                                        <asp:TextBox ID="txtSet1" runat="server" placeholder="Set1.." CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Set2</label>
                                                        <asp:TextBox ID="txtSet2" runat="server" placeholder="Set2.." CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Set3</label>
                                                        <asp:TextBox ID="txtSet3" runat="server" placeholder="Set3.." CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                    <div class="form-group">
                                                        <label class="fntWeightBold">Set4</label>
                                                        <asp:TextBox ID="txtSet4" runat="server" placeholder="Set4.." CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="clearfix"></div>
                                        <div class="footerBtns">
                                            <asp:Button ID="btnSaveNonArobicExercise" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlN');" OnClick="btnSaveNonArobicExercise_Click" Text="Save" />
                                            <asp:Button ID="btnCancelNonArobicExercise" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancelNonArobicExercise_Click" Text="Cancel" />
                                        </div>
                                    </asp:Panel>
                                </div>
                            </div>
                        </asp:Panel>
                        <div class="clearfix"></div>
                        <div class="footerBtns">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text="Save" />
                            <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" OnClick="btnCancel_Click" Text="Cancel" />
                        </div>
                    </div>
                </asp:Panel>
            </div>

        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

