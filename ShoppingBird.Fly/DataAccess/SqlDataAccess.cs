using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace ShoppingBird.Fly.DataAccess
{
    public class SqlDataAccess: IDisposable
    {
        private IDbConnection _connection;
        private IDbTransaction _transaction;
        public void StartTransaction(string ConnectionStringName)
        {
            string connectionString = Helper.GetConnectionString(ConnectionStringName);
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            _transaction = _connection.BeginTransaction();
        }

        /// <summary>
        /// Called only if the transaction succeeds.
        /// </summary>
        public void CommitTransaction()
        {
            //Cannot call if transection is already completed.
            _transaction?.Commit();
            _connection?.Close();
        }

        /// <summary>
        /// Call only if the statements fail.
        /// </summary>
        public void RollbackTransaction()
        {
            _transaction?.Rollback();
            _connection?.Close();
        }

        public void Dispose()
        {
            try
            {
                CommitTransaction();
            }
            catch (InvalidOperationException ex) { if (ex.Message.Contains("SqlTransaction has completed") != true) throw; }
            catch (Exception) { throw; }
            finally
            {
                _transaction?.Dispose();
                _connection?.Close();
            }
        }

        public dynamic SaveDataInTransactionQuerySingle(string storedProcedure, object parameters)
        {
             return _connection.QuerySingle<dynamic>(storedProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public dynamic SaveDataInTransactionExecute(string storedProcedure, object parameters)
        {
            return _connection.Execute(storedProcedure,  parameters,
               commandType: CommandType.StoredProcedure, transaction: _transaction);
        }
        public List<T> LoadDataInTransaction<T, U>(string StoredProcedure, U parameters)
        {
           return _connection.Query<T>(StoredProcedure, parameters,
                commandType: CommandType.StoredProcedure, transaction: _transaction).ToList();
        }
    }
}
