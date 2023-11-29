﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="FormularioFabricante.aspx.cs" Inherits="Comercio.FormularioFabricante" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-md-6">
        <div class="md-3">
            <asp:ScriptManager runat="server" />
            <div class="form-container border border-secondary p-3">
                <h5>Agregar Fabricante / Marca</h5>
                <asp:Label runat="server" Text="Nombre Fabricante o Marca:" CssClass="form-label" MaxLength="40" />
                <asp:TextBox runat="server" ID="TxtFabricante" CssClass="form-control" />

                <div class="form-group">
                    <asp:Label runat="server" ID="lblMensajeError" CssClass="text-danger" Visible="false" />
                </div>

                <div class="button-container mt-4">
                    <div class="btn-group">
                        <asp:Button runat="server" ID="btnAgregarFabricante" OnClick="agregarFabricante_Click" Text="Agregar" CssClass="btn btn-outline-primary btn-block mt-4" Style="margin-right: 10px;" />
                        <asp:Button runat="server" ID="btnCancelar" OnClick="btnCancelar_Click" Text="Cancelar" CssClass="btn btn-outline-primary btn-block mt-4" Style="margin-right: 10px;" />
                        <asp:Button Text="Eliminar" ID="btnEliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger btn-block mt-4" runat="server"/>
                    </div>
                </div>
                <asp:UpdatePanel ID="UpdatePanel" runat="server">
                    <ContentTemplate>
                        <div class="md-3">
                            <%if (ConfirmaEliminacion)

                                {%>
                            <asp:CheckBox Text="Confirmar Eliminación" ID="chkConfirmaEliminacion" runat="server" />
                            <asp:Button Text="Eliminar" ID="btnConfirmaEliminar" OnClick="btnConfirmaEliminar_Click" CssClass="btn btn-outline-danger" runat="server" />
                            <% } %>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
