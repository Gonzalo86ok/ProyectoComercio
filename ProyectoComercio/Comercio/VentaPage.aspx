<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentaPage.aspx.cs" Inherits="Comercio.VentaPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Venta</h3>

    <div class="row">
        <div class="col-4">
            <div id="list-example" class="list-group">

                <asp:GridView ID="dgvCategoria" runat="server" DataKeyNames="Id" OnSelectedIndexChanged="dgvCategoria_SelectedIndexChanged" CssClass="table table-active table-primary" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="CATEGORIAS">
                            <ItemTemplate>
                                <div="list-example" class="list-group">
                                    <%--<p class="product-bran"><%#Eval("Id") %> </p>--%>
                                    <p class="list-group-item list-group-item-action"><%#Eval("Tipo") %></p>
                                </div >
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

