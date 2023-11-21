<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InventarioPage.aspx.cs" Inherits="Comercio.InventarioPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="  container p-2 ">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2 mb-2">Stock De Productos </h3>
    </div>

    <div class="container">
        <div class="row">

            <div class="pb-4"></div>
            <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50">

                <asp:GridView runat="server" ID="dgvStockItem" DataKeyNames="StockId" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <HeaderTemplate>
                                <span style="color: blue;">Código</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoCodigo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <HeaderTemplate>
                                <span style="color: blue;">Nombre</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoNombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Medida">
                            <HeaderTemplate>
                                <span style="color: blue;">Medida</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoMedidaId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad en Stock">
                            <HeaderTemplate>
                                <span style="color: blue;">Cantidad en Stock</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("StockCantidad") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
                            <HeaderTemplate>
                                <span style="color: blue;">Acciones</span>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:Button runat="server" Text="Modificar" ID="btoModificar" OnClick="btoModificar_Click" CommandArgument='<%# Eval("StockId") %>' CssClass="btn btn-outline-primary" />

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>
