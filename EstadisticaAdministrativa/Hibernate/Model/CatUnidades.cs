using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class CatUnidades
    {
        public virtual int idunidad { get; set; }
        public virtual int idarea { get; set; }
        public virtual string nom_area { get; set; }
        public virtual int activo_area { get; set; }
        public virtual DateTime fecha_registro_area { get; set; }
    }
}