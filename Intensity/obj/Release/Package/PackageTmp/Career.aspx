<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="Career.aspx.cs" Inherits="FitnessCenter.Carrer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="about" class="container waypoint">
        <div class="inner">
            <!-- Header -->
            <h1 class="header light gray3 fancy">Make a <span class="colored">Career </span></h1>
            <!-- Description -->
            <p class="h-desc gray4">
                Looking for a Career in <span class="colored bold">Fitness</span> ?<br />
                Join and Make a Career with <span class="colored bold">INTENSITY</span>
            </p>
            <br />
            <br />
            <br />
            <br />
            <div class="col-lg-12">
                <div class="col-lg-6">
                    <h4>A FEW SIMPLE STEPS</h4>
                    <p class="h-desc gray4">
                        Simply complete the form, enter your mobile number and Email.<br />
                        Upload your <span class="colored bold">Resume</span>.<br />
                        And you're Done.
                    </p>
                </div>
                <div class="col-lg-6">
                    <div class="form-group">
                        <label class="bold">Select Position</label>
                        <asp:DropDownList ID="drpPosition" runat="server" CssClass="form"></asp:DropDownList>
                    </div>
                    <div class="form-group">
                        <label class="bold">Name</label>
                        <asp:TextBox ID="txtName" runat="server" CssClass="form" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="bold">Mobile No</label>
                        <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form" required="required"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="bold">Email</label>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form" required="required" TextMode="Email"></asp:TextBox>
                    </div>
                    <div class="form-group">
                        <label class="bold">Upload Resume</label>
                        <asp:FileUpload ID="fuResume" runat="server" />
                    </div>
                </div>
            </div>
            <div class="relative fullwidth col-xs-12">
                <!-- Send Button -->
                <asp:Button ID="btnSend" runat="server" Text="Send" CssClass="form-btn semibold" OnClick="btnSend_Click" />
            </div>
            <!-- Clear -->
            <div class="clear"></div>
            <!-- Your Mail Message -->
            <div class="mail-message-area">
                <!-- Message -->
                <div class="alert-success mail-message not-visible-message">
                    <strong>
                        <asp:Label ID="lblMsg" runat="server" Text="Thank You ! Your email has been delivered."></asp:Label></strong>
                </div>
            </div>
        </div>
    </section>
</asp:Content>
