namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Address state data
    /// 省州地址数据
    /// </summary>
    public record AddressStateDto
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Abbreviation
        /// 缩写
        /// </summary>
        public string? Abbr { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public required string Label { get; init; }
    }
}
