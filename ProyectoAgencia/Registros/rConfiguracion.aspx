<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rConfiguracion.aspx.cs" Inherits="ProyectoAgencia.Registros.rConfiguracion" %>

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
                <h1 class="page-header">Configuracion
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default.aspx">Principal</a>
                    </li>
                    <li class="active">Registro de Configuraciones</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
            <div class="panel-heading">Registros de Configuraciones</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <h3>Ingrese Su Configuracion</h3>
                    <div class="col-md-12">
                        <div class="form-group">
                            <div class="col-md-2 col-xs-2">
                                <asp:Label ID="Label5" For="ConfiguracionTextBox" runat="server" Font-Bold="true" Text="Ingrese su Impuesto"></asp:Label>
                            </div>
                            <div id="ConfiguracionDiv" runat="server" class="col-md-8 col-xs-8">
                                <asp:TextBox ID="ConfiguracionTextBox" MaxLength="4" runat="server" CssClass="form-control" placeholder="Escriba su Impuesto" TextMode="Search" Font-Bold="True"></asp:TextBox>
                            </div>
                            <div class="col-md-2 col-xs-2">
                                <asp:Button ID="GuardarButton" CssClass="btn btn-success" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
