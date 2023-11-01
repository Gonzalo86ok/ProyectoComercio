<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientePage.aspx.cs" Inherits="Comercio.ClientePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Cliente</h3>

     <div class="row">
   
                         <ItemTemplate>
                        <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                        <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>

    </div>
                     <asp:Button runat="server" Text="Agregar" CommandName="Agregar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />

</asp:Content>
