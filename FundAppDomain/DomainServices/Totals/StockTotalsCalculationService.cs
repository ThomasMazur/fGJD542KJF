using FundAppDomain.DomainServices.Stocks;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.Totals;
using FundAppDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FundAppDomain.DomainServices.Totals
{
    public class StockTotalsCalculationService
    {
        #region Privete fields

        private readonly IStockEntityRepository _stockEntityRepository;
        private readonly Func<StockTotals> _stockTotalsFactory;
        private readonly WellKnownRealStocks _wellKnownRealStocks;

        #endregion

        #region Constructors

        public StockTotalsCalculationService(IStockEntityRepository stockEntityRepository,
                                             Func<StockTotals> stockTotalsFactory,
                                             WellKnownRealStocks wellKnownRealStocks)
        {
            if (stockEntityRepository == null)
                throw new ArgumentNullException(nameof(stockEntityRepository));

            if (stockTotalsFactory == null)
                throw new ArgumentNullException(nameof(stockTotalsFactory));

            if (wellKnownRealStocks == null)
                throw new ArgumentNullException(nameof(wellKnownRealStocks));

            _stockEntityRepository = stockEntityRepository;
            _stockTotalsFactory = stockTotalsFactory;
            _wellKnownRealStocks = wellKnownRealStocks;
        }

        #endregion

        #region Public methods

        public decimal TotalMarketValue(Type stockType)
        {

            if (stockType == null)
                throw new ArgumentNullException(nameof(stockType));

            var marketValueTotal = _stockEntityRepository
                                        .FindAll()
                                        .Where(e => e.GetType() == stockType)
                                        .Select(e => e.MarketValue)
                                        .DefaultIfEmpty().Sum();

            return marketValueTotal;
        }


        public Dictionary<Type, StockTotals> CalculateAllTotals()
        {
            var typeTotals = new Dictionary<Type, StockTotals>();

            foreach (var wellKnownType in _wellKnownRealStocks.Types)
            {
                typeTotals[wellKnownType.Value] = _stockTotalsFactory();
            }


            var allTotals = _stockTotalsFactory();

            foreach (var entity in _stockEntityRepository.FindAll())
            {
                allTotals.Increment(entity);
                typeTotals[entity.GetType()].Increment(entity);
            }

            typeTotals[typeof(StockEntity)] = allTotals;

            foreach (var totals in typeTotals)
            {
                totals.Value.Lock();
            }

            return typeTotals;
        }

        #endregion
    }
}
