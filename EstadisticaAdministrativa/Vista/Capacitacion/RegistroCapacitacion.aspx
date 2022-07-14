<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCapacitacion.aspx.cs" Inherits="EstadisticaAdministrativa.Vista.Capacitacion.RegistroCapacitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    
  <link href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
  <!--  <link rel="stylesheet" href="../Css/tamañoselect.css" />-->

   
    <script src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
    <!-- <script src="../Scripts/seleccionarareas.js"></script>-->
  

     <script type="text/javascript">
        $(function () {
            $('[id*=catapoyos]').multiselect({
                  includeSelectAllOption: true
                        });
         });
          $(function () {
            $('[id*=CatapotoEditar]').multiselect({
                  includeSelectAllOption: true
                        });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    
    <asp:Panel runat="server" CssClass="Contenido">
        <h1>Capacitaciones</h1>
        <hr />
        <br />

        <div class="form-group row">
            <asp:Label for="nom_cap" runat="server" class="col-sm-3 col-form-label">Nombre de la capacitación</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox ID="nomcap" runat="server" class="form-control" ValidationGroup="Button1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="nomcap" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>

            </div>
        </div>
        <div class="form-group row">
            <asp:Label for="tema" runat="server" class="col-sm-3 col-form-label">Tema</asp:Label>
            <div class="col-sm-9">
                <asp:DropDownList ID="tema" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>

                </asp:DropDownList>
            </div>
        </div>
        <div class="form-group row">
            <asp:Label for="fecini" runat="server" class="col-sm-3 col-form-label">Fecha Inicio</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox ID="fec_ini" type="date" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" ValidationGroup="Button1"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="fec_ini" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
              
            </div>


            <asp:Label for="fecfin" runat="server" class="col-sm-3 col-form-label">Fecha fin</asp:Label>
            <div class="col-sm-9">
                <asp:TextBox ID="fec_fin" type="date" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" ValidationGroup="Button1"></asp:TextBox>
               <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="fec_fin" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
               
            </div>
        </div>
        <div class="form-group row">
            <label for="tipolp" runat="server" class="col-sm-3 col-form-label">Tipo</label>
            <div class="col-sm-9">
                <asp:DropDownList ID="tipo" runat="server" CssClass="form-control" ValidationGroup="Button1">
                    <asp:ListItem Value="" Selected="True" disabled="true"> Selecciona una opción </asp:ListItem>
                    <asp:ListItem Value="1"> Líneal </asp:ListItem>
                    <asp:ListItem Value="2"> Presencial </asp:ListItem>
                </asp:DropDownList>
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="tipo" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
            </div>
        </div>
        <div class="form-group row">

            <asp:Label for="asis" runat="server" class="col-sm-3 col-form-label">Asistentes</asp:Label>

            <div runat="server" class="col-md-4">
                <asp:Label runat="server">Hombres</asp:Label>
                <asp:TextBox ID="hombre" runat="server" CssClass="form-control" ValidationGroup="Button1"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="hombre" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
            </div>
             <div runat="server" class="col-md-1"></div>

            <div runat="server" class="col-md-4">
                <asp:Label runat="server">Mujeres </asp:Label>
                <asp:TextBox ID="mujer" runat="server" CssClass="form-control" ValidationGroup="Button1"></asp:TextBox>
                  <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server"  ErrorMessage="*Campo obligatorio, no puede estar vacío" ControlToValidate="mujer" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
            </div>
        </div>

        <div class="form-group row">

            <asp:Label for="area" runat="server" class="col-sm-3 col-form-label">Area Encargada</asp:Label>
            <div class="col-sm-9">
                <asp:DropDownList ID="encargada" runat="server" CssClass="form-control">
                    <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>

                </asp:DropDownList>
            </div>
        </div>
        <div class=" form-group row">

            <asp:Label for="apoyo" runat="server" class="col-sm-3 col-form-label">Area de Apoyo</asp:Label>
            <div class="col-sm-9">
                <asp:ListBox ID="catapoyos" runat="server" SelectionMode="Multiple" Width="680px"></asp:ListBox>
            </div>
        </div>


        <asp:Button ID="Button1" class="btn btn-secondary"  ValidationGroup="Button1"  runat="server" Text="Guardar" OnClick="GuardarCapacita" />

    </asp:Panel>



     <!-- <asp:BoundField DataField="idtema" HeaderText="TEMA" /> -->
    <!--  <asp:BoundField DataField="idunidad" HeaderText="UNIDAD ENCARGADA" /> -->

    <!-- <asp:Panel runat="server" class="input-group">
                     <span class="input-group-text">Tema </span>
                        <asp:DropDownList ID="TemaEditar" runat="server" CssClass="form-control">
                                <asp:ListItem  Value="0" Selected="True"> Selecciona una opción </asp:ListItem>
                       </asp:DropDownList>

                </asp:Panel> -->

      <!--   <asp:Panel runat="server" class="input-group">
                     <span class="input-group-text">Unidad Encargada </span>
                      <asp:DropDownList ID="CatEncargadaEditar" runat="server" CssClass="form-control">
                          
                      </asp:DropDownList>

                         <asp:Panel runat="server" class="input-group">
                     <span class="input-group-text">Unidades de Apoyo </span>
                        <asp:ListBox ID="CatApoyoEditar" runat="server" SelectionMode="Multiple">
                   
                </asp:ListBox>

                </asp:Panel> -->

     <br /><br />





    <asp:Panel runat="server">
        <h3>Capacitaciones Registradas</h3>
        <asp:GridView ID="tablaCapacitacion" runat="server" CssClass="table table-striped table-bordered" DataKeyNames="idcapacitacion"
            AutoGenerateColumns="False" GridLines="None" EnableViewState="False"  OnRowCommand="tablaCapacitacion_RowCommand"
            EmptyDataText="No se encuentra información"
            ShowHeaderWhenEmpty="true"  
             AllowPaging="true" OnPageIndexChanging="paginador">
            <Columns>
                <asp:BoundField DataField="idcapacitacion" HeaderText="ID" />
                <asp:BoundField DataField="nom_cap" HeaderText="NOMBRE CAPACITACION" />
              
                <asp:BoundField DataField="fecha_inicio" DataFormatString="{0:d}" HeaderText="FECHA INICIO" />
                <asp:BoundField DataField="fecha_fin" DataFormatString="{0:d}" HeaderText="FEHCA FIN" />
               

                

                <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-secondary" CommandName="EditarCapacitacion" Text="Editar" />
               <!-- <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-primary" CommandName="EliminarCapacitacion" Text="Eliminar" /> -->

            </Columns>
        </asp:GridView>
    </asp:Panel>

    
    
    
    
    <asp:Panel runat="server" ID="mascara" ClientIDMode="Static" Enabled="true" Visible="false">

        <asp:Panel runat="server" CssClass="div_emergente p-4 form-group" ClientIDMode="AutoID">

            <div style="width: 100%; background-color: black;">
                <asp:ImageButton runat="server" ImageUrl="../../Img/close.png" Style="width: 25px; height: 25px;" OnClick="ButtonCerrar_Click" CausesValidation="false" />
            </div>

            <asp:Panel runat="server" class="input-group">
                 <asp:TextBox ID="ideditar" runat="server" class="form-control" aria-label="With textarea"></asp:TextBox>
                <span class="input-group-text">Nombre del curso </span>
                <asp:TextBox ID="NombreEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
            </asp:Panel>

            <br />
            <asp:Panel runat="server" class="input-group">
                <span class="input-group-text">Fecha Incio </span>

                <asp:TextBox ID="FechaInicioEditar"  ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" ValidationGroup="EditarGroup"/>
                <asp:Label runat="server" CssClass="input-group-append">
                    <asp:Label runat="server" ID="Label3" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                    <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                    </asp:Label>
                </asp:Label>
                <axT:MaskedEditExtender ID="emision_extender" runat="server" TargetControlID="FechaInicioEditar" MaskType="Date" Mask="99/99/9999"
                    MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
                <axT:MaskedEditValidator ID="emision_validator" runat="server" ControlExtender="emision_extender" ControlToValidate="FechaInicioEditar" IsValidEmpty="false"
                    EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
                <axT:CalendarExtender runat="server" TargetControlID="FechaInicioEditar" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
           

                <br />

                <span class="input-group-text">Fecha Fin </span>

                <asp:TextBox ID="FechaFinEditar" runat="server" CssClass="form-control form-control-sm" ValidationGroup="EditarGroup" />
                <asp:Label runat="server" CssClass="input-group-append">
                    <asp:Label runat="server" ID="Label2" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                    </asp:Label>
                </asp:Label>

                 <axT:MaskedEditExtender ID="emision_extender1" runat="server" TargetControlID="FechaFinEditar" MaskType="Date" Mask="99/99/9999"
                    MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
                <axT:MaskedEditValidator ID="emision_validator1" runat="server" ControlExtender="emision_extender1" ControlToValidate="FechaFinEditar" IsValidEmpty="false"
                    EmptyValueMessage="* Fecha emisión no puede estar vació" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
                <axT:CalendarExtender runat="server" TargetControlID="FechaFinEditar" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
           

            </asp:Panel>

            <asp:Panel runat="server" class="input-group">
                <span class="input-group-text">Tipo </span>
                <asp:DropDownList ID="TipoEditar" runat="server" CssClass="form-control">
                     <asp:ListItem Value="1"> Líneal </asp:ListItem> 
                     <asp:ListItem Value="2"> Presencial </asp:ListItem>
                </asp:DropDownList>

            </asp:Panel>

            <asp:Panel runat="server" class="input-group">
                <span class="input-group-text">Asistencia Hombres </span>
                <asp:TextBox ID="HombresEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
            </asp:Panel>
            <asp:Panel runat="server" class="input-group">
                <span class="input-group-text">Asistencia Mujeres </span>
                <asp:TextBox ID="MujeresEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
            </asp:Panel>

            <asp:Button ID="ButtonEditarCap" runat="server" Text="Guardar" OnClick="ButtonEditar_Cap"  class="btn btn-secondary float-right" ValidationGroup="EditarGroup" />
            <asp:Button ID="ButtonCancelarCap" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Cap" class="btn btn-secondary float-right" CausesValidation="false" />

        </asp:Panel>
    </asp:Panel>

    <!--</asp:Panel>-->

</asp:Content>

