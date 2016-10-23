using FundAppDomain.Model.AbstractStocks;
using FundAppDomainTests.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FundAppDomainTests.Tests
{
    [TestClass]
    public class StockAddingTests
    {
        #region Test methods

        [TestMethod]
        [TestCategory("domainTest")]
        public void StocksCanBeAddedBasedOnPriceAndQuantity()
        {
            InMemoryDomain.DoTest(rootDomainService =>
            {
                rootDomainService.StockEntitiesService.AddEquity(33,44);
                rootDomainService.StockEntitiesService.AddEquity(1, 11);


                var stocks = new List<StockEntity>(rootDomainService.StockEntitiesService.ListStocks());
                var firstStock = stocks[0];
                var secondStock = stocks[1];


                Assert.AreEqual(33U, firstStock.Quantity);
                Assert.AreEqual(44M, firstStock.Price);

                Assert.AreEqual(1U, secondStock.Quantity);
                Assert.AreEqual(11M, secondStock.Price);

            });

        }

        #endregion
    }
}
