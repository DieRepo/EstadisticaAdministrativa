using EstadisticaAdministrativa.Hibernate.Controller;
using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows;


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
                MostrarCatEncargadaEditar();
                MostrarCatTemaEditar();
                MostrarCatUniEditar();

                mostrarTabla();
                CalendarExtender1.StartDate = DateTime.Today;
                CalendarExtender2.StartDate = DateTime.Today;
                
                hombre.Attributes.Add("onkeypress", "javascript:return SoloNum(event)");
                mujer.Attributes.Add("onkeypress", "javascript:return SoloNum(event)");
                HombresEditar.Attributes.Add("onkeypress", "javascript:return SoloNum(event)");
                MujeresEditar.Attributes.Add("onkeypress", "javascript:return SoloNum(event)");
            }
        }


        protected CapacitacionRegistro Nuevover()
        {
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);
            mapAreas = (Dictionary<int, Areas>)ViewState["Areas"];
            mapTemas = (Dictionary<int, Temas>)ViewState["Temas"];

            var date1 = fec_ini.Text;
            var date2 = fec_fin.Text;

            var numhombres = Convert.ToInt32(hombre.Text);
            var nummujeres = Convert.ToInt32(mujer.Text);

            DateTime dt1 = DateTime.Now;
            DateTime dt2 = dt1;
            var culture = CultureInfo.CreateSpecificCulture("es-MX");
            var styles = DateTimeStyles.None;

            bool fechaValida = DateTime.TryParse(date1, culture, styles, out dt1)
                               && DateTime.TryParse(date2, culture, styles, out dt2);

            Console.WriteLine(dt1 >= dt2);

            if (!fechaValida || dt1 >= dt2)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Favor de verificar fecha de fin no puede ser menor a la fecha de inicio.', function() {}, 'popup1');", true);
               // ScriptManager.RegisterStartupScript(this, this.GetType(), "Información", "mensaje('Favor de verificar fecha de fin no puede ser menor a la fecha de inicio.','danger');", true);
              //  MessageBox.Show("Error, favor de verificar valores");
                return null;
            }
            if (numhombres == 0 && nummujeres == 0)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Favor de verificar asistencias.', function() {}, 'popup1');", true);
                //MessageBox.Show("Error, favor de verificar valores");
                return null;
            }

            CapacitacionRegistro capacita = new CapacitacionRegistro();
            capacita.nom_cap = nomcap.Text;
            capacita.fecha_inicio = dt1;
            capacita.fecha_fin = dt2;
            capacita.tipoCap = Convert.ToInt32(tipo.SelectedValue);

            capacita.asis_hombres = numhombres;
            capacita.asis_mujeres = nummujeres;
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
                    apoyo.activo=1;

                    listaArea.Add(apoyo);
                }
            }
            capacita.idUnidades = listaArea;
            return capacita;


        }


        protected CapacitacionRegistro ModificarCapacitacion(CapacitacionRegistro mod)
        {
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);

            mapAreas = (Dictionary<int, Areas>)ViewState["Areas"];
            mapTemas = (Dictionary<int, Temas>)ViewState["Temas"];

            var date1 = FechaInicioEditar.Text;
            var date2 = FechaFinEditar.Text;
            var numhombres = Convert.ToInt32(HombresEditar.Text);
            var nummujeres = Convert.ToInt32(MujeresEditar.Text);


            DateTime dt1 = DateTime.Now;
            DateTime dt2 = dt1;
            var culture = CultureInfo.CreateSpecificCulture("es-MX");
            var styles = DateTimeStyles.None;

            bool fechaValida = DateTime.TryParse(date1, culture, styles, out dt1)
                               && DateTime.TryParse(date2, culture, styles, out dt2);

            if (!fechaValida || dt1 >= dt2)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Favor de verificar fecha de fin no puede ser menor a la fecha de inicio.', function() {}, 'popup1');", true);
               // ScriptManager.RegisterStartupScript(this, GetType(), "Información", "mensaje('Error','Favor de verificar fecha de fin no puede ser menor a la fecha de inicio.','danger');", true);
                //MessageBox.Show("Error, favor de verificar valores de fechas");
                return null;
            }
            if (numhombres == 0 && nummujeres == 0)
            {
                
                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Favor de verificar asistencias.', function() {}, 'popup1');", true);
              //  MessageBox.Show("Error, favor de verificar valores");
                return null;
            }

            mod.IdCapacitacion = Convert.ToInt32(ideditar.Text);
            mod.nom_cap = NombreEditar.Text;
            mod.fecha_inicio = dt1;
            mod.fecha_fin = dt2;
            mod.tipoCap = Convert.ToInt32(TipoEditar.SelectedValue);
            mod.asis_hombres = numhombres;
            mod.asis_mujeres = nummujeres;
            mod.idUser = idUsuario;
            mod.activo = 1;



            int idtema = Convert.ToInt32(TemaEditar.SelectedValue);
            mod.idtema = mapTemas[idtema];

            int unidadEncargada = Convert.ToInt32(encargada.SelectedValue);
            mod.idunidad = mapAreas[unidadEncargada];

            IList<AreaApoyo> ap = mod.idUnidades;
            List<AreaApoyo> listaArea = new List<AreaApoyo>();
            ListItemCollection itemsAreaApoyo = CatApoyoEditar.Items;

            foreach (AreaApoyo area in ap)
            {
                Console.WriteLine(area.idunidad.idunidad);
                foreach (ListItem l in CatApoyoEditar.Items)
                {
                    if (area.idunidad.idunidad.ToString().Equals(l.Value))
                    {
                        if (l.Selected)
                        {
                            area.activo = 1;
                            l.Selected = false;
                        }
                        else
                        {
                            area.activo = 0;
                        }
                    }

                }
            }


            foreach (ListItem l in CatApoyoEditar.Items)
            {
                if (l.Selected)
                {
                    int valor = Convert.ToInt32(l.Value);
                    Areas area = mapAreas[valor];
                    AreaApoyo apoyo = new AreaApoyo();
                    apoyo.idunidad = area;
                    apoyo.IdCapacitacion = mod;
                    ap.Add(apoyo);
                }
            }
            mod.idUnidades = ap;

            return mod;

        }

        protected void EditarTablaCapacitacion(CapacitacionRegistro capacitaciones)
        {       
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
                        if (li.Value.Equals(area.idunidad.idunidad.ToString()) && area.activo == 1)
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
            if (guardarnuevo == null)
            {
                this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Capacitación no guardada.', function() {}, 'popup1');", true);
                //MessageBox.Show("Error, Capacitación no guarda");
                mostrarTabla();
                limpiarCampoos();
            }
            else
            {

                CapacitacionDAO.Guardar(guardarnuevo);
                this.ClientScript.RegisterStartupScript(this.GetType(), "Éxito", "alertify.alert('Capacitación guardada.', function() {}, 'popup2');", true);
               // MessageBox.Show("Exito, Capacitación guardada");
                limpiarCampoos();
                mostrarTabla();
            }
        }

        public void limpiarCampoos()
        {
            nomcap.Text = "";
            fec_fin.Text = "";
            fec_ini.Text = "";
            tipo.SelectedValue = "";
            hombre.Text = "";
            mujer.Text = "";
            MostrarCatEncargada();
            MostrarCatUni();
            MostrarCatTema();
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
            CatApoyoEditar.DataValueField = "idunidad";
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
            try
            {
                int idEditar = Convert.ToInt32(ViewState["idEditar"]);
                List<CapacitacionRegistro> jvi = CapacitacionDAO.ObtenCapacitacion(idEditar);

                
                var guardarnuevo = ModificarCapacitacion(jvi[0]);

                if (guardarnuevo==null)
                {

                    this.ClientScript.RegisterStartupScript(this.GetType(), "Error", "alertify.alert('Capacitación no modificada.', function() {}, 'popup1');", true);
                    //MessageBox.Show("Error, Capacitación no guardada");
                }
                else
                {
                    CapacitacionDAO.Guardar(guardarnuevo);
                    this.ClientScript.RegisterStartupScript(this.GetType(), "Éxito", "alertify.alert('Capacitación modificada.', function() {}, 'popup2');", true);
                  //  MessageBox.Show("Exito, Capacitación modificada");
                    mascara.Visible = false;
                    mostrarTabla();
                }
            
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.ToString());
            }

        }


        /*btn Cancelar*/
        protected void ButtonCancelar_Cap(object sender, EventArgs e)
        {
            mascara.Visible = false;
            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);
        }
    }
}
