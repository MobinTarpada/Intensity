<%@ Page Title="" Language="C#" MasterPageFile="~/Design.Master" AutoEventWireup="true" CodeBehind="VirtualTour.aspx.cs" Inherits="FitnessCenter.VirtualTour" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <section id="features" class="container waypoint">
                <div class="inner">
                    <!-- Header -->
                    <h1 class="header light white fancy"><span class="colored">Virtual </span>Tour</h1>
                    <!-- Description -->
                    <p class="h-desc white">
                        <asp:ListView ID="lvVideo" runat="server" OnItemDataBound="lvVideo_ItemDataBound">
                            <ItemTemplate>
                                <div class="col-lg-6">
                                    <asp:HiddenField ID="hfId" runat="server" Value='<%#Eval("ID") %>' />
                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("name") %>' CssClass="white"></asp:Label>
                                    <br />
                                    <video id="video" runat="server" width="420" height="315" controls></video>
                                    <%--<iframe id="video" runat="server" width="420" height="315" frameborder="0" allowfullscreen></iframe>--%>
                                </div>
                            </ItemTemplate>
                        </asp:ListView>
                    </p>
                </div>
            </section>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
