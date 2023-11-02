<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InventarioPage.aspx.cs" Inherits="Comercio.InventarioPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

     <%--       public int Id { get; set; }
        public decimal Cantidad { get; set; }
        public Sucursal Sucursal { get; set; }
         <h3 class="p-1 text-center">Inventario</h3>
        public decimal CantidadMinima { get; set; }--%>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h3 class="p-1 text-center">Productos y Stock</h3>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
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
                    <!-- Agregar más controles para la información del Producto -->

                    <!-- Controles para la información del Stock -->
                    <div class="form-group">
                        <asp:Label runat="server" Text="Cantidad en Stock:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtCantidadStock" CssClass="form-control" />
                    </div>
                    <div class="form-group">
                        <asp:Label runat="server" Text="Sucursal:" CssClass="form-label" />
                        <asp:DropDownList ID="ddlSucursal" runat="server" CssClass="form-control"></asp:DropDownList>
                    </div>
                    <!-- Agregar más controles para la información del Stock -->

                    <!-- Botón para agregar producto al stock -->
                    <asp:Button runat="server" ID="btnAgregarProducto" Text="Agregar Producto al Stock" CssClass="btn btn-secondary" />

                </div>
            </div>
        </div>
    </div>

</asp:Content>
