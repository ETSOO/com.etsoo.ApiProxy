namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Currency data
    /// 币种数据
    /// </summary>
    public class CurrencyDto : ExchangeRateDto
    {
        /// <summary>
        /// Currency id, like CNY, USD
        /// 币种编号，比如 CNY = 人民币, USD = 美元
        /// </summary>
        public string Id { get; init; } = default!;

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public string Label { get; init; } = default!;
    }
}
