using FundAppDomain.DomainServices.Stocks;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppDomain.ApplicationServices
{
    public class StockEntitesService
    {
        #region Public events

        public event EventHandler<EventArgs> OnStockAdded
        {
            add
            {
                _stockAddService.OnStockAdded += value;
            }

            remove
            {
                _stockAddService.OnStockAdded -= value;
            }
        }

        #endregion

        #region Private fields

        private readonly StockAddService _stockAddService;
        private readonly NewStockMinimalData.Factory _newStockMinimalDataFactory;
        private readonly IStockEntityRepository _stockEntityRepository;

        #endregion


        #region Constructors

        public StockEntitesService(StockAddService stockAddService,
            NewStockMinimalData.Factory newStockMinimalDataFactory,
            IStockEntityRepository stockEntityRepository
            )
        {
            _stockAddService = stockAddService;
            _newStockMinimalDataFactory = newStockMinimalDataFactory;
            _stockEntityRepository = stockEntityRepository;
        }

        #endregion

        #region Public methods

        public void AddBond(uint quantity, decimal price)
        {
            _stockAddService.AddNewBond(_newStockMinimalDataFactory(quantity, price));
        }

        public void AddEquity(uint quantity, decimal price)
        {
            _stockAddService.AddNewEquity(_newStockMinimalDataFactory(quantity, price));
        }


        public IEnumerable<StockEntity> ListStocks()
        {
            return _stockEntityRepository.FindAll();
        }

        #endregion
    }
}
