using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace TaidouDatabase
{
    class NHibernateHelper
    {
        private static ISessionFactory sessionFactory = null;

        private static void InitializeSessionFactror()
        {
            sessionFactory = Fluently.Configure().Database(MySQLConfiguration.Standard.ConnectionString(db => db
                .Server("127.0.0.1")
                .Database("yaojun")
                .Username("root")
                .Password("root")))
                .Mappings(x => x.FluentMappings.AddFromAssemblyOf<NHibernateHelper>()).BuildSessionFactory();
        }

        private static ISessionFactory SessionFactory
        {
            get
            {
                if(sessionFactory == null)
                    InitializeSessionFactror();
                return sessionFactory;
            }
        }

        public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();
        }
    }
}
