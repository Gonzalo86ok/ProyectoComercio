<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="RegistrarUsuario.aspx.cs" Inherits="Comercio.RegistrarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Formulario</h3>
    <!-- Formulario de agregar productos -->
    <div class="form-container border border-secondary p-3">
        <h5>Agregar Usuario</h5>
        <div class="row">
            <div class="col-md-6">

                <asp:Label runat="server" Text="Usuario:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtUsuario" CssClass="form-control" />

                <asp:Label runat="server" Text="Contraseña:" CssClass="form-label" />
                <asp:TextBox runat="server" ID="txtContraseña" CssClass="form-control" />
                 <asp:Label ID="lblMensaje2" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnAgregarUsuario" runat="server" Text="Registrar" OnClick="btnAgregarUser_Click1" CssClass="btn btn-success"/>

            </div>
            
    </div>
        </div>
</asp:Content>
