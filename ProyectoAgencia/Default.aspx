<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoAgencia.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    

        <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide" style="left: 0px; top: 2px; height: 303px; bottom: -9px">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner">
            <div class="item active">
                <div class="fill" style="background-image:url('/Contenido/aviones.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Vuelos</h2>
                    <asp:Button ID="VueloButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Reservar" OnClick="VueloButton_Click" />
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('/Contenido/Crucero.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Cruceros</h2>
                     <asp:Button ID="CruceroButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Reservar" OnClick="CruceroButton_Click" />
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('/Contenido/luxury-hotel.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Hoteles y Resorts</h2>
                     <asp:Button ID="HotelResortButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Reservar" OnClick="HotelResortButton_Click" />
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev">
            <span class="icon-prev"></span>
        </a>
        <a class="right carousel-control" href="#myCarousel" data-slide="next">
            <span class="icon-next"></span>
        </a>
    </header>
    <!-- Page Content -->

    <div class="container">

        <!-- Marketing Icons Section -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="text-center">
                    Bienvenido a Agencia de Viajes Hidalgo
                </h1>
            </div>
        </div>
     </div>
</asp:Content>
