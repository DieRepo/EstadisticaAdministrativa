using EstadisticaAdministrativa.Hibernate.Modelo;
using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class TemaDAO
    {

        public static IList<Cattemas> ListAll()
        {
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion
                    .CreateCriteria(typeof(Cattemas))
                    .List<Cattemas>();
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