using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;

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
