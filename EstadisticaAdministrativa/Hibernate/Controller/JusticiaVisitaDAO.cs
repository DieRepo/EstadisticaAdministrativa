using EstadisticaAdministrativa.Hibernate.Modelo;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace EstadisticaAdministrativa.Hibernate.Controller
{
    class JusticiaVisitaDAO
    {
        public static JusticiaVisita GuardarJusticiaVisita(JusticiaVisita o)
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
                Debug.WriteLine("Error al guardar JusticiaVisita: " + e.Source + "\n\n" + e.Message + "\n\n" + e.InnerException + "\n\n" + e.StackTrace);
                return o;
            }
            finally
            {
                NHibernateHelper.CloseSesion();
            }
        }

        public static List<JusticiaVisita> ObtenJusticiaVisita(long? id)
        {

            List<JusticiaVisita> ag = new List<JusticiaVisita>();
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion.Query<JusticiaVisita>()
                                        .Where(c => c.Id == id)
                                        .ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error al traer al agresor: " + e.Message + "\n" + e.StackTrace);
                return null;
            }
            finally
            {
                NHibernateHelper.CloseSesion();
            }

        }

        public static IList<JusticiaVisita> ListAll()
        {
            try
            {
                NHibernateHelper.OpenSession();
                return NHibernateHelper.Sesion
                    .CreateCriteria(typeof(JusticiaVisita))
                    .List<JusticiaVisita>();
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


        public static IList<object[]> ListNative(string query)
        {
            try
            {
                NHibernateHelper.OpenSession();
                IList<object[]> result = NHibernateHelper.Sesion
                    .CreateQuery(query)
                    .List<object[]>();
                return result;
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

        public static IList<object[]> ObtenerConsultaNativa(string query)
        {
            try
            {
                NHibernateHelper.OpenSession();
                IList<object[]> result = NHibernateHelper.Sesion
                    .CreateSQLQuery(query)
                    .List<object[]>();
                return result;
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