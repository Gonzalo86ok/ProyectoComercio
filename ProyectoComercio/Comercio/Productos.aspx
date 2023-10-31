<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="Comercio.Productos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="p-1 text-center">Producto</h3>

    <div class="container">
        <h5>Agregar Producto</h5>
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <asp:Label runat="server" Text="Código:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />

                    <asp:Label runat="server" Text="Nombre:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />

                    <asp:Label runat="server" Text="Descripción:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtDescripcion" CssClass="form-control" />

                    <asp:Label runat="server" Text="Categoría:" CssClass="form-label" />
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>


                    <asp:Label runat="server" Text="Fabricante:" CssClass="form-label" />
                    <asp:DropDownList ID="ddlFabricante" runat="server" CssClass="form-control"></asp:DropDownList>


                    <asp:Button runat="server" ID="btnAgregarFabricante" Text="Agregar" CssClass="btn btn-secondary ml-2" Style="margin-right: 10px;" />

                </div>
            </div>
        </div>
    </div>

    <div class="pb-4"></div>

    <div class="table-container pb-4 ">
        <asp:GridView runat="server" ID="dgvProducto" DataKeyNames="Id" OnSelectedIndexChanged="dgvProducto_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
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
                        <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                        <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>







    <asp:GridView runat="server" ID="dgvCategoria"></asp:GridView>
    <asp:GridView runat="server" ID="dgvFabricante"></asp:GridView>
    <asp:GridView runat="server" ID="dgvMedida"></asp:GridView>
    <asp:GridView runat="server" ID="dgvSucursal"></asp:GridView>

</asp:Content>
