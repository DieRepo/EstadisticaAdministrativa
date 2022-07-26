using EstadisticaAdministrativa.Hibernate.Modelo;
using System;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class JusticiaBotarga
    {
        public virtual int id { get; set; }
        public virtual DateTime fechaReporta { get; set; }
        public virtual int eventos { get; set; }
        public virtual int total { get; set; }
        public virtual int dias { get; set; }
        public virtual JusticiaVisita JusticiaVisita { get; set; }
        public virtual int idUser { get; set; }
    }
}