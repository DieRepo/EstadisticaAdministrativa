using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class CapacitacionMap : ClassMap<CapacitacionRegistro>
    {
        public CapacitacionMap()
        {
            Table("tblcapacitacion");
            Id(x => x.IdCapacitacion).GeneratedBy.Identity();
            Map(x => x.nom_cap);
            Map(x => x.fecha_inicio);
            Map(x => x.fecha_fin);
            Map(x => x.tipoCap);
            Map(x => x.asis_hombres);
            Map(x => x.asis_mujeres);
            Map(x => x.idUser);
            Map(x => x.activo);
            References(x => x.idtema).Column("idtema");
            References(x => x.idunidad).Column("idunidad");
            HasMany(x => x.idUnidades).Inverse().AsBag().Not.LazyLoad().Cascade.All();



        }

    }
}
