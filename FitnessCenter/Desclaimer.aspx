<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="Desclaimer.aspx.cs" Inherits="FitnessCenter.Desclaimer" %>

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
                changeYear: true
            });
            SetMenuActive("liDesclaimer");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="updatePnlDisclaimer" runat="server">
        <ContentTemplate>
            <div class="page-content">
                <div class="row">
                    <div class="col-md-12">
                        <h3 class="page-title">Disclaimer                          
                        </h3>
                        <ul class="page-breadcrumb breadcrumb">
                            <li><i class="fa fa-home"></i>
                                <a href="Desclaimer.aspx">Home </a>
                                <i class="fa fa-angle-right"></i>
                            </li>
                        </ul>
                    </div>
                </div>
                <asp:Panel ID="pnlView" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Disclaimer Details</label>
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
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" CssClass="btn btn-primary mrgLeft5 mrgTop10" />
                                        <%--<asp:Button ID="CheckRFIDCardNo" runat="server" Text="Check RFID Card" CssClass="btn btn-primary pull-right mrgTop10" OnClick="CheckRFIDCardNo_Click" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdDisclaimersForm" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdDisclaimersForm_PageIndexChanging" AllowPaging="true" PageSize="100" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdDisclaimersForm_Sorting" AllowSorting="true"
                                    OnRowCommand="grdDisclaimersForm_RowCommand" OnSelectedIndexChanged="grdDisclaimersForm_SelectedIndexChanged">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FIRST NAME" SortExpression="FIRSTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Last Name" SortExpression="LASTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("lastName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Agreement Number" SortExpression="USERNAME">
                                            <ItemTemplate>
                                                <span><%# Eval("agreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="EMAIL">
                                            <ItemTemplate>
                                                <span><%# Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RFID Card Number" SortExpression="EMAIL">
                                            <ItemTemplate>
                                                <span><%# Eval("RFIDCardNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">
                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditDisclaimerForm"><i class="fa fa-edit"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailDesclaimerForm"><i class="fa fa-file"></i></asp:LinkButton>
                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteDisclaimerForm" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

                <asp:Panel ID="pnlDisclaimerDetails" runat="server">
                    <div class="portlet box blue">
                        <div class="portlet-title">
                            <div class="caption">
                                <label>Disclaimer Entry Details</label>
                            </div>
                        </div>

                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="col-md-4">
                                        <div class="form-body">
                                           <%-- <div class="form-group">
                                                <asp:TextBox ID="txtSearchDetails" runat="server" placeholder="Searching.." CssClass="form-control"></asp:TextBox>
                                            </div>--%>
                                        </div>
                                    </div>
                                    <%--<div class="col-md-8">
                                        <asp:Button ID="btnEntrySearch" runat="server" Text="Search Entry" CssClass="btn btn-primary mrgLeft5 mrgTop10" OnClick="btnEntrySearch_Click" />
                                        <%--<asp:Button ID="CheckRFIDCardNo" runat="server" Text="Check RFID Card" CssClass="btn btn-primary pull-right mrgTop10" OnClick="CheckRFIDCardNo_Click" />--%>
                                   <%-- </div>--%>
                                </div>
                            </div>
                            <div class="table-responsive">
                                <asp:GridView ID="grdDisclaimerDetails" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                    OnPageIndexChanging="grdDisclaimerDetails_PageIndexChanging" AllowPaging="true" PageSize="10" PagerStyle-CssClass="CustomPagination"
                                    OnSorting="grdDisclaimerDetails_Sorting" AllowSorting="true"
                                    OnRowCommand="grdDisclaimerDetails_RowCommand">
                                    <Columns>
                                        <asp:TemplateField HeaderText="FIRST NAME" SortExpression="FIRSTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("firstName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Last Name" SortExpression="LASTNAME">
                                            <ItemTemplate>
                                                <span><%#Eval("lastName") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Agreement Number" SortExpression="Agreement">
                                            <ItemTemplate>
                                                <span><%# Eval("agreementNumber") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Membership Number" SortExpression="Membership">
                                            <ItemTemplate>
                                                <span><%# Eval("membershipUniqueId") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="RFID Card Number" SortExpression="RFID">
                                            <ItemTemplate>
                                                <span><%# Eval("RFIDNo") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Entry Date" SortExpression="Entry Date">
                                            <ItemTemplate>
                                                <span><%# Eval("insertDate") %></span>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="ACTION">
                                            <ItemTemplate>
                                                <div class="gridActionsIcon">--%>
                                                    <%--<asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditDisclaimerEntry"><i class="fa fa-edit"></i></asp:LinkButton>--%>
                                                    <%--<asp:LinkButton ID="lnkBtnDetail" runat="server" ToolTip="Detail" CommandArgument='<%# Eval("ID") %>' CommandName="DetailDesclaimerForm"><i class="fa fa-file"></i></asp:LinkButton>--%>
                                                   <%-- <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteDisclaimerEntry" />
                                                </div>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
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
                                <label>Desclaimer</label>
                            </div>
                        </div>
                        <div class="portlet-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-body">
                                        <div class="form-group">
                                            <label class="fntWeightBold">RFID Card Number</label>
                                            <asp:TextBox ID="txtRFIDCardNumber" placeholder="Enter RFID Card Number..." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" AutoPostBack="True" runat="server"></asp:TextBox>
                                        </div>
                                        <asp:Panel ID="pnlLeadsDetails" runat="server">
                                            <div class="form-group">
                                                <label class="fntWeightBold">Date</label>
                                                <asp:TextBox ID="txtDate" CssClass="form-control pnl1text-input datePicker" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Name</label>
                                                <asp:TextBox ID="txtName" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Register Number</label>
                                                <asp:TextBox ID="txtRegNumber" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Address</label>
                                                <asp:TextBox ID="txtAddress" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server" TextMode="MultiLine"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">City</label>
                                                <asp:TextBox ID="txtCity" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Email</label>
                                                <asp:TextBox ID="txtEmail" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">MObile Number</label>
                                                <asp:TextBox ID="txtMobileNumber" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Age</label>
                                                <asp:TextBox ID="txtAge" CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Sex</label>
                                                <asp:TextBox ID="txtSex" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Height</label>
                                                <asp:TextBox ID="txtHeight" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">Weight</label>
                                                <asp:TextBox ID="txtWeight" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                            <div class="form-group">
                                                <label class="fntWeightBold">FrameSize</label>
                                                <asp:TextBox ID="txtFrameSize" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                            </div>
                                        </asp:Panel>
                                        <p></p>
                                        <asp:UpdatePanel ID="updtpnl1" runat="server">
                                            <ContentTemplate>
                                                <div class="clearfix"></div>
                                                <div class="col-md-12" style="margin-bottom: 10px;">
                                                    <h3>Questions</h3>
                                                </div>
                                                <div class="col-md-12">
                                                    <asp:ListView ID="lstQuestions" runat="server" OnSelectedIndexChanged="lstQuestions_SelectedIndexChanged" OnItemDataBound="lstQuestions_ItemDataBound">
                                                        <ItemTemplate>
                                                            <div>
                                                                <asp:Label ID="lblQuestionText" runat="server" Style="font-weight: bold;" Text='<%# "Que-" + Eval("ID") + ". " +   Eval("questions") %>'></asp:Label>
                                                                <asp:HiddenField ID="hdnFldQuestionTypeId" runat="server" Value='<%#Eval("questionTypeId") %>' />
                                                                <asp:HiddenField ID="hdnFldSelfQuestionID" runat="server" Value='<%#Eval("QuestionId") %>' />
                                                                <asp:HiddenField ID="hdnfldqestionOptionID" runat="server" Value='<%#Eval("OptionId") %>' />
                                                                <asp:HiddenField ID="hdnFldQuestionId" runat="server" Value='<%#Eval("ID") %>' />
                                                                <div class="clearfix"></div>
                                                                <div class="mrgTop10">
                                                                    <div class="form-body">
                                                                        <asp:Panel ID="pnlSingleType" runat="server">
                                                                            <div class="form-group">
                                                                                <asp:TextBox ID="txtQuestionAnswer" runat="server" CssClass="form-control"></asp:TextBox>
                                                                            </div>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlMultipleTypeRadio" runat="server">
                                                                            <div class="col-md-12">
                                                                                <div class="form-group">
                                                                                    <asp:RadioButtonList ID="lstQuestionSingleOption" CssClass="col-md-6" runat="server" AutoPostBack="true" OnSelectedIndexChanged="lstQuestionSingleOption_SelectedIndexChanged" OnItemDataBound="lstQuestionSingleOption_ItemDataBound" RepeatColumns="4"></asp:RadioButtonList>
                                                                                </div>
                                                                            </div>
                                                                        </asp:Panel>
                                                                        <asp:Panel ID="pnlMultipleType" runat="server">
                                                                            <div class="col-md-12">
                                                                                <asp:ListView ID="lstQuestionOptions" runat="server" OnItemDataBound="lstQuestionOptions_ItemDataBound">
                                                                                    <ItemTemplate>
                                                                                        <div class="col-md-12">
                                                                                            <div class="form-group">
                                                                                                <asp:HiddenField ID="hdnFldOptionId" runat="server" Value='<%#Eval("ID") %>' />
                                                                                                <label class="checkbox">
                                                                                                    <asp:CheckBox ID="chkOptions" runat="server" Style="margin-left: 0px;" />
                                                                                                    <label for="chkOptions"><%#Eval("options") %></label>
                                                                                                </label>
                                                                                            </div>
                                                                                        </div>
                                                                                    </ItemTemplate>
                                                                                </asp:ListView>
                                                                            </div>
                                                                        </asp:Panel>
                                                                    </div>
                                                                </div>
                                                            </div>
                                                        </ItemTemplate>
                                                    </asp:ListView>
                                                    <div class="form-group">
                                                        <table class="table table-advance table-bordered table-hover">
                                                            <tr>
                                                                <td>
                                                                    <h4>Details of:</h4>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>a) </label>
                                                                </td>
                                                                <td>
                                                                    <label>Muscuokelable injury in past or Present ?</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt1" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>b) </label>
                                                                </td>
                                                                <td>
                                                                    <label>Taking Dietary supplements / steroids </label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt2" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>c) </label>
                                                                </td>
                                                                <td>
                                                                    <label>Under Medication :</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt3" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td>
                                                                    <label>d) </label>
                                                                </td>
                                                                <td>
                                                                    <label>Aware of any other medical problems ?</label>
                                                                </td>
                                                                <td>
                                                                    <asp:TextBox ID="txt4" runat="server"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </div>
                                                    <div class="clearfix"></div>
                                                </div>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <p></p>
                                        <asp:Panel ID="pnlOffice" runat="server">
                                            <div class="portlet box blue">
                                                <div class="portlet-title">
                                                    <div class="caption">
                                                        <label>For Office Use</label>
                                                    </div>
                                                </div>
                                                <div class="portlet-body">
                                                    <div class="row">
                                                        <div class="col-md-12">
                                                            <div class="form-body">
                                                                <div class="form-group">
                                                                    <label class="fntWeightBold">
                                                                        Member's Register Number :- 
                                                                    <asp:Label ID="lblAgreeNum" runat="server"></asp:Label></label>
                                                                </div>
                                                                <div class="form-group">
                                                                    <p class="fntWeightBold">
                                                                        I,<asp:Label ID="lblTitle" runat="server"></asp:Label>
                                                                        agree to give my concept to join INTENSITY BEYOND FITNESS for all gymming related activities i.e. resistance, cardiovascular, aerobic zone
                                                                    </p>
                                                                    <p class="fntWeightBold">
                                                                        All exercise related points have been well explained and understood by 
                                                                        me and by signing this form, I am personally responsible for all actions and workouts
                                                                        during my fitness tenture at INTENSITY BEYOND FITNESS I will also not hold the branch and/or it's
                                                                        satff responsible for any of the injury, minor/major, that may occur during my presence
                                                                        in the permisses.
                                                                    </p>
                                                                    <p class="fntWeightBold">
                                                                        Safety of all my belongings and other valuables is my sole responsibility.
                                                                        Fee paid once will not be transferable, refundable on any direct or pro data basis. 
                                                                        The fee structure has been understood by me in details.
                                                                    </p>
                                                                </div>

                                                                <div class="form-group">
                                                                    <h3>Contact Details In Case of Emeergency</h3>
                                                                </div>
                                                                <table class="table table-responsive table-advance table-bordered table-hover">
                                                                    <tr>
                                                                        <td>Sr.No
                                                                        </td>
                                                                        <td>
                                                                            <label>Name</label>
                                                                        </td>
                                                                        <td>
                                                                            <label>Relationship</label>
                                                                        </td>
                                                                        <td>
                                                                            <label>MobileNumber</label>
                                                                        </td>
                                                                        <td>
                                                                            <lable>Landline</lable>
                                                                        </td>
                                                                        <td>
                                                                            <label>Area</label>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>1 <%--<asp:TextBox ID="txtSrNo1" runat="server"></asp:TextBox>--%>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtName1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRelation1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMobileno1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLandline1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtArea1" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>2<%--<asp:TextBox ID="txtSrNo2" runat="server"></asp:TextBox>--%></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtName2" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRelation2" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMobileno2" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLandline2" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtArea2" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>3<%--<asp:TextBox ID="txtSrNo3" runat="server"></asp:TextBox>--%></td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtName3" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtRelation3" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtMobileno3" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtLandline3" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtArea3" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                    <tr>
                                                                        <td>
                                                                            <label>Family Doctor's name</label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFamDocName" runat="server"></asp:TextBox>
                                                                        </td>
                                                                        <td>
                                                                            <label>Family Doctor's Number</label>
                                                                        </td>
                                                                        <td>
                                                                            <asp:TextBox ID="txtFamDocNo" runat="server"></asp:TextBox>
                                                                        </td>
                                                                    </tr>
                                                                </table>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </asp:Panel>
                                        <p></p>
                                        <asp:Panel ID="pnlMeasurement" runat="server">
                                            <div class="col-md-12">
                                                <asp:Panel ID="pnlMeasurementView" runat="server">
                                                    <div class="portlet box blue">
                                                        <div class="portlet-title">
                                                            <div class="caption">
                                                                <label>Measurement</label>
                                                            </div>
                                                        </div>
                                                        <div class="portlet-body">
                                                            <div class="row">
                                                                <div class="col-md-12">
                                                                    <asp:Button ID="btnAddMeasurement" runat="server" Text="Add Measurement" CssClass="btn btn-primary pull-right mrgBottom10" OnClick="btnAddMeasurement_Click" />
                                                                </div>
                                                            </div>
                                                            <div class="table-responsive">
                                                                <asp:GridView ID="grdMeasurement" runat="server" GridLines="None" CssClass="table table-bordered table-advance table-hover"
                                                                    EmptyDataText="No Record Found..!" AutoGenerateColumns="false"
                                                                    OnRowCommand="grdMeasurement_RowCommand">
                                                                    <Columns>
                                                                        <asp:TemplateField HeaderText="Weight">
                                                                            <ItemTemplate>
                                                                                <span><%# Eval("WEIGHT") %></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="HEIGHT">
                                                                            <ItemTemplate>
                                                                                <span><%#Eval("HEIGHT")%></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="FAT">
                                                                            <ItemTemplate>
                                                                                <span><%#Eval("FAT")%></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BMI">
                                                                            <ItemTemplate>
                                                                                <span><%#Eval("BMI")%></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="BMR">
                                                                            <ItemTemplate>
                                                                                <span><%#Eval("BMR")%></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField HeaderText="Date">
                                                                            <ItemTemplate>
                                                                                <span><%#Eval("insertDate","{0:dd/MM/yyyy}")%></span>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                        <asp:TemplateField>
                                                                            <ItemTemplate>
                                                                                <div class="gridActionsIcon">
                                                                                    <asp:LinkButton ID="lnkBtnEdit" runat="server" ToolTip="Edit" CommandArgument='<%# Eval("ID") %>' CommandName="EditMeasurement"><i class="fa fa-edit"></i></asp:LinkButton>
                                                                                    <asp:LinkButton ID="lnkBtnDelete" runat="server" ToolTip="Delete" CommandArgument='<%# Eval("ID") %>' OnClientClick="DeleteConfirmPopupFromGrid('Delete','Are you sure you want to delete this record?',this.id);return false;"><i class="fa fa-trash-o"></i></asp:LinkButton>
                                                                                    <asp:Button ID="btnDelete" runat="server" CommandArgument='<%# Eval("ID") %>' CssClass="dsplNone" CommandName="DeleteMeasurement" />
                                                                                </div>
                                                                            </ItemTemplate>
                                                                        </asp:TemplateField>
                                                                    </Columns>
                                                                </asp:GridView>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>

                                                <asp:Panel ID="pnlMeasurementEdit" runat="server">
                                                    <div class="portlet box blue">
                                                        <div class="portlet-title">
                                                            <div class="caption">
                                                                <label>Measurement</label>
                                                            </div>
                                                        </div>
                                                        <div class="portlet-body">
                                                            <div class="row">
                                                                <div class="col-md-6">
                                                                    <div class="form-body">
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">Weight</label>
                                                                            <asp:TextBox ID="txtMWeight" CssClass="form-control" placeholder="Weight in kg" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">Height</label>
                                                                            <asp:TextBox ID="txtMHeight" CssClass="form-control" placeholder="Height in Meter" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div>
                                                                            <asp:Button ID="BMIClick" runat="server" Text="Generate BMI" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlA');" OnClick="BMIClick_Click"/>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">BMI</label>
                                                                            <asp:TextBox ID="txtBMi" CssClass="form-control" ReadOnly="true" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">FAT</label>
                                                                            <asp:TextBox ID="txtFat" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">BMR</label>
                                                                            <asp:TextBox ID="txtBMR" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">NECK</label>
                                                                            <asp:TextBox ID="txtNeck" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">SHOULDER</label>
                                                                            <asp:TextBox ID="txtShoulder" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">CHEST</label>
                                                                            <asp:TextBox ID="txtChest" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">ARMS</label>
                                                                            <asp:TextBox ID="txtArms" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">WAIST</label>
                                                                            <asp:TextBox ID="txtWaist" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">HIPS</label>
                                                                            <asp:TextBox ID="txtHips" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">THIGH</label>
                                                                            <asp:TextBox ID="txtThigh" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                        <div class="form-group">
                                                                            <label class="fntWeightBold">CALF</label>
                                                                            <asp:TextBox ID="txtCalf" CssClass="form-control" onchange="RemoveValidate(this);" runat="server"></asp:TextBox>
                                                                        </div>
                                                                    </div>
                                                                </div>

                                                                <div class="clearfix"></div>
                                                                <div class="footerBtns">
                                                                    <asp:Button ID="btnSaveMeasurement" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnlA');" Text="SaveMeasurement" OnClick="btnSaveMeasurement_Click" />
                                                                    <asp:Button ID="btnCancelMeasurement" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="CancelMeasurement" OnClick="btnCancelMeasurement_Click" />
                                                                </div>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                        </asp:Panel>
                                        <p></p>
                                        <asp:Panel ID="Pnlnext1" runat="server">
                                            <div>
                                                <%--<asp:Button ID="btnNext1" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Next" OnClick="btnNext1_Click" />--%>
                                            </div>
                                        </asp:Panel>
                                        <asp:Panel ID="pnlSave" runat="server">
                                            <div class="clearfix"></div>
                                            <div class="footerBtns">
                                                <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" Text="Save" OnClick="btnSave_Click" />
                                                <asp:Button ID="btnCancel" runat="server" CssClass="btn default pull-right mrgLeft5" OnClientClick="RemoveAllValidation();" Text="Cancel" OnClick="btnCancel_Click" />
                                            </div>
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </asp:Panel>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
