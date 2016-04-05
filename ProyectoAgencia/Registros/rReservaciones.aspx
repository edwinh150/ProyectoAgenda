<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rReservaciones.aspx.cs" Inherits="ProyectoAgencia.Registros.rReservaciones" %>

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
                    <li class="active">Registro de Reservaciones</li>
                </ol>
            </div>
        </div>

        <!-- /.row -->
        <div class="panel panel-primary">
            <div class="panel-heading">Registros de Reservaciones</div>
            <div class="panel-body">
                <div class="form-horizontal col-md-12" role="form">
                    <div class="form-group">
                        <h3>Ingrese Sus Datos</h3>
                        <div class="col-md-12">
                            <div class="form-group">
                                <div class="col-md-2 col-xs-2">
                                    <asp:Label ID="Label5" For="ReservacionIdTextBox" runat="server" Font-Bold="true" Text="Id por Reservacion"></asp:Label>
                                </div>
                                <div id="ReservacionIdDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="ReservacionIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id" TextMode="Search" Font-Bold="True"></asp:TextBox>
                                </div>
                                <div class="col-md-2 col-xs-2">
                                    <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                </div>
                            </div>


                            <div class="form-group form-inline">
                                <div class="col-md-3 col-xs-3">
                                </div>
                                <div class="col-md-2">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label4" runat="server" Text="Usuario es" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="UsuarioIdLabel" CssClass=" form-control" runat="server" Text="Usuario"></asp:Label>
                                            <p class="help-block">
                                            </p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-2">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label2" runat="server" Text="Id de Solicitud" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="SolicitudIdLabel" CssClass=" form-control" runat="server" Text="Solicitud"></asp:Label>
                                            <p class="help-block">
                                            </p>
                                        </div>
                                    </div>
                                </div>

                                <div class="col-md-3">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label6" runat="server" Text="Fecha de Solicitud" Font-Bold="True"></asp:Label>
                                            <asp:Label ID="FechaCreacionLabel" CssClass="form-control" runat="server" Text=""></asp:Label>
                                            <p class="help-block">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-12 col-xs-12 text-center">
                                    <asp:Label ID="Label3" runat="server" Text="Asunto" Font-Bold="True"></asp:Label>
                                </div>
                                <div class="col-md-2 col-xs-2">
                                </div>
                                <div id="AsuntoDiv" runat="server" class="col-md-8 col-xs-8">
                                    <asp:TextBox ID="AsuntoTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Asunto"></asp:TextBox>
                                </div>
                            </div>
                            <div class="col-md-12">
                            </div>
                        </div>

                        <div class="col-md-12">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <center>
                                        <asp:Label ID="Label11" runat="server" Text="Estado" Font-Bold="True"></asp:Label>
                                        <asp:CheckBox ID="EsActivoCheckBox" runat="server" />
                                        <p class="help-block">
                                        </p>
                                    </center>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>

                            <div class="panel panel-success">
                                <div class="panel-body">
                                    <div class="col-md-12" role="form">
                                        <div class="form-group">
                                            <center>
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-2">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label For="TipoSolicitudIdDropDownList" ID="Label10" runat="server" Text="Tipo De Solicitud" Font-Bold="True"></asp:Label>
                                    <asp:DropDownList ID="TipoSolicitudIdDropDownList" AutoPostBack="true" CssClass="form-control" runat="server" OnSelectedIndexChanged="TipoSolicitudIdDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                    <p class="help-block">
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label For="CompaniaIdDropDownList" ID="Label16" runat="server" Text="Compañia" Font-Bold="True"></asp:Label>
                                    <asp:DropDownList ID="CompaniaIdDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <p class="help-block">
                                    </p>
                                </div>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label For="CategoriaIdDropDownList" ID="Label17" runat="server" Text="Categoria" Font-Bold="True"></asp:Label>
                                    <asp:DropDownList ID="CategoriaIdDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                    <p class="help-block">
                                    </p>
                                </div>
                            </div>
                        </div>
                        </center>
                                            <div class="form-inline col-md-12" role="form">
                                                <div class="col-md-2">
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="control-group form-group">
                                                        <div class="controls">
                                                            <asp:Label For="PaisOrigenDropDownList" ID="OrigenLabel" runat="server" Text="Origen" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="PaisOrigenDropDownList" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="PaisOrigenDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                                            <asp:DropDownList ID="OrigenDropDownList" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="OrigenDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                                            <p class="help-block">
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-5">
                                                    <div class="control-group form-group">
                                                        <div class="controls">
                                                            <asp:Label For="PaisDestinoDropDownList" ID="DestinoLabel" runat="server" Text="Destino" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="PaisDestinoDropDownList" CssClass="form-control" AutoPostBack="true" runat="server" OnSelectedIndexChanged="PaisDestinoDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                                            <asp:DropDownList ID="DestinoDropDownList" CssClass="form-control" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DestinoDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                                            <p class="help-block">
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <center>
                                    <div class="col-md-12">
                                        <div class="control-group form-group">
                                            <div class="controls">
                                                <asp:Label ID="EstadoLabel" runat="server" Text="Destino: " Font-Bold="True"></asp:Label>
                                                <asp:CheckBox ID="EstadoCheckBox" runat="server" Text=" Solo Ida" AutoPostBack="true" OnCheckedChanged="EstadoCheckBox_CheckedChanged"></asp:CheckBox>
                                            </div>
                                        </div>
                                    </div>
                                </center>
                                                <div class="col-md-12">
                                                </div>

                                                <div class="form-inline col-md-12">
                                                    <div class="col-md-2">
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="control-group form-group">
                                                            <div class="controls">
                                                                <asp:Label ID="FechaInicialLabel" runat="server" Text="Fecha de Salida" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="FechaInicialTextBox" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <p class="help-block">
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div id="FechaFinal" runat="server" class="control-group form-group">
                                                            <div class="controls">
                                                                <asp:Label ID="FechaFinalLabel" runat="server" Text="Fecha de Regreso" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="FechaFinalTextBox" type="date" runat="server" CssClass="form-control"></asp:TextBox>
                                                                <p class="help-block">
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                    </div>
                                                </div>
                                                <div class="form-inline col-md-12">
                                                    <div class="col-md-2">
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="control-group form-group">
                                                            <div id="PrecioDiv" runat="server" class="controls">
                                                                <asp:Label ID="Label13" runat="server" Text="Precio" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="PrecioTextBox" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Precio" OnTextChanged="PrecioTextBox_TextChanged"></asp:TextBox>
                                                                <p class="help-block">
                                                                </p>
                                                            </div>
                                                        </div>
                                                        
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="control-group form-group">
                                                            <div id="ImpuestoDiv" runat="server" class="controls">
                                                                <asp:Label ID="Label1" runat="server" Text="Imp" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="ImpuestoTextBox" runat="server" AutoPostBack="true" CssClass="form-control" placeholder="Impuesto" OnTextChanged="ImpuestoTextBox_TextChanged"></asp:TextBox>
                                                                <p class="help-block">
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="control-group form-group">
                                                            <div class="controls">
                                                                <asp:Label ID="Label14" runat="server" Text="Total" Font-Bold="True"></asp:Label>
                                                                <asp:TextBox ID="TotalTextBox" ReadOnly="true" runat="server" CssClass="form-control" placeholder="Total"></asp:TextBox>
                                                                <p class="help-block">
                                                                </p>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="control-group form-group">
                                                        <div class="controls">
                                                            <asp:Label ID="Label7" runat="server" Text="Personas" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="CantidadPersonaDropDownList" runat="server">
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <p class="help-block">
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="control-group form-group">
                                                        <div class="controls">
                                                            <asp:Label ID="Label8" runat="server" Text="Niños" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="CantidadNinoDropDownList" runat="server">
                                                                <asp:ListItem>0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <p class="help-block">
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="control-group form-group">
                                                        <div class="controls">
                                                            <asp:Label ID="Label9" runat="server" Text="Bebes" Font-Bold="True"></asp:Label>
                                                            <asp:DropDownList ID="CantidadBebeDropDownList" runat="server">
                                                                <asp:ListItem>0</asp:ListItem>
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                            </asp:DropDownList>
                                                            <p class="help-block">
                                                            </p>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-12">
                                            <center>
                                        <div class="btn-group text-center">
                                            <asp:Button ID="AgregarDetalleButton" CssClass="btn btn-success" runat="server" Text="Agregar Solicitud" OnClick="AgregarDetalleButton_Click" />
                                        </div>
                                    </center>
                                        </div>
                                        <div class="table table-responsive col-md-12">
                                            <asp:GridView ID="DetalleTextGridView" Width="100%" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                        </div>
                                        <div class="table table-responsive col-md-12">
                                            <asp:GridView ID="DetalleGridView" Width="100%" CssClass="table table-bordered table-hover table-striped" runat="server"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>

                    <div class="col-md-12">
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
