using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UbsSampleFundApp.Services;
using UbsSampleFundApp.View.Utilities;

namespace UbsSampleFundApp.View.Screens.MenuScreen
{
    public class ManuScreenViewModel
    {
        #region Constructors

        public ManuScreenViewModel()
        {
            AddNewBondStock = new RelayCommand(_ => {


                GlobalServices.DoDomainRootJob(domainRoot =>
                {
                    var newStockWindow = new NewStockWindow(domainRoot.StockEntitiesService.AddBond);
                    newStockWindow.ShowDialog();
                });
            });

            AddNewEquityStock = new RelayCommand(_ => {

                GlobalServices.DoDomainRootJob(domainRoot =>
                {
                    var newStockWindow = new NewStockWindow(domainRoot.StockEntitiesService.AddEquity);
                    newStockWindow.ShowDialog();
                });
            });
        }

        #endregion

        #region Properties

        public ICommand AddNewBondStock { set; get; }

        public ICommand AddNewEquityStock { set; get; } 

        #endregion
    }
}
