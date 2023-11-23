<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="  container p-2 ">
        <h3 class="p-1 text-center border border-primary-subtle rounded bg-primary bg-opacity-50  p-2 mb-2">Informes </h3>
    </div>


    <%--Contenedor inicial tres cuadros  --%>
    <div class="container">
        <div class="table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50">
            <div class="container text-center">
                <div class="row">
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Venta Del Día</h4>
                        <asp:Label ID="lbVentaDia" runat="server" Text="00.0" Style="font-size: 24px;"></asp:Label>

                    </div>

                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>$ Del Día</h4>
                        <asp:Label ID="lbGastoDia" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>

                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Rendimiento del Día</h4>
                        <asp:Label ID="lbRendimientoDia" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                </div>
            </div>

            <%--Contenedor final tres cuadros Dia  --%>
            <%--Contenedor inicial tres cuadros Mes --%>
            <div class="container text-center">
                <div class="row">
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Venta Del Mes</h4>
                        <asp:Label ID="lbVentaMes" runat="server" Text="00.0" Style="font-size: 24px;"></asp:Label>

                    </div>

                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>$ Del Mes</h4>
                        <asp:Label ID="lbGastoMes" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>

                    </div>
                    <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                        <h4>Rendimiento del Mes</h4>
                        <asp:Label ID="lbRendimientoMes" runat="server" Text="0.00" Style="font-size: 24px;"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <%-- Pestallas para los informes --%>
    <div class="container">
        <div class="md-3 p-3 bg-primary bg-opacity-10 border border-4 border-primary-subtle rounded-4">
            <ul class="nav nav-tabs table-container pb-4 border border-primary-subtle p-2 mb-2  rounded bg-primary bg-opacity-50" id="myTabs" role="tablist">
                <li class="nav-item" role="presentation">
                    <a class="nav-link active" id="ventas-tab" data-bs-toggle="tab" data-bs-target="#ventas" role="tab" aria-controls="ventas" aria-selected="true">Informe de Ventas</a>
                </li>
                <li class="nav-item" role="presentation">
                    <a class="nav-link" id="stock-tab" data-bs-toggle="tab" data-bs-target="#stock" role="tab" aria-controls="stock" aria-selected="false">Informe de Modificaciones de Stock</a>
                </li>
            </ul>

            <!-- Contenido de las pestañas -->
            <div class="tab-content" id="myTabContent">
                <div class="tab-pane fade show active" id="ventas" role="tabpanel" aria-labelledby="ventas-tab">
                    <!-- Contenido del informe de ventas -->
                    <asp:GridView runat="server" ID="dgvHistorialVentas" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary mx-auto">
                    </asp:GridView>

                    <!-- ... -->
                </div>
                <div class="tab-pane fade" id="stock" role="tabpanel" aria-labelledby="stock-tab">
                    <!-- Contenido del informe de modificaciones de stock -->
                    <asp:GridView runat="server" ID="dgvStockHistoria" DataKeyNames="Id" CssClass="table table-striped table-bordered table-hover table-primary table table-bordered border-primary mx-auto">
                    </asp:GridView>
                    <!-- ... -->
                </div>
            </div>
        </div>
    </div>


</asp:Content>
