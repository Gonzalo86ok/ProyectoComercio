<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ClientePage.aspx.cs" Inherits="Comercio.ClientePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<%--    internal class Cliente
 {
     public Persona Persona { get; set; }
     public TipoComercio Comercio { get; set; }
     public TipoRol TipoRol { get; set; }
     public bool Activo { get; set; }
     // Modificar la clase, y crear una nueva que administre la cantidad de ventas.
 }--%>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Cliente</h3>

    <div class="container">
        <h5>Agregar Cliente</h5>
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

                    <asp:Label runat="server" Text="Tipo de Comercio:" CssClass="form-label" />
                    <asp:DropDownList ID="ddlTipoComercio" runat="server" CssClass="form-control"></asp:DropDownList>

                    <asp:Label runat="server" Text="TipoRol:" CssClass="form-label" />
                    <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control"></asp:DropDownList>


                    <asp:Button runat="server" ID="btnAgregarCliente" Text="Agregar" CssClass="btn btn-secondary ml-2" Style="margin-right: 10px;" />

                </div>
            </div>
        </div>
    </div>
    <div class="pb-4"></div>
    <div class="row">
        <itemtemplate>
            <asp:Button runat="server" Text="Modificar" CommandName="Modificar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-primary" />
            <asp:Button runat="server" Text="Eliminar" CommandName="Eliminar" CommandArgument='<%# Eval("Id") %>' CssClass="btn btn-danger" />
        </itemtemplate>
    </div>
 

</asp:Content>
