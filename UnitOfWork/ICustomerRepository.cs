using System.Data.SqlClient;
using UnitOfWork.Model;

namespace UnitOfWork
{
    public interface ICustomerRepository
    {
        SqlDataReader GetCustomer(int customerCode);
        bool InsertCustomer(DtoCustomer customer, int num);
        bool UpdateCustomer(DtoCustomer customer);
    }
}