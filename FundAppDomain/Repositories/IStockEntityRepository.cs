using FundAppDomain.Model.AbstractStocks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace FundAppDomain.Repositories
{
    public interface IStockEntityRepository
    {

        IEnumerable<StockEntity> FindAll();

        void Add(StockEntity entity);
        
    }
}
