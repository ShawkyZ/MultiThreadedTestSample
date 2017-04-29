using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace UnitOfWork
{
    public static class UnityConfiguration
    {
        public static void RegisterTypes()
        {
            Shared.UnityConfiguration.Container.RegisterType<ICustomerRepository, CustomerRepository>();
            Shared.UnityConfiguration.Container.RegisterType<IUnitOfWork, UnitOfWork>(new PerThreadLifetimeManager());
        }
    }
}
