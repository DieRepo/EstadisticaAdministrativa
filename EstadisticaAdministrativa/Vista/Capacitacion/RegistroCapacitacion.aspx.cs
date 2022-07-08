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
            MostrarCatEncargada();
            MostrarCatTema();

        }

        protected CapacitacionRegistro Nuevover()
        {
            CapacitacionRegistro capacita = new CapacitacionRegistro();
            capacita.nom_cap = nomcap.Text;
            capacita.fecha_fin = Convert.ToDateTime(fec_fin.Text);
            capacita.fecha_inicio = Convert.ToDateTime(fec_ini.Text);
            capacita.tipoCap = Convert.ToInt32(tipo.SelectedValue);
            capacita.asis_hombres = Convert.ToInt32(hombre.Text);
            capacita.asis_mujeres = Convert.ToInt32(mujer.Text);
            //capacita.idTema = Convert.ToInt32(tema.SelectedValue);
            //capacita.idUnidad= Convert.ToInt32(encargada.SelectedValue);


            List<AreaApoyo> listaArea = new List<AreaApoyo>();
            foreach (ListItem li in catapoyos.Items)
            {
                if (li.Selected)
                {
                    AreaApoyo area = new AreaApoyo();
                    area.idunidad = Convert.ToInt32(li.Value);
                    area.IdCapacitacion = capacita;
                    //.Add(area);
                }
                
            }

            capacita.idunidad = listaArea;

            return capacita;
        }


        protected void GuardarCapacita(object sender, EventArgs e)
        {
            var guardarnuevo = Nuevover();

            CapacitacionDAO.Guardar(guardarnuevo);
        }

        public void MostrarCatUni()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAll();
            catapoyos.DataSource = lista;
            catapoyos.DataTextField = "nomarea";
            catapoyos.DataValueField = "idUnidad";
            catapoyos.DataBind();
        }

        public void MostrarCatTema()
        {
            List<Temas> lista = (List<Temas>)TemaDAO.ListAllTema();
            tema.DataSource = lista;
            tema.DataTextField = "nombre_tema";
            tema.DataValueField = "idtema";
            tema.DataBind();
        }

        public void MostrarCatEncargada()
        {
            List<Areas> lista = (List<Areas>)UnidadesDAO.ListAllEncargada();
            encargada.DataSource = lista;
            encargada.DataTextField = "nomarea";
            encargada.DataValueField = "idUnidad";
            encargada.DataBind();
        }
    }
}