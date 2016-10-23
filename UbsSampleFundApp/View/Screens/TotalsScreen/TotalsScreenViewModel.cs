using FundAppDomain.Model.AbstractStocks;
using System.Collections.ObjectModel;
using UbsSampleFundApp.Services;

namespace UbsSampleFundApp.View.Screens.TotalsScreen
{
    public class TotalsScreenViewModel
    {
        #region Constructors

        public TotalsScreenViewModel()
        {
            Rows = new ObservableCollection<TotalsGridRow>();

            ReloadGrid();


            GlobalServices.DoDomainRootJob(domainRoot =>
            {
                domainRoot.StockEntitiesService.OnStockAdded += (s, e) =>
                {
                    ReloadGrid();
                };
            });

        }

        #endregion

        #region Properties

        public ObservableCollection<TotalsGridRow> Rows { set; get; }

        #endregion

        #region Private methods


        private void ReloadGrid()
        {
            GlobalServices.DoDomainRootJob(domainRoot =>
            {
                var calculatedStockTotals = domainRoot.StockTotalsService.GetTototals();

                Rows.Clear();
                Rows.Add(new TotalsGridRow("All", calculatedStockTotals[typeof(StockEntity)]));

                foreach (var totals in domainRoot.StockTotalsService.GetTototals())
                {
                    if (totals.Key == typeof(StockEntity))
                        continue;

                    Rows.Add(new TotalsGridRow(totals.Key.Name, totals.Value));
                }
            });
        }


        #endregion
    }
}
