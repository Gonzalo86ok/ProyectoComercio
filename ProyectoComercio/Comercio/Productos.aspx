<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="  container p-2 ">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2">Producto </h3>
    </div>
    <div class="container">
        <div class="md-3 p-3 bg-info bg-opacity-10  border border-4 border-primary-subtle rounded-end">
            <ul class="nav nav-tabs" id="myTabs" role="tablist">
                <li class="nav-item" role="presentation">
                    <a class="nav-link active" id="producto-tab" data-bs-toggle="tab" data-bs-target="#producto" role="tab" aria-controls="producto" aria-selected="true">Producto</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="categoria-tab" data-bs-toggle="tab" data-bs-target="#categoria" role="tab" aria-controls="categoria" aria-selected="false">Categoría</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="medida-tab" data-bs-toggle="tab" data-bs-target="#medida" role="tab" aria-controls="medida" aria-selected="false">Medida</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="fabricante-tab" data-bs-toggle="tab" data-bs-target="#fabricante" role="tab" aria-controls="fabricante" aria-selected="false">Fabricante</a>
                </li>
            </ul>
            <div class="tab-content" id="myTabsContent">
                <div class="tab-pane fade show active" id="producto" role="tabpanel" aria-labelledby="producto-tab">
                    <div class="form-container border border-secondary p-3">
                        <div class="pb-4"></div>
                        <div class="table-container pb-4 text-center">
                            <h5>Listado Productos</h5>
                            <asp:GridView runat="server" ID="dgvProducto" DataKeyNames="Id" OnSelectedIndexChanged="dgvProducto_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover table-primary" AutoGenerateColumns="false">
                                <Columns>
                                    <asp:TemplateField HeaderText="Código">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Codigo") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Nombre") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Categoría">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Categoria") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Fabricante">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Fabricante") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Descripción">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Descripcion") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Medida">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Medida") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Precio">
                                        <ItemTemplate>
                                            <asp:Label runat="server" Text='<%# Eval("Precio") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:Button runat="server" Text="Modificar" OnClick="btnModificarProducto_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                                            <asp:Button runat="server" Text="Eliminar" OnClick="EliminarProducto_Click" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>
                        <asp:Button runat="server" ID="btnAgregarProducto1" OnClick="btnAgregarProducto_Click1" Text="Agregar Producto" CssClass="btn btn-success" />
                    </div>
                </div>
                <div class="tab-pane fade" id="categoria" role="tabpanel" aria-labelledby="categoria-tab">
                    <div class="form-container border border-secondary p-3 text-center">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="md-3">
                                    <h5>Listado Categoria</h5>
                                    <asp:GridView runat="server" ID="dgvCategoria" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Categoría de Producto:">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# Eval("Tipo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="btnModificarCategoria" Text="Modificar" OnClick="btnModificarCategoria_Click" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                                                    <asp:Button runat="server" ID="btnEliminarCategoria" OnClick="btnEliminarCategoria_Click" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                                <asp:Button runat="server" ID="agregarCategoria" OnClick="agregarCategoria_Click" Text="Agregar Categoria" CssClass="btn btn-success" />
                        </div>
                    </div>
                    <div class="pb-4"></div>
                </div>
                <div class="tab-pane fade" id="medida" role="tabpanel" aria-labelledby="medida-tab">
                    <div class="form-container border border-secondary p-3 text-center">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="md-3">
                                    <h5>Listado Medidas</h5>

                                    <asp:GridView runat="server" ID="dgvMedida" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Medida de Producto:">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# Eval("Tipo") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="modificarMedida" OnClick="modificarMedida_Click" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                                                    <asp:Button runat="server" ID="eliminarMedida" OnClick="eliminarMedida_Click" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Button runat="server" ID="btnAgregarMedida" OnClick="btnAgregarMedida_Click" Text="Agregar Medida" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="pb-4"></div>
                </div>
                <div class="tab-pane fade" id="fabricante" role="tabpanel" aria-labelledby="fabricante-tab">
                    <div class="form-container border border-secondary p-3 text-center">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="md-3">
                                    <h5>Listado Fabricante o Marca</h5>
                                    <asp:GridView runat="server" ID="dgvFabricante" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary" AutoGenerateColumns="false">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Fabricante de Producto:">
                                                <ItemTemplate>
                                                    <asp:Label runat="server" Text='<%# Eval("Nombre") %>' />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Acciones">
                                                <ItemTemplate>
                                                    <asp:Button runat="server" ID="ModificarFabricante" OnClick="ModificarFabricante_Click" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                                                    <asp:Button runat="server" ID="EliminarFabricante" OnClick="EliminarFabricante_Click" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <asp:Button runat="server" ID="agregarFabricante" OnClick="agregarFabricante_Click" Text="Agregar Fabricante" CssClass="btn btn-success" />
                            </div>
                        </div>
                    </div>
                    <div class="pb-4"></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
