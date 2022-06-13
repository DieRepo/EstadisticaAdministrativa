<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="RegistroJusticia.aspx.cs" Inherits="EstadisticaAdministrativa.Vista.Justicia.RegistroJusticia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:Panel runat="server" CssClass="Contenido">
        <h1>Yo por la justicia</h1>
        <hr />
        <br />
        <asp:Panel runat="server" class="input-group">
            <span class="input-group-text">Escuela o Insitución: </span>
            <asp:TextBox ID="TextNombre" runat="server" class="form-control" aria-label="With textarea" ></asp:TextBox>
            <asp:RequiredFieldValidator runat="server" ID="nombre_validator" ErrorMessage="* Escuela o Institución no puede estar vacío" ControlToValidate="TextNombre"
                    ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true" />
        </asp:Panel>
        <br />
        <asp:Panel runat="server" class="input-group">
            <span class="input-group-text">Fecha que reporta:     </span>

            <asp:TextBox ID="FechaRegistro"  ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy"  CssClass="form-control form-control-sm" />
            <asp:Label runat="server" CssClass="input-group-append">
                <asp:Label runat="server" ID="emision_icon" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                </asp:Label>
            </asp:Label>
            <axT:MaskedEditExtender ID="emision_extender" runat="server" TargetControlID="FechaRegistro" MaskType="Date" Mask="99/99/9999"
                MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
            <axT:MaskedEditValidator ID="emision_validator" runat="server" ControlExtender="emision_extender" ControlToValidate="FechaRegistro" IsValidEmpty="false"
                EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
            <axT:CalendarExtender runat="server" TargetControlID="FechaRegistro" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
        </asp:Panel>

        <br />
        <br />


        <asp:Panel runat="server" ID="contenido_tabla_visitas">

            <h3>VISITAS</h3>
            <asp:Table ID="Tabla1" runat="server"
                CellPadding="3" CellSpacing="5"
                GridLines="both" >
                <asp:TableHeaderRow runat="server"
                    BackColor="#b71c1c" ForeColor="White">
                    <asp:TableCell
                        ColumnSpan="2"
                        Text="" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Niños" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Padres" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Docentes" />
                </asp:TableHeaderRow>

                <asp:TableFooterRow ID="Table1HeaderRow"
                    BackColor="#b71c1c" ForeColor="White"
                    runat="server">
                    <asp:TableCell
                        ColumnSpan="2"
                        Text="" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                </asp:TableFooterRow>
            </asp:Table>
            
        </asp:Panel>

        <br /><br />
            <asp:Panel runat="server" ID="Panel_Botargas">

                <h3>APOYO DE BOTARGAS</h3>

                <asp:Table ID="TableBotargas" runat="server"
                    CellPadding="3" CellSpacing="5"
                    GridLines="both" class="table">

                    <asp:TableHeaderRow runat="server"
                        BackColor="#b71c1c" ForeColor="White">
                        <asp:TableCell Text="" 
                            />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Fecha" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Eventos" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Total" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Numero de días" />
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" Text="1"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="FechaApoyo" type="Date" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBoxEventos" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBoxTotal" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBoxDias" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
            </asp:Panel>


            <asp:Button ID="Button_Guardar" class="btn btn-secondary" runat="server" Text="Guardar" OnClick="Button_Guardar_Click" />





    </asp:Panel>

    <br /><br />
    <asp:Panel runat="server">
        <h3>Registrado</h3>
        <asp:GridView ID="tablaRegistros" runat="server" CssClass="table table-striped table-bordered" DataKeyNames="ID"
            AutoGenerateColumns="False" GridLines="None" EnableViewState="False" OnRowCommand="tablaRegistros_RowCommand"
            EmptyDataText="No se ha agregado información"
             ShowHeaderWhenEmpty="true" OnPageIndexChanging="paginador" AllowPaging="true">
            <Columns>
                <asp:BoundField DataField="ID" HeaderText="CVE" />
                <asp:BoundField DataField="NombreEscuela" HeaderText="ESCUELA / INSTITUCIÓN" />
                <asp:BoundField DataField="FechaReporta" HeaderText="FECHA QUE REPORTA" />
