using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using NUnit.Framework;
using UnitOfWork.BO;
using UnitOfWork.Model;

namespace UnitOfWork.BOTest
{
    [TestFixture]
    public class DeadlockTest
    {
        private List<Exception> exceptionList = new List<Exception>();
        [Test]
        public void InsertCustomer_Deadlock_Exception()
        {
            //Arrange
            var dtoCustomer = new DtoCustomer{CustomerCode = 32,CustomerName = "testCustomer", Id = 3};
            //Act
            ExecuteWithMultiThreads(ExecuteForInsert,10,dtoCustomer);
            //Assert
            Assert.IsTrue(exceptionList.Count < 10);
        }

        public Thread ExecuteForInsert(DtoCustomer customer, int threadNum)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    new BoCustomer().Insert(customer, threadNum);
                }
                catch (Exception ex)
                {
                    var sqlException = ex as SqlException;
                    if (sqlException != null && sqlException.Number == 1205)
                    {
                        Console.WriteLine($"Deadlock on thread #{threadNum}");
                        exceptionList.Add(sqlException);
                    }
                }
            });
            thread.Start();
            return thread;
        }
        public void ExecuteWithMultiThreads(Func<DtoCustomer,int,Thread> action, int threadsNum, DtoCustomer customer)
        {
            var threadList = new List<Thread>();
            for (var i = 0; i < threadsNum; i++)
            {
                threadList.Add(action.Invoke(customer, i));
            }
            while (threadList.Any(thread => thread.IsAlive))
            {
            }
        }
    }
}
