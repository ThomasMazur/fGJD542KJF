using FundAppDomain.Model.RealStocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace FundAppDomain.DomainServices.Stocks
{
    public class WellKnownRealStocks
    {
        #region Private fields

        private readonly IReadOnlyDictionary<string, Type> _types = new ReadOnlyDictionary<string, Type>(new Dictionary<string, Type>() {
            { "Bond", typeof(Bond) },
            { "Equity", typeof(Equity) } });

        #endregion

        #region Properties

        public IReadOnlyDictionary<string, Type> Types
        {
            get
            {
                return _types;
            }
        }

        #endregion
    };
}

