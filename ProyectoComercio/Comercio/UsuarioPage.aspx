<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UsuarioPage.aspx.cs" Inherits="Comercio.UsuarioPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .checkbox-margin {
            margin-right: 45px; /* Ajusta el margen según tus necesidades */
        }
    </style>

    <h3 class="p-1 text-center">Usuario</h3>
    <div class="container">
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

                    <h6>Permisos:</h6>
                    <div class="form-group">
                        <table>
                            <tr>
                                <td>
                                    <asp:Label ID="Label1" runat="server" Text="Inicio"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox1" runat="server" CssClass="checkbox-margin" />
                                </td>
                                <td>
                                    <asp:Label ID="Label2" runat="server" Text="Venta"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox2" runat="server" CssClass="checkbox-margin" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label3" runat="server" Text="Caja"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox3" runat="server" CssClass="checkbox-margin" />
                                </td>
                                <td>
                                    <asp:Label ID="Label4" runat="server" Text="Inventario"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox4" runat="server" CssClass="checkbox-margin" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label5" runat="server" Text="Proveedor"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox5" runat="server" CssClass="checkbox-margin" />
                                </td>
                                <td>
                                    <asp:Label ID="Label6" runat="server" Text="Cliente"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox6" runat="server" CssClass="checkbox-margin" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label7" runat="server" Text="Precio"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox7" runat="server" CssClass="checkbox-margin" />
                                </td>
                                <td>
                                    <asp:Label ID="Label8" runat="server" Text="Usuario"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox8" runat="server" CssClass="checkbox-margin" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="Label9" runat="server" Text="Compra"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox9" runat="server" CssClass="checkbox-margin" />
                                </td>
                                <td>
                                    <asp:Label ID="Label10" runat="server" Text="Sucursal"></asp:Label>
                                </td>
                                <td>
                                    <asp:CheckBox ID="CheckBox10" runat="server" CssClass="checkbox-margin" />
                                </td>
                            </tr>
                        </table>
                    </div>

                <asp:Button ID="btnAgregar" runat="server" Text="Agregar Usuario" OnClick="btnAgregar_Click1" CssClass="btn btn-success"/>
                </div>
            </div>
        </div>
    </div>

    <div class="pb-4"></div>
</asp:Content>



