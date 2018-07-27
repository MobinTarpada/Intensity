<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="Services.aspx.cs" Inherits="FitnessCenter.Services" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Clients -->
    <section id="clients" class="container waypoint">
        <!-- Team Inner -->
        <div class="inner team">
            <!-- Header -->
            <h1 class="header light gray3 fancy"><span class="colored">Facilities </span>Provided by us</h1>
            <!-- Description -->
            <p class="h-desc gray4">Description of<span class="colored bold"> Facilities</span></p>

            <!-- Members -->
            <div class="team-members inner-details">
                <!-- Member -->
                <asp:ListView runat="server" ID="lstServices">
                    <ItemTemplate>
                        <div class="col-xs-4 member animated" data-animation="fadeInUp" data-animation-delay="0">
                            <div class="member-inner">
                                <!-- Team Member Image -->
                                <a class="team-image">
                                    <!-- Img -->
                                    <img src='<%#Eval("image") %>' alt="" />
                                </a>
                                <div class="member-details">
                                    <div class="member-details-inner">
                                        <!-- Name -->
                                        <h2 class="member-name light"><%#Eval("facilityName") %></h2>
                                        <!-- Description -->
                                        <p class="member-description"><%#Eval("description") %></p>
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
                    </ItemTemplate>
                </asp:ListView>
                <!-- End Member -->
            </div>
            <!-- End Members -->
        </div>
        <!-- End Team Inner -->
    </section>
    <!-- End Team Section -->
</asp:Content>
