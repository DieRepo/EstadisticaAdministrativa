using EstadisticaAdministrativa.Hibernate.Controller;
using EstadisticaAdministrativa.Hibernate.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadisticaAdministrativa.Vista.Capacitacion

{
    public partial class RegistroCapacitacion : System.Web.UI.Page
    {
      
        Dictionary<string, string> d;
        int idcapacitacionEditar;

        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCatUni();
            MostrarCatEncargada();
            MostrarCatTema();
            mostrarTabla();
            int idEditar = Convert.ToInt32(ViewState["idEditar"]) == 0 ? 0 : Convert.ToInt32(ViewState["idEditar"]);

            if (idEditar != 0)
            {
                List<CapacitacionRegistro> jvi = CapacitacionDAO.ObtenCapacitacion(idEditar);
                Label val = (Label)tablaCapacitacion.FindControl("idVisitaEd_0");
                if (tablaCapacitacion.Rows.Count < 3)
                {
                    EditarTablaCapacitacion(jvi[0]);
                }

            }

        }


        protected CapacitacionRegistro Nuevover()
        {
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);

            CapacitacionRegistro capacita = new CapacitacionRegistro();
            capacita.nom_cap = nomcap.Text;
            capacita.fecha_fin = Convert.ToDateTime(fec_fin.Text);
            capacita.fecha_inicio = Convert.ToDateTime(fec_ini.Text);
            capacita.tipoCap = Convert.ToInt32(tipo.SelectedValue);
            capacita.asis_hombres = Convert.ToInt32(hombre.Text);
            capacita.asis_mujeres = Convert.ToInt32(mujer.Text);
            capacita.activo = 1;
            capacita.idUser = idUsuario;
            //capacita.idunidad = Convert.ToInt32(encargada.SelectedValue);

            List<AreaApoyo> listaArea = new List<AreaApoyo>();
            foreach (ListItem li in catapoyos.Items)
            {
                if (li.Selected)
                {
                    AreaApoyo area = new AreaApoyo();
                    //area.idunidad = Convert.ToInt32(li.Value);
                    area.IdCapacitacion = capacita;
                    //.Add(area);
                }

            }

            capacita.idunidad = listaArea;
            return capacita;
        }

        protected CapacitacionRegistro ModificarCapacitacion()
        {
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);
            CapacitacionRegistro mod = new CapacitacionRegistro();
            mod.IdCapacitacion = Convert.ToInt32( ideditar.Text);
            mod.nom_cap = NombreEditar.Text;
            mod.fecha_inicio = Convert.ToDateTime(FechaInicioEditar.Text);
            mod.fecha_fin = Convert.ToDateTime(FechaFinEditar.Text);
            mod.tipoCap= Convert.ToInt32(TipoEditar.SelectedValue);
            mod.asis_hombres=Convert.ToInt32(HombresEditar.Text);
            mod.asis_mujeres= Convert.ToInt32(MujeresEditar.Text);
            mod.idUser = idUsuario;
            mod.activo = 1;
            //capacita.idunidad = Convert.ToInt32(encargada.SelectedValue);

            //List<AreaApoyo> listaArea = new List<AreaApoyo>();
            return mod;
           
        }


        protected void GuardarCapacita(object sender, EventArgs e)
        {
            var guardarnuevo = Nuevover();

            CapacitacionDAO.Guardar(guardarnuevo);
            limpiarCampoos();
            mostrarTabla();
        }
                          
        public void limpiarCampoos()
        {
            nomcap.Text = "";
            fec_fin.Text = "";
            fec_ini.Text = "";
            tipo.SelectedValue = "";
            hombre.Text = "";
            mujer.Text = "";

        }
        public void MostrarCatUni()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAll();
            catapoyos.DataSource = lista;
            catapoyos.DataTextField = "nomarea";
            catapoyos.DataBind();
        }

        public void MostrarCatTema()
        {
            List<Temas> lista = (List<Temas>)TemaDAO.ListAllTema();
            tema.DataSource = lista;
            tema.DataTextField = "nombre_tema";
            tema.DataBind();
        }


        public void MostrarCatEncargada()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAllEncargada();
            encargada.DataSource = lista;
            encargada.DataTextField = "nomarea";
            encargada.DataBind();
        }


        public void mostrarTabla()
        {
            List<CapacitacionRegistro> lista = (List<CapacitacionRegistro>)CapacitacionDAO.VistaTablas();
            tablaCapacitacion.DataSource = lista;
            tablaCapacitacion.DataBind();
        }


        protected void tablaCapacitacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
           ViewState["idEditar"] = 0;
           

            try
            {
                idcapacitacionEditar = (int)tablaCapacitacion.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                ViewState["idEditar"] = idcapacitacionEditar;

                IList<CapacitacionRegistro> result = CapacitacionDAO.ObtenCapacitacion(idcapacitacionEditar);
              
                if (e.CommandName.Equals("EditarCapacitacion"))
                {
                    if (result[0] != null)
                    {
                        EditarTablaCapacitacion(result[0]);
                    }
                    mascara.Visible = true;
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.ToString());
            }

        }

        protected void EditarTablaCapacitacion(CapacitacionRegistro capacitaciones)
        {
            try
            {
                d = (Dictionary<String, String>)Session["usuario"];
                int idUsuario = Convert.ToInt32(d["idUsuario"]);

                ideditar.Text =  capacitaciones.IdCapacitacion.ToString();
                NombreEditar.Text = capacitaciones.nom_cap;
                // TemaEditar. = capacitaciones.idTema;
                FechaInicioEditar.Text = capacitaciones.fecha_inicio.ToString();
                FechaFinEditar.Text = capacitaciones.fecha_fin.ToString();
                TipoEditar.SelectedValue = capacitaciones.tipoCap.ToString();
                          
                HombresEditar.Text = capacitaciones.asis_hombres.ToString();
                MujeresEditar.Text = capacitaciones.asis_mujeres.ToString();
                // CatEncargadaEditar = capacitaciones.idunidad;
                // CatapotoEditar.Text = capacitaciones.idunidad;
                capacitaciones.idUser = idUsuario;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception :" + ex.ToString());
            }

        }

      /*  protected void EliminarCapacitacion()
        {

            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);

            CapacitacionRegistro elicap = new CapacitacionRegistro();
            elicap.IdCapacitacion = Convert.ToInt32(ideditar.Text);
            elicap.idUser = idUsuario;
            elicap.activo = 0;
            //capacita.idunidad = Convert.ToInt32(encargada.SelectedValue);

            //List<AreaApoyo> listaArea = new List<AreaApoyo>();
           // return elicap;


        }*/


        protected void paginador(object sender, GridViewPageEventArgs e)
        {
            tablaCapacitacion.PageIndex = e.NewPageIndex;
            mostrarTabla();
        }


         /*btn EDITAR capacitacion*/
        protected void ButtonEditar_Cap(object sender, EventArgs e)
        {
            try
            {
                int idEditar = Convert.ToInt32(ViewState["idEditar"]);
                List<CapacitacionRegistro> jvi = CapacitacionDAO.ObtenCapacitacion(idEditar);


                var guardarnuevo = ModificarCapacitacion();

                CapacitacionDAO.Guardar(guardarnuevo);
                mascara.Visible = false;
                mostrarTabla();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);

            
              
        }

                     
       /* protected void Button_Eliminar_Cap(object sender, EventArgs e){

            try
            {
                int idEditar = Convert.ToInt32(ViewState["idEditar"]);
                List<CapacitacionRegistro> jvi = CapacitacionDAO.ObtenCapacitacion(idEditar);


                var eliminarcap = EliminarCapacitacion();

                CapacitacionDAO.EliminarCapacitacion(eliminarcap);
                mascara.Visible = false;
                mostrarTabla();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);

        }*/




        /*btn Cancelar*/
        protected void ButtonCancelar_Cap(object sender, EventArgs e)
        {
            mascara.Visible = false;
            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);
        }

        /*btn cerrar*/
        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            mascara.Visible = false;
        }

        protected void tablaCapacitacion_PageIndexChanged(object sender, EventArgs e)
        {

        }
    }
}