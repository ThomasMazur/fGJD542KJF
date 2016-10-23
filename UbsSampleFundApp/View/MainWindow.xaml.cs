using FundAppDomain.ApplicationServices;
using FundAppPersistence.Instrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using UbsSampleFundApp.Services;

namespace UbsSampleFundApp.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            GlobalServices.Initialize();

            // add some demo data
            GlobalServices.DoDomainRootJob(domainRoot => domainRoot.StockEntitiesService.AddBond(3, 44));
            GlobalServices.DoDomainRootJob(domainRoot => domainRoot.StockEntitiesService.AddBond(3, 44));
            GlobalServices.DoDomainRootJob(domainRoot => domainRoot.StockEntitiesService.AddEquity(9999, 999999));

            InitializeComponent();
        } 

        #endregion
    }
}
