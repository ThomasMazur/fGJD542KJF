using FundAppDomain.ApplicationServices;
using FundAppPersistence.Instrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UbsSampleFundApp.Services
{
    public class GlobalServices
    {
        #region Private fields
        private static RootService DomainRoot { set; get; }
        #endregion

        #region Initializers

        public static void Initialize()
        {
            DomainRoot = new RootService(new InMemoryStockRepository());
        }

        #endregion

        #region Public methods

        // do job if all has been initialized correct
        public static void DoDomainRootJob(Action<RootService> job)
        {
            if (DomainRoot != null)
            {
                job(DomainRoot);
            }
        } 
        #endregion


    }

}
