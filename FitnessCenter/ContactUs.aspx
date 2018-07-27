<%@ Page Title="" Language="C#"  Debug="true" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="ContactUs.aspx.cs" Inherits="FitnessCenter.ContactUs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- Contact Section -->
            <section id="contact" class="container parallax4">
                <!-- Contact Inner -->
                <div class="inner contact">
                    <!-- Form Area -->
                    <div class="contact-form">
                        <h4 class="header light gray3 fancy"><span class="colored">Contact</span> Us</h4>
                        <p class="h-desc gray3 bold">
                            Connect with <span class="colored bold">INTENSITY</span><br />
                            We'd <i class="fa fa-heart colored"></i> to hear You.
                        </p>
                        <p class="h-desc gray3 bold">
                            At <span class="colored bold">INTENSITY</span> we are always here to help.
                        </p>
                        <h4 class="header light gray3">SEND US A<span class="colored"> Message</span></h4>
                        <p class="h-desc gray3 bold">
                            If you have any <span class="colored bold">Feedback</span> or questions about our clubs, our website or our service in general, 
                            please send us a message by completing our enquiry form.<br />
                            <span class="colored bold">OR</span><br />
                            Give us a call at <span class="bold colored">079 2790-4546,079 2790-4547.</span>
                        </p>
                        <!-- Left Inputs -->
                        <div class="col-xs-6 animated" data-animation="fadeInLeft" data-animation-delay="300">
                            <!-- Name -->
                            <asp:TextBox ID="txtName" runat="server" CssClass="form" required="required" placeholder="Name"></asp:TextBox>
                            <%--<input type="text" name="name" id="name" required="required" class="form" placeholder="Name" />--%>
                            <!-- Email -->
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form" required="required" placeholder="Email" TextMode="Email"></asp:TextBox>
                            <%--<input type="email" name="mail" id="mail" required="required" class="form" placeholder="Email" />--%>
                            <!-- Subject -->
                            <asp:TextBox ID="txtSubject" runat="server" CssClass="form" required="required" placeholder="Subject"></asp:TextBox>
                            <%--<input type="text" name="subject" id="subject" required="required" class="form" placeholder="Subject" />--%>
                        </div>
                        <!-- End Left Inputs -->
                        <!-- Right Inputs -->
                        <div class="col-xs-6 animated" data-animation="fadeInRight" data-animation-delay="400">
                            <!-- Message -->
                            <asp:TextBox ID="txtMessage" runat="server" CssClass="form textarea" placeholder="Message" TextMode="MultiLine"></asp:TextBox>
                            <%--<textarea name="message" id="message" class="form textarea" placeholder="Message"></textarea>--%>
                        </div>
                        <!-- End Right Inputs -->
                        <!-- Bottom Submit -->
                        <div class="relative fullwidth col-xs-12">
                            <!-- Send Button -->
                            <asp:Button ID="btnSend" runat="server" Text="Send Message" CssClass="form-btn semibold" OnClick="btnSend_Click" />
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
