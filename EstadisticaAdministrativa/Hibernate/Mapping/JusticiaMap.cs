using EstadisticaAdministrativa.Hibernate.Modelo;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class JusticiaMap : ClassMap<JusticiaVisita>
    {
        public JusticiaMap()
        {
            Table("tbljusticia");
            Id(x => x.Id).GeneratedBy.Identity();
            Map(x => x.NombreEscuela);
            Map(x => x.MesReporta);
            Map(x => x.AnioReporta);
            Map(x => x.FechaReporta);
            Map(x => x.FechaRegistro);
            Map(x => x.idUser);

            HasMany(x => x.JusticiaRegistros).Inverse().AsBag().Not.LazyLoad().Cascade.All();
            HasMany(x => x.ApoyoBotargas).Inverse().AsBag().Not.LazyLoad().Cascade.All();
        }
    }
}