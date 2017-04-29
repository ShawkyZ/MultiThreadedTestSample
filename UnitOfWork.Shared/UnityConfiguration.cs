using Microsoft.Practices.Unity;

namespace UnitOfWork.Shared
{
    public static class UnityConfiguration
    {
        private static UnityContainer _container;
        public static UnityContainer Container => _container ?? (_container = new UnityContainer());
    }
}
