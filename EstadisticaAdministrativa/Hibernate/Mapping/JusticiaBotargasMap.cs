using EstadisticaAdministrativa.Hibernate.Model;
using FluentNHibernate.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Mapping
{
    class JusticiaBotargasMap : ClassMap<JusticiaBotarga>
    {
        public JusticiaBotargasMap(){
            Table("tbljusticiabotargas");
            Id(x => x.id).GeneratedBy.Identity();
            Map(x => x.fechaReporta);
            Map(x => x.eventos);
            Map(x => x.total);
            Map(x => x.dias);
            Map(x => x.idUser);
            References(x => x.JusticiaVisita).
                Column("idRegistro")
                .Cascade.All();
        }
    }
}