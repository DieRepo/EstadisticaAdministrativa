using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI.WebControls;

namespace EstadisticaAdministrativa
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        String query = "";
        MySqlCommand cmd;
        String ruta = "";
        Dictionary<String, String> d;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] is null)
            {
                redirectLogin();
            }

            if (!IsPostBack)
            {
                obtenerMenuUsuario();
            }

        }

        public void obtenerMenuUsuario()
        {
            int idMenu = 0, idSubmenu = 0, idMenuTemporal = 0;
            String location = "";
            MySqlConnection con = null;
            List<String> listaPaginas = null;
            String pagina = obtenerPagina();
            d = (Dictionary<String, String>)Session["usuario"];
            int idUsuario = Convert.ToInt32(d["idUsuario"]);
            try
            {
                con = new MySqlConnection(System.Configuration.ConfigurationManager.AppSettings["local"]);
                con.Open();
                cmd = new MySqlCommand("obtenMenuUsuario", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                MySqlDataReader resultado = cmd.ExecuteReader();
                listaPaginas = new List<string>();
                while (resultado.Read())
                {
                    idMenu = Convert.ToInt32(resultado["idmenu"]);
                    idSubmenu = Convert.ToInt32(resultado["idsubmenu"].ToString());
                    location = resultado["location"].ToString();

                    if (idMenu != idMenuTemporal)
                    {
                        menu.Items.Add(new MenuItem(resultado["desmenu"].ToString(),
                        resultado["idmenu"].ToString(), "", null));
                    }

                    MenuItem mnu = new MenuItem(resultado["dessubmenu"].ToString(),
                       resultado["idsubmenu"].ToString(), "", location);
                    menu.FindItem(resultado["idmenu"].ToString()).ChildItems.Add(mnu);
                    idMenuTemporal = idMenu;
                    listaPaginas.Add(location);
                }

                for (int i = 0; i < menu.Items.Count; i++)
                {
                    menu.Items[i].Selectable = false;
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


            Boolean acceso = pagina.EndsWith("Inicio.aspx") ? true : false;
            foreach (var l in listaPaginas)
            {
                if (l.EndsWith(pagina))
                {
                    acceso = true;
                }
            }

            if (!acceso)
            {
                redirectInicio(); //Si no tiene acceso se envia a página de Inicio
            }
            else
            {

                //Agregar información del usuario para mostrar
                //Session["usuario"]

                d = (Dictionary<String, String>)Session["usuario"];

                String nombre = d["nombre"];
                TextNombreUsuario.Text = nombre;
            }

        }

        protected string obtenerPagina()
        {
            ruta = HttpContext.Current.Request.Url.ToString();
            string cadena = HttpContext.Current.Request.Url.AbsoluteUri;
            string[] Separado = cadena.Split('/');
            string Final = Separado[Separado.Length - 1];
            return Final;
        }

        protected void redirectLogin()
        {
            String[] sc = HttpContext.Current.Request.Url.Host.ToString().Split('/');
            Response.Redirect("~/Login.aspx");
        }

        protected void redirectInicio()
        {
            String[] sc = HttpContext.Current.Request.Url.Host.ToString().Split('/');
            Response.Redirect("~/Vista/Inicio.aspx");
        }

        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            Session.RemoveAll();
            Session.Abandon();
            redirectLogin();
        }

        protected void Inicio_Click(object sender, EventArgs e)
        {
            redirectInicio();
        }
    }
}