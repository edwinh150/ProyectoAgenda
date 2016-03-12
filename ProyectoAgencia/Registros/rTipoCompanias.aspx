﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rTipoCompanias.aspx.cs" Inherits="ProyectoAgencia.Registros.rTipoCompanias" %>
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
            <div class="col-md-12">
                <h1 class="page-header">Registrar
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default.aspx">Principal</a>
                    </li>
                    <li class="active">Registro de Tipo de Compañias</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
        <div class="panel-heading">Registros de Tipo de Compañias</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">
                <h3>Ingrese Sus Datos</h3>
                    <div class="col-md-2">
                        </div>
                    <div class="col-md-8">
                        <div class="form-inline" role="form">
                            <div class="control-group form-group">
                                <div class="controls">
                                        <asp:Label ID="Label5" For="CompaniaCruceroIdTextBox" runat="server" Font-Bold="true" Text="Id por Tipo de Comp."></asp:Label>
                                        <asp:TextBox ID="TipoCompaniaIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id" TextMode="Search" Font-Bold="True"></asp:TextBox>
                                        <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                        <p class="help-block"></p>
                                </div>
                            </div>
                        </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label1" runat="server" Text="Descripcion" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="DescripcionTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Tipo de Compañia"></asp:TextBox>
                                    <p class="help-block">
                                         <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" errormessage="Por Favor Entre un Tipo de Compañia" controltovalidate="DescripcionTextBox" runat="server">
                                         </asp:requiredfieldvalidator>
                                    </p>
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
        </div>
      </div>
</asp:Content>