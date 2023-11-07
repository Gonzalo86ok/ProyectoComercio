<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Formulario.aspx.cs" Inherits="Comercio.Formulario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Formulario</h3>
    <!-- Formulario de agregar productos -->
    <div class="form-container border border-secondary p-3">
        <h5>Agregar Producto</h5>
        <div class="row">
            <div class="col-md-6">

                <asp:Label runat="server" Text="Código:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />

                <asp:Label runat="server" Text="Nombre:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />

                <asp:Label runat="server" Text="Descripción:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />

                <asp:Label runat="server" Text="Precio:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control" />

            </div>
            <div class="col-md-6">
                <div class="md-3">
                    <asp:Label runat="server" Text="Categoría:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtCategoria" CssClass="form-control"></asp:TextBox>

                    <asp:Label runat="server" Text="Fabricante o Marca:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtFabricante" CssClass="form-control"></asp:TextBox>

                    <asp:Label runat="server" Text="Medida:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtMedida" CssClass="form-control"></asp:TextBox>

                    <asp:Button runat="server" ID="btnAgregarProducto" OnClick="btnAgregarProducto_Click" Text="Agregar" CssClass="btn btn-outline-primary ml-2 mt-4 " Style="margin-right: 10px;" />
                </div>
            </div>
        </div>

</asp:Content>
