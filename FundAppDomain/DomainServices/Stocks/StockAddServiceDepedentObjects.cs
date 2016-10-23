using FundAppDomain.DomainServices;
using FundAppDomain.Model;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.RealStocks;
using FundAppDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAppDomain.DomainServices.Stocks
{
    public class StockAddServiceDepedentObjects
    {
        #region Constructors

        public StockAddServiceDepedentObjects(IStockEntityRepository stockRepository,
                            StockNamingService namingService,
                            Func<StockMasterData, Bond> bondStockFactory,
                            Func<StockMasterData, Equity> equityStockFactory)
        {
            if (stockRepository == null)
                throw new ArgumentNullException(nameof(stockRepository));

            if (namingService == null)
                throw new ArgumentNullException(nameof(namingService));

            if (bondStockFactory == null)
                throw new ArgumentNullException(nameof(bondStockFactory));

            if (equityStockFactory == null)
                throw new ArgumentNullException(nameof(equityStockFactory));

            StockRepository = stockRepository;
            NamingService = namingService;
            BondStockFactory = bondStockFactory;
            EquityStockFactory = equityStockFactory;
        }

        #endregion

        #region Properties

        public IStockEntityRepository StockRepository { private set; get; }

        public StockNamingService NamingService { private set; get; }
        

        public Func<StockMasterData, Bond> BondStockFactory { private set; get; }

        public Func<StockMasterData, Equity> EquityStockFactory { private set; get; }

        public Dictionary<Type, Func<StockMasterData, StockEntity>> StockFactory { private set; get; }


        #endregion
    }
}
