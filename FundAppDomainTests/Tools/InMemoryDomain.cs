using FundAppDomain.ApplicationServices;
using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Repositories;
using Moq;
using System;
using System.Collections.Generic;

namespace FundAppDomainTests.Tools
{
    internal class InMemoryDomain
    {
        #region Public methods

        public  static void DoTest(Action<RootService> testJob)
        {
            Mock<IStockEntityRepository> repositoryMock = new Mock<IStockEntityRepository>();

            var stocksBackend = new List<StockEntity>();

            repositoryMock.Setup(r => r.FindAll()).Returns(stocksBackend);
            repositoryMock.Setup(r => r.Add(It.IsAny<StockEntity>())).Callback<StockEntity>(s =>
            {
                stocksBackend.Add(s);
            });

            var rootDomainService = new RootService(repositoryMock.Object);

            testJob(rootDomainService);
        } 

        #endregion
    }
}
