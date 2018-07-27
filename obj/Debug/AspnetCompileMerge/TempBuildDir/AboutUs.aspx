<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="AboutUs.aspx.cs" Inherits="FitnessCenter.AboutUs" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function pageLoad() {

            var count = 0, prop = 0;

            GiveClass("p", "h-desc gray4");
            var ele = document.getElementsByTagName("span");

            //RemoveClass();
        }
        // pageLoad();
    </script>
    <style>
        h3 {
            margin-bottom: 0px;
        }

        .shortcode-section > ul {
            list-style: inherit;
        }
    </style>
    <link href="assets/assets/css/accordion.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- About -->
    <section id="about" class="container waypoint">
        <div class="inner accordion">
            <!-- Header -->
            <h1 class="header light gray3 fancy"><span class="colored">Know </span>about us</h1>
            <ajaxToolkit:Accordion ID="accAboutUs" runat="server" AutoSize="None"
                FadeTransitions="true"
                TransitionDuration="250"
                FramesPerSecond="40"
                RequireOpenedPane="false" HeaderCssClass="" ContentCssClass="accordion-content" CssClass="accordion" SelectedIndex="-1">
                <HeaderTemplate>
                    <h3><span class="colored uppercase extrabold condensed"><%#Eval("heading") %></span></h3>
                </HeaderTemplate>
                <ContentTemplate>
                    <!--col-lg-12-->
                    <div class="col-lg-12">
                        <!--col-lg-8-->
                        <div class="col-lg-12">
                            <!-- Description -->
                            <article class="shortcode-section">
                                <%#Eval("Description") %>
                            </article>
                        </div>
                        <!-- End col-lg-8-->
                        <!--col-lg-4-->
                        <%--<div class="col-lg-4">
                            <br />
                            <img src='<%#Eval("image") %>' class="img-responsive" />
                        </div>--%>
                        <!-- End col-lg-4-->
                    </div>
                    <!-- End col-lg-12-->
                </ContentTemplate>
            </ajaxToolkit:Accordion>
            <!--col-lg-12-->
            <%--<div class="col-lg-12">
                <!--col-lg-8-->
                <div class="col-lg-8">
                    <!-- Description -->
                    <article class="shortcode-section" runat="server" id="aboutUs">
                        <p class="h-desc gray4">
                            <span class="colored uppercase extrabold condensed">EXECUTIVE SUMMARY</span>
                            <br />
                            <br />
                            <span class="colored uppercase bold condensed">INTENSITY</span> is our brand name of the business. We will provide the premium health & <span class="colored bold">Fitness</span> services to the population.<br />
                            Our business is based on the two simple facts which are as follow:<br />
                            <ul>
                                <li class="fa fa-hand-o-right">We are focused towards changing people’s lifestyle by offering and educating area population.</li>
                                <br />
                                <li class="fa fa-hand-o-right">Our concern is to provide premium health and fitness services in various location of Ahmedabad.</li>
                            </ul>
                        </p>
                        <p class="h-desc gray4">
                            At <span class="colored uppercase bold condensed">INTENSITY</span>, we tie population directly to the health and fitness issues. We believe that traditional approaches to the current health care alternative are point in the wrong direction. 
                These traditional efforts are what we call sensitive, for example we wait until we have been stricken with illness or injury, and then pay for the necessary treatments. 
                Our contemporary approach, which emphasizes prevention and good health and fitness promotion, is much more proactive.
                        </p>
                        <p class="h-desc gray4">
                            By helping Population, change their activity patterns and choose more healthy lifestyles, <span class="colored uppercase bold condensed">INTENSITY</span> will lower their health care expenditures, while raising healthy lifestyle. 
                    Better lifestyle will reduce stress and mental fatigue, boosts natural energy, Cure sleeping disorders, improves cardiovascular function, healthy appetite which also helps to reduce and control bodyweight and fat percentage etc.
                        </p>
                        <p class="h-desc gray4">
                            INTENSITY encourages and creates opportunities for people to design healthy lifestyle for self, their family and friends. 
                            We are agents of change, and we are dealing for Future Obesity, so we called ourselves FOPSA (Future Obesity Problem Solving Agents). 
                            High Tech age appropriate cardio equipment and health and fitness planning tools are utilised to improve individual wellbeing status 
                            with targeted personal interventions.
                        </p>
                        <p class="h-desc gray4">
                            <span class="colored uppercase extrabold condensed">COMPANY SUMMARY</span>
                            <br />
                            <br />
                            INTENSITY is a premier Health & Fitness service provider in Ahmedabad.  
                            Mr. Prashant Soni is a High Profile Certified Health & Fitness Professional. 
                            Since long he is in fitness and travel around the world to work with world’s leading health and fitness organisations. 
                            He is running his business from home-based location in Ahmedabad and the Business has been consistently grown since its inception.
                        </p>
                    </article>
                </div>
                <!-- End col-lg-8-->
                <!--col-lg-4-->
                <div class="col-lg-4" runat="server" id="aboutImg">
                    <br />
                    <img src="assets/img/CompanyLogoWhite.png" class="img-responsive" />
                    <br />
                    <img src="assets/assets/images/clients/66.jpg" class="img-responsive" />
                    <br />
                    <img src="assets/assets/images/fitness/FOPSA.png" class="img-responsive" />
                    <br />
                    <img src="assets/assets/images/clients/11.jpg" class="img-responsive" />
                </div>
                <!-- End col-lg-4-->
            </div>--%>
            <!-- End col-lg-12-->
        </div>
        <!-- End About Inner -->
    </section>
    <!-- End About Section -->
</asp:Content>
