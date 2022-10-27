using Dapper;
using ShoppingBird.Fly.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.DataAccess
{
    public interface IDataAccessBase
    {
        SqlMapper.ICustomQueryParameter GetInvoiceDetailsUDT(List<CartItemModel> cartItems);
        Task<List<T>> LoadDataAsync<T>(string storedProcedure);
        Task<List<T>> LoadDataWithParameterAsync<T, TU>(string storedProcedure, TU parameter);
        Task<List<T>> LoadDataWithQueryAndParametersAsync<T, TU>(string query, TU parameters, string connectionName = "CD4Data");
        Task<List<T>> LoadDataWithQueryAsync<T>(string query, string dataSource);
        Task<GenericTwoListModel> LoadStaticDataTwoSetsAsync<T, TU>(string storedProcedure);
        Task<GenericModelAndListModel> QueryMultiple_GetModelAndListWithParameterAsync<T, TU, TV>(string storedProcedure, TV parameters) where T : new();
        Task<GenericThreeListsModel> QueryMultiple_GetThreeListsWithParameterAsync<T, TU, TV, TW>(string storedProcedure, TW parameters) where T : new();
        Task<GenericTwoListModel> QueryMultiple_GetTwoListsWithParameterAsync<T, TU, TV>(string storedProcedure, TV parameters) where T : new();
        Task<dynamic> QueryMultiple_WithProvidedReturnTypes_NoParameters(string storedProcedure, TypesModel listTypes, dynamic simpleTypes);
        Task<T> SelectInsertOrUpdateAsync<T, TU>(string storedProcedure, TU parameters);
    }
}