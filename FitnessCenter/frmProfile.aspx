<%@ Page Title="" Language="C#" MasterPageFile="~/MstFitnessCenter.Master" AutoEventWireup="true" CodeBehind="frmProfile.aspx.cs" Inherits="FitnessCenter.frmProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        //function PageLoad() {
        //    SetMenuActive("liProfile");
        //}
        $(document).ready(function () {
            SetMenuActive("liProfile");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%-- <asp:UpdatePanel ID="updtPnlProfile" runat="server">
        <ContentTemplate>--%>
    <div class="page-content">
        <div class="row">
            <div class="col-md-12">
                <h3 class="page-title">UsersProfile
                </h3>
                <ul class="page-breadcrumb breadcrumb">
                    <li><i class="fa fa-home"></i>
                        <a href="frmManageUsers.aspx" id="lnkhome" runat="server">Home </a>
                        <i class="fa fa-angle-right"></i>
                    </li>
                </ul>
            </div>
        </div>
        <asp:Panel ID="pnlEdit" runat="server">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <label>User Profile</label>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-6">
                            <h3>User Detail</h3>
                            <div class="form-body">
                                <div class="form-group">
                                    <label class="fntWeightBold">First Name</label>
                                    <asp:TextBox ID="txtFirstName" runat="server" placeholder="First Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="fntWeightBold">Last Name</label>
                                    <asp:TextBox ID="txtLastName" runat="server" placeholder="Last Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" ReadOnly="True"></asp:TextBox>
                                </div>


                                <div class="form-group">
                                    <label class="fntWeightBold">Username</label>
                                    <asp:TextBox ID="txtUsername" runat="server" placeholder="User Name.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);"></asp:TextBox>
                                </div>

                                <div class="form-group">
                                    <asp:FileUpload ID="FileUploadControl" runat="server" />
                                    <asp:Image ID="imgProfileImageChange" AlternateText="Profile Image" runat="server" Height="150px" width="150px"/>
                                    <div>
                                        <br />
                                        <asp:Label runat="server" ID="StatusLabel" ForeColor="Red"/>
                                    </div>
                                </div>

                                <div class="form-group">
                                    <label class="fntWeightBold">Email</label>
                                    <asp:TextBox ID="txtEmail" runat="server" placeholder="Email.." CssClass="form-control" onchange="RemoveValidate(this);"></asp:TextBox>
                                </div>
                                <div class="form-group">
                                    <label class="fntWeightBold">Password</label>
                                    <asp:TextBox ID="txtPassword" runat="server" placeholder="Password.." CssClass="form-control pnl1text-input" onchange="RemoveValidate(this);" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                        </div>

                        <div class="clearfix"></div>
                        <div class="footerBtns">
                            <asp:Button ID="btnSave" runat="server" CssClass="btn blue pull-right mrgRight10 mrgLeft5" OnClientClick="return ValidateCustom('pnl1');" OnClick="btnSave_Click" Text="Save" />
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        </div>
        <%--<asp:Panel ID="pnlProfilePic" runat="server">
            <div class="portlet box blue">
                <div class="portlet-title">
                    <div class="caption">
                        <label>Profile Picture</label>
                    </div>
                </div>
                <div class="portlet-body">
                    <div class="row">
                        <div class="col-md-6">
        </asp:Panel>--%>
        <%-- </ContentTemplate>
    </asp:UpdatePanel>--%>

        <%--<asp:UpdateProgress ID="upAdd" runat="server" AssociatedUpdatePanelID="updtPnlProfile">
            <ProgressTemplate>
                <div class="ajax-loading">
                    <div></div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>--%>
</asp:Content>
