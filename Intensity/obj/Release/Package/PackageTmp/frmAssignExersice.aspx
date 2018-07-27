<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmAssignExersice.aspx.cs" Inherits="FitnessCenter.frmAssignExersice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {
            $(".datePicker").datepicker({
                changeMonth: true,
                changeYear: true,
                yearRange: '1950:2016',
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
            SetMenuActive("liManageAssignExercise");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatepnlAssignExersice" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Assign Exersice</h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="frmAssignExersice.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Exersice</label>
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
                                        <asp:Button ID="btnAddExersice" runat="server" Text="Add Exersice" CssClass="btn btn-primary pull-right mrgTop10" OnClick="btnAddExersice_Click" />
                                    </div>
                                </div>
                            </div>



                            <div class="table-responsive">

                                <asp:GridView ID="grdExersice" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination" OnRowCommand="grdExersice_RowCommand" OnSelectedIndexChanging="grdExersice_SelectedIndexChanging" OnSorting="grdExersice_Sorting">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%#Eval("FULLNAME") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("MEMBERID") %>' CommandName="EditExercise"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("MEMBERID") %>' CommandName="DetailExercise"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("MEMBERID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("MEMBERID") %>' CssClass="dsplNone" CommandName="DeleteExercise" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:GridView ID="grdDetailsExercise" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Member Name" SortExpression="MemberName">
                                            <ItemTemplate>
                                                <span><%#Eval("FULLNAME") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Exercise Name" SortExpression="ExerciseName">
                                            <ItemTemplate>
                                                <span><%#Eval("exerciseName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="EXERCISE TYPE" SortExpression="ExerciseType">
                                            <ItemTemplate>
                                                <span><%# Convert.ToString(Eval("exerciseTypeId")) == "1" ? "Arobic Exercise" : "Non-Arobic Exercise" %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Body Type" SortExpression="BodyType">
                                            <ItemTemplate>
                                                <span><%# Convert.ToString(Eval("bodyTypeId")) == "1" ? "Ectomorph" : Convert.ToString(Eval("bodyTypeId")) == "2" ? "Endomorph" : "Mesomorph"%></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="LevelId" SortExpression="LevelId">
                                            <ItemTemplate>
                                                <span><%#Eval("levelId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Set1" SortExpression="Set1">
                                            <ItemTemplate>
                                                <span><%#Eval("set1") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Set2" SortExpression="Set2">
                                            <ItemTemplate>
                                                <span><%#Eval("set2") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Set3" SortExpression="Set3">
                                            <ItemTemplate>
                                                <span><%#Eval("set3") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="SET4" SortExpression="Set4">
                                            <ItemTemplate>
                                                <span><%#Eval("set4") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Duration" SortExpression="Duration">
                                            <ItemTemplate>
                                                <span><%#Eval("duration") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RPM" SortExpression="RPM">
                                            <ItemTemplate>
                                                <span><%#Eval("RPM") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Resistence" SortExpression="Resistence">
                                            <ItemTemplate>
                                                <span><%#Eval("Resistence") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Calories" SortExpression="Calories">
                                            <ItemTemplate>
                                                <span><%#Eval("Calories") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Distance" SortExpression="Distance">
                                            <ItemTemplate>
                                                <span><%#Eval("Distance") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>


                                        <asp:TemplateField HeaderText="is PersonalTrainingPack Allow" SortExpression="PTP">
                                            <ItemTemplate>
                                                <span><%# Eval ("isPersonalTrainingPackAllow") %></span>
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
                                                <label class="fntWeightBold">MemberName</label>
                                                <asp:DropDownList ID="ddlMembers" runat="server" CssClass="form-control" AutoPostBack="True"></asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">BodyType</label>
                                                <asp:DropDownList ID="ddlBodyType" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="0">Select Bodytype</asp:ListItem>
                                                    <asp:ListItem Value="1">Ectomorph</asp:ListItem>
                                                    <asp:ListItem Value="2">Endomorph</asp:ListItem>
                                                    <asp:ListItem Value="3">Mesomorph</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Level</label>
                                                <asp:DropDownList ID="ddlLevel" runat="server" CssClass="form-control" AutoPostBack="True">
                                                    <asp:ListItem Value="0">Select Level</asp:ListItem>
                                                    <asp:ListItem Value="1">1</asp:ListItem>
                                                    <asp:ListItem Value="2">2</asp:ListItem>
                                                    <asp:ListItem Value="3">3</asp:ListItem>
                                                    <asp:ListItem Value="4">4</asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div>
                                                <asp:Button ID="btnSet" Text="SET" runat="server" CssClass="btn blue mrgLeft " OnClick="btnSet_Click" />
                                                <asp:Label ID="lblErrorMsg" runat="server" CssClass="fntWeightBold" ForeColor="Red"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlNonArobic" runat="server">
                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <label>Non-Arobic Exercise</label>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="form-body">
                                                            <asp:ListView ID="lstNonArobicExercise" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                                                ItemPlaceholderID="itemPlaceHolder1">
                                                                <ItemTemplate>
                                                                    <div class="form-body">
                                                                        <div class="form-group">
                                                                            <asp:HiddenField ID="hfNACardId" runat="server" Value='<%#Eval("CardID") %>' />
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">ExerciseName</label>
                                                                            <asp:TextBox ID="txtNAExercise" Text='<%#Eval("exerciseName") %>' runat="server" placeholder="Non-Arobic Exercixe.." CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label>Set1</label>
                                                                            <asp:TextBox ID="txtSet1" runat="server" placeholder="Set1.." Text='<%#Eval("set1") %>' CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label>Set2</label>
                                                                            <asp:TextBox ID="txtSet2" runat="server" placeholder="Set2.." Text='<%#Eval("set2") %>' CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label>Set3</label>
                                                                            <asp:TextBox ID="txtSet3" runat="server" placeholder="Set3.." Text='<%#Eval("set3") %>' CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label>Set4</label>
                                                                            <asp:TextBox ID="txtSet4" runat="server" placeholder="Set4.." Text='<%#Eval("set4") %>' CssClass="form-control pnlNtext-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </asp:Panel>
                                <div class="clearfix"></div>
                                <asp:Panel ID="pnlArobic" runat="server">

                                    <div class="portlet box blue">
                                        <div class="portlet-title">
                                            <div class="caption">
                                                <label>Arobic Exercise</label>
                                            </div>
                                        </div>
                                        <div class="portlet-body">
                                            <div class="row">
                                                <div class="col-md-12">
                                                </div>
                                                <div class="col-md-12">
                                                    <div class="col-md-6">
                                                        <div class="form-body">
                                                            <asp:ListView ID="lstArobicExercise" runat="server" GroupPlaceholderID="groupPlaceHolder1"
                                                                ItemPlaceholderID="itemPlaceHolder1">
                                                                <ItemTemplate>
                                                                    <div class="form-group">
                                                                        <asp:HiddenField ID="hfACardId" runat="server" Value='<%#Eval("CardID") %>' />
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label class="fntWeightBold">ExerciseName</label>
                                                                        <asp:TextBox ID="txtAExerciseName" runat="server" placeholder="ExerciseName.." Text='<%#Eval("exerciseName") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label>Duration</label>
                                                                        <asp:TextBox ID="txtDuration" runat="server" placeholder="Duration.." Text='<%#Eval("duration") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label>RPM</label>
                                                                        <asp:TextBox ID="txtRPM" runat="server" placeholder="RPM.." Text='<%#Eval("RPM") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label>Resistence</label>
                                                                        <asp:TextBox ID="txtResistence" runat="server" placeholder="Resistence.." Text='<%#Eval("Resistence") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label>Calories</label>
                                                                        <asp:TextBox ID="txtCalories" runat="server" placeholder="Calories.." Text='<%#Eval("Calories") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                    <div class="form-group">
                                                                        <label>Distance</label>
                                                                        <asp:TextBox ID="txtDistance" runat="server" placeholder="Distance.." Text='<%#Eval("Distance") %>' CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                                                    </div>
                                                                </ItemTemplate>
                                                            </asp:ListView>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                </asp:Panel>


                                <div class="footerBtns">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                                </div>
                            </div>
                        </div>
                </asp:Panel>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
