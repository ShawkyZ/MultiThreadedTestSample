using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Practices.Unity;
using UnitOfWork.Model;

namespace UnitOfWork.BO
{
    public class BoCustomer
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _uow;

        public BoCustomer()
        {
            UnityConfiguration.RegisterTypes();
            _customerRepository = Shared.UnityConfiguration.Container.Resolve<ICustomerRepository>();
            _uow = Shared.UnityConfiguration.Container.Resolve<IUnitOfWork>();
        }
        public void Insert(DtoCustomer customer,int num)
        {
            _uow.Commit(()=> _customerRepository.InsertCustomer(customer, num));
        }

        public void Update(DtoCustomer customer)
        {
            customer.CustomerCode = new Random().Next(0, 500);
            _customerRepository.UpdateCustomer(customer);
        }

        public List<DtoCustomer> Load()
        {
            throw new System.NotImplementedException();
        }
    }
}
