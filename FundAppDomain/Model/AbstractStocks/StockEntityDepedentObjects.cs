using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model.Policies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAppDomain.Model.AbstractStocks
{
    public class StockEntityDepedentObjects
    {
        public delegate StockEntityDepedentObjects Factory(StockMasterData masterData);

        #region Constructors

        public StockEntityDepedentObjects(StockTotalsCalculationService stockTotals,
                                            StockWarningPolicy stockWarningPolicy,
                                            StockMasterData masterData)
        {
            if (stockTotals == null)
                throw new ArgumentNullException(nameof(stockTotals));

            if (masterData == null)
                throw new ArgumentNullException(nameof(masterData));

            if (stockWarningPolicy == null)
                throw new ArgumentNullException(nameof(stockWarningPolicy));

            Totals = stockTotals;
            StockMasterData = masterData;
            WarningPolicy = stockWarningPolicy;
        }

        #endregion

        #region Properties

        public StockTotalsCalculationService Totals
        {
            private set;

            get;
        }

        public StockMasterData StockMasterData
        {
            private set;

            get;
        }

        public StockWarningPolicy WarningPolicy
        {
            private set;
            get;
        }

        #endregion
    }
}
