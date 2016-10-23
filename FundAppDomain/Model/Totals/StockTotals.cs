using FundAppDomain.Model.AbstractStocks;
using System;

namespace FundAppDomain.Model.Totals
{
    public class StockTotals
    {
        #region Private fields

        private bool _isLockedForIncrementation = false;

        #endregion

        #region Public properties

        public uint TotalNumber { private set; get; }

        public decimal TotalStockWeight { private set; get; }

        public decimal TotalMarketValue { private set; get; }

        #endregion

        #region Public methods

        public void Increment(StockEntity stockEntity)
        {
            if (_isLockedForIncrementation)
                throw new InvalidOperationException("Object is locked for incrementation");

            TotalNumber++;
            TotalStockWeight += stockEntity.StockWeight;
            TotalMarketValue += stockEntity.StockWeight;
        }


        public void Lock()
        {
            _isLockedForIncrementation = true;
        }

        #endregion
    }
}
