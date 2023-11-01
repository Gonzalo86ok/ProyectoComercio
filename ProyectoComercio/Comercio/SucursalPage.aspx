<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="SucursalPage.aspx.cs" Inherits="Comercio.SucursalPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3 class="p-1 text-center">Sucursal</h3>

    <div class="container">
        <h5>Agregar Sucursal</h5>
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <asp:Label runat="server" Text="Nombre:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control" />

                    <asp:Label runat="server" Text="Direcció:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />


                    <asp:Button runat="server" ID="btnAgregarFabricante" Text="Agregar" CssClass="btn btn-secondary ml-2" Style="margin-right: 10px;" />

                </div>
            </div>
        </div>
    </div>

    <div class="table-container pb-4 ">
        <asp:GridView runat="server" ID="dgvSucursal" DataKeyNames="Id" OnSelectedIndexChanged="dgvSucursal_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover" AutoGenerateColumns="false">
            <Columns>
                <asp:TemplateField HeaderText="Código">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Nombre") %>' />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="Nombre">
                    <ItemTemplate>
                        <asp:Label runat="server" Text='<%# Eval("Direccion") %>' />
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





    <asp:ListView runat="server" ID="lvSucursal" ItemType="Dominio.Sucursal">
        <ItemTemplate>
            <div class="card mb-3">
                <div class="card-body">
                    <h5 class="card-title"><%# Item.Nombre %></h5>
                    <p class="card-text"><%# Item.Direccion %></p>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>

</asp:Content>
