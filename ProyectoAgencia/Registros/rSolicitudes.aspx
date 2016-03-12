<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="rSolicitudes.aspx.cs" Inherits="ProyectoAgencia.Registros.rSolicitudes" %>
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
                    <li class="active">Registro de Solicitudes</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
        <div class="panel-heading">Registros de Solicitudes</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">
                <h3>Ingrese Sus Datos</h3>
                    <div class="col-md-2">
                        </div>
                    <div class="col-md-8">
                        <center>
                            <div class="form-inline" role="form">
                                <div class="control-group form-group">
                                    <div class="controls">
                                            <asp:Label ID="Label5" For="SolicitudIdTextBox" runat="server" Font-Bold="true" Text="Id por Solicitud"></asp:Label>
                                            <asp:TextBox ID="SolicitudIdTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Id" TextMode="Search" Font-Bold="True"></asp:TextBox>
                                            <asp:Button ID="BuscarButton" CssClass="btn btn-toolbar" runat="server" Text="Buscar" OnClick="BuscarButton_Click" />
                                            <p class="help-block"></p>
                                    </div>
                                </div>
                        </div>
                        </center>
                        </div>
                        <div class="form-inline col-md-12" role="form">
                            <div class="col-md-2"></div>
                            <div class="col-md-6">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label ID="Label4" runat="server" Text="Usuario es" Font-Bold="True"></asp:Label>
                                        <asp:Label ID="UsuarioIdLabel" CssClass=" form-control" runat="server" Text="Usuario"></asp:Label>
                                        <p class="help-block">
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
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
                        <div class="col-md-3">
                        </div>
                        <div class="col-md-6">
                            <div class="control-group form-group">
                                    <div class="controls">
                                        <center>
                                            <asp:Label ID="Label3" runat="server" Text="Asunto" Font-Bold="True"></asp:Label>
                                        </center>
                                        <asp:TextBox ID="AsuntoTextBox" runat="server" CssClass="form-control" placeholder="Escriba un Asunto"></asp:TextBox>
                                        <p class="help-block">
                                             <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" errormessage="Por Favor Entre un Asunto" controltovalidate="AsuntoTextBox" runat="server">
                                             </asp:requiredfieldvalidator>
                                        </p>
                                    </div>
                            </div>
                        </div>
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
                                    <asp:DropDownList ID="TipoSolicitudIdDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
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
                        <div class="col-md-12">
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label15" runat="server" Text="Eleccion de Destino" Font-Bold="True"></asp:Label>
                                    <asp:RadioButtonList ID="EstadoRadioButtonList" runat="server" RepeatDirection="Horizontal" Height="16px" Width="195px">  
                                            <asp:ListItem Selected="True">Ida</asp:ListItem>
                                            <asp:ListItem>Ida/Vuelta</asp:ListItem>
                                    </asp:RadioButtonList>
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
                                            <asp:Label For="OrigenDropDownList" ID="Label11" runat="server" Text="Origen" Font-Bold="True"></asp:Label>
                                            <asp:DropDownList ID="OrigenDropDownList" CssClass="form-control" runat="server" OnSelectedIndexChanged="OrigenDropDownList_SelectedIndexChanged"></asp:DropDownList>
                                            <p class="help-block">
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label For="DestinoDropDownList" ID="Label12" runat="server" Text="Destino" Font-Bold="True"></asp:Label>
                                            <asp:DropDownList ID="DestinoDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                            <p class="help-block">
                                            </p>
                                        </div>
                                    </div>
                               </div>
                               <div class="form-inline col-md-12">
                               <div class="col-md-2">
                                </div>
                                <div class="col-md-4">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label1" runat="server" Text="Rango de Fecha" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="FechaInicialTextBox" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                            <p class="help-block">
                                                    <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" errormessage="Por Favor Entre su Fecha" controltovalidate="FechaInicialTextBox" runat="server">
                                                    </asp:requiredfieldvalidator>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label2" runat="server" Text="Rango de Fecha" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="FechaFinalTextBox" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                            <p class="help-block">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" errormessage="Por Favor Entre su Fecha" controltovalidate="FechaFinalTextBox" runat="server">
                                                    </asp:requiredfieldvalidator>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                </div>
                               <div class="form-inline col-md-12">
                               <div class="col-md-2">
                                </div>
                                <div class="col-md-4">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label13" runat="server" Text="Rango de Precio" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="PrecioInicialTextBox" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                            <p class="help-block">
                                                 <asp:requiredfieldvalidator id="RequiredFieldValidator4" forecolor="Red" errormessage="Por Favor Entre su Precio" controltovalidate="PrecioInicialTextBox" runat="server">
                                                 </asp:requiredfieldvalidator>
                                            </p>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:Label ID="Label14" runat="server" Text="Rango de Precio" Font-Bold="True"></asp:Label>
                                            <asp:TextBox ID="PrecioFinalTextBox" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                            <p class="help-block">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator5" forecolor="Red" errormessage="Por Favor Entre su Precio" controltovalidate="PrecioFinalTextBox" runat="server">
                                                </asp:requiredfieldvalidator>
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
                                                <asp:ListItem>0</asp:ListItem>
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                                <asp:ListItem>9</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
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
                                                <asp:ListItem>8</asp:ListItem>
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
                                <div class="col-md-12">
                                    <div class="control-group form-group">
                                        <div class="controls">
                                            <asp:GridView ID="DetalleGridView" Width="100%" runat="server"></asp:GridView>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            </div>
                            </div>
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
        </div>
</asp:Content>
