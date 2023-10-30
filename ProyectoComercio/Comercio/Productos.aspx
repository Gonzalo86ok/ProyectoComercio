<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView runat="server" ID="dgvCategoria"></asp:GridView>
    <asp:GridView runat="server" ID="dgvFabricante"></asp:GridView>
    <asp:GridView runat="server" ID="dgvMedida"></asp:GridView>
    <asp:GridView runat="server" ID="dgvSucursal"></asp:GridView>
    <asp:GridView runat="server" ID="dgvProducto"></asp:GridView>
</asp:Content>
