using FundAppDomain.Model.AbstractStocks;
using System.Windows.Media;

namespace UbsSampleFundApp.View.Screens.GridScreen
{
    public class StockGridRow
    {
        #region Private fields

        private readonly StockEntity _stockEntity;

        #endregion

        #region Constructors

        public StockGridRow(StockEntity stockEntity)
        {
            _stockEntity = stockEntity;
        }

        #endregion

        #region Properties

        public string Type
        {
            get
            {
                return _stockEntity.GetType().Name;
            }
        }

        public string Name
        {
            get
            {
                return _stockEntity.Name;
            }
        }

        public decimal Price
        {
            get
            {
                return _stockEntity.Price;
            }
        }

        public decimal Quantity
        {
            get
            {
                return _stockEntity.Quantity;
            }
        }

        public decimal StockWeight
        {
            get
            {
                return _stockEntity.StockWeight;
            }
        }

        public decimal MarketValue
        {
            get
            {
                return _stockEntity.MarketValue;
            }
        }

        public decimal TransactionCost
        {
            get
            {
                return _stockEntity.TransactionCost;
            }
        }

        public Brush RowBackground
        {
            get
            {
                if(_stockEntity.IsWarning)
                    return new SolidColorBrush(Color.FromRgb(255, 0, 0));

                return null;
            }
        }

        #endregion
    }
}
