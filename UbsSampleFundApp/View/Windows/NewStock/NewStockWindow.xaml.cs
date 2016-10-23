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
using UbsSampleFundApp.View.Windows.NewStock;

namespace UbsSampleFundApp.View
{
    /// <summary>
    /// Interaction logic for NewStockWindow.xaml
    /// </summary>
    public partial class NewStockWindow : Window
    {
        #region Constructors

        public NewStockWindow(Action<uint, decimal> addNewStock)
        {
            InitializeComponent();
            DataContext = new NewStockViewModel(this, addNewStock);
        }

        public NewStockWindow()
        {
            InitializeComponent();
        }

        #endregion
    }
}
