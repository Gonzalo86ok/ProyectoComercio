<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioStock.aspx.cs" Inherits="Comercio.FormularioStock" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h3 class="p-1 text-center">Stock</h3>
    <div class="container">
        <div class="row">

            <div class="col-md-6 ">
                <div class="form-container border border-secondary p-3">
                    <!-- Controles para la información del Producto -->
                    <div class="form-group">
                        <asp:Label runat="server" Text="Código del Producto:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtCodigoProducto" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" Text="Nombre del Producto:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtNombreProducto" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" Text="Medida:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtMedida" CssClass="form-control" />
                    </div>


                    <div class="form-group">
                        <asp:Label runat="server" Text="Cantidad en Stock:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtCantidadStock" CssClass="form-control" />
                    </div>

                </div>
            </div>

            <div class="col-md-6  ">
                <div class="md-3">

                    <div class="form-group">
                        <asp:Label runat="server" Text="Cantidad:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtAgregaCantidad" CssClass="form-control" />
                    </div>

                    <asp:Button runat="server" ID="btnAgregar"  Text="Agregar Stock" OnClick="btnAgregar_Click" CssClass="btn btn-outline-primary" />
                    <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-warning" />
                    <asp:Button runat="server" ID="btoEliminar" Text="Eliminar"      OnClick="btoEliminar_Click" CssClass="btn btn-outline-danger" />
                    
                </div>
                <asp:Label ID="lblMensaje" runat="server" Text="" ></asp:Label>
            </div>
        </div>
    </div>
</asp:Content>
