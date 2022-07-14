using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class AreasApoyoMap : ClassMap<AreaApoyo>
    {
        public AreasApoyoMap()
        {
            Table("tblapoyoarea");
            Id(x => x.idapoyo).GeneratedBy.Identity();
            References(x => x.IdCapacitacion).Column("IdCapacitacion").Cascade.All();
            References(x => x.idunidad).Column("idunidad").Cascade.All();

        }
    }
}

