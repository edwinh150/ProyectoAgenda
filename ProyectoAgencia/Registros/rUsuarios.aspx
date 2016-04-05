<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoAgencia.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/toastr.min.css" rel="stylesheet" />
        
    <script src=" ../js/jquery-2.2.0.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/toastr.min.js"></script>

        <!-- Page Content -->
    <div class="container">

        <!-- Page Heading/Breadcrumbs -->
        <div class="row">
            <div class="container col-md-12">
                <h1 class="page-header">Registrar
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default.aspx">Principal</a>
                    </li>
                    <li class="active">Registro de Usuario</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
        <div class="panel-heading">Registros de Usuarios</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
                <h3>Ingrese Sus Datos</h3>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label5" For="UsuarioIdTextBox" runat="server" Font-Bold="true" Text="Id por Usuario"></asp:Label>
                                </div>
                                <div id="UsuarioIdDiv" runat="server" class="col-md-4 col-xs-4">
                                    <asp:TextBox ID="UsuarioIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id" TextMode="Search" Font-Bold="True"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-xs-2">
                                    <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="NombreUsuarioDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre de Usuario"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label2" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="ContrasenaDiv" runat="server" class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Contrasena" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label10" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="RepetirContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba de nuevo su Contrasena" TextMode="Password"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-xs-2">
                                    <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="GuardarButton" forecolor="Red" errormessage="No Coincide" controltovalidate="RepetirContrasenaTextBox" ControlToCompare="ContrasenaTextBox"></asp:CompareValidator>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label7" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="NombreDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label8" runat="server" Text="Apellido" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="ApellidoDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="ApellidoTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Apellido"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label3" runat="server" Text="Correo Electronico" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="EmailDiv" runat="server" class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" placeholder="Escriba su Email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label9" runat="server" type="phone" Text="Telefono" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="TelefonoDiv" runat="server" class="col-md-8 col-xs-8">                                    
                                    <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" placeholder="Escriba su Telefono" runat="server" type="Phone"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento" Font-Bold="True"></asp:Label>
                                 </div>
                                <div class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="FechaNacimientoTextBox" type="date" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label6" runat="server" Text="Tipo de Usuario" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-8 col-xs-8">
                                    <asp:DropDownList ID="TipoUsuarioDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <center>
                                <div class="btn-group text-center">
                                    <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                                    <asp:Button ID="LimpiarButton" CssClass="btn btn-warning" runat="server" Text="Limpiar" OnClick="LimpiarButton_Click" />
                                    <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                                </div>
                            </center>
                </div>
            </div>
        </div>
      </div>
</asp:Content>
