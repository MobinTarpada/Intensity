<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="FreeTrial.aspx.cs" Inherits="FitnessCenter.FreeTrial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Contact Section -->
    <section id="contact" class="container parallax4">
        <!-- Contact Inner -->
        <div class="inner contact">
            <!-- Form Area -->
            <div class="contact-form">
                <h4 class="header light gray3 fancy"><span class="colored">Free Membership</span></h4>
                <p class="h-desc gray3 bold">
                    Give us reason in 50 words, why you want to join 
 <span class="colored bold">INTENSITY BEYOND FITNESS </span>and win<br />

                </p>
                <%--<p class="h-desc gray3 bold">
                    At <span class="colored bold">INTENSITY</span> we are always here to help.
                </p>--%>
                <h4 class="header light gray3 colored bold fancy">1 month free membership<span class="colored"></span></h4>
                <%--<p class="h-desc gray3 bold">
                    If you have any <span class="colored bold">Feedback</span> or questions about our clubs, our website or our service in general, 
                            please send us a message by completing our enquiry form.<br />
                    <span class="colored bold">OR</span><br />
                    Give us a call at <span class="bold colored">079 2790-4546,079 2790-4547.</span>
                </p>--%>
                <div class="portlet-body">
                    <!-- Left Inputs -->

                    <div class="col-xs-6 animated" data-animation="fadeInLeft" data-animation-delay="300">
                        
                                <!-- Name -->
                                <%--<label class="bold colored">Name:</label>--%>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form" required="required" placeholder="Full Name:"></asp:TextBox>
                                <%--<input type="text" name="name" id="name" required="required" class="form" placeholder="Name" />--%>
                                <%--<label class="bold colored">Email:</label>--%>
                                <!-- Contact -->
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form" required="required" placeholder="Contact:"></asp:TextBox>
                                <!-- Email -->
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form" placeholder="Email: (Optional)" TextMode="Email"></asp:TextBox>
                                <%--<input type="email" name="mail" id="mail" required="required" class="form" placeholder="Email" />--%>
                                <!-- Fitness Goal -->
                                <div class="pull-left">Fitness Goal</div>                                    
                                <asp:RadioButtonList CssClass="col-lg-12 radio-list" ID="rdoGoalList" runat="server" RepeatDirection="Horizontal">
                                    <asp:ListItem Text="health" Value="1"></asp:ListItem>
                                    <asp:ListItem Text="shape" Value="2"></asp:ListItem>
                                    <asp:ListItem Text="strength" Value="3"></asp:ListItem>
                                    <asp:ListItem Text="sports" Value="4"></asp:ListItem>
                                    <asp:ListItem Text="fitness" Value="5"></asp:ListItem>
                                </asp:RadioButtonList>
                                <%--<input type="text" name="subject" id="subject" required="required" class="form" placeholder="Subject" />--%>
                            </div>
                            <!-- End Left Inputs -->
                            <!-- Right Inputs -->
                            <div class="col-xs-6 animated" data-animation="fadeInRight" data-animation-delay="400">
                                <!-- Message -->
                                <asp:TextBox ID="txtMessage"  runat="server" CssClass="form textarea" required="required" placeholder="Message" TextMode="MultiLine"></asp:TextBox>
                                <%--<textarea name="message" id="message" class="form textarea" placeholder="Message"></textarea>--%>
                            </div>
                        </div>
                    <div class="clear"></div>
                <!-- End Right Inputs -->
                <!-- Bottom Submit -->
                <div class="relative fullwidth col-xs-12">
                    <!-- Send Button -->
                    <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="form-btn semibold" OnClick="btnSend_Click1" />
                </div>
                <!-- End Bottom Submit -->
                <!-- Clear -->
                <div class="clear"></div>
                <!-- Your Mail Message -->
                <div class="mail-message-area">
                    <!-- Message -->
                    <div class="alert gray-bg mail-message not-visible-message">
                        <strong>
                            <asp:Label ID="lblMsg" runat="server" Text="Thank You ! Your email has been delivered."></asp:Label></strong>
                    </div>
                </div>
            </div>
            <!-- End Contact Form Area -->
        </div>
        <!-- End Inner -->
    </section>
    <!-- End Contact Section -->
</asp:Content>
