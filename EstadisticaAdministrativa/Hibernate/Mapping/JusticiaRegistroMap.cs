using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class JusticiaRegistroMap : ClassMap<JusticiaRegistro>
    {
        public JusticiaRegistroMap() {
            Table("tbljusticiaregistros");
            Id(x => x.id).GeneratedBy.Identity();
            Map(x => x.ninoHombre);
            Map(x => x.ninoMujer);
            Map(x => x.padres);
            Map(x => x.madres);
            Map(x => x.docenteHombre);
            Map(x => x.docenteMujer);
            Map(x => x.mesReporta);
            Map(x => x.idTipo);
            Map(x => x.idUser);
            References(x => x.JusticiaVisita).
                Column("idRegistro")
                .Cascade.All();
        }

    }
}