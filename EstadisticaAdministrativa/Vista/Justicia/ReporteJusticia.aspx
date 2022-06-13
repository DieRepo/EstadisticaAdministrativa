<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="ReporteJusticia.aspx.cs" Inherits="EstadisticaAdministrativa.Vista.Justicia.ReporteJusticia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <h1>Reportes "Yo por la justicia"</h1>
    <br />


    <asp:Panel runat="server" class="input-group">
        <span class="input-group-text">Fecha de Inicio:     </span>

        <asp:TextBox ID="FechaInicio" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" />
        <asp:Label runat="server" CssClass="input-group-append">
            <asp:Label runat="server" ID="inicio_icon" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
            </asp:Label>
        </asp:Label>
        <axT:MaskedEditExtender ID="inicio_extender" runat="server" TargetControlID="FechaInicio" MaskType="Date" Mask="99/99/9999"
            MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
        <axT:MaskedEditValidator ID="inicio_validator" runat="server" ControlExtender="inicio_extender" ControlToValidate="FechaInicio" IsValidEmpty="false"
            EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
        <axT:CalendarExtender runat="server" TargetControlID="FechaInicio" Format="dd/MM/yyyy" PopupButtonID="inicio_icon" />
    </asp:Panel>

    <br />
    <asp:Panel runat="server" class="input-group">
        <span class="input-group-text">Fecha de término:     </span>

        <asp:TextBox ID="FechaFin" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" />
        <asp:Label runat="server" CssClass="input-group-append">
            <asp:Label runat="server" ID="fin_icon" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
            </asp:Label>
        </asp:Label>
        <axT:MaskedEditExtender ID="fin_extender" runat="server" TargetControlID="FechaFin" MaskType="Date" Mask="99/99/9999"
            MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
        <axT:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="fin_extender" ControlToValidate="FechaFin" IsValidEmpty="false"
            EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
        <axT:CalendarExtender runat="server" TargetControlID="FechaFin" Format="dd/MM/yyyy" PopupButtonID="fin_icon" />
    </asp:Panel>

    <asp:Panel runat="server">
            <asp:Button ID="Button_Consultar" class="btn btn-secondary" runat="server" Text="Consultar" OnClick="Button_Consultar_Click" />
    </asp:Panel>

    <br />


    <asp:Panel runat="server">
        <h3>Lúdicas</h3>
        <asp:GridView ID="tablaVisitasLudicas" runat="server" CssClass="table table-striped table-bordered"
            AutoGenerateColumns="False" GridLines="None"
            EmptyDataText="No se ha agregado información"
             ShowHeaderWhenEmpty="true" >
            <Columns>
                <asp:BoundField DataField="nombreTipo" HeaderText="VISITA" />
                <asp:BoundField DataField="NH" HeaderText="NIÑOS" />
                <asp:BoundField DataField="NM" HeaderText="NIÑAS" />
                <asp:BoundField DataField="P" HeaderText="PADRES" />
                <asp:BoundField DataField="M" HeaderText="MADRES" />
                <asp:BoundField DataField="DH" HeaderText="DOCENTE (H)" />
                <asp:BoundField DataField="DM" HeaderText="DOCENTE (M)" />
            </Columns>

        </asp:GridView>
        <br /><br />
        <p></p>
         <h3>Guiadas</h3>
        <asp:GridView ID="tablaVisitasGuiadas" runat="server" CssClass="table table-striped table-bordered"
            AutoGenerateColumns="False" GridLines="None"
            EmptyDataText="No se ha agregado información"
             ShowHeaderWhenEmpty="true" >
                        <Columns>
                <asp:BoundField DataField="nombreTipo" HeaderText="VISITA" />
                <asp:BoundField DataField="NH" HeaderText="NIÑOS" />
                <asp:BoundField DataField="NM" HeaderText="NIÑAS" />
                <asp:BoundField DataField="P" HeaderText="PADRES" />
                <asp:BoundField DataField="M" HeaderText="MADRES" />
                <asp:BoundField DataField="DH" HeaderText="DOCENTE (H)" />
                <asp:BoundField DataField="DM" HeaderText="DOCENTE (M)" />
            </Columns>

        </asp:GridView>
        <br /><br />
        <p></p>
        <h3>Apoyo de botargas</h3>
        <asp:GridView ID="tablaApoyoBotargas" runat="server" CssClass="table table-striped table-bordered"
            AutoGenerateColumns="false" GridLines="None"
            EmptyDataText="No se ha agregado información"
             ShowHeaderWhenEmpty="true"  AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="Eventos" HeaderText="EVENTOS" />
                <asp:BoundField DataField="Total" HeaderText="TOTAL" />
                <asp:BoundField DataField="Dias" HeaderText="DIAS" />
            </Columns>
        </asp:GridView>
    </asp:Panel>
</asp:Content>
