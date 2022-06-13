using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Modelo
{
    public class ReporteBotargas
    {
        private string fecha;
        private int eventos;
        private int total;
        private int dias;

        public string Fecha { get => fecha; set => fecha = value; }
        public int Eventos { get => eventos; set => eventos = value; }
        public int Total { get => total; set => total = value; }
        public int Dias { get => dias; set => dias = value; }
    }
}