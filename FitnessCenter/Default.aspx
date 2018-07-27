<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="FitnessCenter.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <!-- Home Section -->
            <section id="home">
                <div id="slides">
                    <div class="slides-container table-responsive">
                        <!-- Slider Images -->
                        <asp:ListView class="table-responsive" ID="lstSlider" runat="server">
                            <ItemTemplate>
                                <div class="img-responsive">
                                    <asp:Image ID="imgSlider" runat="server" ImageUrl='<%#Eval("imagePath") %>' />
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                        <%--<div class="image2"></div>
                        <div class="image1"></div>
                        <div class="image3"></div>
                        <div class="image4"></div>
                        <div class="image5"></div>
                        <div class="image6"></div>--%>
                        <!-- End Slider Images -->
                    </div>
                    <!-- Slider Controls -->
                    <nav class="slides-navigation">
                        <a href="#" class="next"></a>
                        <a href="#" class="prev"></a>
                    </nav>
                </div>
                <!-- End Home Slides -->
                <%--<div class="v2 absolute">
                    <!-- Auto Typocraphic Texts -->
                    <div class="typographic">
                        <!-- Your Logo -->
                        <div class="logo">
                            <img src="assets/img/CompanyLogoWhite.png" width="200" alt="Logo" />
                        </div>
                        <h2 class=" condensed uppercase no-padding no-margin bold gray1">Introducing</h2>
                        <h2 class=" condensed uppercase no-padding no-margin bold colored">Fitness Passion</h2>
                        <a href="#about" class="scroll"><i class="arrow-down fa fa-3x fa-angle-double-down"></i></a>
                    </div>
                    <!--End Auto Typocraphic Texts -->
                </div>--%>
                <!-- End V2 area -->
            </section>
            <!-- End Home Section -->

            <!-- About Section -->
            <section id="about" class="container waypoint">
                <div class="inner">

                    <!-- Header -->
                    <h1 class="header light gray3 fancy"><span class="colored">Know </span>about us</h1>
                    <!-- Description -->
                    <p class="h-desc gray4">
                        <span class="colored bold">INTENSITY</span> is our brand name of the business. We will provide the premium health & <span class="colored bold">Fitness</span> services to the population.<br />
                        Our business is based on the two simple facts which are as follow:<br />
                        <ul>
                            <li class="fa fa-hand-o-right">We are focused towards changing people’s lifestyle by offering and educating area population.</li>
                            <br />
                            <li class="fa fa-hand-o-right">Our concern is to provide premium health and fitness services in various location of Ahmedabad.</li>
                        </ul>
                        <br />
                        <p class="h-desc gray4">
                            <span class="colored bold">INTENSITY</span> is more than fitness centre. It’s a part of lifestyle. At the <span class="colored bold">INTENSITY</span> we are committed to the health and wellbeing of mind, body and spirit.
                        </p>
                        <p>
                        </p>
                        <!-- Bottom Submit -->
                        <div class="relative fullwidth col-xs-12">
                            <!-- Send Button -->
                            <a class="form-btn semibold" href="AboutUs.aspx">Know More</a>
                        </div>
                        <!-- End Bottom Submit -->
                        <hr />
                        <p>
                        </p>
                        <p>
                        </p>
                    </p>
                </div>
                <!-- End About Inner -->
            </section>
            <!-- End About Section -->

            <!-- Virtual Tour -->
            <section id="features" class="container">
                <div class="inner">
                    <!-- Header -->
                    <h1 class="header light white fancy"><span class="colored">Virtual </span>Tour</h1>
                    <!-- Description -->
                    <p class="h-desc white">
                        Curious About <span class="colored bold">INTENSITY</span>?
                Want to know how it is?
                    </p>
                    <p class="h-desc white">
                        So, Have a look at us.
                    </p>
                    <p class="h-desc white">
                        Take our <span class="colored bold">Virtual</span> Tour and
                Explore our <span class="colored bold">INTENSE</span> Gym
                    </p>
                    <!-- Bottom Submit -->
                    <div class="relative fullwidth col-xs-12">
                        <!-- Send Button -->
                        <a href="VirtualTour.aspx" class="form-btn semibold">Take a Tour</a>
                    </div>
                    <!-- End Bottom Submit -->
                </div>
            </section>
            <!-- End Virtual Tour -->

            <!-- Testimonials -->
            <section id="testimonial" class="testimonials parallax2">
                <div class="inner">
                    <!-- Header -->
                    <h1 class="header light gray3 fancy"><span class="colored">Services </span>We Give.</h1>
                    <!-- Description -->
                    <p class="h-desc gray4">We shall offer numbers of fitness activities and programme to our clients by our premium services.</p>
                    <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                        <!-- Indicators -->
                        <ol class="carousel-indicators">
                            <%--<li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>--%>
                            <asp:ListView runat="server" ID="lvServiceSlide">
                                <ItemTemplate>
                                    <li data-target="#carousel-example-generic" runat="server" id="liService" class="active"></li>
                                </ItemTemplate>
                            </asp:ListView>
                            <%--<li data-target="#carousel-example-generic" data-slide-to="2"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="3"></li>--%>
                        </ol>
                        <!-- Wrapper for slides -->
                        <div class="carousel-inner">
                            <asp:ListView runat="server" ID="lvServices">
                                <ItemTemplate>
                                    <div class="item" runat="server" id="divService">
                                        <ul>
                                            <li class="monial">
                                                <!-- Text -->
                                                <h1 class="condensed white"><span class="colored"><%#Eval("facilityName") %></span></h1>
                                                <!-- Name -->
                                                <p class="light"><%#Eval("description") %></p>
                                            </li>
                                        </ul>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>

                    </div>
                </div>
                <!-- End Inner Div -->
            </section>
            <!-- End Testimonials Section -->
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
