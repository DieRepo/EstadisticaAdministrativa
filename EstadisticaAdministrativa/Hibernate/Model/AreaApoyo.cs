using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class AreaApoyo
    {
        public virtual int idapoyo { get; set; }
        public virtual CapacitacionRegistro IdCapacitacion { get; set; }
        public virtual Areas idunidad { get; set; }
        public virtual int activo { get; set; }
        public virtual DateTime fechaRegistro { get; set; }

    }
}