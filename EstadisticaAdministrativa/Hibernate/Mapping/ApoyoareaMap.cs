using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class ApoyoareaMap : ClassMap<ApoyoArea>
    {
        public ApoyoareaMap()
        {
            Table("tblapoyoarea");
            Id(x => x.idapoyo).GeneratedBy.Identity();
            Map(x => x.IdCapacitacion);
            Map(x => x.idunidad);

            References(x => x.idCapacita).Column("IdCapacitacion").Cascade.All();

            HasMany(x => x.unidadApoyo).Inverse().AsBag().Not.LazyLoad().Cascade.All();
        }
    }
}

