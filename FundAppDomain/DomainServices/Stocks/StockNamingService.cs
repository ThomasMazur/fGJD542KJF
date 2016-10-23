using FundAppDomain.Model.AbstractStocks;
using FundAppDomain.Repositories;
using System.Linq;
using System.Text.RegularExpressions;

namespace FundAppDomain.DomainServices.Stocks
{
    public class StockNamingService
    {
        #region Private fields

        private readonly IStockEntityRepository _stockRepository;
        private readonly Regex _regex = new Regex(@"\d+$");

        #endregion


        #region Constructors

        public StockNamingService(IStockEntityRepository stockRepository)
        {
            _stockRepository = stockRepository;
        }

        #endregion

        #region Public methods

        public string NextNamedBasedIdentity<T>() where T : StockEntity
        {
            var nextLocalIndex = _stockRepository.FindAll()
                .Where(e => e is T)
                .Select(e => uint.Parse(_regex.Match(e.Name).Value))
                .DefaultIfEmpty().Max() + 1;

            return $"{typeof(T).Name}{nextLocalIndex}" ;
        } 

        #endregion
    }
}
