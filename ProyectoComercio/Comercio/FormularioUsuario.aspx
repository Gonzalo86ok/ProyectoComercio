<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioUsuario.aspx.cs" Inherits="Comercio.FormularioUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <h3 class="p-1 text-center">Formulario</h3>
    <!-- Formulario de agregar productos -->
    <div class="form-container border border-secondary p-3">
        <h5>Modificar Usuario</h5>
        <div class="row">
            <div class="col-md-6">

                <asp:Label runat="server" Text="Nuevo Usuario:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />

                <asp:Label runat="server" Text="Nueva Contraseña:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" />
                <asp:Label ID="lblMensaje2" runat="server" Text=""></asp:Label>

      
            <asp:Button ID="btnModificar" runat="server" Text="Agregar Cambios" OnClick="btnModificacion_Click1" CssClass="btn btn-success"/>
                <asp:Button runat="server" ID="btnCancelarModificar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-outline-danger " />

            </div>

            
    </div>
        </div>
</asp:Content>
