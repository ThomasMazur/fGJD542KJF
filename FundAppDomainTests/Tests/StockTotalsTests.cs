using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Model.RealStocks;
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
    public class StockTotalsTests
    {
        #region Test methods

        [TestMethod]
        [TestCategory("domainTest")]
        public void StockTotalNumbersAreCalculatedCorrectly()
        {
            InMemoryDomain.DoTest(rootDomainService =>
            {
                rootDomainService.StockEntitiesService.AddEquity(1, 3);
                rootDomainService.StockEntitiesService.AddEquity(1, 3);

                var totals = rootDomainService.StockTotalsService.GetTototals();


                var totalsAll = totals[typeof(StockEntity)];
                var totalsBond = totals[typeof(Bond)];
                var totalsEquity = totals[typeof(Equity)];
                Assert.AreEqual(2U, totalsAll.TotalNumber);
                Assert.AreEqual(2U, totalsEquity.TotalNumber);
                Assert.AreEqual(0U, totalsBond.TotalNumber);
            });

        }

        #endregion
    }
}
