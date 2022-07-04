﻿using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Model
{
    public class ApoyoArea
    {
        public virtual int idapoyo { get; set; }
        public virtual int IdCapacitacion { get; set; }
        public virtual IList<CatUnidades> idunidad { get; set; }
    }
}