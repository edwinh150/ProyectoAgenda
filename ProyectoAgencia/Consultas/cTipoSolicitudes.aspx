<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="cTipoSolicitudes.aspx.cs" Inherits="ProyectoAgencia.Consultas.cTipoSolicitudes" %>
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
                    <li class="active">Consulta de Tipo de Solicitudes</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
    <div class="panel panel-primary">
        <div class="panel-heading">Consultar de Tipo de Solicitudes</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">

                    <%--Consultar--%>
                    <div class="form-group">
                        <asp:Label For="CodigoTextBox" ID="Label1" class="col-md-3 control-label input-sm" runat="server" Text=" Consultar por"></asp:Label>
                        <div class="col-lg-2 col-md-2">
                             <asp:DropDownList ID="TipoSolicitudDropDownList" CssClass="form-control" runat="server" Height="38px">
                                 <asp:ListItem Value="TipoSolicitud">Id de Solicitudes</asp:ListItem>
                                 <asp:ListItem Value="Descripcion">Descripcion</asp:ListItem>
                             </asp:DropDownList>
                        </div>
                        <div id="CodigoDiv" runat="server" class="col-lg-4 col-md-4">
                            <asp:TextBox ID="CodigoTextBox" runat="server" CssClass="form-control" placeholder="Escribe un caracter valido" MaxLength="50"></asp:TextBox>
                        </div>
                        <div class="col-xs-1 col-sm-1 col-lg-2 col-md-2">
                            <asp:Button ID="BuscarButton" CssClass="btn btn-primary" OnClick="BuscarButton_Click" runat="server" Text="Buscar" /> 
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
