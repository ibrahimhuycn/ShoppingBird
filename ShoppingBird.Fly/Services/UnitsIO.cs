using ShoppingBird.Fly.DataAccess;
using ShoppingBird.Fly.Interfaces;
using ShoppingBird.Fly.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBird.Fly.Services
{
    public class UnitsIO : IUnitsIO
    {
        private readonly IDataAccessBase _dataAccessBase;

        public UnitsIO(IDataAccessBase dataAccessBase)
        {
            _dataAccessBase = dataAccessBase;
        }
        public async Task<List<UnitsModel>> LoadAllUnitsAsync()
        {
            var storedProcedure = "[dbo].[usp_GetAllUnits]";
            var units  = await _dataAccessBase.LoadDataAsync<UnitsModel>(storedProcedure);
            return units;
        }

        public async Task<UnitsModel> UpdateUnitAsync(UnitsModel e)
        {
            var storedProcedure = "[dbo].[usp_UpdateUnitAndReturnUpdated]";
            var parameters = new { Id = e.Id, Unit = e.Unit, Description = e.Description };
            var updated = await _dataAccessBase.SelectInsertOrUpdateAsync<UnitsModel, dynamic>(storedProcedure, parameters);
            return updated;
        }

        public async Task<UnitsModel> InsertUnitAsync(string unit, string description)
        {
            var storedProcedure = "[dbo].[usp_InsertUnitAndReturnInserted]";
            var parameters = new
            {
                Unit = unit, Description = description
            };
            var inserted = await _dataAccessBase.SelectInsertOrUpdateAsync<UnitsModel, dynamic>(storedProcedure, parameters);
            return inserted;
        }
    }
}
