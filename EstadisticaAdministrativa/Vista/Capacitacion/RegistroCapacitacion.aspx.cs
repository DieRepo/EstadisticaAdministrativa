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
        protected void Page_Load(object sender, EventArgs e)
        {
            MostrarCatUni();

        }

        protected Capacitacion Nuevover()
        {
            Capacitacion capacita = new Capacitacion();
            return capacita;
        }


        protected void Insert(object sender, EventArgs e)
        {
            var guardarnuevo = Nuevover();

            CapacitacionDAO.Guardar(guardarnuevo);
        }

        public void MostrarCatUni()
        {
            List<CatUnidades> lista = (List<CatUnidades>)CapacitacionDAO.ListAll();
            catapoyos.DataSource = lista;
            catapoyos.DataBind();
        }
    }
}