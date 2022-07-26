using EstadisticaAdministrativa.Hibernate.Model;
using System;
using System.Diagnostics;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class ApoyoUnidadDAO
    {

        public static AreaApoyo Guardar(AreaApoyo o)
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