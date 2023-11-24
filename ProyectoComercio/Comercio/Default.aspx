<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="  container p-2 ">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2 mb-2">Informes </h3>
    </div>
    <%--Contenedor inicial tres cuadros  --%>
    <div class="container">
        <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50">
            <div class="container text-center">
                <div class="row">
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Venta Del Día</h4>
                        <asp:Label ID="lbVentaDia" runat="server" Text="00.0" Style="font-size: 24px;"></asp:Label>
                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>$ Del Día</h4>
                        <asp:Label ID="lbGastoDia" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Rendimiento del Día</h4>
                        <asp:Label ID="lbRendimientoDia" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                </div>
            </div>
            <%--Contenedor final tres cuadros Dia  --%>
            <%--Contenedor inicial tres cuadros Mes --%>
            <div class="container text-center">
                <div class="row">
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Venta Del Mes</h4>
                        <asp:Label ID="lbVentaMes" runat="server" Text="00.0" Style="font-size: 24px;"></asp:Label>
                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>$ Del Mes</h4>
                        <asp:Label ID="lbGastoMes" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Rendimiento del Mes</h4>
                        <asp:Label ID="lbRendimientoMes" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Pestallas para los informes --%>
    <div class="container">
        <div class="md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle rounded-4">
            <ul class="nav nav-tabs table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50" id="myTabs" role="tablist">
                <li class="nav-item" role="presentation">
                    <a class="nav-link active" id="ventas-tab" data-bs-toggle="tab" data-bs-target="#ventas" role="tab" aria-controls="ventas" aria-selected="true">Informe de Ventas</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="stock-tab" data-bs-toggle="tab" data-bs-target="#stock" role="tab" aria-controls="stock" aria-selected="false">Informe de Modificaciones de Stock</a>
                </li>
            </ul>
            <!-- Contenido de las pestañas -->








            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="ventas" role="tabpanel" aria-labelledby="ventas-tab">
                    <!-- Contenido del informe de ventas -->
                    <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50">
                        <div class="container border border-primary-subtle rounded p-2 mb-2 bg-primary bg-opacity-50">
                            <p>Indicar parámetros de búsqueda:</p>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtDesde" class="form-label">Desde:</label>
                                    <asp:TextBox ID="txtDesdeV" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtHasta" class="form-label">Hasta:</label>
                                    <asp:TextBox ID="txtHastaV" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                </div>
                            </div>


                            <div class="row mt-3">
                                <div class="col-md-6">
                                    <label class="visually-hidden" for="btnBuscar">Buscar</label>
                                    <asp:Button ID="BtnFechaVen" runat="server" Text="Buscar" OnClick="BtnFechaVen_Click" CssClass="btn btn-success"></asp:Button>
                                </div>
                                <div class="col-md-6">                                   
                                    <asp:Button ID="btnLimpiarVent" runat="server" Text="Limpiar búsqueda" CssClass="btn btn-secondary" OnClick="btnLimpiarVent_Click" />
                                </div>
                            </div>


                            <hr class="my-4">
                            <!-- Línea separadora -->
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtBusqueda" class="form-label">Búsqueda rápida:</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>                                       
                                        <asp:Button ID="BtnbusquedaRapidaVent" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="BtnbusquedaRapidaVent_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <asp:GridView runat="server" ID="dgvHistorialVentas" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary mx-auto">
                    </asp:GridView>
                </div>
              
                
                
                
                
                
                <div class="tab-pane fade" id="stock" role="tabpanel" aria-labelledby="stock-tab">
                    <!-- Contenido del informe de modificaciones de stock -->
                    <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50">
                        <div class="container border border-primary-subtle rounded p-2 mb-2 bg-primary bg-opacity-50">
                            <p>Indicar parámetros de búsqueda:</p>
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtDesde" class="form-label">Desde:</label>
                                    <asp:TextBox ID="txtDesde" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                </div>
                                <div class="col-md-6">
                                    <label for="txtHasta" class="form-label">Hasta:</label>
                                    <asp:TextBox ID="txtHasta" runat="server" CssClass="form-control" type="date"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row mt-3">
                                <div class="col-md-6">
                                    <label class="visually-hidden" for="btnBuscar">Buscar</label>
                                    <asp:Button ID="btnStockFecha" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="btnStockFecha_Click" />
                                </div>
                                <div class="col-md-6">
                                     <asp:Button ID="btnLimpiarBusqStock" runat="server" Text="Limpiar búsqueda" CssClass="btn btn-secondary" OnClick="btnLimpiarBusqStock_Click" />
                                </div>
                            </div>
                            <hr class="my-4">                                                                            
                            <!-- Línea separadora -->
                            <div class="row">
                                <div class="col-md-6">
                                    <label for="txtBusqueda" class="form-label">Búsqueda rapida:</label>
                                    <div class="input-group">
                                        <asp:TextBox ID="txtBusqueda" runat="server" CssClass="form-control" placeholder="Buscar..."></asp:TextBox>                                                            
                                         <asp:Button ID="btnBusqRapidaStock" runat="server" Text="Buscar" CssClass="btn btn-secondary" OnClick="btnBusqRapidaStock_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>

                    <asp:GridView runat="server" ID="dgvStockHistoria" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary mx-auto" AutoGenerateColumns="false">
                        <Columns>
                            <asp:TemplateField HeaderText="Fecha y Hora">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("FechaHoraRegistro") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Codigo">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Producto.Codigo") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Producto">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Producto.Nombre") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Cantidad">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("CantidadAnterior") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Movimiento">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("CantidadNueva") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Operación">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Operacion") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Comentario">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Comentario") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Usuario">
                                <ItemTemplate>
                                    <asp:Label runat="server" Text='<%# Eval("Usuario.User") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Acciones"></asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
