<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Site.Master" AutoEventWireup="true" CodeBehind="RegistroCapacitacion.aspx.cs" Inherits="EstadisticaAdministrativa.Vista.Capacitacion.RegistroCapacitacion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />

    <link rel="stylesheet" type="text/css" href="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css"  />
    <link rel="stylesheet" href="../../Css/Sesion.css" />
    <link rel="stylesheet" href="../../Css/alertifyjs/alertify.css"  />
    <link rel="stylesheet" href="../../Css/alertifyjs/themes/default.css"  />
    <link rel="stylesheet" href="../../Css/animate.css" />
    <link rel="stylesheet" href="../../Css/pnotify.custom.min.css" />
    <style type="text/css">
    .alertify.popup2
    {
        background: Green;
    }
    .alertify.popup1
    {
        background: Red;
    }
</style>
   
         
    <script src="../.././Scripts/alertify.js"></script>
    <script src="../.././Scripts/alertify.min.js"></script>
    <script src="../.././Scripts/pnotify.custom.min.js"></script>
    <script src="../.././Scripts/Sesion.js"></script>
    <script type="text/javascript" src="https://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" ></script>


    <script type="text/javascript">

        $(function () {
            $('[id*=catapoyos]').multiselect({
                includeSelectAllOption: true
            });
        });
        $(function () {
            $('[id*=CatApoyoEditar]').multiselect({
                includeSelectAllOption: true
            });
        });
   
          
          function SoloNum(e) {
                    var key_press = document.all ? key_press = e.keyCode : key_press = e.which;
                    return ((key_press > 47 && key_press < 58));
                    alert("Agregar solo numeros");
                }
    </script>
    
       

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <asp:Panel runat="server" CssClass="Contenido">
        <h1>Capacitaciones</h1>
        <hr />
        <br />

        <button type="button" class="btn btn-secondary" data-toggle="modal" data-target="#exampleModalCenter">
            Agregar
        </button>

        <br />
        <br />

        <asp:Panel runat="server">
            <h3>Capacitaciones Registradas</h3>
            <asp:GridView ID="tablaCapacitacion" runat="server" CssClass="table table-striped table-bordered" DataKeyNames="idcapacitacion"
                AutoGenerateColumns="False" GridLines="None" EnableViewState="False" OnRowCommand="tablaCapacitacion_RowCommand"
                EmptyDataText="No se encuentra información"
                ShowHeaderWhenEmpty="true"
                AllowPaging="true" OnPageIndexChanging="paginador">


                <Columns>
                    <asp:BoundField DataField="idcapacitacion" HeaderText="ID" />
                    <asp:BoundField DataField="nom_cap" HeaderText="NOMBRE CAPACITACION" />
                    <asp:BoundField DataField="fecha_inicio" DataFormatString="{0:d}" HeaderText="FECHA INICIO" />
                    <asp:BoundField DataField="fecha_fin" DataFormatString="{0:d}" HeaderText="FEHCA FIN" />

                    <asp:ButtonField ButtonType="Button" ControlStyle-CssClass="btn-secondary" CommandName="EditarCapacitacion" Text="Editar" />


                </Columns>
            </asp:GridView>
        </asp:Panel>

        <asp:Panel runat="server" ID="mascara" ClientIDMode="Static" Enabled="true" Visible="false">

           

            <asp:Panel runat="server" CssClass="div_emergente p-4 form-group" ClientIDMode="AutoID">
                 <h3>Editar Capacitación</h3>
                <hr />
                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">ID </span>
                    <asp:TextBox ID="ideditar" runat="server" class="form-control" aria-label="With textarea" Enabled="False"></asp:TextBox>
                </asp:Panel>

                <br />
                <asp:Panel runat="server" class="input-group">

                    <span class="input-group-text col-sm-3">Nombre del curso </span>
                    <asp:TextBox ID="NombreEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
                </asp:Panel>

                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Tema </span>
                    <asp:DropDownList ID="TemaEditar" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </asp:Panel>
                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Fecha Incio </span>
                    <asp:TextBox ID="FechaInicioEditar" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy" CssClass="form-control form-control-sm" ValidationGroup="EditarGroup" />
                    <asp:Label runat="server" CssClass="input-group-append">
                        <asp:Label runat="server" ID="Label3" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                    <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                        </asp:Label>
                    </asp:Label>
                    <axT:MaskedEditExtender ID="emision_extender" runat="server" TargetControlID="FechaInicioEditar" MaskType="Date" Mask="99/99/9999"
                        MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
                    <axT:MaskedEditValidator ID="emision_validator" runat="server" ControlExtender="emision_extender" ControlToValidate="FechaInicioEditar" IsValidEmpty="false"
                        EmptyValueMessage="*Campo Obligatorio" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
                    <axT:CalendarExtender runat="server" TargetControlID="FechaInicioEditar" ID="CalendarExtender4" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
                    <br />
                    <span class="input-group-text col-sm-3">Fecha Fin </span>
                    <asp:TextBox ID="FechaFinEditar" runat="server" CssClass="form-control form-control-sm" ValidationGroup="EditarGroup" />
                    <asp:Label runat="server" CssClass="input-group-append">
                        <asp:Label runat="server" ID="Label2" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                        </asp:Label>
                    </asp:Label>
                    <axT:MaskedEditExtender ID="emision_extender1" runat="server" TargetControlID="FechaFinEditar" MaskType="Date" Mask="99/99/9999"
                        MessageValidatorTip="true" AutoComplete="true" OnInvalidCssClass="text-danger" />
                    <axT:MaskedEditValidator ID="emision_validator1" runat="server" ControlExtender="emision_extender1" ControlToValidate="FechaFinEditar" IsValidEmpty="false"
                        EmptyValueMessage="*Campo Obligatorio" InvalidValueMessage="* Fecha no valida" ForeColor="Red" Font-Size="Small" Font-Italic="true" Display="Dynamic" />
                    <axT:CalendarExtender runat="server" TargetControlID="FechaFinEditar" ID="CalendarExtender3" Format="dd/MM/yyyy" PopupButtonID="emision_icon" />
                </asp:Panel>
                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Tipo </span>
                    <asp:DropDownList ID="TipoEditar" runat="server" CssClass="form-control">
                        <asp:ListItem Value="1"> Línea </asp:ListItem>
                        <asp:ListItem Value="2"> Presencial </asp:ListItem>
                        <asp:ListItem Value="3"> Ambos </asp:ListItem>
                    </asp:DropDownList>
                </asp:Panel>
                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Asistencia Hombres </span>
                    <asp:TextBox ID="HombresEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
                    <span class="input-group-text col-sm-3">Asistencia Mujeres </span>
                    <asp:TextBox ID="MujeresEditar" runat="server" class="form-control" aria-label="With textarea" required="true"></asp:TextBox>
                </asp:Panel>

                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Unidad Encargada </span>
                    <asp:DropDownList ID="CatEncargadaEditar" runat="server" CssClass="form-control">
                    </asp:DropDownList>
                </asp:Panel>

                <br />

                <asp:Panel runat="server" class="input-group">
                    <span class="input-group-text col-sm-3">Unidades de Apoyo </span>
                    <asp:ListBox ID="CatApoyoEditar" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </asp:Panel>
                <br />

                <asp:Button ID="ButtonEditarCap" runat="server" Text="Guardar" OnClick="ButtonEditar_Cap" class="btn btn-secondary float-right" ValidationGroup="EditarGroup" />
                <asp:Button ID="ButtonCancelarCap" runat="server" Text="Cancelar" OnClick="ButtonCancelar_Cap" class="btn btn-danger float-left" CausesValidation="false" />

            </asp:Panel>
        </asp:Panel>


        <!-- parte de nuevo -->


        <!-- Modal -->
        <div class="modal fade" id="exampleModalCenter" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-lg">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title" id="exampleModalLongTitle">Nueva Capacitación</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">

                        <div class="col-12">

                            <span class="input-group-text col-sm-3">Nombre del curso </span>

                            <asp:TextBox ID="nomcap" runat="server" class="form-control" aria-label="With textarea" ValidationGroup="Button1"></asp:TextBox>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator" runat="server" ErrorMessage="*Campo obligatorio" ControlToValidate="nomcap" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                ValidationGroup="Button1"></asp:RequiredFieldValidator>

                            <span class="input-group-text col-sm-3">Tema</span>

                            <asp:DropDownList ID="tema" runat="server"  CssClass="form-control">

                                <asp:ListItem Value="0" runat="server" Selected="True"> Selecciona una opción </asp:ListItem>

                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*Campo obligatorio" ControlToValidate="tema" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                ValidationGroup="Button1"></asp:RequiredFieldValidator>

                            <asp:Panel runat="server" class="input-group">
                                <span class="input-group-text col-sm-3">Fecha inicio</span>

                                <asp:TextBox ID="fec_ini" runat="server" CssClass="form-control form-control-sm" ValidationGroup="Button1" placeholder="dd/mm/yyyy" />
                                <asp:Label runat="server" CssClass="input-group-append">
                                    <asp:Label runat="server" ID="Label5" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                    <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                                    </asp:Label>
                                </asp:Label>
 
                                <axT:CalendarExtender runat="server" TargetControlID="fec_ini" ID="CalendarExtender1" Format="dd/MM/yyyy" />
                                

                                <span class="input-group-text col-sm-3">Fecha fin</span>

                                <asp:TextBox ID="fec_fin" runat="server" CssClass="form-control form-control-sm" ValidationGroup="Button1" placeholder="dd/mm/yyyy" />
                                <asp:Label runat="server" CssClass="input-group-append">
                                    <asp:Label runat="server" ID="Label1" ClientIDMode="Static" CssClass="input-group-text bg-danger">
                                                        <asp:Label runat="server" CssClass="text-white far fa-calendar-alt"/>
                                    </asp:Label>
                                </asp:Label>
 
                                <axT:CalendarExtender runat="server" TargetControlID="fec_fin" Format="dd/MM/yyyy" PopupButtonID="emision_icon" ID="CalendarExtender2" />
                                
                            </asp:Panel>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*Fecha inicio obligatorio" ControlToValidate="fec_ini" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                    ValidationGroup="Button1"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*Fecha fin obligatorio" ControlToValidate="fec_fin" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                    ValidationGroup="Button1"></asp:RequiredFieldValidator>

                            <span class="input-group-text col-sm-3">Tipo</span>

                            <asp:DropDownList ID="tipo" runat="server" CssClass="form-control" ValidationGroup="Button1">
                                <asp:ListItem Value="" Selected="True" disabled="true"> Selecciona una opción </asp:ListItem>
                                <asp:ListItem Value="1"> Línea </asp:ListItem>
                                <asp:ListItem Value="2"> Presencial </asp:ListItem>
                                <asp:ListItem Value="3"> Ambos </asp:ListItem>
                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*Campo obligatorio" ControlToValidate="tipo" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                ValidationGroup="Button1"></asp:RequiredFieldValidator>

                            <asp:Panel runat="server" class="input-group">
                                <span class="input-group-text col-sm-3">Asistencia Hombres </span>
                                     <asp:TextBox ID="hombre" runat="server" class="form-control form-control-sm"  MaxLength="999" aria-label="With textarea" ValidationGroup="Button1"></asp:TextBox>

                                <span class="input-group-text col-sm-3">Asistencia Mujeres </span>
                                    <asp:TextBox ID="mujer" runat="server"  class="form-control form-control-sm" min="0" aria-label="With textarea" ValidationGroup="Button1"></asp:TextBox>

                            </asp:Panel>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*Asistencia Hombres obligatorio" ControlToValidate="hombre" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                    ValidationGroup="Button1"  ValidationExpression="\d+"></asp:RequiredFieldValidator>
                           
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*Asistencia Mujeres obligatorio" ControlToValidate="mujer" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                    ValidationGroup="Button1"  ValidationExpression="\d+"></asp:RequiredFieldValidator>


                            <span class="input-group-text col-sm-3">Area Encargada</span>

                            <asp:DropDownList ID="encargada" runat="server" CssClass="form-control">
                                <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>

                            </asp:DropDownList>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*Campo obligatorio" ControlToValidate="encargada" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                ValidationGroup="Button1"></asp:RequiredFieldValidator>

                            <span class="input-group-text col-sm-3">Area de Apoyo</span>

                            <asp:ListBox ID="catapoyos" runat="server" SelectionMode="Multiple" Width="80%">
                                <asp:ListItem Value="-1" Selected="True"> Selecciona una opción </asp:ListItem>
                            </asp:ListBox>


                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*Campo obligatorio" ControlToValidate="catapoyos" ForeColor="Red" Font-Size="Small" Font-Italic="true" SetFocusOnError="true"
                                ValidationGroup="Button1"></asp:RequiredFieldValidator>

                        </div>
                        </div>

                        <div class="modal-footer">
                            <button type="button" class="btn btn-secondary" data-dismiss="modal">Cerrar</button>
                            <asp:Button ID="Button1" class="btn btn-primary" ValidationGroup="Button1" runat="server" Text="Guardar" OnClick="GuardarCapacita" />

                        </div>
                    </div>
                </div>
            </div>
    </asp:Panel>


</asp:Content>

