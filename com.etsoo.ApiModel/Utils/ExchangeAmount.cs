using com.etsoo.ApiModel.Dto.SmartERP;

namespace com.etsoo.ApiModel.Utils
{
    /// <summary>
    /// Exchange amount
    /// 外币兑换金额
    /// </summary>
    public class ExchangeAmount
    {
        readonly IEnumerable<CurrencyDto> currencies;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="currencies">Currencies</param>
        public ExchangeAmount(IEnumerable<CurrencyDto> currencies)
        {
            this.currencies = currencies;
        }

        /// <summary>
        /// Calculate
        /// 计算
        /// </summary>
        /// <param name="amount">Amount</param>
        /// <param name="sourceCurrency">Source currency</param>
        /// <param name="targetCurrency">Target currency</param>
        /// <returns>Result</returns>
        public decimal? Calc(decimal amount, string sourceCurrency, string? targetCurrency = null)
        {
            var sc = currencies.FirstOrDefault(c => c.Id.Equals(sourceCurrency));
            var tc = string.IsNullOrEmpty(targetCurrency) ? currencies.FirstOrDefault(c => c.ExchangeRate == 100) : currencies.FirstOrDefault(c => c.Id.Equals(targetCurrency));
            if (sc == null || tc == null) return null;

            return Math.Round(
                (1000 * amount * sc.ExchangeRate) /
                    tc.ExchangeRate
            ) / 1000;
        }
    }
}
