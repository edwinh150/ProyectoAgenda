<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rUsuarios.aspx.cs" Inherits="ProyectoAgencia.Registros.rUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <!-- /.row -->
    <div class="row">
            <div class="col-md-8">
                <h3>Ingrese Sus Datos</h3>
                <form name="RegistroUsuario" id="RegistroUsuarioForm" novalidate>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label5" runat="server" Text="Usuario Id"></asp:Label>
                            <asp:TextBox ID="UsuarioIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id"></asp:TextBox>
                            <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario"></asp:Label>
                            <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre de Usuario"></asp:TextBox>
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label2" runat="server" Text="Contrasena"></asp:Label>
                            <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Contrasena"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label7" runat="server" Text="Nombre"></asp:Label>
                            <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                            <p class="help-block"></p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label8" runat="server" Text="Apellido"></asp:Label>
                            <asp:TextBox ID="ApellidoTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Apellido"></asp:TextBox>
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
                            <asp:Label ID="Label9" runat="server" Text="Telefono"></asp:Label>
                            <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" placeholder="Escriba su Telefono" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento"></asp:Label>
                            <asp:TextBox ID="FechaNacimientoTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label6" runat="server" Text="Tipo de Usuario"></asp:Label>
                            <asp:DropDownList ID="TipoUsuarioDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                    <asp:Button ID="ModificarButton" CssClass="btn btn-primary" runat="server" Text="Modificar" OnClick="ModificarButton_Click" />
                    <asp:Button ID="EliminarButton" CssClass="btn btn-danger" runat="server" Text="Eliminar" OnClick="EliminarButton_Click" />
                </form>
            </div>
        </div>
    </div>
</asp:Content>
