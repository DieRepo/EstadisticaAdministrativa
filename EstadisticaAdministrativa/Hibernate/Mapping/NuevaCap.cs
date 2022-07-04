using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class NuevaCap : ClassMap<NuevaCapacitacion>
    {
        public NuevaCap()
        {
            Table("tbl_capacitacion");
            Id(x => x.Idcapacitacion).GeneratedBy.Identity();
            Map(x => x.nom_cap);
            Map(x => x.fecha_inicio);
            Map(x => x.fecha_fin);
            Map(x => x.asis_hombres);
            Map(x => x.asis_mujeres);
            Map(x => x.idUser);
            Map(x => x.idunidad);
            Map(X => X.id_tema);
           // References(x => x.);
        }

    }
}