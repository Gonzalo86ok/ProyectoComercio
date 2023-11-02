<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ProveedorPage.aspx.cs" Inherits="Comercio.ProveedorPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <%--  internal class Proveedor
{
    public int Id { get; set; }
    public Persona Persona { get; set; }
    public Categoria Categoria { get; set; }
    public TipoRol TipoRol { get; set; }
    public bool Activo { get; set; }
    
  public class Persona
 {
     public int Id { get; set; }
     public string Nombre { get; set; }
     public string Apellido { get; set; }
     public string Telefono { get; set; }
     public string Email { get; set; }
     public string Direccion { get; set; }
 }

}--%>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Proveedor</h3>
    <div class="container">
        <h5>Agregar Proveedor</h5>
        <div class="row">
            <div class="col-md-6">
                <div class="form-container border border-secondary p-3">
                    <asp:Label runat="server" Text="Apellido:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtApellido" CssClass="form-control" />

                    <asp:Label runat="server" Text="Nombre:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control" />

                    <asp:Label runat="server" Text="Telefono:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtTelefono" CssClass="form-control" />

                    <asp:Label runat="server" Text="Email:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="txtMail" CssClass="form-control" />


                    <asp:Label runat="server" Text="Dirección:" CssClass="form-label" />
                    <asp:TextBox runat="server" ID="TextDireccion" CssClass="form-control" />

                    <asp:Label runat="server" Text="Categoria:" CssClass="form-label" />
                    <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-control"></asp:DropDownList>

                    <asp:Label runat="server" Text="TipoRol:" CssClass="form-label" />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>


                    <asp:Button runat="server" ID="btnAgregarFabricante" Text="Agregar" CssClass="btn btn-secondary ml-2" Style="margin-right: 10px;" />

                </div>
            </div>
        </div>
    </div>

    <div class="pb-4"></div>
    <div class="row">
        <asp:Repeater ID="RepeaterFabricantes" runat="server">
            <ItemTemplate>
                <div class="col-md-4">
                    <div class="card mb-4">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        </div>
                        <itemtemplate>
                            <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
                            <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
                        </itemtemplate>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
    
</asp:Content>
