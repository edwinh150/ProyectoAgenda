<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cPerfilNotificaciones.aspx.cs" Inherits="ProyectoAgencia.Consultas.cPerfilNotificaciones" %>

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
                <h1 class="page-header">Consultar Mis Solicitudes y Reservaciones
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default.aspx">Principal</a>
                    </li>
                    <li class="active">Perfil:Listado Actual</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
            <div class="panel-heading">Solicitudes Hechas:</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="col-md-12">
                        <div class="form-group">
                            <%--Grid--%>
                            <div class="table table-responsive col-md-12">
                                <asp:GridView ID="SolicitudesGridView" runat="server" Width="100%" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="true">
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="SolicitudId" DataNavigateUrlFormatString="~/Registros/rReservaciones.aspx?Id={0}" Text="Aceptar" HeaderText="Eleccion" />
                                    </Columns>
                                </asp:GridView>
                            </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="panel panel-primary">
            <div class="panel-heading">Reservaciones Hechas:</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="col-md-12">
                        <div class="form-group">
                            <%--Grid--%>
                            <div class="table table-responsive col-md-12">
                                <asp:GridView ID="ReservacionesGridView" runat="server" Width="100%" CssClass="table table-bordered table-hover table-striped" AutoGenerateColumns="true">
                                    <Columns>
                                        <asp:HyperLinkField DataNavigateUrlFields="ReservacionId" DataNavigateUrlFormatString="~/Registros/rReservaciones.aspx?Id={0}" Text="Aceptar" HeaderText="Eleccion" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
