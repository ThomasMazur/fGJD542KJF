using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.Policies;

namespace FundAppDomain.Model.RealStocks
{
    public sealed class Equity : StockEntity
    {
        #region Constructors

        public Equity(StockTotalsCalculationService stockTotals,
                      StockWarningPolicy stockWarningPolicy,
                      StockMasterData masterData) : base(stockTotals, stockWarningPolicy, masterData)
        { }

        #endregion

        #region Overrides

        protected override decimal TransactionCostRatio
        {
            get
            {
                return 0.005M;
            }
        }


        protected override decimal TransactionCostToleranceValue
        {
            get
            {
                return 200000;
            }
        }

        #endregion
    }
}
