<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="ProyectoAgencia.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
            <div class="text-center">
                <div class="row">
                    <div class="col-md-3">
                        </div>
                    <div class="col-md-6">
                        <h3>Inicio de Session</h3>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label1" runat="server" Text="Nombre Usuario"></asp:Label>
                                        <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                                    <p class="help-block">
                                        <asp:RequiredFieldValidator ControlToValidate="NombreTextBox" ErrorMessage="Por Favor Ingrese Su Nombre de Usuario" ID="NombreValidacion" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                                    </p>
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label2" runat="server" Text="Contrasena"></asp:Label>
                                    <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Contrasena" TextMode="Password"></asp:TextBox>
                                    <p class="help-block">
                                        <asp:RequiredFieldValidator ControlToValidate="ContrasenaTextBox" ErrorMessage="Por Favor Ingrese Una Contrasena" ID="ContrasenaValidacion" ForeColor="Red" runat="server"></asp:RequiredFieldValidator>
                                    </p>
                                </div>
                            </div>
                            <div class="btn-group">
                                <asp:Button ID="IniciarButton" CssClass="btn btn-primary" runat="server" Text="Iniciar Session" OnClick="IniciarButton_Click" />
                                <asp:Button ID="RegistrarButton" CssClass="btn btn-link" runat="server" Text="Registrarte" OnClick="RegistrarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
        </div>
</asp:Content>
