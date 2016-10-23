
using FundAppDomain.Model;
using FundAppDomain.Model.AbstractStocks;
using System;

namespace FundAppDomain.DomainServices.Stocks
{
    public class StockAddService
    {
        #region Public events

        public event EventHandler<EventArgs> OnStockAdded;

        #endregion

        #region Private fields

        private readonly StockAddServiceDepedentObjects _depedentObjects;


        #endregion

        #region Constructors

        public StockAddService(StockAddServiceDepedentObjects depedentObjects)
        {
            if (depedentObjects == null)
                throw new ArgumentNullException(nameof(depedentObjects));

            _depedentObjects = depedentObjects;
        }

        #endregion

        #region Public methods

        public void AddNewBond(NewStockMinimalData stockMinimalData)
        {
            AddNewStock(_depedentObjects.BondStockFactory, stockMinimalData);
        }

        public void AddNewEquity(NewStockMinimalData stockMinimalData)
        {
            AddNewStock(_depedentObjects.EquityStockFactory, stockMinimalData);
        }

        #endregion

        #region Private methods


        public void AddNewStock<T>(Func<StockMasterData, T> factory, NewStockMinimalData stockMinimalData) where T : StockEntity
        {
            var stockMasterData = new StockMasterData(_depedentObjects.NamingService.NextNamedBasedIdentity<T>(), stockMinimalData);
            var stockEntity = factory(stockMasterData);

            _depedentObjects.StockRepository.Add(stockEntity);

            OnStockAdded?.Invoke(this, new EventArgs());
        }
        
        #endregion
    }
}
