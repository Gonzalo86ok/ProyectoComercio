<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SucursalPage.aspx.cs" Inherits="Comercio.SucursalPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Sucursal</h3>

     <asp:ListView runat="server" ID="lvSucursal" ItemType="Dominio.Sucursal">
        <ItemTemplate>
            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title"><%# Item.Nombre %></h5>
                    <p class="card-text"><%# Item.Direccion %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
