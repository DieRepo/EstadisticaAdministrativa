using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;

namespace EstadisticaAdministrativa.Hibernate.Modelo
{
    public class JusticiaVisita
    {
        public virtual int Id { get; set; }
        public virtual string NombreEscuela { get; set; }
        public virtual int MesReporta { get; set; }
        public virtual int AnioReporta { get; set; }
        public virtual int Activo { get; set; }
        public virtual DateTime FechaReporta { get; set; }
        public virtual DateTime FechaRegistro { get; set; }
        public virtual IList<JusticiaRegistro> JusticiaRegistros { get; set; }
        public virtual IList<JusticiaBotarga> ApoyoBotargas { get; set; }
        public virtual int idUser { get; set; }


    }
}