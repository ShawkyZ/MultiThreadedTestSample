using System;
using System.Data.SqlClient;

namespace UnitOfWork
{
    public interface IUnitOfWork
    {
        SqlTransaction Transaction { get; set; }
        void Commit(Action action);
    }
}