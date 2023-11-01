<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedorPage.aspx.cs" Inherits="Comercio.ProveedorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Proveedor</h3>
    <div class="row">
        <asp:Repeater ID="RepeaterFabricantes" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>                            
                        </div>
                          <ItemTemplate>
                        <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                        <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
        <asp:Button runat="server" Text="Agregar" CommandName="Agregar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
</asp:Content>
