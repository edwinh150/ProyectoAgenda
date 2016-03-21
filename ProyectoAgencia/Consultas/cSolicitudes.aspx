<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cSolicitudes.aspx.cs" Inherits="ProyectoAgencia.Consultas.cSolicitudes" %>
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
            <div class="col-lg-12">
                <h1 class="page-header">Consultar
                </h1>
                <ol class="breadcrumb">
                    <li><a href="/Default.aspx">Principal</a>
                    </li>
                    <li class="active">Consulta de Solicitudes</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
    <div class="panel panel-primary">
        <div class="panel-heading">Consultar de Solicitudes</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">

                    <%--Consultar--%>
                    <div class="form-group">
                        <asp:Label For="CodigoTextBox" ID="Label1" class="col-md-3 control-label input-sm" runat="server" Text=" Consultar por"></asp:Label>
                        <div class="col-lg-2 col-md-2">
                             <asp:DropDownList ID="SolicitudesDropDownList" CssClass="form-control" runat="server" Height="38px">
                                 <asp:ListItem Value="SolicitudId">Id de Solicitud</asp:ListItem>
                                 <asp:ListItem Value="FechaCreacion">Fecha de Creacion</asp:ListItem>
                                 <asp:ListItem Value="Asunto">Asunto</asp:ListItem>
                                 <asp:ListItem Value="UsuarioId">Id de Usuario</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div class="col-lg-4 col-md-4">
                            <asp:TextBox ID="CodigoTextBox" runat="server" CssClass="form-control" placeholder="Escribe un caracter valido"></asp:TextBox>
                        </div>
                        <div class="col-xs-1 col-sm-1 col-lg-2 col-md-2">
                            <asp:Button ID="BuscarButton" runat="server" CssClass="btn btn-primary" OnClick="BuscarButton_Click" Text="Buscar"/>
                        </div>
                        <div class="col-md-1">
                        </div>
                    </div>
                    <%--Grid--%>
                    <div class="table table-responsive col-md-12">
                        <asp:GridView ID="ConsultaGridView" runat="server" Width="100%" CssClass="table table-bordered table-hover table-striped">                         
                        </asp:GridView>
                    </div>
            </div>
        </div>
        </div>
        </div>    
        </div>
</asp:Content>
