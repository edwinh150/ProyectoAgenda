<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rCompanias.aspx.cs" Inherits="ProyectoAgencia.Registros.rCompanias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="../css/bootstrap.min.css" rel="stylesheet" />
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
                    <li class="active">Registro de Compañias</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
            <div class="panel-heading">Registros de Compañias</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <h3>Ingrese Sus Datos</h3>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-2 col-xs-2">
                                <asp:Label ID="Label5" For="CompaniaIdTextBox" runat="server" Font-Bold="true" Text="Id por Compañia"></asp:Label>
                            </div>
                            <div id="CompaniaIdDiv" runat="server" class="col-md-8 col-xs-8">
                                <asp:TextBox ID="CompaniaIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id" TextMode="Search" Font-Bold="True"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-xs-2">
                                <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                            </div>
                        </div>

                        <div class="form-group">
                            <div class="col-md-2 col-xs-2">
                                <asp:Label ID="Label1" runat="server" Text="Descripcion" Font-Bold="True"></asp:Label>
                            </div>
                            <div id="DescripcionDiv" runat="server" class="col-md-8 col-xs-8">
                                <asp:TextBox ID="DescripcionTextBox" runat="server" CssClass="form-control" placeholder="Escriba una Descripcion"></asp:TextBox>
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
                                <asp:Label ID="Label6" runat="server" Text="Tipo de Compañia" Font-Bold="True"></asp:Label>
                            </div>
                            <div id="TipoCompaniaDiv" runat="server" class="col-md-8 col-xs-8">
                                <asp:DropDownList ID="TipoCompaniaDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
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
</asp:Content>
