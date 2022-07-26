using System;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    [Serializable]
    public class Areas
    {
        public virtual int idunidad { get; set; }
        public virtual int idarea { get; set; }
        public virtual string nomarea { get; set; }
        public virtual int activoarea { get; set; }
        public virtual DateTime fecha_reg_area { get; set; }

    }
}
