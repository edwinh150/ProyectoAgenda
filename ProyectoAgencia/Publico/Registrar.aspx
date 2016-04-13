<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ProyectoAgencia.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet"/>
    <link href="../css/toastr.min.css" rel="stylesheet" />
        
    <script src=" ../js/jquery-2.2.0.js"></script>

    <!-- Bootstrap Core JavaScript -->
    <script src="../js/bootstrap.min.js"></script>

    <script src="../js/toastr.min.js"></script>
    <div class="container col-md-12">
    <div class="row">
            <div class="form-horizontal col-md-12" role="form">
                <h3>Ingrese Sus Datos</h3>
                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre de Usuario" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="NombreUsuarioDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="NombreUsuarioTextBox" MaxLength="50" runat="server" CssClass="form-control" placeholder="Escriba su Nombre de Usuario"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label2" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="ContrasenaDiv" runat="server" class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="ContrasenaTextBox" MaxLength="50" runat="server" CssClass="form-control" placeholder="Escriba su Contrasena" TextMode="Password"></asp:TextBox>
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label10" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="RepetirContrasenaTextBox" MaxLength="50" runat="server" CssClass="form-control" placeholder="Escriba de nuevo su Contrasena" TextMode="Password"></asp:TextBox>
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
                                    <asp:TextBox ID="NombreTextBox" MaxLength="50" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label8" runat="server" Text="Apellido" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="ApellidoDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="ApellidoTextBox" MaxLength="50" runat="server" CssClass="form-control" placeholder="Escriba su Apellido"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label3" runat="server" Text="Correo Electronico" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="EmailDiv" runat="server" class="col-md-8 col-xs-8">                                   
                                    <asp:TextBox ID="EmailTextBox" MaxLength="30" CssClass="form-control" runat="server" placeholder="Escriba su Email" TextMode="Email"></asp:TextBox>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label9" runat="server" type="phone" Text="Telefono" Font-Bold="True"></asp:Label>
                                </div>
                                <div id="TelefonoDiv" runat="server" class="col-md-8 col-xs-8">                                    
                                    <asp:TextBox ID="TelefonoTextBox" MaxLength="10" CssClass="form-control" placeholder="Escriba su Telefono" runat="server" type="Phone"></asp:TextBox>
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
                    <asp:Button ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="GuardarButton_Click" />
            </div>
        </div>
    </div>
</asp:Content>
