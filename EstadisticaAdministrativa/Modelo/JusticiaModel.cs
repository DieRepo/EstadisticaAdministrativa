namespace EstadisticaAdministrativa.Modelo
{
    public class JusticiaModel
    {
        public virtual int Id { get; set; }
        public virtual string NombreEscuela { get; set; }
        public virtual int MesReporta { get; set; }
        public virtual int AnioReporta { get; set; }
        public virtual int Activo { get; set; }
    }
}