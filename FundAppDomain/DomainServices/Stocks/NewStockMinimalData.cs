using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FundAppDomain.DomainServices.Stocks
{
    public class NewStockMinimalData
    {
        #region Types

        public delegate NewStockMinimalData Factory(uint quantity, decimal price); 

        #endregion

        #region Constructors

        public NewStockMinimalData(uint quantity, decimal price)
        {
            Quantity = quantity;
            Price = price;
        }

        #endregion

        #region Properites

        public uint Quantity { private set; get; }

        public decimal Price { private set; get; } 

        
        #endregion
    }
}
