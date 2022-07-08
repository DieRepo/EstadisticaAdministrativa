using EstadisticaAdministrativa.Hibernate;
using EstadisticaAdministrativa.Hibernate.Controller;
using EstadisticaAdministrativa.Hibernate.Model;
using EstadisticaAdministrativa.Hibernate.Modelo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EstadisticaAdministrativa.Vista.Justicia
{
    public partial class RegistroJusticia : System.Web.UI.Page
    {
        MySqlCommand cmd;
        MySqlDataReader r;
        String sql;
        Dictionary<string, string> d;
        int idRegistroEditar;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            generarTabla();
            mostrarTabla();
            int idEditar = Convert.ToInt32(ViewState["idEditar"]) == 0 ? 0 : Convert.ToInt32(ViewState["idEditar"]);
            
            if (idEditar != 0) {
                List<JusticiaVisita> jvi = JusticiaVisitaDAO.ObtenJusticiaVisita(idEditar);
                Label val = (Label)TablaEditar.FindControl("idVisitaEd_0");
                    if (TablaEditar.Rows.Count < 3)
                    {
                        generarTablaDinamicaEditar(jvi[0]);
                    }
                
            }

        }

        public void limpiarCampos()
        {
            int contRow = 1, countTemp = 2, i = 0, j = 0;
            TextNombre.Text = "";
            FechaApoyo.Text = "";
            FechaRegistro.Text = "";
            TextBoxEventos.Text = "";
            TextBoxTotal.Text = "";
            TextBoxDias.Text = "";

            foreach (TableRow rw in Tabla1.Rows)
            {
                if (contRow > countTemp)
                {
                    foreach (TableCell cel in rw.Cells)
                    {
                        if (j < (rw.Cells.Count - countTemp))
                        {
                            string idc = "c_" + i + "_" + j;
                            TextBox val = (TextBox)rw.FindControl(idc);
                            val.Text = "";
                        }
                        j++;
                    }
                    i++;
                    j = 0;
                }
                contRow++;
            }
        }

        public int[] obtenerFilasColumnas()
        {
            int[] datos = { 0, 0 };
            MySqlConnection con = null;

            try
            {
                con = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["local"]);
                con.Open(); 
                cmd = new MySqlCommand("obtenDatosTablaJusticia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                MySqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    datos[0] = Convert.ToInt32(resultado["filas"]);
                    datos[1] = Convert.ToInt32(resultado["columnas"]);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción : " + ex.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return datos;
        }



        public List<string[]> obtenerTiposVisitas()
        {
            List<string[]> datos = new List<string[]>();
            MySqlConnection con = null;

            try
            {
                con = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["local"]);
                con.Open();
                sql = "SELECT CONCAT(ID,' , ', nombreTipo, ',', nombreTemp)  info FROM die_estadistica_administrativa.tblcatvisita where activo = 1; ";
                cmd = new MySqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                MySqlDataReader resultado = cmd.ExecuteReader();
                while (resultado.Read())
                {
                    string[] dato = resultado["info"].ToString().Split(',');
                    datos.Add(dato);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Excepción : " + ex.ToString());
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
            return datos;
        }

        protected JusticiaVisita leerTabla() {
            int[] valores = obtenerFilasColumnas();
            int i = 0, j = -1, contRow = 1, countTemp=2, idTipo=0;

            d = (Dictionary<String, String>)Session["usuario"];

            int idUsuario = Convert.ToInt32(d["idUsuario"]);

            var jv = new JusticiaVisita
            {
                NombreEscuela = TextNombre.Text,
                MesReporta = 05,
                AnioReporta = 2021,
                FechaReporta = Convert.ToDateTime(FechaRegistro.Text),
                idUser = idUsuario
            };

            IList<JusticiaRegistro> list = new List<JusticiaRegistro>();
            var subReg = new JusticiaRegistro();

            //Agregar información de los tipos de Visitas
            foreach (TableRow rw in Tabla1.Rows) {
                if (contRow > countTemp) {
                    subReg = new JusticiaRegistro();
                    subReg.JusticiaVisita = jv;

                    String idLabel = "idVisita_" + (contRow - 3 );
                    Label labelText = (Label)rw.FindControl(idLabel);
                    idTipo = Convert.ToInt32(labelText.Text);
                    subReg.idTipo = idTipo;
                    subReg.idUser = idUsuario;

                    foreach (TableCell cel in rw.Cells)
                    {
                        if (j == -1)
                        {
                            
                        } else if (j < (rw.Cells.Count - countTemp)) {
                            string idc = "c_" + i + "_" + j;
                            TextBox val = (TextBox)rw.FindControl(idc);
                            int valor = val.Text.Equals("") ? 0 : Convert.ToInt32(val.Text);
                            subReg = AgregaValor(subReg, contRow, j, valor);
                        }
                        j++;
                    }
                    i++;
                    j = -1;
                    list.Add(subReg);
                }
                else {
                    //Row 1 y 2 son encabezados po lo que no se validan
                }
                contRow++;   
            }
            jv.JusticiaRegistros = list;

            //Agregar información de apoyo de botargas
            IList<JusticiaBotarga> listB = new List<JusticiaBotarga>();
            var subRegBot = new JusticiaBotarga();
            subRegBot.idUser = idUsuario;
            string fechaB = FechaApoyo.Text.Equals("") ? "" : FechaApoyo.Text;
            if (!fechaB.Equals("")) {
                subRegBot.fechaReporta =  Convert.ToDateTime(fechaB);
            }
            string evento = TextBoxEventos.Text.Equals("") ? "0" : TextBoxEventos.Text;
            subRegBot.eventos = Convert.ToInt32(evento);
            string totalB = TextBoxTotal.Text.Equals("") ? "0" : TextBoxTotal.Text;
            subRegBot.total = Convert.ToInt32(totalB);
            string diasB = TextBoxDias.Text.Equals("") ? "0" : TextBoxDias.Text;
            subRegBot.dias = Convert.ToInt32(diasB);
            subRegBot.JusticiaVisita = jv;
            listB.Add(subRegBot);
            jv.ApoyoBotargas = listB;

            return jv;
        }

        protected JusticiaVisita leerTablaEditar(JusticiaVisita jv)
        {
            try
            {
                int[] valores = obtenerFilasColumnas();
                int i = 0, j = -1, contRow = 1, countTemp = 2, idTipo = 0;

                d = (Dictionary<String, String>)Session["usuario"];

                int idUsuario = Convert.ToInt32(d["idUsuario"]);

                jv.NombreEscuela = TextNombreEditar.Text;
                jv.FechaReporta = Convert.ToDateTime(FechaRegistroEditar.Text);

                //Agregar información de los tipos de Visitas
                foreach (TableRow rw in TablaEditar.Rows)
                {
                    if (contRow > countTemp)
                    {
                        JusticiaRegistro subReg = jv.JusticiaRegistros[i];

                        String idLabel = "idVisitaEd_" + (contRow - 3);
                        Label labelText = (Label)rw.FindControl(idLabel);

                        foreach (TableCell cel in rw.Cells)
                        {
                            if (j == -1)
                            {

                            }
                            else if (j < (rw.Cells.Count - countTemp))
                            {
                                string idc = "e_" + i + "_" + j;
                                TextBox val = (TextBox)rw.FindControl(idc);
                                int valor = val.Text.Equals("") ? 0 : Convert.ToInt32(val.Text);
                                subReg = AgregaValor(subReg, contRow, j, valor);
                            }
                            j++;
                        }
                        i++;
                        j = -1;
                        jv.JusticiaRegistros[subReg.idTipo-1] = subReg;
                    }
                    else
                    {
                        //Row 1 y 2 son encabezados po lo que no se validan
                    }
                    contRow++;
                }

                //Agregar información de apoyo de botargas
                var subRegBot = jv.ApoyoBotargas[0];
                string fechaB = TextBox1.Text.Equals("") ? "" : TextBox1.Text;
                if (!fechaB.Equals(""))
                {
                    subRegBot.fechaReporta = Convert.ToDateTime(fechaB);
                }
                string evento = TextBox2.Text.Equals("") ? "0" : TextBox2.Text;
                subRegBot.eventos = Convert.ToInt32(evento);
                string totalB = TextBox3.Text.Equals("") ? "0" : TextBox3.Text;
                subRegBot.total = Convert.ToInt32(totalB);
                string diasB = TextBox4.Text.Equals("") ? "0" : TextBox4.Text;
                subRegBot.dias = Convert.ToInt32(diasB);
                subRegBot.JusticiaVisita = jv;
                jv.ApoyoBotargas[0] = subRegBot;
            }
            catch (Exception ex) {
                Console.WriteLine("Exception  "+ex.ToString());
            }

            return jv;
        }

        protected JusticiaRegistro AgregaValor(JusticiaRegistro jr, int row, int cell, int valor) {
            if (cell == 0)
            {
                jr.ninoMujer = valor;
            }else if (cell == 1) {
                jr.ninoHombre = valor;
            } else if (cell == 2) {
                jr.madres = valor;
            } else if (cell == 3) {
                jr.padres = valor;
            } else if (cell == 4) {
                jr.docenteMujer = valor;
            } else if (cell == 5) {
                jr.docenteHombre = valor;
            }

            return jr;
        }

        protected int AgregaValorEdita(JusticiaRegistro jr,  int cell)
        {
            int valor = 0;
            try
            {
                if (cell == 0)
                {
                    valor = jr.ninoMujer;
                }
                else if (cell == 1)
                {
                    valor = jr.ninoHombre;
                }
                else if (cell == 2)
                {
                    valor = jr.madres;
                }
                else if (cell == 3)
                {
                    valor = jr.padres;
                }
                else if (cell == 4)
                {
                    valor = jr.docenteMujer;
                }
                else if (cell == 5)
                {
                    valor = jr.docenteHombre;
                }

            }
            catch (Exception ex) {
            }

            return valor;
        }


        protected void generarTablaDinamicaEditar(JusticiaVisita justicia)
        {
            try {
                int[] valores = obtenerFilasColumnas();
                List<string[]> lista = obtenerTiposVisitas();
                int numrows = valores[0];
                int numcells = valores[1];
                d = (Dictionary<String, String>)Session["usuario"];
                int valorGuardado = 0;

                int idUsuario = Convert.ToInt32(d["idUsuario"]);

                TextNombreEditar.Text = justicia.NombreEscuela;
                FechaRegistroEditar.Text = justicia.FechaReporta.ToString();

                for (int j = 0; j < numrows; j++)
                {
                    TableRow r = new TableRow();
                    string[] info = lista[j];
                    JusticiaRegistro rtemporal = null;
                    foreach (var rj in justicia.JusticiaRegistros)
                    {
                        if (rj.idTipo.ToString().Equals(info[0].Trim()))
                        {
                            rtemporal = rj;
                        }
                    }

                    for (int i = -2; i < numcells; i++)
                    {
                        TableCell c = new TableCell();

                        if (i == -2)
                        {
                            Label lbl = new Label();
                            lbl.Text = (j + 1).ToString();
                            lbl.ID = "idVisitaEd_" + j;
                            c.Controls.Add(lbl);
                        }
                        else if (i == -1)
                        {
                            Label lbl = new Label();
                            lbl.Text = info[1];
                            c.Controls.Add(lbl);
                        }
                        else
                        {
                            if (rtemporal != null)
                            {
                                valorGuardado = AgregaValorEdita(rtemporal, i);
                                TextBox tb = new TextBox();
                                tb.ID = "e_" + j + "_" + i;
                                tb.Text = valorGuardado.ToString();
                                tb.Attributes.Add("class", "form-control");
                                tb.Attributes.Add("Type", "number");
                                tb.Attributes.Add("min", "0");
                                tb.Attributes.Add("id", "e_" + j + "_" + i);
                                c.Controls.Add(tb);
                            }

                        }

                        r.Cells.Add(c);
                    }
                    TablaEditar.Rows.Add(r);
                }

                TextBox1.Text = (justicia.ApoyoBotargas[0].fechaReporta).ToString("yyyy-MM-dd"); ;
                TextBox2.Text = justicia.ApoyoBotargas[0].eventos.ToString();
                TextBox3.Text = justicia.ApoyoBotargas[0].total.ToString();
                TextBox4.Text = justicia.ApoyoBotargas[0].dias.ToString();
            } 
            catch (Exception ex) {
                Console.WriteLine("Exception :" + ex.ToString());
            }
            
        }

        protected void generarTablaDinamica()
        {
            int[] valores = obtenerFilasColumnas();
            List<string[]> lista = obtenerTiposVisitas();
            int numrows = valores[0];
            int numcells = valores[1];

            for (int j = 0; j < numrows; j++)
            {
                TableRow r = new TableRow();
                string[] info = lista[j];
                for (int i = -2; i < numcells; i++)
                {
                    TableCell c = new TableCell();

                    if (i == -2)
                    {
                        Label lbl = new Label();
                        lbl.Text = (j + 1).ToString();
                        lbl.ID = "idVisita_" + j;
                        c.Controls.Add(lbl);
                    }
                    else if (i == -1)
                    {
                        Label lbl = new Label();
                        lbl.Text = info[1];
                        c.Controls.Add(lbl);
                    }
                    else
                    {
                        TextBox tb = new TextBox();
                        tb.ID = "c_" + j + "_" + i;
                        tb.Attributes.Add("class", "form-control");
                        tb.Attributes.Add("Type", "number");
                        tb.Attributes.Add("min", "0");
                        tb.Attributes.Add("id", "c_" + j + "_" + i);
                        c.Controls.Add(tb);
                    }

                    r.Cells.Add(c);
                }
                Tabla1.Rows.Add(r);
            }
        }



        protected void Button_Guardar_Click(object sender, EventArgs e)
        {
            var justicia  = leerTabla();
            JusticiaVisitaDAO.GuardarJusticiaVisita(justicia) ;
            limpiarCampos();
            mostrarTabla();
           
        }

        public void mostrarTabla() {
            List<JusticiaVisita> lista = (List<JusticiaVisita>)JusticiaVisitaDAO.ListAll();
            tablaRegistros.DataSource = lista;
            tablaRegistros.DataBind();
        }

        protected void paginador(object sender, GridViewPageEventArgs e)
        {
            tablaRegistros.PageIndex = e.NewPageIndex;
            mostrarTabla();
        }

        protected void tablaRegistros_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            ViewState["idEditar"] = 0;
            try
            {
                idRegistroEditar = (int)tablaRegistros.DataKeys[Convert.ToInt32(e.CommandArgument)].Value;
                ViewState["idEditar"] = idRegistroEditar;
                List<JusticiaVisita> result = JusticiaVisitaDAO.ObtenJusticiaVisita(idRegistroEditar);
                if (e.CommandName.Equals("EditarRegistro"))
                    {
                    if (result[0] != null) {
                        generarTablaDinamicaEditar(result[0]);
                    }
                    mascara.Visible = true;
                }  
            }
            catch (Exception ex)
            {
                Console.WriteLine("ERROR " + ex.ToString());
            }

        }


        public void generarTabla() {

            generarTablaDinamica();
//            generarTablaDinamicaEditar(new JusticiaVisita());
        }

        

        protected void ButtonEditar_Click(object sender, EventArgs e)
        {
            try {
                int idEditar = Convert.ToInt32(ViewState["idEditar"]);
                List<JusticiaVisita> jvi = JusticiaVisitaDAO.ObtenJusticiaVisita(idEditar);
                JusticiaVisita jv = leerTablaEditar(jvi[0]);
                JusticiaVisitaDAO.GuardarJusticiaVisita(jv);
                mascara.Visible = false;
                mostrarTabla();
            } catch (Exception ex) {
                Console.WriteLine("Exception: "+ex.ToString());
            }

            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);
        }

        protected void ButtonCancelar_Click(object sender, EventArgs e)
        {
            mascara.Visible = false;
            Response.Redirect(this.Page.Request.AppRelativeCurrentExecutionFilePath);
        }

        protected void ButtonCerrar_Click(object sender, EventArgs e)
        {
            mascara.Visible = false;
        }


    }
}