namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Address region data
    /// 国家或地区数据
    /// </summary>
    public class AddressRegionDto
    {
        /// <summary>
        /// Id, like CN for China
        /// 国家编号
        /// </summary>
        public string Id { get; init; } = default!;

        /// <summary>
        /// Number id, like 156 for China
        /// 数字编号
        /// </summary>
        public string Nid { get; init; } = default!;

        /// <summary>
        /// Continent id
        /// 洲编号
        /// </summary>
        public string ContinentId { get; init; } = default!;

        /// <summary>
        /// Phone exit code for international dial, like 00 in China
        /// 国际拨号的电话退出代码
        /// </summary>
        public string ExitCode { get; init; } = default!;

        /// <summary>
        /// National (truck) prefix
        /// 国内呼叫的拨号
        /// </summary>
        public string? NationalPrefix { get; init; }

        /// <summary>
        /// Area code for international dial, like 86 for China
        /// 国际电话区号
        /// </summary>
        public string Idd { get; init; } = default!;

        /// <summary>
        /// Currency, like CNY for China's currency
        /// 币种
        /// </summary>
        public string Currency { get; init; } = default!;

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public string Label { get; init; } = default!;

        /// <summary>
        /// Pinyin or other query assistant data
        /// 拼音或其他辅助查询字符串
        /// </summary>
        public string? Py { get; init; }
    }
}
