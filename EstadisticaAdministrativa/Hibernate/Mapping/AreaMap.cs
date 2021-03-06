using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class AreaMap : ClassMap<Areas>
    {
        public AreaMap()
        {
            Table("tblcatareas");
            Id(x => x.idunidad).GeneratedBy.Identity();
            Map(x => x.idarea);
            Map(x => x.nomarea);
            Map(x => x.activoarea);
            Map(x => x.fecha_reg_area);

        }
    }
}
