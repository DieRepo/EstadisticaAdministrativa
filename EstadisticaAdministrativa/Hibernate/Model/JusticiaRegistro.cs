using EstadisticaAdministrativa.Hibernate.Modelo;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class JusticiaRegistro
    {
        public virtual int id { get; set; }
        public virtual int idTipo { get; set; }
        public virtual int ninoHombre { get; set; }
        public virtual int ninoMujer { get; set; }
        public virtual int padres { get; set; }
        public virtual int madres { get; set; }
        public virtual int docenteHombre { get; set; }
        public virtual int docenteMujer { get; set; }
        public virtual int mesReporta { get; set; }
        public virtual JusticiaVisita JusticiaVisita { get; set; }
        public virtual int idUser { get; set; }


    }
}