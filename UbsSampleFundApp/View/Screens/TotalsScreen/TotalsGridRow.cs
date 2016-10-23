using FundAppDomain.Model.Totals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbsSampleFundApp.View.Screens.TotalsScreen
{
    public class TotalsGridRow
    {

        #region Private fields

        private StockTotals _stockTotals;

        #endregion

        #region Constructors

        public TotalsGridRow(string scope, StockTotals stockTotals)
        {
            Scope = scope;
            _stockTotals = stockTotals;
        }

        #endregion

        #region Properties

        public string Scope
        {
            private set;
            get;
        }

        public uint Number
        {
            get
            {
                return _stockTotals.TotalNumber;
            }
        }


        public decimal StockWeight
        {
            get
            {
                return _stockTotals.TotalStockWeight;
            }
        }

        public decimal MarketValue
        {
            get
            {
                return _stockTotals.TotalMarketValue;
            }
        } 
        #endregion

    }
}
