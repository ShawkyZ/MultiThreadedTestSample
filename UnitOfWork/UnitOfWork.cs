using System;
using System.Data.SqlClient;
using System.Transactions;
using Microsoft.Practices.Unity;
using IsolationLevel = System.Data.IsolationLevel;

namespace UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public SqlTransaction Transaction { get; set; }
        public void Commit(Action action)
        {
                try
                {
                    action.Invoke();
                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    var sqlException = ex as SqlException;
                    if (sqlException != null && sqlException.Number == 1205)
                    {
                        //Transaction.Rollback();
                        //Repeat Action
                        throw sqlException;
                    }
                    throw ex;
                }
        }
    }
}