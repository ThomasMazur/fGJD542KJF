using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbsSampleFundApp.View.Utilities
{
    public class ViewModelBase :  INotifyPropertyChanged
    {
        #region Public events

        public event PropertyChangedEventHandler PropertyChanged; 

        #endregion

        #region Proptected methods

        protected void NotifyPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        } 

        #endregion
    }
}
