using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class CattemaMap : ClassMap<Cattemas>
    {
        public CattemaMap()
        {
            Table("cattemas");
            Id(x => x.idtema).GeneratedBy.Identity();
            Map(x => x.nombre_tema);
            Map(x => x.activo_tema);
            Map(x => x.fecha_registro_tema);


        }
    }
}
