<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuarioPage.aspx.cs" Inherits="Comercio.UsuarioPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .checkbox-margin {
            margin-right: 45px; /* Ajusta el margen según tus necesidades */
        }
    </style>

    <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2">Usuario</h3>
    <div class="container table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50 p-3 ">
        <h5>Agregar Usuario</h5>
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <div class="form-group">
                        <asp:Label runat="server" Text="Usuario:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />
                    </div>

                    <div class="form-group">
                        <asp:Label runat="server" Text="Contrasena:" CssClass="form-label" />
                        <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" />
                    </div>                                      
                    
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregar_Click1" CssClass="btn btn-success"/>
                </div>
            </div>
        </div>
    </div>

    <div class="pb-4"></div>
    <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50 p-3">
        <h5>Listado de Usuarios</h5>
                    <div class="pb-4"></div>
                    <div class="table-container pb-4 ">
                        <asp:GridView runat="server" ID="dgvUsuario" DataKeyNames="Id" OnSelectedIndexChanged="dgvUsuario_SelectedIndexChanged" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary" AutoGenerateColumns="false">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("Id") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Usuario">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("User") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="TipoUsuario">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("TipoUsuario") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Acciones">
                                    <ItemTemplate>
                                        <asp:Button runat="server" Text="Modificar" OnClick="btnModificarUsuario_Click" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-outline-primary" />
                                        <asp:Button runat="server" Text="Eliminar" OnClick="btnEliminarUsuario_Click" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-outline-danger" />                                       
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
</asp:Content>



