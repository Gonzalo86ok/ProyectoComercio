﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentaPage.aspx.cs" Inherits="Comercio.VentaPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container p-2">
        <div class="container border border-primary-subtle rounded p-2 mb-2 bg-primary bg-opacity-50 text-center">
            <div class="row align-items-center">
                <div class="col">
                    <asp:DropDownList runat="server" ID="ddlCategorias" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlCategorias_SelectedIndexChanged">
                        <asp:ListItem Text="Elige una categoría" Value="" Selected="True"></asp:ListItem>
           
                    </asp:DropDownList>
                </div>
                <div class="col">
                    <h3 class="p-1 text-primary">Ventas</h3>
                </div>
            </div>
        </div>
    </div>

    <div class="container p-2">
        <!-- Contenedor de la ventana de ventas -->
        <div class="container-fluid ">
            <div class="row">
                <!-- División para el contenido principal -->
                <div class="col-md-9 md-3 p-3 bg-primary bg-opacity-10 border border-6 border-primary-subtle rounded-4">
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
                        <div class="border border-primary-subtle rounded-3 p-3 md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle rounded-4" style="height: calc(75vh - 150px); width: 330px; overflow-y: auto;">
                            <asp:GridView ID="gdvCompra" runat="server" CssClass=" table table-dark table-border md-3 p-3 bg-primary bg-opacity-10 border border-primary-subtle rounded-4" AutoGenerateColumns="false">
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
                        </div>
                        <!-- Elementos fijos abajo -->
                        <div class="mt-3 d-flex justify-content-between">
                            <asp:Button ID="BtnFinalizarVenta" runat="server" Text="Finalizar Venta" CssClass="btn btn-outline-primary" OnClick="BtnFinalizarVenta_Click" />
                            <asp:Button ID="btnCancalar" runat="server" Text="Cancelar" CssClass="btn btn-outline-warning" OnClick="btnCancalar_Click" />
                        </div>
                        <div class="mt-3 input-group input-group-sm mb-3">
                            <span class="input-group-text" id="inputGroup-sizing-sm" style="font-weight: bold; font-size: 18px; color: #004080;">Total:</span>
                            <asp:TextBox ID="txtSumaVentas" runat="server" Style="border: 2px solid #6C757D; border-radius: 8px; padding: 10px; font-size: larger; text-align: center; background-color: #004080; color: #FFFFFF;" aria-label="Sizing example input" aria-describedby="inputGroup-sizing-lg"></asp:TextBox>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>    

</asp:Content>
