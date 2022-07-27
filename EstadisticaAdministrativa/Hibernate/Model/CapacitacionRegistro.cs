using System;
using System.Collections.Generic;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class CapacitacionRegistro
    {
        public virtual int IdCapacitacion { get; set; }
        public virtual string nom_cap { get; set; }
        public virtual DateTime? fecha_inicio { get; set; }
        public virtual DateTime? fecha_fin { get; set; }
        public virtual int tipoCap { get; set; }
        public virtual int asis_hombres { get; set; }
        public virtual int asis_mujeres { get; set; }
        public virtual int idUser { get; set; }
        public virtual int activo { get; set; }

        public virtual Temas idtema { get; set; }
        public virtual Areas idunidad { get; set; }

        public virtual IList<AreaApoyo> idUnidades { get; set; } //area encargada


    }
}
