using System;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Practices.Unity;
using UnitOfWork.Model;

namespace UnitOfWork
{
    public class CustomerRepository : ICustomerRepository
    {
        public bool InsertCustomer(DtoCustomer customer,int num)
        {
            var sqlConnection = new SqlConnection(@"Data Source=.;Initial Catalog=DeadlockTests;Integrated Security=True");
            sqlConnection.Open();
            var transaction = sqlConnection.BeginTransaction();
            Shared.UnityConfiguration.Container.Resolve<IUnitOfWork>().Transaction = transaction;
            using (var objCommand = new SqlCommand())
            {
                objCommand.Connection = sqlConnection;
                objCommand.Transaction = transaction;
                objCommand.CommandText = "DEADLOCKPROC";
                objCommand.CommandType = CommandType.StoredProcedure;
                objCommand.Parameters.AddWithValue("COLNUM", num);
                objCommand.CommandTimeout = 60;
                objCommand.ExecuteNonQuery();
            }
            return true;
        }
        
        public SqlDataReader GetCustomer(int customerCode)
        {
           throw new NotImplementedException();
        }
     
        public virtual bool UpdateCustomer(DtoCustomer customer)
        {
            throw new NotImplementedException();
        }
    }
}
