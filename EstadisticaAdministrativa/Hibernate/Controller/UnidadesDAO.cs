using EstadisticaAdministrativa.Hibernate.Modelo;
using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class UnidadesDAO
    {
        public static IList<Areas> ListAll()
        {
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion
                    .CreateCriteria(typeof(Areas))
                    .List<Areas>();
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error al traer al lista: " + e.Message + "\n" + e.StackTrace);
                return null;
            }

            finally
            {
                NHibernateHelper.CloseSesion();
            }

        }

        public static IList<Areas> ListAllEncargada()
        {
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion
                    .CreateCriteria(typeof(Areas))
                    .List<Areas>();
            }

            catch (Exception e)
            {
                Debug.WriteLine("Error al traer al lista: " + e.Message + "\n" + e.StackTrace);
                return null;
            }

            finally
            {
                NHibernateHelper.CloseSesion();
            }

        }

    }
}