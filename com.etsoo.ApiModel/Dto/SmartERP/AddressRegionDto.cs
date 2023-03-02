namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Address region data
    /// 国家或地区数据
    /// </summary>
    public record AddressRegionDto
    {
        /// <summary>
        /// Id, like CN for China
        /// 国家编号
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Number id, like 156 for China
        /// 数字编号
        /// </summary>
        public required string Nid { get; init; }

        /// <summary>
        /// Continent id
        /// 洲编号
        /// </summary>
        public required string ContinentId { get; init; }

        /// <summary>
        /// Phone exit code for international dial, like 00 in China
        /// 国际拨号的电话退出代码
        /// </summary>
        public required string ExitCode { get; init; }

        /// <summary>
        /// National (truck) prefix
        /// 国内呼叫的拨号
        /// </summary>
        public string? NationalPrefix { get; init; }

        /// <summary>
        /// Area code for international dial, like 86 for China
        /// 国际电话区号
        /// </summary>
        public required string Idd { get; init; }

        /// <summary>
        /// Currency, like CNY for China's currency
        /// 币种
        /// </summary>
        public required string Currency { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public required string Label { get; init; }

        /// <summary>
        /// Pinyin or other query assistant data
        /// 拼音或其他辅助查询字符串
        /// </summary>
        public string? Py { get; init; }
    }
}
