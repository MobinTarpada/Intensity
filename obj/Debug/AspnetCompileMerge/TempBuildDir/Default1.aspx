<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default1.aspx.cs" Inherits="Fitness_Home.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Fitness</title>
    <meta name="description" content="" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <!--Favicon -->
    <link rel="icon" type="image/png" href="assets/assets/images/favicon.jpg" />
    <!-- CSS Files -->
    <link href="assets/assets/css/reset.css" rel="stylesheet" />
    <link href="assets/assets/css/animate.min.css" rel="stylesheet" />
    <link href="assets/assets/css/bootstrap.min.css" rel="stylesheet" />
    <link href="assets/assets/css/style.css" rel="stylesheet" />
    <link href="assets/assets/css/font-awesome.css" rel="stylesheet" />
    <link href="assets/assets/css/owl.carousel.css" rel="stylesheet" />
    <link href="assets/assets/css/responsive.css" rel="stylesheet" />
    <link href="assets/assets/css/player/YTPlayer.css" rel="stylesheet" />
    <link href="assets/assets/css/pro-bars.css" rel="stylesheet" />
    <!-- End CSS Files -->
</head>
<body>
    <!-- Navigation -->
    <section id="navigation" class="dark-nav">
        <!-- Navigation Inner -->
        <div class="nav-inner">
            <!-- Site Logo -->
            <div class="site-logo fancy">
                <a href="#" id="logo-text" class="scroll logo">Intensity
                </a>
            </div>
            <!-- End Site Logo -->
            <a class="mini-nav-button gray2"><i class="fa fa-bars"></i></a>
            <!-- Navigation Menu -->
            <div class="nav-menu">
                <ul class="nav uppercase">
                    <li><a href="#home" class="scroll">Home</a></li>
                    <li><a href="#about" class="scroll">About us</a></li>
                    <li><a href="#features" class="scroll">Virtual Tour</a></li>
                    <li><a href="#clients" class="scroll">Facilities</a></li>
                    <li><a href="#testimonial" class="scroll">Carrier</a></li>
                    <li><a href="#testimonial" class="scroll">Free Trial</a></li>
                    <li><a href="#contact" class="scroll">Contact</a></li>
                    <li><a href="frmLogin.aspx" class="scroll">My Intensity</a></li>
                </ul>
            </div>
            <!-- End Navigation Menu -->
        </div>
        <!-- End Navigation Inner -->
    </section>
    <!-- End Navigation Section -->
    <!-- Home Section -->
    <section id="home" class="relative">
        <div id="slides">
            <div class="slides-container relative">
                <!-- Slider Images -->
                <div class="image2"></div>
                <div class="image1"></div>
                <div class="image3"></div>
                <div class="image4"></div>
                <div class="image5"></div>
                <div class="image6"></div>
                <%--<div class="image7"></div>
                <div class="image8"></div>
                <div class="image9"></div>
                <div class="image10"></div>
                <div class="image11"></div>
                <div class="image12"></div>
                <div class="image13"></div>
                <div class="image14"></div>
                <div class="image15"></div>
                <div class="image16"></div>
                <div class="image17"></div>
                <div class="image18"></div>
                <div class="image19"></div>
                <div class="image20"></div>
                <div class="image21"></div>
                <div class="image22"></div>
                <div class="image23"></div>
                <div class="image24"></div>
                <div class="image25"></div>--%>
                <!-- End Slider Images -->
            </div>
            <!-- Slider Controls -->
            <nav class="slides-navigation">
                <a href="#" class="next"></a>
                <a href="#" class="prev"></a>
            </nav>
        </div>
        <!-- End Home Slides -->
        <div class="v2 absolute">
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
        </div>
        <!-- End V2 area -->
    </section>
    <!-- End Home Section -->
    <!-- Fun Acts -->
    <section id="fun-acts" class="container">
        <div class="inner fun-acts">
            <div class="about-margin"></div>
            <a class="about-icon">
                <i class="fa fa-life-ring"></i>
            </a>
            <br />
            <!-- Header -->
            <h1 class="header light gray1 animated" data-animation="fadeInLeft" data-animation-delay="400">Winners Train,<span class="colored" data-animation="fadeInRight">Losers Complain</span>
            </h1>
            <!-- Description -->
            <p class="h-desc"><span class="colored">lorem Ipsum is lorem Ipsum</span> lorem Ipsum is simply dummy text of the printing and typesetting industry loremipsum. lorem Ipsum is simply dummy text of the printing and typesetting industry loremipsum is simple.</p>
        </div>
        <!-- End Fun Acts Inner -->
    </section>
    <!-- End Fun Acts Section -->
    <!-- About -->
    <section id="about" class="container waypoint">
        <div class="inner">

            <!-- Header -->
            <h1 class="header light gray3 fancy"><span class="colored">Know </span>about us</h1>
            <!-- Description -->
            <p class="h-desc gray4">
                lorem Ipsum is<span class="colored bold"> lorem Ipsum</span> of passages of Lorem Ipsum available, but the majority have suffered alteration.<br />
                <br />
            </p>
            <hr />

            <!-- Boxes -->
            <div class="boxes">

                <div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="100">
                    <p class="lead">Pressure check up</p>
                    <hr />
                    <br />
                    <a class="about-icon">
                        <i class="fa fa-stethoscope"></i>
                    </a>
                    <br />
                    <br />
                    <p class="light about-text">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority.</p>
                </div>

                <div class="col-xs-3 col-sm-6 col-md-3 about-box animated" data-animation="fadeIn" data-animation-delay="300">
                    <p class="lead">Max. gym equipments</p>
                    <hr />
                    <br />
                    <a class="about-icon">
                        <i class="fa fa-wheelchair"></i>
                    </a>
                    <br />
                    <br />
                    <p class="light about-text">lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority.</p>
                </div>

                <div class="col-xs-12 col-md-6 col-sm-12 about-box animated" data-animation="fadeIn" data-animation-delay="700">
                    <p class="lead lead-text">Best in the city</p>
                    <hr>
                    <p class="left pro-bars" style="color: rgb(83, 205, 181);">Treadmill </p>
                    <div class="pro-bar-container color-green-sea">
                        <div class="pro-bar bar-100 color-turquoise" data-pro-bar-percent="100">
                            <div class="pro-bar-candy candy-ltr"></div>
                        </div>
                    </div>
                    <p class="left pro-bars" style="color: #3498DB;">Spinning </p>
                    <div class="pro-bar-container color-belize-hole">
                        <div class="pro-bar bar-80 color-peter-river" data-pro-bar-percent="80" data-pro-bar-delay="200">
                            <div class="pro-bar-candy candy-ltr"></div>
                        </div>
                    </div>
                    <p class="left pro-bars" style="color: #B483C8;">Cardio </p>
                    <div class="pro-bar-container color-wisteria">
                        <div class="pro-bar bar-70 color-amethyst" data-pro-bar-percent="70" data-pro-bar-delay="300">
                            <div class="pro-bar-candy candy-ltr"></div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- End Boxes -->
        </div>
        <!-- End About Inner -->
    </section>
    <!-- End About Section -->
    <!-- Features -->
    <section id="features" class="container">
        <div class="inner">
            <!-- Header -->
            <h1 class="header light gray1 fancy">Take Our <span class="colored fancy">Virtual Tour</span></h1>
            <!-- Description -->
            <p class="h-desc white bold">Virtual Tour<span class="colored bold"> Description </span></p>
            <div class="features-boxes">
                <!-- Box 1 -->
                <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="0">
                    <!-- Icon -->
                    <a class="f-icon">
                        <i class="fa fa-eye"></i>
                    </a>
                    <!-- Header -->
                    <p class="feature-head">Facility 1</p>
                    <!-- Text -->
                    <p class="feature-text ">Description of Facility 1</p>
                </div>

                <!-- Box 2 -->
                <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="100">
                    <!-- Icon -->
                    <a class="f-icon">
                        <i class="fa fa-tablet"></i>
                    </a>
                    <!-- Header -->
                    <p class="feature-head">Facility 2</p>
                    <!-- Text -->
                    <p class="feature-text ">Description of Facility 2</p>
                </div>

                <!-- Box 3 -->
                <div class="col-xs-4 f-box animated" data-animation="fadeIn" data-animation-delay="200">
                    <!-- Icon -->
                    <a class="f-icon">
                        <i class="fa fa-flask"></i>
                    </a>
                    <!-- Header -->
                    <p class="feature-head">Facility 3</p>
                    <!-- Text -->
                    <p class="feature-text light">Description of Facility 3</p>
                </div>
                <div class="clear"></div>
            </div>
            <!-- End Features Boxes -->
        </div>
        <!-- End Features Inner -->
    </section>
    <!-- End Features Section -->
    <!-- Clients -->
    <section id="clients" class="container">
        <!-- Team Inner -->
        <div class="inner team">
            <!-- Header -->
            <h1 class="header light gray3 fancy"><span class="colored">Facilities </span>Provided by us</h1>
            <!-- Description -->
            <p class="h-desc gray4">Description of<span class="colored bold"> Facilities</span></p>

            <!-- Members -->
            <div class="team-members inner-details">
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="0">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/11.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 1</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 1</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Link -->
                                    <a href="#"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="100">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/22.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 2</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 2</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Image -->
                                    <a href="#"><i class="fa fa-camera"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="200">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/33.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 3</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 3</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Link -->
                                    <a href="#"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="300">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/44.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 4</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 4</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Image -->
                                    <a href="#"><i class="fa fa-camera"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="400">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/55.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 5</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 5</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Link -->
                                    <a href="#"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="0">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/66.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 6</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 6</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Link -->
                                    <a href="#"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="100">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/77.png" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 7</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 7</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Image -->
                                    <a href="#"><i class="fa fa-camera"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="200">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/88.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 8</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 8</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Link -->
                                    <a href="#"><i class="fa fa-link"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
                <!-- Member -->
                <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="500">
                    <div class="member-inner">
                        <!-- Team Member Image -->
                        <a class="team-image">
                            <!-- Img -->
                            <img src="assets/assets/images/clients/99.jpg" alt="" />
                        </a>
                        <div class="member-details">
                            <div class="member-details-inner">
                                <!-- Name -->
                                <h2 class="member-name light">Facility 9</h2>
                                <!-- Description -->
                                <p class="member-description">Description of Facility 9</p>
                                <!-- Socials -->
                                <div class="socials">
                                    <!-- Image -->
                                    <a href="#"><i class="fa fa-camera"></i></a>
                                </div>
                                <!-- End Socials -->
                            </div>
                            <!-- End Detail Inner -->
                        </div>
                        <!-- End Details -->
                    </div>
                    <!-- End Member Inner -->
                </div>
                <!-- End Member -->
            </div>
            <!-- End Members -->
        </div>
        <!-- End Team Inner -->
    </section>
    <!-- End Team Section -->
    <!-- Testimonials -->
    <section id="testimonial" class="testimonials parallax2">
        <div class="inner">
            <!-- Header -->
            <h1 class="header light gray3 fancy"><span class="colored">Our </span>Carriers</h1>
            <!-- Description -->
            <p class="h-desc gray4">Description of<span class="colored bold"> Carriers</span></p>
            <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
                <!-- Indicators -->
                <ol class="carousel-indicators">
                    <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="1"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="2"></li>
                    <li data-target="#carousel-example-generic" data-slide-to="3"></li>
                </ol>
                <!-- Wrapper for slides -->
                <div class="carousel-inner">
                    <div class="item active">
                        <ul>
                            <li class="monial">
                                <!-- Text -->
                                <h1 class="condensed white"><span class="colored">Carrier 1</span> Description</h1>
                                <!-- Name -->
                                <p class="light">John Doe</p>
                            </li>
                        </ul>
                    </div>
                    <div class="item">
                        <ul>
                            <li class="monial">
                                <!-- Text -->
                                <h1 class="condensed white"><span class="colored">Carrier 2</span> Description</h1>
                                <!-- Name -->
                                <p class="light">Jane Doe</p>
                            </li>
                        </ul>
                    </div>
                    <div class="item">
                        <ul>
                            <li class="monial">
                                <!-- Text -->
                                <h1 class="condensed white"><span class="colored">Carrier 3</span> Description</h1>
                                <!-- Name -->
                                <p class="light">Severe Dane</p>
                            </li>
                        </ul>
                    </div>
                    <div class="item">
                        <ul>
                            <li class="monial">
                                <!-- Text -->
                                <h1 class="condensed white"><span class="colored">Carrier 4</span> Description</h1>
                                <!-- Name -->
                                <p class="light">Severe Dane</p>
                            </li>
                        </ul>
                    </div>
                </div>

            </div>
        </div>
        <!-- End Inner Div -->
    </section>
    <!-- End Testimonials Section -->
    <!-- Blockquote -->
    <section id="blockquote">
        <div class="inner no-padding">
            <!-- Your Text -->
            <p class="normal gray1 blockquote fancy">
                This is our Client's motivation, we work with Passion!
                <a href="#about" class="scroll"><i class="fa fa-arrow-right"></i></a>
            </p>
        </div>
    </section>
    <!-- End Blockquote Section -->
    <!-- Contact Section -->
    <section id="contact" class="container parallax4">
        <!-- Contact Inner -->
        <div class="inner contact">
            <!-- Form Area -->
            <div class="contact-form">

                <h4 class="header light gray3 fancy"><span class="colored">Contact</span> Us</h4>
                <p class="h-desc gray3">
                    lorem Ipsum is lorem Ipsum of passages of Lorem Ipsum available, but the majority have suffered alteration.<br />
                    Email us or give us a call at <span class="bold colored">+1 (800) 245-1234.</span>
                </p>
                <!-- Form -->
                <form id="contact-us" method="post" action="#">
                    <!-- Left Inputs -->
                    <div class="col-xs-6 animated" data-animation="fadeInLeft" data-animation-delay="300">
                        <!-- Name -->
                        <input type="text" name="name" id="name" required="required" class="form" placeholder="Name" />
                        <!-- Email -->
                        <input type="email" name="mail" id="mail" required="required" class="form" placeholder="Email" />
                        <!-- Subject -->
                        <input type="text" name="subject" id="subject" required="required" class="form" placeholder="Subject" />
                    </div>
                    <!-- End Left Inputs -->
                    <!-- Right Inputs -->
                    <div class="col-xs-6 animated" data-animation="fadeInRight" data-animation-delay="400">
                        <!-- Message -->
                        <textarea name="message" id="message" class="form textarea" placeholder="Message"></textarea>
                    </div>
                    <!-- End Right Inputs -->
                    <!-- Bottom Submit -->
                    <div class="relative fullwidth col-xs-12">
                        <!-- Send Button -->
                        <button type="submit" id="submit" name="submit" class="form-btn semibold">Send Message</button>
                    </div>
                    <!-- End Bottom Submit -->
                    <!-- Clear -->
                    <div class="clear"></div>
                </form>
                <!-- Your Mail Message -->
                <div class="mail-message-area">
                    <!-- Message -->
                    <div class="alert gray-bg mail-message not-visible-message">
                        <strong>Thank You !</strong> Your email has been delivered.
                    </div>
                </div>
            </div>
            <!-- End Contact Form Area -->
        </div>
        <!-- End Inner -->
    </section>
    <!-- End Contact Section -->
    <!-- Site Socials and Address -->
    <section id="site-socials" class="no-padding">
        <div class="site-socials inner no-padding">
            <!-- Socials -->
            <div class="socials animated" data-animation="fadeInLeft" data-animation-delay="400">
                <!-- Facebook -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-facebook"></i>
                </a>
                <!-- Twitter -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-twitter"></i>
                </a>
                <!-- Instagram -->
                <a href="#" class="social">
                    <i class="fa fa-instagram"></i>
                </a>
                <!-- Linkedin -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-linkedin"></i>
                </a>
                <!-- Vimeo -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-vimeo-square"></i>
                </a>
                <!-- Youtube -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-youtube"></i>
                </a>
                <!-- Google Plus -->
                <a href="#" target="_blank" class="social">
                    <i class="fa fa-google-plus"></i>
                </a>
            </div>
            <!-- Adress, Mail -->
            <div class="address socials animated" data-animation="fadeInRight" data-animation-delay="500">
                <!-- Phone Number, Mail -->
                <p>Phone: +1 (800) 245-1234 Email : <a href="mailto:info@Fitness.com" class="colored">info@Fitness.com</a> Address: 23 Renesa, Surma Beach, Newyork</p>
                <!-- Top Button -->
                <a href="#home" class="scroll top-button">
                    <i class="fa fa-arrow-circle-up fa-2x"></i>
                </a>
            </div>
            <!-- End Adress, Mail -->
        </div>
        <!-- End Inner -->
    </section>
    <!-- End Site Socials and Address -->
    <!-- Footer -->
    <footer id="footer" class="footer">
        <!-- Your Company Name -->
        <img src="assets/assets/images/logo-icon.png" width="200" alt="Logo" />
        <!-- Copyright -->
        <p class="copyright normal">© 2014 <span class="colored">Fitness.</span> All Rights Reserved.</p>
    </footer>
    <!-- End Footer -->
    <!-- JS Files -->
    <script src="assets/assets/js/jquery-1.11.0.min.js"></script>
    <script src="assets/assets/js/bootstrap.min.js"></script>
    <script src="assets/assets/js/jquery.appear.js"></script>
    <script src="assets/assets/js/jquery.prettyPhoto.js"></script>
    <script src="assets/assets/js/modernizr-latest.js"></script>
    <script src="assets/assets/js/SmoothScroll.js"></script>
    <script src="assets/assets/js/jquery.parallax-1.1.3.js"></script>
    <script src="assets/assets/js/jquery.easing.1.3.js"></script>
    <script src="assets/assets/js/jquery.superslides.js"></script>
    <script src="assets/assets/js/jquery.flexslider.js"></script>
    <script src="assets/assets/js/jquery.mb.YTPlayer.js"></script>
    <script src="assets/assets/js/jquery.fitvids.js"></script>
    <script src="assets/assets/js/jquery.slabtext.js"></script>
    <script src="assets/assets/js/plugins.js"></script>
    <script>

        $("a.about-icon").hover(function () {
            $(this).children("i").addClass("fa-spin");
        }, function () {
            $(this).children("i").removeClass("fa-spin");
        });

    </script>
</body>
</html>