<%--                <asp:ButtonField ButtonType="Button" CommandName="VerRegistro" Text="Ver" />--%>
                <asp:ButtonField ButtonType="Button" CommandName="EditarRegistro" Text="Editar" />

            </Columns>
        </asp:GridView>
    </asp:Panel>

        <asp:Panel runat="server" ID="mascara" ClientIDMode="Static" Enabled="true" Visible="false">


            <asp:Panel runat="server" CssClass="div_emergente p-4 form-group" ClientIDMode="AutoID">

                <div style="width: 100%; background-color: black;">
                    <asp:ImageButton runat="server" ImageUrl="../../Img/close.png" Style="width: 25px; height: 25px;" OnClick="ButtonCerrar_Click" CausesValidation="false" />
                </div>

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text">Escuela o Insitución: </span>
                    <asp:TextBox ID="TextNombreEditar" runat="server" class="form-control" aria-label="With textarea"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ID="nombreEditar_validator" ErrorMessage="* Escuela o Institución no puede estar vacío" ControlToValidate="TextNombreEditar"
                        ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true" />
                </asp:Panel>
        <br />
        <asp:Panel runat="server" class="input-group">
            <span class="input-group-text">Fecha que reporta:     </span>

            <asp:TextBox ID="FechaRegistroEditar"  ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy hh:mm:ss" CssClass="form-control form-control-sm" ValidationGroup="EditarGroup"/>
            <asp:Label runat="server" CssClass="input-group-append">
                <asp:Label runat="server" ID="Label1" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                </asp:Label>
            </asp:Label>
            <axT:MaskedEditExtender ID="MaskedEditExtender1" runat="server" TargetControlID="FechaRegistroEditar" MaskType="Date" Mask="99/99/9999"
                MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
            <axT:MaskedEditValidator ID="MaskedEditValidator1" runat="server" ControlExtender="emision_extender" ControlToValidate="FechaRegistroEditar" IsValidEmpty="false"
                EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
            <axT:CalendarExtender runat="server" TargetControlID="FechaRegistroEditar" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
        </asp:Panel>


                        <asp:Table ID="TablaEditar" runat="server"
                CellPadding="3" CellSpacing="5"
                GridLines="both" >
                <asp:TableHeaderRow runat="server"
                    BackColor="#b71c1c" ForeColor="White">
                    <asp:TableCell
                        ColumnSpan="2"
                        Text="" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Niños" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Padres" />
                    <asp:TableHeaderCell
                        ColumnSpan="2"
                        Text="Docentes" />
                </asp:TableHeaderRow>

                <asp:TableFooterRow ID="TableFooterRow1"
                    BackColor="#b71c1c" ForeColor="White"
                    runat="server">
                    <asp:TableCell
                        ColumnSpan="2"
                        Text="" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Mujer" />
                    <asp:TableCell
                        Scope="Column"
                        Text="Hombre" />
                </asp:TableFooterRow>
            </asp:Table>

             <asp:Panel runat="server" ID="Panel1">

                <h3></h3>

                <asp:Table ID="TableBotargasEditar" runat="server"
                    CellPadding="3" CellSpacing="5"
                    GridLines="both" class="table">

                    <asp:TableHeaderRow runat="server"
                        BackColor="#b71c1c" ForeColor="White">
                        <asp:TableCell Text="" 
                            />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Fecha" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Eventos" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Total" />
                        <asp:TableHeaderCell
                            ColumnSpan="1"
                            Text="Numero de días" />
                    </asp:TableHeaderRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label runat="server" Text="1"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox1" type="Date" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" >

                            </asp:TextBox>
                        </asp:TableCell>
                    </asp:TableRow>

                </asp:Table>
            </asp:Panel>



            <asp:Button ID="ButtonEditar" runat="server" Text="Guardar" OnClick="ButtonEditar_Click" class="btn btn-secondary float-right" ValidationGroup="EditarGroup" />
            <asp:Button ID="ButtonCancelar" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Click" class="btn btn-secondary float-right" CausesValidation="false"/>


        </asp:Panel>



    </asp:Panel>


</asp:Content>
