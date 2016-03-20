<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AjaxEjemplo.aspx.cs" Inherits="ProyectoAgencia.AjaxEjemplo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.0/jquery.min.js"></script>
    <script>
$(document).ready(function(){
    $("button").click(function(){
        $.post("AjaxEjemplo.aspx/Multiplicar()",
        {
            
        });
    });
});
</script>
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <div class="form-group">
                    <asp:TextBox ID="CargarTextBox" runat="server" CssClass="form-control" placeholder="Cargar Datos"></asp:TextBox>
                    <asp:Button ID="CargarButton" CssClass="btn btn-primary" runat="server" Text="Cargar" OnClick="CargarButton_Click" />
                </div>
            </div>
            <div class="col-md-12">
                <div class="form-group">
                    <asp:Label ID="MultiplicacionLabel" runat="server" Text="Label"></asp:Label>
                    <asp:TextBox ID="OperacionTextBox" CssClass="form-control" runat="server"></asp:TextBox>
                    <asp:Button ID="OperacionButton" CssClass="btn btn-success" runat="server" Text="Multiplicar" OnClick="OperacionButton_Click" />
                    <button id="Calcular">Calcular Con Ajax</button>
                </div>            
            </div>
        </div>
    </div>
</asp:Content>
