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
                <div class="fill" style="background-image: url('/Contenido/aviones.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Vuelos</h2>
                    <div class="btn-group">
                        <asp:Button ID="VueloButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Solicitar" OnClick="VueloButton_Click" />
                        <asp:Button ID="rVueloButton" CssClass="btn btn-primary" ForeColor="Black" runat="server" Text="Reservar" OnClick="rVueloButton_Click" />
                    </div>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image: url('/Contenido/Crucero.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Cruceros</h2>
                    <div class="btn-group">
                        <asp:Button ID="CruceroButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Solicitar" OnClick="CruceroButton_Click" />
                        <asp:Button ID="rCruceroButton" CssClass="btn btn-default" ForeColor="Black" runat="server" Text="Reservar" OnClick="rCruceroButton_Click" />
                    </div>
                </div>
            </div>
            <div class="item">
                <div class="fill" style="background-image: url('/Contenido/luxury-hotel.jpg');"></div>
                <div class="carousel-caption">
                    <h2>Hoteles y Resorts</h2>
                    <div class="btn-group">
                        <asp:Button ID="HotelResortButton" CssClass="btn btn-toolbar" ForeColor="Black" runat="server" Text="Solicitar" OnClick="HotelResortButton_Click" />
                        <asp:Button ID="rHotelResortButton" CssClass="btn btn-warning" ForeColor="Black" runat="server" Text="Reservar" OnClick="rHotelResortButton_Click" />
                    </div>
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
                <h1 class="text-center">Bienvenido a Agencia de Viajes Edwin Hidalgo Beta
                </h1>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4><i class="fa fa-fw fa-check"></i>El Mas Confiable</h4>
                </div>
                <div class="panel-body">
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                    <a href="#" class="btn btn-default">Leer Mas</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4><i class="fa fa-fw fa-gift"></i>Muchas Ofertas</h4>
                </div>
                <div class="panel-body">
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                    <a href="#" class="btn btn-default">Leer Mas</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="panel panel-default">
                <div class="panel-heading">
                    <h4><i class="fa fa-fw fa-compass"></i>Facil de Reservar </h4>
                </div>
                <div class="panel-body">
                    <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit. Itaque, optio corporis quae nulla aspernatur in alias at numquam rerum ea excepturi expedita tenetur assumenda voluptatibus eveniet incidunt dicta nostrum quod?</p>
                    <a href="#" class="btn btn-default">Leer Mas</a>
                </div>
            </div>
        </div>
        <!-- Portfolio Section -->
        <div class="row">
            <div class="col-lg-12">
                <h2 class="page-header">Ofertas de Este Mes</h2>
            </div>
            <div class="col-md-4 col-sm-6">
                <a href="/Publico/Servicios.aspx">
                    <img class="img-responsive img-portfolio img-hover" src="http://placehold.it/700x450" alt="">
                </a>
            </div>
            <div class="col-md-4 col-sm-6">
                <a href="/Publico/Servicios.aspx">
                    <img class="img-responsive img-portfolio img-hover" src="http://placehold.it/700x450" alt="">
                </a>
            </div>
            <div class="col-md-4 col-sm-6">
                <a href="/Publico/Servicios.aspx">
                    <img class="img-responsive img-portfolio img-hover" src="http://placehold.it/700x450" alt="">
                </a>
            </div>
        </div>
    </div>
</asp:Content>
