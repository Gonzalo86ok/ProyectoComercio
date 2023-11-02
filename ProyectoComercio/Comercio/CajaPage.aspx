<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CajaPage.aspx.cs" Inherits="Comercio.CajaPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Administración de Caja, Compras y Gastos</h3>
    
    <div class="container">
        <!-- Sección de Caja -->
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <h4>Caja</h4>
                    <asp:Label runat="server" Text="Saldo Actual:" CssClass="form-label" />
                    <asp:Label runat="server" ID="lblSaldo" CssClass="form-control" Text="1000.00" />

                    <asp:Label runat="server" Text="Ingresar Dinero:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtIngresarDinero" CssClass="form-control" />
                    <asp:Button runat="server" ID="btnIngresarDinero" Text="Ingresar" CssClass="btn btn-secondary" />

                    <asp:Label runat="server" Text="Retirar Dinero:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtRetirarDinero" CssClass="form-control" />
                    <asp:Button runat="server" ID="btnRetirarDinero" Text="Retirar" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
        
        <!-- Sección de Compras -->
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <h4>Compras</h4>
                    <asp:DropDownList runat="server" ID="ddlProductos" CssClass="form-control">
                    
                    </asp:DropDownList>

                    <asp:TextBox runat="server" ID="txtCantidad" CssClass="form-control" placeholder="Cantidad" />
                    <asp:TextBox runat="server" ID="txtCosto" CssClass="form-control" placeholder="Costo por unidad" />
                    <asp:Button runat="server" ID="btnRegistrarCompra" Text="Registrar Compra" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
        
        <!-- Sección de Gastos -->
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <h4>Gastos</h4>
                    <asp:TextBox runat="server" ID="txtDescripcionGasto" CssClass="form-control" placeholder="Descripción del Gasto" />
                    <asp:TextBox runat="server" ID="txtDineroGastado" CssClass="form-control" placeholder="Dinero Gastado" />
                    <asp:Button runat="server" ID="btnRegistrarGasto" Text="Registrar Gasto" CssClass="btn btn-secondary" />
                </div>
            </div>
        </div>
        
        <!-- Registro de Compras -->
        <div class="row">
            <div class="col-md-12">
                <div class="form-container border border-secondary p-3">
                    <h4>Registro de Compras</h4>
                    <asp:GridView runat="server" ID="gvRegistroCompras" CssClass="table table-striped">
                        
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

