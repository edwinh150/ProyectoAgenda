<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoAgencia.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
                <br /><br />
                <br /><br />
      
        <!-- Header Carousel -->
    <header id="myCarousel" class="carousel slide" style="left: -5px; top: -101px; height: 277px; bottom: 101px">
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
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('/Contenido/Crucero.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Cruceros</h2>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image:url('/Contenido/luxury-hotel.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Hoteles y Resorts</h2>
                </div>
            </div>
        </div>

        <!-- Controls -->
        <a class="left carousel-control" href="#myCarousel" data-slide="prev" style="left: 0; top: 2px; bottom: 0; width: 15%">
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
                <div class="text-center">
                    <asp:Button ID="CerrarSessionButton" CssClass="btn btn-danger" runat="server" Text="Cerrar Session" OnClick="CerrarSessionButton_Click" /> 
                </div>
            </div>
        </div>
     </div>
</asp:Content>
