using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NHibernetMVC_001.Models
{
    public class NHibertnateSession
    {
        public static ISession OpenSession()
        {
            var configuration = new NHibernate.Cfg.Configuration();
            var configurationPath = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\hibernate.cfg.xml");
            configuration.Configure(configurationPath);
            var employeeConfigurationFile = HttpContext.Current.Server.MapPath(@"~\Models\Nhibernate\Employee.hbm.xml");
            configuration.AddFile(employeeConfigurationFile);
            ISessionFactory sessionFactory = configuration.BuildSessionFactory();
            return sessionFactory.OpenSession();
        }
    }
}