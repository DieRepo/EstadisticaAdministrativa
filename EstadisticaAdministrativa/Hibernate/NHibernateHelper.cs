using EstadisticaAdministrativa.Hibernate.Modelo;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Tool.hbm2ddl;
using System.Reflection;

namespace EstadisticaAdministrativa.Hibernate
{

    public class NHibernateHelper
    {
        private static ISessionFactory _sessionFactory;
        private static ISession session = null;

        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    InitializeSessionFactory();
                return _sessionFactory;
            }
        }

        public static ISession Sesion
        {
            get { return session; }
        }

        private static void InitializeSessionFactory()
        {
            _sessionFactory = Fluently.Configure()
                .Database(MySQLConfiguration.Standard
                .ConnectionString(System.Configuration.ConfigurationManager.AppSettings["local"])
                .ShowSql()
                )
                .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }

        public static ISession OpenSession()
        {
            session = SessionFactory.OpenSession();

            return session;
        }

        public static void CloseSesion()
        {
            session.Close();
        }
    }
}