<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentaPage.aspx.cs" Inherits="Comercio.VentaPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-2">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50 p-2 mb-2">Venta</h3>
    </div>
    <div class="row">
        <div class="col-6 mx-auto">
            <div class="mb-3">
                <asp:Label Text="Filtrar" runat="server" />
                <asp:TextBox runat="server" ID="txtFiltro" CssClass="form-control" AutoPostBack="true" OnTextChanged="filtro_TextChanged" />
            </div>
        </div>
    </div>
    <div class="container p-2">
        <!-- Contenedor de la ventana de ventas -->
        <div class="container-fluid">
            <div class="row">
                <!-- División para el contenido principal -->
                <div class="col-md-9">
                    <div class="row row-cols-1 row-cols-md-4 g-1 justify-content-center text-center d-flex">
                        <asp:Repeater ID="dgvProducto" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-center">
                                    <div class="card text-bg-dark mb-3 border border-2 border border-primary-subtle" style="width: 185px; height: 220px;">
                                        <div class="card-body d-flex flex-column justify-content-between">
                                            <h5 class="card-titlet" style="min-height: 50px;"><%#Eval("Nombre")%></h5>
                                            <p class="card-text" style="height: 30px;"><%#Eval("Categoria")%></p>
                                            <p class="card-text">$<%#Eval("precio")%></p>
                                            <div class="d-flex justify-content-center align-items-center">
                                                <asp:TextBox ID="txtCantidad" runat="server" CssClass="border-primary-subtle text-center" Style="width: 50px;" onkeypress="return event.keyCode != 13;"></asp:TextBox>
                                                <asp:Button ID="BtnAgregar" runat="server" Text="Agregar" CssClass="btn btn-outline-success rounded" CommandArgument='<%#Eval("id") %>' CommandName="Id" OnClick="BtnAgregar_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                    </div>
                </div>
                <!-- División para el div fijo en la ventana de ventas -->
                <div class="col-md-3 mt-1">
                    <asp:Label ID="lbMensaje" runat="server" Text=""></asp:Label>
                    <!-- Contenido fijo a la derecha -->
                    <div class="position-sticky top-0">
                        <div class="border border-primary-subtle rounded-3 p-3" style="height: calc(75vh - 150px); width: 330px; overflow-y: auto;">
                            <asp:GridView ID="gdvCompra" runat="server" CssClass="table table-dark table-border" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:BoundField HeaderText="N°" DataField="Numero" />
                                    <asp:BoundField HeaderText="Producto" DataField="Producto.Nombre" />
                                    <asp:BoundField HeaderText="Cant" DataField="Cantidad" />
                                    <asp:BoundField HeaderText="Valor" DataField="Monto" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:Button runat="server" ID="btnEliminar" Text="-" CommandName="Eliminar" CommandArgument='<%# Eval("Producto.Id") %>' OnClick="btnEliminar_Click" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <!-- Elementos fijos abajo -->
                            <div class="mt-3 d-flex justify-content-between">
                                <asp:Button ID="BtnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-outline-primary" OnClick="BtnFinalizarVenta_Click" />
                                <asp:Button ID="btnCancalar" runat="server" Text="Cancelar" CssClass="btn btn-outline-warning" OnClick="btnCancalar_Click" />
                            </div>
                            <div class="mt-3 input-group input-group-sm mb-3">
                                <span class="input-group-text" id="inputGroup-sizing-sm">Total:</span>
                                <asp:TextBox ID="txtSumaVentas" runat="server" CssClass="form-control mb-2 rounded" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
