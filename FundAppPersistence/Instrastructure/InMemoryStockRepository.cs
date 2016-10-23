using FundAppDomain.Repositories;
using System;
using System.Linq;
using System.Collections.Generic;
using FundAppDomain.Model.AbstractStocks;
using System.Linq.Expressions;

namespace FundAppPersistence.Instrastructure
{
    public class InMemoryStockRepository : IStockEntityRepository
    {
        #region Private fields

        private readonly List<StockEntity> _stockEntities = new List<StockEntity>();

        #endregion

        #region Public methods

        public void Add(StockEntity entity)
        {
            _stockEntities.Add(entity);
        }

        public IEnumerable<StockEntity> FindAll()
        {

            return new List<StockEntity>(_stockEntities);
        } 

        #endregion
    }
}
