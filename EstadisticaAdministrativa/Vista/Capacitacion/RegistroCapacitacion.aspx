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
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel runat="server" CssClass="Contenido">
        <h1>Capacitaciones</h1>
        <hr />
        <br />

    <div class="form-group row">
       <asp:label for="nom_cap" runat="server" class="col-sm-3 col-form-label">Nombre de la capacitación</asp:label>
        <div class="col-sm-9">
          <asp:TextBox ID="nomcap" runat="server" class="form-control"></asp:TextBox>
        </div>
    </div>
  <div class="form-group row">
    <asp:label for="tema" runat="server" class="col-sm-3 col-form-label">Tema</asp:label>
        <div class="col-sm-9">
           <asp:DropDownList ID="tema" runat="server" CssClass="form-control">
                              <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>
                              <asp:ListItem Value="1"> tema1 </asp:ListItem>
                              <asp:ListItem Value="2"> tema2 </asp:ListItem>
                         </asp:DropDownList>
       </div>
  </div>
  <div class="form-group row">
    <asp:label for="fecini" runat="server" class="col-sm-3 col-form-label">Fecha Inicio</asp:label>
   <div class="col-sm-9">
       <asp:TextBox ID="fec_ini"  type="date" ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy"  CssClass="form-control form-control-sm"></asp:TextBox>
      </div>     
            
  
    <asp:label for="fecfin" runat="server" class="col-sm-3 col-form-label">Fecha fin</asp:label>
    <div class="col-sm-9">
       <asp:TextBox ID="fec_fin" type="date"  ClientIDMode="Static" runat="server" placeholder="dd/MM/yyyy"  CssClass="form-control form-control-sm"></asp:TextBox>
    </div>
  </div>
  <div class="form-group row">
    <label for="tipolp" runat="server" class="col-sm-3 col-form-label">Tipo</label>
    <div class="col-sm-9">
        <asp:DropDownList ID="tipo" runat="server" CssClass="form-control">
                          <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>
                          <asp:ListItem Value="1"> Líneal </asp:ListItem>
                          <asp:ListItem Value="2"> Presencial </asp:ListItem>
                     </asp:DropDownList>
    </div>
  </div>
    <div class="form-group row">

        <asp:label for="asis" runat="server" class="col-sm-3 col-form-label">Asistentes</asp:label>
       
           <div  runat="server" class="col-md-4">
                        <asp:Label runat="server">Hombres</asp:Label> 
                        <asp:TextBox ID="hombre" runat="server"  CssClass="form-control"></asp:TextBox>
                    </div>
           
                   <div runat="server" class="col-md-4">
                        <asp:Label runat="server">Mujeres </asp:Label> 
                        <asp:TextBox ID="mujer" runat="server" CssClass="form-control"></asp:TextBox>
                    </div>
        </div>
   
       <div class="form-group row">

        <asp:label for="area" runat="server" class="col-sm-3 col-form-label">Area Encargada</asp:label>
        <div class="col-sm-9">
           <asp:DropDownList ID="encargada" runat="server" CssClass="form-control">
                          <asp:ListItem Value="0" Selected="True"> Selecciona una opción </asp:ListItem>
                          <asp:ListItem Value="1"> area1 </asp:ListItem>
                          <asp:ListItem Value="2"> area2 </asp:ListItem>
                      </asp:DropDownList>
        </div>
    </div>
          <div class=" form-group row">

            <asp:label for="apoyo" runat="server" class="col-sm-3 col-form-label">Area de Apoyo</asp:label>
            <div class="col-sm-9">
                <asp:ListBox ID="catapoyos" runat="server" SelectionMode="Multiple" Width="680px">
                   
                </asp:ListBox>
            </div>
              </div>

  
     <asp:Button ID="Button1" class="btn btn-secondary" runat="server" Text="Guardar" OnClick="Insert" />

    </asp:Panel>



</asp:Content>

