using Autofac;
using FundAppDomain.DomainServices.Stocks;
using FundAppDomain.DomainServices.Totals;
using FundAppDomain.Model;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.Policies;
using FundAppDomain.Model.RealStocks;
using FundAppDomain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FundAppDomain.ApplicationServices
{
    public class RootService
    {
        #region Private fields

        private IContainer _container;

        #endregion

        #region Constructors

        public RootService(IStockEntityRepository stockEntityRepository)
        {
            var builder = new ContainerBuilder();

            builder.RegisterInstance(stockEntityRepository).As<IStockEntityRepository>();
            

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Except<RootService>()
                .Except<StockEntitesService>()
                .Except<StockTotalsService>()
                .Except<StockNamingService>()
                .AsSelf()
                .AsImplementedInterfaces();

            builder.RegisterType<StockEntitesService>().AsSelf().SingleInstance();
            builder.RegisterType<StockTotalsService>().AsSelf().SingleInstance();
            builder.RegisterType<StockNamingService>().AsSelf().SingleInstance();

            
            _container = builder.Build();

            
            StockEntitiesService = _container.Resolve<StockEntitesService>();
            StockTotalsService = _container.Resolve<StockTotalsService>();
        }

        #endregion

        #region Properties

        public StockEntitesService StockEntitiesService
        {
            private set;
            get;
        }

        public StockTotalsService StockTotalsService
        {
            private set;
            get;
        }

        #endregion
    }
}
