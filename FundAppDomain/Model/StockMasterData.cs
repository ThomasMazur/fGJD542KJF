using FundAppDomain.DomainServices.Stocks;
using System;

namespace FundAppDomain.Model
{
    public class StockMasterData
    {
        #region Types
        
        public delegate StockMasterData Factory(string name, NewStockMinimalData minimalData); 

        #endregion

        #region Constructors

        public StockMasterData(string name, decimal price, uint quantity)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            Name = name;
            Price = price;
            Quantity = quantity;
        }

        public StockMasterData(string name, NewStockMinimalData minimalData) : this(name, minimalData.Price, minimalData.Quantity)
        {

        } 

        #endregion


        public string Name { private set; get; }

        public decimal Price { private set; get; }

        public uint Quantity { private set; get; }
    }
}
