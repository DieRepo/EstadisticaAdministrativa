using System;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    [Serializable]
    public class Temas
    {
        public virtual int idtema { get; set; }
        public virtual string nombre_tema { get; set; }
        public virtual int activo_tema { get; set; }
        public virtual DateTime fecha_registro_tema { get; set; }

    }
}
