﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registrar.aspx.cs" Inherits="ProyectoAgencia.Registrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
    <div class="row">
            <div class="col-md-8">
                <h3>Ingrese Sus Datos</h3>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label5" runat="server" Text="Nombre de Usuario" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="NombreUsuarioTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre de Usuario"></asp:TextBox>
                            <p class="help-block">
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" errormessage="Por Favor Entre su Nombre de Usuario" controltovalidate="NombreUsuarioTextBox" runat="server">
                                    </asp:requiredfieldvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label6" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="ContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Contrasena" TextMode="Password"></asp:TextBox>
                            <p class="help-block">
                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" errormessage="Por Favor Entre su Contrasena" controltovalidate="ContrasenaTextBox" runat="server">
                                    </asp:requiredfieldvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label8" runat="server" Text="Contrasena" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="RepetirContrasenaTextBox" runat="server" CssClass="form-control" placeholder="Escriba de nuevo su Contrasena" TextMode="Password"></asp:TextBox>
                            <p class="help-block">
                                 <asp:requiredfieldvalidator id="RequiredFieldValidator7" forecolor="Red" errormessage="Por Favor Entre su Contrasena" controltovalidate="RepetirContrasenaTextBox" runat="server">
                                 </asp:requiredfieldvalidator>
                                 <asp:CompareValidator ID="CompareValidator1" runat="server" forecolor="Red" errormessage="La contrasena no Coincide" controltovalidate="RepetirContrasenaTextBox" ControlToCompare="ContrasenaTextBox"></asp:CompareValidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label1" runat="server" Text="Nombre" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="NombreTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Nombre"></asp:TextBox>
                            <p class="help-block">
                                <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" errormessage="Por Favor Entre su Nombre" controltovalidate="NombreTextBox" runat="server">
                                 </asp:requiredfieldvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label2" runat="server" Text="Apellido" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="ApellidoTextBox" runat="server" CssClass="form-control" placeholder="Escriba su Apellido"></asp:TextBox>
                            <p class="help-block">
                                <asp:requiredfieldvalidator id="RequiredFieldValidator4" forecolor="Red" errormessage="Por Favor Entre su Apellido" controltovalidate="ApellidoTextBox" runat="server">
                                 </asp:requiredfieldvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label3" runat="server" Text="Correo Electronico" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="EmailTextBox" CssClass="form-control" runat="server" placeholder="Escriba su Email" TextMode="Email"></asp:TextBox>
                            <p class="help-block">
                                <asp:regularexpressionvalidator validationexpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" errormessage="Invalido Formato de Correo." forecolor="Red" controltovalidate="EmailTextBox" runat="server">
                                </asp:regularexpressionvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label7" runat="server" Text="Telefono" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="TelefonoTextBox" CssClass="form-control" placeholder="Escriba su Telefono" runat="server" TextMode="Phone" MaxLength="11"></asp:TextBox>
                            <p class="help-block">
                                <asp:requiredfieldvalidator id="RequiredFieldValidator5" forecolor="Red" errormessage="Por Favor Entre su Telefono" controltovalidate="TelefonoTextBox" runat="server">
                                 </asp:requiredfieldvalidator>
                            </p>
                        </div>
                    </div>
                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label4" runat="server" Text="Fecha de Nacimiento" Font-Bold="True"></asp:Label>
                            <asp:TextBox ID="FechaNacimientoTextBox" CssClass="form-control" runat="server" TextMode="DateTimeLocal"></asp:TextBox>
                            <p class="help-block">
                             <!--    <asp:requiredfieldvalidator id="RequiredFieldValidator6" forecolor="Red" errormessage="Por Favor Entre su Fecha de Nacimiento" controltovalidate="FechaNacimientoTextBox" runat="server">
                                 </asp:requiredfieldvalidator> -->
                            </p>
                        </div>
                    </div>
                    <div id="success"></div>
                    <!-- For success/fail messages -->
                    <asp:Button ID="GuardarButton" CssClass="btn btn-primary" runat="server" Text="Registrarse" OnClick="GuardarButton_Click" />

            </div>
        </div>
    </div>
</asp:Content>
