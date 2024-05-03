using Dapper;
using System;
using System.Collections.Generic;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShoppingBird.Fly.Helpers;
using ShoppingBird.Fly.Models;

namespace ShoppingBird.Fly.DataAccess
{
    public class DataAccessBase : IDataAccessBase
    {
        internal readonly SqlDataAccessHelper Helper;

        public DataAccessBase()
        {
            Helper = new SqlDataAccessHelper();
        }

        public async Task<List<T>> LoadDataAsync<T>(string storedProcedure)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                results = await connection.QueryAsync<T>(storedProcedure, CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        internal List<T> LoadDataSynchronously<T>(string storedProcedure)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                results = connection.Query<T>(storedProcedure, CommandType.StoredProcedure);
            }

            return results.ToList();
        }

        /// <summary>
        /// Loads a list of data from database with specific type with provided query and datasource name
        /// </summary>
        /// <typeparam name="T">Return type</typeparam>
        /// <param name="query">SQL query</param>
        /// <param name="dataSource">data source</param>
        /// <returns></returns>
        public async Task<List<T>> LoadDataWithQueryAsync<T>(string query, string dataSource)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(dataSource)))
            {
                results = await connection.QueryAsync<T>(query, CommandType.Text);
            }

            return results.ToList();
        }
        public async Task<List<T>> LoadDataWithQueryAndParametersAsync<T, TU>(string query, TU parameters, string connectionName = "CD4Data")
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString(connectionName)))
            {
                results = await connection.QueryAsync<T>(query, parameters);
            }

            return results.ToList();
        }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<List<T>> LoadDataWithParameterAsync<T, TU>
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
            (string storedProcedure, TU parameter)
        {
            IEnumerable<T> results = new List<T>();
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                return connection.QueryAsync<T>
                    (storedProcedure, parameter, commandType: CommandType.StoredProcedure).Result.ToList();
            }
        }

        /// <summary>
        /// NOTE: T should be the first type of data set returned by the query / procedure
        /// NOTE: U should be the second type of data set returned by the query / procedure
        /// MEANS that the generic classes should be passed in the order that is expected to be returned by the query.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="storedProcedure"></param>
        /// <returns>returns a class with List<T> AND List<U> as public properties</returns>
        public async Task<GenericTwoListModel> LoadStaticDataTwoSetsAsync<T, TU>
            (string storedProcedure)
        {
            var genericTwoList = new GenericTwoListModel();
            var returnData = genericTwoList.GetLists<T, TU>();

            List<T> listT = null;
            List<TU> listU = null;

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, CommandType.StoredProcedure))
                {
                    listT = lists.Read<T>().ToList();
                    listU = lists.Read<TU>().ToList();
                }
            }

            returnData.T1 = listT;
            returnData.U1 = listU;
            return returnData;
        }

        /// <summary>
        /// Executes query and get multiple objects with model, list , stored procedure and paramters
        /// </summary>
        /// <typeparam name="T">The type of model instance to be returned</typeparam>
        /// <typeparam name="U">The type of list instance to be returned</typeparam>
        /// <typeparam name="V">parameter type</typeparam>
        /// <param name="storedProcedure">The stored procedure name</param>
        /// <param name="parameters">instance of parameters</param>
        /// <returns></returns>
        public async Task<GenericModelAndListModel> QueryMultiple_GetModelAndListWithParameterAsync<T, TU, TV>
            (string storedProcedure, TV parameters) where T : new()
        {
            var genericModelAndListList = new GenericModelAndListModel();
            var returnData = genericModelAndListList.GetNewModel<T, TU>();

            var instanceT = default(T);
            List<TU> listU = null;

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                {
                    instanceT = lists.Read<T>().FirstOrDefault();
                    listU = lists.Read<TU>().ToList();
                }
            }

            returnData.T1 = instanceT;
            returnData.U1 = listU;
            return returnData;
        }

        /// <summary>
        /// Executes query and get multiple objects with TWO Lists, stored procedure and paramters
        /// </summary>
        /// <typeparam name="T">The type of list instance to be returned</typeparam>
        /// <typeparam name="U">The type of list instance to be returned</typeparam>
        /// <typeparam name="V">parameter type</typeparam>
        /// <param name="storedProcedure">The stored procedure name</param>
        /// <param name="parameters">instance of parameters</param>
        /// <returns></returns>
        public async Task<GenericTwoListModel> QueryMultiple_GetTwoListsWithParameterAsync<T, TU, TV>
            (string storedProcedure, TV parameters) where T : new()
        {
            var genericTwoListList = new GenericTwoListModel();
            var returnData = genericTwoListList.GetLists<T, TU>();

            List<T> listT = null;
            List<TU> listU = null;

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                {
                    listT = lists.Read<T>().ToList();
                    listU = lists.Read<TU>().ToList();
                }
            }

            returnData.T1 = listT;
            returnData.U1 = listU;
            return returnData;
        }

        /// <summary>
        /// Executes query and get multiple objects with THREE Lists, stored procedure and paramters
        /// </summary>
        /// <typeparam name="T">The type of list instance to be returned</typeparam>
        /// <typeparam name="U">The type of list instance to be returned</typeparam>
        /// <typeparam name="V">The type of list instance to be returned</typeparam>
        /// <param name="storedProcedure">The stored procedure name</param>
        /// <param name="parameters">instance of parameters</param>
        /// <returns></returns>
        public async Task<GenericThreeListsModel> QueryMultiple_GetThreeListsWithParameterAsync<T, TU, TV, TW>
            (string storedProcedure, TW parameters) where T : new()
        {
            var genericModelAndListList = new GenericThreeListsModel();
            var returnData = genericModelAndListList.GetLists<T, TU, TV>();

            List<T> listT = null;
            List<TU> listU = null;
            List<TV> listV = null;

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure))
                {
                    listT = lists.Read<T>().ToList();
                    listU = lists.Read<TU>().ToList();
                    listV = lists.Read<TV>().ToList();
                }
            }

            returnData.T1 = listT;
            returnData.U1 = listU;
            returnData.V1 = listV;
            return returnData;
        }

        public async Task<dynamic> QueryMultiple_WithProvidedReturnTypes_NoParameters(string storedProcedure, TypesModel listTypes, dynamic simpleTypes)
        {
            var dynamicResults = new List<dynamic>();

            foreach (var item in listTypes.GenericModelsList)
            {
                dynamicResults.Add(Activator.CreateInstance(item));
            }

            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                using (var lists = await connection.QueryMultipleAsync(storedProcedure, commandType: CommandType.StoredProcedure))
                {
                    var counter = 0;
                    foreach (var item in simpleTypes)
                    {
                        var t = item.GetType();
                        dynamicResults[counter] = lists.Read(t);
                        counter += 1;
                    }
                }
            }

            return dynamicResults;

        }

        public async Task<T> SelectInsertOrUpdateAsync<T, TU>(string storedProcedure, TU parameters)
        {
            using (IDbConnection connection = new SqlConnection(Helper.GetConnectionString()))
            {
                var s = await connection.QueryFirstOrDefaultAsync<T>
                    (storedProcedure, parameters, commandType: CommandType.StoredProcedure);
                return s;
            }

        }

        public SqlMapper.ICustomQueryParameter GetInvoiceDetailsUDT(List<CartItemModel> cartItems)
        {
            var returnTable = new DataTable();
            returnTable.Columns.Add("ItemId").DataType = typeof(int);
            returnTable.Columns.Add("Price").DataType = typeof(decimal);
            returnTable.Columns.Add("Quantity").DataType = typeof(decimal);

            //Add rows to the Data table declared, and return
            for (int i = 0; i < cartItems.Count; i++)
            {
                var request = cartItems[i];
                returnTable.Rows.Add(request.ItemId, request.RetailPrice, request.Quantity);
            }
            return returnTable.AsTableValuedParameter("[dbo].[InvoiceDetailsUDT]");
        }
    }

}
