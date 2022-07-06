using EstadisticaAdministrativa.Hibernate.Modelo;
using EstadisticaAdministrativa.Hibernate.Model; 
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class CapacitacionDAO
    {

        public static CapacitacionRegistro Guardar(CapacitacionRegistro o)
        {
            NHibernateHelper.OpenSession();
           

            var t = NHibernateHelper.Sesion.BeginTransaction();
            try
            {

                NHibernateHelper.Sesion.SaveOrUpdate(o);
                t.Commit();

                return o;
            }

            catch (Exception e)
            {

                t.Rollback();
                Debug.WriteLine("Error al guardar: " + e.Source + "\n\n" + e.Message + "\n\n" + e.InnerException + "\n\n" + e.StackTrace);
                return o;
            }

            finally
            {
                NHibernateHelper.CloseSesion();
            }
        }
    }
}