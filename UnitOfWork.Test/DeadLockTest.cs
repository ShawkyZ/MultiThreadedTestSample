using System.Data;
using System.Threading;
using NUnit.Framework;
using Rhino.Mocks;
using UnitOfWork.BO;
using UnitOfWork.Model;

namespace UnitOfWork.Test
{
    [TestFixture]
    public class DeadLockTest
    {
        [Test]
        public void DeadlockTest()
        {
            //arrrange
            //var boCustomer = new BoCustomer();
            //var mockedCustomerRepositry = MockRepository.GenerateMock<ICustomerRepository>();
            //mockedCustomerRepositry.Expect(x => x.UpdateCustomer(null)).IgnoreArguments().Return(true);
            //mockedCustomerRepositry.Expect(x => x.InsertCustomer(null)).IgnoreArguments().Return(true);

            ////act
            /// 
            /// 
            //for (var i = 0; i < 3; i++)
            //{
            //    new Thread(() => boCustomer.Insert(new DtoCustomer())).Start();
            //}
          //  mockedCustomerRepositry.VerifyAllExpectations();
            //   new BoCustomer().Insert(null);
            // Call to database
        }
    }
}
