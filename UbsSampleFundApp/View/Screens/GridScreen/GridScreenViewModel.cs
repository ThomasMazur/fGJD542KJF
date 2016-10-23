using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.RealStocks;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UbsSampleFundApp.Services;

namespace UbsSampleFundApp.View.Screens.GridScreen
{
    public class GridScreenViewModel
    {
        #region Constructors

        public GridScreenViewModel()
        {
            Rows = new ObservableCollection<StockGridRow>();


            ReloadGrid();

            GlobalServices.DoDomainRootJob(domainRoot =>
            {
                domainRoot.StockEntitiesService.OnStockAdded += (s, e) => ReloadGrid();
            }
            );

        }


        #endregion

        #region Properties

        public ObservableCollection<StockGridRow> Rows { set; get; }

        #endregion

        #region Private methods

        private void ReloadGrid()
        {
            GlobalServices.DoDomainRootJob(domainRoot =>
            {

                Rows.Clear();

                foreach (var stock in domainRoot.StockEntitiesService.ListStocks())
                {
                    Rows.Add(new StockGridRow(stock));
                }

            });
        }

        #endregion
    }
}
