using EstadisticaAdministrativa.Hibernate.Controller;
using EstadisticaAdministrativa.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI.WebControls;

namespace EstadisticaAdministrativa.Vista.Justicia
{
    public partial class ReporteJusticia : System.Web.UI.Page
    {
        String query = "";
        String condicionFechas1 = "";
        String condicionFechas2 = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            GenerarConsulta();
        }

        protected void GenerarConsulta()
        {
            mostrarReporteLudicas();
            mostrarReporteGuiadas();
            mostrarReporteApoyoBotargas();
        }


        public void mostrarReporteLudicas()
        {
            query = "SELECT j.idTipo , v.nombreTipo , SUM(j.ninoHombre) ninosH, SUM(j.ninoMujer) ninosM, "
                + " SUM(j.padres) padres, SUM(j.madres) madres, "
                + " SUM(j.docenteHombre) docenteH , SUM(j.docenteMujer) docenteM "
                + " from tbljusticiaregistros j "
                + " LEFT JOIN tblcatvisita v ON v.id = j.idTipo"
                + " left join tbljusticia js ON j.idRegistro = js.id"
                + " where j.idTipo in (1, 2, 3) "
                + condicionFechas1 + "  group by j.idTipo ";
            List<object[]> result = (List<object[]>)JusticiaVisitaDAO.ObtenerConsultaNativa(query);
            tablaVisitasLudicas.DataSource = convertirReporteVisita(result);
            tablaVisitasLudicas.DataBind();
        }



        public void mostrarReporteGuiadas()
        {
            query = "SELECT j.idTipo , v.nombreTipo , SUM(j.ninoHombre) ninosH, SUM(j.ninoMujer) ninosM, "
                + " SUM(j.padres) padres, SUM(j.madres) madres, "
                + " SUM(j.docenteHombre) docenteH , SUM(j.docenteMujer) docenteM "
                + " from tbljusticiaregistros j "
                + " LEFT JOIN tblcatvisita v ON v.id = j.idTipo"
                + " left join tbljusticia js ON j.idRegistro = js.id"
                + " where j.idTipo in (4) " + condicionFechas1 + " group by j.idTipo ";
            List<object[]> result = (List<object[]>)JusticiaVisitaDAO.ObtenerConsultaNativa(query);
            tablaVisitasGuiadas.DataSource = convertirReporteVisita(result);
            tablaVisitasGuiadas.DataBind();
        }

        public void mostrarReporteApoyoBotargas()
        {
            query = "SELECT  1, SUM(b.eventos) eventos, SUM(b.total) total , SUM(b.dias) dias , j.FechaRegistro" +
                "    FROM tbljusticiabotargas b" +
                "    RIGHT JOIN tbljusticia j ON b.idRegistro = j.Id " +
                condicionFechas2;
            List<object[]> lista = JusticiaVisitaDAO.ObtenerConsultaNativa(query).ToList();
            tablaApoyoBotargas.DataSource = convertirReporteBotargas(lista);
            tablaApoyoBotargas.DataBind();
        }

        protected List<ReporteVisita> convertirReporteVisita(List<object[]> li)
        {
            List<ReporteVisita> list1 = new List<ReporteVisita>();
            foreach (var q in li)
            {
                var rv = new ReporteVisita()
                {
                    NombreTipo = q[0] + ". " + q[1],
                    NH = q[2].ToString(),
                    NM = q[3].ToString(),
                    P = q[4].ToString(),
                    M = q[5].ToString(),
                    DH = q[6].ToString(),
                    DM = q[7].ToString()
                };
                list1.Add(rv);
            }
            return list1;
        }

        protected List<ReporteBotargas> convertirReporteBotargas(List<object[]> li)
        {
            List<ReporteBotargas> list1 = new List<ReporteBotargas>();
            foreach (var q in li)
            {
                var rv = new ReporteBotargas()
                {
                    Fecha = q[0].ToString(),
                    Eventos = Convert.ToInt32(q[1]),
                    Total = Convert.ToInt32(q[2]),
                    Dias = Convert.ToInt32(q[3])
                };
                list1.Add(rv);
            }
            return list1;
        }

        protected void Button_Consultar_Click(object sender, EventArgs e)
        {
            string fechaDeInicio = Convert.ToDateTime(FechaInicio.Text).ToString("yyyy-MM-dd");
            string fechaDeFin = Convert.ToDateTime(FechaFin.Text).ToString("yyyy-MM-dd");

            condicionFechas1 = " AND js.FechaReporta between '" + fechaDeInicio + " 00:00:00' and '"
                 + fechaDeFin + " 23:59:00' "; ;

            condicionFechas2 = " WHERE j.FechaReporta between '" + fechaDeInicio + " 00:00:00' and '"
                 + fechaDeFin + " 23:59:00' ";
            GenerarConsulta();
        }
    }
}