using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class Temas
    {
        public virtual int idtema { get; set; }
        public virtual string nombre_tema { get; set; }
        public virtual int activo_tema { get; set; }
        public virtual DateTime fecha_registro_tema { get; set; }

        public virtual CapacitacionRegistro capacitaciones { get; set; }

    }
}