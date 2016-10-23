using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model.Policies;
using FundAppDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAppDomain.Model.AbstractStocks
{
    public abstract class StockEntity
    {
        #region Private fields

        private readonly StockTotalsCalculationService _stockTotals;
        private readonly StockWarningPolicy _stockWarningPolicy;
        private readonly StockMasterData _masterData;

        #endregion

        #region Constructors

        public StockEntity(StockTotalsCalculationService stockTotals,
                           StockWarningPolicy stockWarningPolicy,
                           StockMasterData masterData)
        {

            if (stockTotals == null)
                throw new ArgumentNullException(nameof(stockTotals));

            if (stockWarningPolicy == null)
                throw new ArgumentNullException(nameof(stockWarningPolicy));

            if (masterData == null)
                throw new ArgumentNullException(nameof(masterData));

            _stockTotals = stockTotals;
            _stockWarningPolicy = stockWarningPolicy;
            _masterData = masterData;
        }

        #endregion

        #region Properties

        public string Name
        {
            get
            {
                return _masterData.Name;
            }
        }

        public decimal Price
        {

            get
            {
                return _masterData.Price;
            }
        }

        public uint Quantity
        {
            get
            {
                return _masterData.Quantity;
            }
        }

        public decimal MarketValue
        {

            get
            {
                return Price * Quantity;
            }

        }

        public decimal StockWeight
        {
            get
            {
                var totalMarketValue = _stockTotals.TotalMarketValue(GetType());
                if (totalMarketValue == 0)
                    return 0;

                return MarketValue / totalMarketValue;
            }
        }

        public decimal TransactionCostTolerance
        {
            get
            {
                return TransactionCostToleranceValue;
            }
        }


        public decimal TransactionCost
        {
            get
            {
                return TransactionCostRatio * MarketValue;
            }
        }

        public bool IsWarning
        {
            get
            {
                return _stockWarningPolicy.IsWarning(this);
            }
        }
        
        #endregion

        #region Protected

        protected abstract decimal TransactionCostRatio
        {
            get;
        }


        protected abstract decimal TransactionCostToleranceValue
        {
            get;
        }

        #endregion
    }
}
