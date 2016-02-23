<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ProyectoAgencia.Registrar" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="">

    <title>Agencia de Viajes</title>

    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">

    <!-- Custom CSS -->
    <link href="css/modern-business.css" rel="stylesheet">

    <!-- Custom Fonts -->
    <link href="font-awesome/css/font-awesome.min.css" rel="stylesheet" type="text/css">

    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body>
    <form id="form1" runat="server">
    <div>
           <!-- Navigation -->
    <nav class="navbar navbar-inverse navbar-fixed-top" role="navigation">
        <div class="container">
            <!-- Brand and toggle get grouped for better mobile display -->
            <div class="navbar-header">
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target="#bs-example-navbar-collapse-1">
                    <span class="sr-only">Toggle navigation</span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                    <span class="icon-bar"></span>
                </button>
                <a class="navbar-brand" href="Default.aspx">Inicio</a>
            </div>
            <!-- Collect the nav links, forms, and other content for toggling -->
            <div class="collapse navbar-collapse" id="bs-example-navbar-collapse-1">
                <ul class="nav navbar-nav navbar-right">
                    <li>
                        <a href="about.html">Sobre Nosotros</a>
                    </li>
                    <li>
                        <a href="services.html">Servicios</a>
                    </li>
                    <li>
                        <a href="Contact.aspx">Contactos</a>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Portfolio <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="portfolio-1-col.html">1 Column Portfolio</a>
                            </li>
                            <li>
                                <a href="portfolio-2-col.html">2 Column Portfolio</a>
                            </li>
                            <li>
                                <a href="portfolio-3-col.html">3 Column Portfolio</a>
                            </li>
                            <li>
                                <a href="portfolio-4-col.html">4 Column Portfolio</a>
                            </li>
                            <li>
                                <a href="portfolio-item.html">Single Portfolio Item</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Blog <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="blog-home-1.html">Blog Home 1</a>
                            </li>
                            <li>
                                <a href="blog-home-2.html">Blog Home 2</a>
                            </li>
                            <li>
                                <a href="blog-post.html">Blog Post</a>
                            </li>
                        </ul>
                    </li>
                    <li class="dropdown">
                        <a href="#" class="dropdown-toggle" data-toggle="dropdown">Other Pages <b class="caret"></b></a>
                        <ul class="dropdown-menu">
                            <li>
                                <a href="full-width.html">Full Width Page</a>
                            </li>
                            <li>
                                <a href="sidebar.html">Sidebar Page</a>
                            </li>
                            <li>
                                <a href="faq.html">FAQ</a>
                            </li>
                            <li>
                                <a href="404.html">404</a>
                            </li>
                            <li>
                               
                            </li>
                        </ul>
                    </li>
                    
                </ul>
            </div>
            <!-- /.navbar-collapse -->
        </div>
        <!-- /.container -->
    </nav>
                <br /><br />
            <!-- Page Content -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="col-lg-12">
                <h1 class="page-header">Registrarse
                </h1>
                <ol class="breadcrumb">
                    <li><a href="Default.aspx">Principal</a>
                    </li>
                    <li class="active">Registrarse</li>
                </ol>
            </div>
        </div>
        <!-- /.row aqui empieza el formulario-->
    <div class="row">
            <div class="col-md-8">
                <h3>Ingrese Sus Datos</h3>
                <form name="RegistroUsuario" id="RegistroUsuarioForm" novalidate>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label2" runat="server" Text="Contrasena"></asp:Label>
                            <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Telefono"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label3" runat="server" Text="Correo Electronico"></asp:Label>
                            <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" placeholder="Escriba su Email"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                            <asp:TextBox ID="FechaNacimientoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <asp:Button ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="GuardarButton_Click" />
                </form>
            </div>
        </div>
    </div>
                    <!-- Footer -->
        <footer>
            <div class="row">
                <div class="col-lg-12">
                    <p>Copyright &copy; Mi sitio Edwin Hidalgo Lopez</p>
                </div>
            </div>
        </footer>
    
    </div>
    </form>
</body>
</html>
