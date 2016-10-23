using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.Policies;

namespace FundAppDomain.Model.RealStocks
{
    public sealed class Bond : StockEntity
    {
        #region Constructors

        public Bond(StockTotalsCalculationService stockTotals,
                            StockWarningPolicy stockWarningPolicy,
                            StockMasterData masterData) : base(stockTotals, stockWarningPolicy, masterData)
        { }

        #endregion

        #region Overrides

        protected override decimal TransactionCostRatio
        {
            get
            {
                return 0.02M;
            }
        }

        protected override decimal TransactionCostToleranceValue
        {
            get
            {
                return 100000;
            }
        }

        #endregion
    }
}
