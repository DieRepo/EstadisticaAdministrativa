using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class TemaDAO
    {

        public static IList<Temas> ListAllTema()
        {
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion
                    .CreateCriteria(typeof(Temas))
                    .List<Temas>();
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