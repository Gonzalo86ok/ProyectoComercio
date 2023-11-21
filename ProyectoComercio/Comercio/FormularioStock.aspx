<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioStock.aspx.cs" Inherits="Comercio.FormularioStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="  container p-2 ">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2 mb-2">Stock</h3>
    </div>

    <div class="  container ">
        <div class="container border border-2 border-primary-subtle border-secondary p-3 rounded-4">
            <div class="row">

                <div class="col-md-6 ">
                    <div class="md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle rounded-4">
                        <!-- Controles para la información del Producto -->
                        <div class="form-group">
                            <asp:Label runat="server" Text="Código del Producto:" CssClass="form-label" />
                            <asp:TextBox runat="server" ID="txtCodigoProducto" CssClass="form-control" />
                        </div>

                        <div class="form-group ">
                            <asp:Label runat="server" Text="Nombre del Producto:" CssClass="form-label" />
                            <asp:TextBox runat="server" ID="txtNombreProducto" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Medida:" CssClass="form-label" />
                            <asp:TextBox runat="server" ID="txtMedida" CssClass="form-control" />
                        </div>

                        <div class="form-group">
                            <asp:Label runat="server" Text="Cantidad en Stock:" CssClass="form-label" />
                            <asp:TextBox runat="server" ID="txtCantidadStock" CssClass="form-control " />
                        </div>

                    </div>
                </div>

                <div class="col-md-6  ">
                    <div class="md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle rounded-4">
                        <div class="form-group">
                            <asp:Label runat="server" Text="Cantidad:" CssClass="form-label" />
                            <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
                            <asp:TextBox runat="server" ID="txtAgregaCantidad" CssClass="form-control" />
                        </div>
                        <div class=" p-2">
                            <asp:Button runat="server" ID="btnAgregar" Text=" + " OnClick="btnAgregar_Click" CssClass="btn btn-outline-primary" />
                            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click" CssClass="btn btn-outline-warning" />
                            <asp:Button ID="btnAceptar" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" CssClass="btn btn-outline-success" />
                            <asp:Button runat="server" ID="btoEliminar" Text=" - " OnClick="btoEliminar_Click" CssClass="btn btn-outline-danger" />
                        </div>
                    </div>
                    <div class=" p-1"></div>

                    <div class="md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle  rounded-4">
                        <div class="form-group">
                            <asp:Label ID="Label1" runat="server" Text="Motivo: "></asp:Label>
                            <asp:Label ID="lbMotivo" runat="server" Text=""></asp:Label>
                            <asp:TextBox ID="txtMotivo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>

                        </div>
                        <asp:Label ID="lbAceptarCambio" runat="server" Text=""></asp:Label>
                    </div>
                </div>
            </div>
        </div>
      </div>
</asp:Content>
