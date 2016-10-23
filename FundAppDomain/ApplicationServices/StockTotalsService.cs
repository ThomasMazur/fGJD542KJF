using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model.Totals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAppDomain.ApplicationServices
{
    public class StockTotalsService
    {
        #region Private fields

        private readonly StockTotalsCalculationService _stockTotalsCalculator;

        #endregion


        #region Constructors

        public StockTotalsService(StockTotalsCalculationService stockTotalsCalculator)
        {
            _stockTotalsCalculator = stockTotalsCalculator;
        }

        #endregion

        #region Public methods

        public Dictionary<Type, StockTotals> GetTototals()
        {
            
            return _stockTotalsCalculator.CalculateAllTotals();
        }

        #endregion
    }
}
