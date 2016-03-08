<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PeticionVuelos.aspx.cs" Inherits="ProyectoAgencia.PeticionVuelos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
                    <li class="active">Registro de Vuelos</li>
                </ol>
            </div>
        </div>
        <!-- /.row -->
        <div class="panel panel-primary">
        <div class="panel-heading">Registros de Vuelos</div>
        <div class="panel-body">
        <div class="form-horizontal col-md-12" role="form">
            <div class="form-group">
                <div class="col-md-2"></div>
                <div class="col-md-8">
                <center>
                    <asp:Label ID="DestinoLabel" runat="server" Font-Size="Large" Font-Bold="True" Text="Vuelo de Salida"></asp:Label>
                

                    <div class="control-group form-group">
                        <div class="controls">
                            <asp:Label ID="Label4" runat="server" Text="Estado" Font-Bold="True"></asp:Label>
                            <asp:RadioButtonList ID="DestinoRadioButtonList" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True">Ida</asp:ListItem>
                                <asp:ListItem>Ida/Vuelta</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </center>

                <div class="col-md-12"></div>
                        <div class="form-inline col-md-12" role="form">
                           <div class="col-md-2">
                            </div>
                            <div class="col-md-4">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label For="OrigenDropDownList" ID="Label11" runat="server" Text="Origen" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="OrigenDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label For="DestinoDropDownList" ID="Label12" runat="server" Text="Destino" Font-Bold="True"></asp:Label>
                                        <asp:DropDownList ID="DestinoDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                        <div class="form-inline col-md-12" role="form">
                            <div class="col-md-6">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label ID="Label1" runat="server" Text="Rango de Fecha" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="FechaInicialTextBox" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                        <p class="help-block">
                                                <asp:requiredfieldvalidator id="RequiredFieldValidator1" forecolor="Red" errormessage="Por Favor Entre su Fecha" controltovalidate="FechaInicialTextBox" runat="server">
                                                </asp:requiredfieldvalidator>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label ID="Label2" runat="server" Text="Rango de Fecha" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="FechaFinalTextBox" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                        <p class="help-block">
                                            <asp:requiredfieldvalidator id="RequiredFieldValidator2" forecolor="Red" errormessage="Por Favor Entre su Fecha" controltovalidate="FechaFinalTextBox" runat="server">
                                                </asp:requiredfieldvalidator>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>

                        <div class="form-inline col-md-12" role="form">
                            <div class="col-md-6">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label ID="Label13" runat="server" Text="Rango de Precio" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="PrecioInicialTextBox" runat="server" CssClass="form-control" placeholder="Desde"></asp:TextBox>
                                        <p class="help-block">
                                             <asp:requiredfieldvalidator id="RequiredFieldValidator6" forecolor="Red" errormessage="Por Favor Entre su Precio" controltovalidate="PrecioInicialTextBox" runat="server">
                                             </asp:requiredfieldvalidator>
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-6">
                                <div class="control-group form-group">
                                    <div class="controls">
                                        <asp:Label ID="Label14" runat="server" Text="Rango de Precio" Font-Bold="True"></asp:Label>
                                        <asp:TextBox ID="PrecioFinalTextBox" runat="server" CssClass="form-control" placeholder="Hasta"></asp:TextBox>
                                        <p class="help-block">
                                            <asp:requiredfieldvalidator id="RequiredFieldValidator8" forecolor="Red" errormessage="Por Favor Entre su Precio" controltovalidate="PrecioFinalTextBox" runat="server">
                                             </asp:requiredfieldvalidator>
                                        </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label7" runat="server" Text="Cantidad de Personas" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="CantidadPersonaTextBox" runat="server" CssClass="form-control" placeholder="Escriba la Cantidad"></asp:TextBox>
                                    <p class="help-block">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator3" forecolor="Red" errormessage="Por Favor Entre la Cantidad de Persona" controltovalidate="CantidadPersonaTextBox" runat="server">
                                         </asp:requiredfieldvalidator>
                                    </p>
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label8" runat="server" Text="Cantidad de Niño" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="CantidadNinoTextBox" runat="server" CssClass="form-control" placeholder="Escriba la Cantidad"></asp:TextBox>
                                    <p class="help-block">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator4" forecolor="Red" errormessage="Por Favor Entre la cantidad de Niño sino ponga 0" controltovalidate="EdadesNinoTextBox" runat="server">
                                         </asp:requiredfieldvalidator>
                                    </p>
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label9" runat="server" Text="Edades de los Niños" Font-Bold="True"></asp:Label>
                                    <asp:TextBox ID="EdadesNinoTextBox" CssClass="form-control" placeholder="Edades de los Niño separado por comas" runat="server" ></asp:TextBox>
                                    <p class="help-block">
                                        <asp:requiredfieldvalidator id="RequiredFieldValidator5" forecolor="Red" errormessage="Por Favor Entre las Edades de los Niño separado por comas Ej:8,12,3." controltovalidate="EdadesNinoTextBox" runat="server">
                                         </asp:requiredfieldvalidator>
                                    </p>
                                </div>
                            </div>
                            <div class="control-group form-group">
                                <div class="controls">
                                    <asp:Label ID="Label3" runat="server" Text="Compañia de Aerolinea" Font-Bold="True"></asp:Label>
                                    <asp:DropDownList ID="CompaniaAerolineaDropDownList" CssClass="form-control" runat="server"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="btn-group">
                                <asp:Button ID="ContinuarButton" CssClass="btn btn-success" runat="server" Text="Continuar" OnClick="ContinuarButton_Click" />
                            </div>
                    </div>
                </div>
            </div>
        </div>
        </div>
      </div>
</asp:Content>
