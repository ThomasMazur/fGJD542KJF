using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UbsSampleFundApp.Services;
using UbsSampleFundApp.View.Utilities;

namespace UbsSampleFundApp.View.Windows.NewStock
{
    public class NewStockViewModel : ViewModelBase
    {
        #region Constructors

        public NewStockViewModel(NewStockWindow window, Action<uint, decimal> addNewStock)
        {
            AddStockCommand = new RelayCommand(_ =>
            {

                addNewStock(uint.Parse(Quantity), decimal.Parse(Price));
                window.Close();
            }, _ =>
            {

                uint quantityAsNumber;
                decimal priceAsNumber;
                return uint.TryParse(Quantity, out quantityAsNumber) && decimal.TryParse(Price, out priceAsNumber);
            });

            CloseCommand = new RelayCommand(_ => window.Close());
        }

        #endregion

        #region Properties

        public ICommand AddStockCommand { set; get; }

        public ICommand CloseCommand { set; get; }

        private string _Quantity;
        public string Quantity
        {
            set
            {
                _Quantity = value;
                NotifyPropertyChanged(nameof(Quantity));
            }

            get
            {
                return _Quantity;
            }
        }

        private string _Price;
        public string Price
        {
            set
            {
                _Price = value;
                NotifyPropertyChanged(nameof(Price));
            }

            get
            {
                return _Price;
            }
        }

        #endregion

    }
}
