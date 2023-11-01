<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="PrecioPage.aspx.cs" Inherits="Comercio.PrecioPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Precio</h3>

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
                     <asp:Label ID="Label1" runat="server" Text="Cambiar Valor"></asp:Label>
                     <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                     <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                     
                 </ItemTemplate>
             </asp:TemplateField>
         </Columns>
     </asp:GridView>
 </div>
</asp:Content>
