<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CajaPage.aspx.cs" Inherits="Comercio.CajaPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Caja</h3>
    <asp:Button ID="btnIniciarVenta" runat="server" Text="Iniciar Venta" OnClick="btnIniciarVenta_Click" CssClass="btn btn-primary" />

</asp:Content>
