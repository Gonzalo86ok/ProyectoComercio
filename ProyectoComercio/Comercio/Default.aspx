<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Comercio.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    
    <%--Contenedor inicial tres cuadros  --%>
    <div class="container text-center">
        <div class="row">
            <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                <h4>Venta Del Día</h4>
                <asp:Label ID="lbVentaDia" runat="server" Text="00.0" style="font-size: 24px; "></asp:Label>
                
            </div>

            <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                <h4>  $ Del Día</h4>
                <asp:Label ID="lbGastoDia" runat="server" Text="0.00" style="font-size: 24px;"></asp:Label>
                
            </div>
            <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
                <h4>Rendimiento del Día</h4>
                <asp:Label ID="lbRendimientoDia" runat="server" Text="0.00" style="font-size: 24px;"></asp:Label>
            </div>
        </div>
    </div>
    <%--Contenedor final tres cuadros Dia  --%>
    <%--Contenedor inicial tres cuadros Mes --%>
 <div class="container text-center">
     <div class="row">
         <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
             <h4>Venta Del Mes</h4>
             <asp:Label ID="lbVentaMes" runat="server" Text="00.0" style="font-size: 24px; "></asp:Label>
             
         </div>

         <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
             <h4> $ Del Mes</h4>
             <asp:Label ID="lbGastoMes" runat="server" Text="0.00" style="font-size: 24px;"></asp:Label>
             
         </div>
         <div class="col" style="width: 100px; height: 100px; border: 1px solid black; background-color: gray">
             <h4>Rendimiento del Mes</h4>
             <asp:Label ID="lbRendimientoMes" runat="server" Text="0.00" style="font-size: 24px;"></asp:Label>
         </div>
     </div>
 </div>
 <%--Contenedor final tres cuadros Mes  --%>

</asp:Content>
