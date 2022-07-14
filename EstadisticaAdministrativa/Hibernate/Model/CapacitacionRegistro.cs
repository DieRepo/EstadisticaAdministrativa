using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class CapacitacionRegistro
    {
        public virtual int IdCapacitacion { get; set; }
        public virtual string nom_cap { get; set; }
         
        public virtual DateTime?  fecha_inicio { get; set; }
        public virtual DateTime?  fecha_fin { get; set; }
        public virtual int tipoCap { get; set; }
        public virtual int asis_hombres { get; set; }
        public virtual int asis_mujeres { get; set; }
        public virtual int idUser { get; set; }
        public virtual int activo { get; set; }
        //public virtual int idTema { get; set; }
        //public virtual int idUnidad { get; set; }

        public virtual IList<AreaApoyo> idunidad { get; set; } //area encargada


    }
}