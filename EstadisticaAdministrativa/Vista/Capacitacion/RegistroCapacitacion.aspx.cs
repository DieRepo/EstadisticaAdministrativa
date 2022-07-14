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
        Dictionary<int, Areas> mapAreas;
        Dictionary<int, Temas> mapTemas;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarCatUni();
                MostrarCatEncargada();
                MostrarCatTema();
                mostrarTabla();

            }
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
            mapAreas = (Dictionary<int, Areas>)ViewState["Areas"];
            mapTemas = (Dictionary<int, Temas>)ViewState["Temas"];

            CapacitacionRegistro capacita = new CapacitacionRegistro();
            capacita.nom_cap = nomcap.Text;
            capacita.fecha_fin = Convert.ToDateTime(fec_fin.Text);
            capacita.fecha_inicio = Convert.ToDateTime(fec_ini.Text);
            capacita.tipoCap = Convert.ToInt32(tipo.SelectedValue);
            capacita.asis_hombres = Convert.ToInt32(hombre.Text);
            capacita.asis_mujeres = Convert.ToInt32(mujer.Text);
            capacita.activo = 1;

            capacita.idUser = idUsuario;
            int idtema = Convert.ToInt32(tema.SelectedValue);
            capacita.idtema = mapTemas[idtema];

            int unidadEncargada = Convert.ToInt32(encargada.SelectedValue);
            capacita.idunidad = mapAreas[unidadEncargada];

            List<AreaApoyo> listaArea = new List<AreaApoyo>();

            foreach (ListItem l in catapoyos.Items)
            {
                if (l.Selected)
                {
                    int valor = Convert.ToInt32(l.Value);
                    Areas area = mapAreas[valor];
                    AreaApoyo apoyo = new AreaApoyo();
                    apoyo.idunidad = area;
                    apoyo.IdCapacitacion = capacita;

                    listaArea.Add(apoyo);
                }
            }
            capacita.idUnidades = listaArea;
            return capacita;

        }


        protected CapacitacionRegistro ModificarCapacitacion()
        {
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);
            mapAreas = (Dictionary<int, Areas>)ViewState["Areas"];
            mapTemas = (Dictionary<int, Temas>)ViewState["Temas"];


            CapacitacionRegistro mod = new CapacitacionRegistro();
            mod.IdCapacitacion = Convert.ToInt32(ideditar.Text);
            mod.nom_cap = NombreEditar.Text;
            mod.fecha_inicio = Convert.ToDateTime(FechaInicioEditar.Text);
            mod.fecha_fin = Convert.ToDateTime(FechaFinEditar.Text);
            mod.tipoCap = Convert.ToInt32(TipoEditar.SelectedValue);
            mod.asis_hombres = Convert.ToInt32(HombresEditar.Text);
            mod.asis_mujeres = Convert.ToInt32(MujeresEditar.Text);
            mod.idUser = idUsuario;
            mod.activo = 1;

            int idtema = Convert.ToInt32(tema.SelectedValue);
            mod.idtema = mapTemas[idtema];

            int unidadEncargada = Convert.ToInt32(encargada.SelectedValue);
            mod.idunidad = mapAreas[unidadEncargada];

            List<AreaApoyo> listaArea = new List<AreaApoyo>();

            foreach (ListItem l in catapoyos.Items)
            {
                if (l.Selected)
                {
                    int valor = Convert.ToInt32(l.Value);
                    Areas area = mapAreas[valor];
                    AreaApoyo apoyo = new AreaApoyo();
                    apoyo.idunidad = area;
                    apoyo.IdCapacitacion = mod;

                    listaArea.Add(apoyo);
                }
            }
            mod.idUnidades = listaArea;

            return mod;

        }

        protected void EditarTablaCapacitacion(CapacitacionRegistro capacitaciones)
        {
            MostrarCatEncargadaEditar();
            MostrarCatTemaEditar();
            MostrarCatUniEditar();
            try
            {
                d = (Dictionary<String, String>)Session["usuario"];
                int idUsuario = Convert.ToInt32(d["idUsuario"]);

                mapAreas = (Dictionary<int, Areas>)ViewState["Areas"];
                mapTemas = (Dictionary<int, Temas>)ViewState["Temas"];



                ideditar.Text = capacitaciones.IdCapacitacion.ToString();
                NombreEditar.Text = capacitaciones.nom_cap;
                FechaInicioEditar.Text = capacitaciones.fecha_inicio.ToString();
                FechaFinEditar.Text = capacitaciones.fecha_fin.ToString();
                TipoEditar.SelectedValue = capacitaciones.tipoCap.ToString();
                HombresEditar.Text = capacitaciones.asis_hombres.ToString();
                MujeresEditar.Text = capacitaciones.asis_mujeres.ToString();

                capacitaciones.idUser = idUsuario;


                TemaEditar.SelectedValue = capacitaciones.idtema.idtema.ToString();
                CatEncargadaEditar.SelectedValue = capacitaciones.idunidad.idunidad.ToString();

                TemaEditar.SelectedValue = capacitaciones.idtema.idtema.ToString();
                CatEncargadaEditar.SelectedValue = capacitaciones.idunidad.idunidad.ToString();

                foreach (ListItem li in CatApoyoEditar.Items)
                {
                    foreach (AreaApoyo area in capacitaciones.idUnidades)
                    {
                        if (li.Value.Equals(area.idunidad.idunidad.ToString()))
                        {
                            li.Selected = true;
                        }
                    }
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception :" + ex.ToString());
            }

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
            catapoyos.DataValueField = "idUnidad";
            catapoyos.DataBind();
            mapAreas = new Dictionary<int, Areas>();
            foreach (Areas area in lista)
            {
                mapAreas.Add(area.idunidad, area);
            }
            ViewState["Areas"] = mapAreas;
        }

        public void MostrarCatTema()
        {
            List<Temas> lista = (List<Temas>)TemaDAO.ListAllTema();
            tema.DataSource = lista;
            tema.DataTextField = "nombre_tema";
            tema.DataValueField = "idtema";
            tema.DataBind();
            mapTemas = new Dictionary<int, Temas>();
            foreach (Temas tema in lista)
            {
                mapTemas.Add(tema.idtema, tema);
            }
            ViewState["Temas"] = mapTemas;
        }


        public void MostrarCatEncargada()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAllEncargada();
            encargada.DataSource = lista;
            encargada.DataTextField = "nomarea";
            encargada.DataValueField = "idunidad";
            encargada.DataBind();
        }


        public void MostrarCatUniEditar()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAll();
            CatApoyoEditar.DataSource = lista;
            CatApoyoEditar.DataTextField = "nomarea";
            CatApoyoEditar.DataValueField = "idUnidad";
            CatApoyoEditar.DataBind();
            mapAreas = new Dictionary<int, Areas>();
            foreach (Areas area in lista)
            {
                mapAreas.Add(area.idunidad, area);
            }
            ViewState["Areas"] = mapAreas;
        }

        public void MostrarCatTemaEditar()
        {
            List<Temas> lista = (List<Temas>)TemaDAO.ListAllTema();
            TemaEditar.DataSource = lista;
            TemaEditar.DataTextField = "nombre_tema";
            TemaEditar.DataValueField = "idtema";
            TemaEditar.DataBind();
            mapTemas = new Dictionary<int, Temas>();
            foreach (Temas tema in lista)
            {
                mapTemas.Add(tema.idtema, tema);
            }
            ViewState["Temas"] = mapTemas;
        }


        public void MostrarCatEncargadaEditar()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAllEncargada();
            CatEncargadaEditar.DataSource = lista;
            CatEncargadaEditar.DataTextField = "nomarea";
            CatEncargadaEditar.DataValueField = "idunidad";
            CatEncargadaEditar.DataBind();
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



        protected void paginador(object sender, GridViewPageEventArgs e)
        {
            tablaCapacitacion.PageIndex = e.NewPageIndex;
            mostrarTabla();
        }


        /*btn EDITAR capacitacion*/
        protected void ButtonEditar_Cap(object sender, EventArgs e)
        {
            MostrarCatEncargadaEditar();
            MostrarCatTemaEditar();
            MostrarCatUniEditar();

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