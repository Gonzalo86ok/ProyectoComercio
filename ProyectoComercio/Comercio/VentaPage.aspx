<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VentaPage.aspx.cs" Inherits="Comercio.VentaPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3 class="p-1 text-center">Venta</h3>
    <div class="row">
        <div class="col-12">
            <div class="card-deck">
               <asp:Repeater ID="rptCategorias" runat="server">
                    <ItemTemplate>
                        <div class="card">
                            <div class="card-body">
                                <h5 class="card-title"><%# Eval("Tipo") %></h5>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </div>
</asp:Content>
