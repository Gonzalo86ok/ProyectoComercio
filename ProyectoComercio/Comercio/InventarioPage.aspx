<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="InventarioPage.aspx.cs" Inherits="Comercio.InventarioPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h3 class="p-1 text-center">Stock De Productos </h3>
    <div class="container">
        <div class="row">

            <div class="pb-4"></div>
            <div class="table-container pb-4 ">
                <asp:GridView runat="server" ID="dgvStockItem" DataKeyNames="StockId" CssClass="table table-striped table-bordered table-hover table-primary" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Código">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoCodigo") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Nombre">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoNombre") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Medida">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("ProductoMedidaId") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Cantidad en Stock">
                            <ItemTemplate>
                                <asp:Label runat="server" Text='<%# Eval("StockCantidad") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText="Acciones">
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
