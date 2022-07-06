﻿using EstadisticaAdministrativa.Hibernate.Controller;
using EstadisticaAdministrativa.Hibernate.Model;
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
            MostrarCatTema();

        }

        protected CapacitacionRegistro Nuevover()
        {
            CapacitacionRegistro capacita = new CapacitacionRegistro();
            return capacita;
        }


        protected void Insert(object sender, EventArgs e)
        {
            var guardarnuevo = Nuevover();

            CapacitacionDAO.Guardar(guardarnuevo);
        }

        public void MostrarCatUni()
        {
            List<CatUnidades> lista = (List<CatUnidades>)UnidadesDAO.ListAll();
            catapoyos.DataSource = lista;
            catapoyos.DataBind();
        }

        public void MostrarCatTema()
        {
            List<CatUnidades> lista = (List<CatUnidades>)TemaDAO.ListAllTemas();
            tema.DataSource = lista;
            tema.DataBind();
        }
    }
}