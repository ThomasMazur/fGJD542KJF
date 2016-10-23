using FundAppDomain.Model.AbstractStocks;

namespace FundAppDomain.Model.Policies
{
    public class StockWarningPolicy
    {
        #region Public methods

        public bool IsWarning(StockEntity stockEntity)
        {
            return stockEntity.MarketValue < 0 || stockEntity.TransactionCost > stockEntity.TransactionCostTolerance;
        }

        #endregion
    }
}
