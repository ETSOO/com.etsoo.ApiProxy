namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Address state data
    /// 省州地址数据
    /// </summary>
    public class AddressStateDto
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public string Id { get; init; } = default!;

        /// <summary>
        /// Abbreviation
        /// 缩写
        /// </summary>
        public string? Abbr { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public string Label { get; init; } = default!;
    }
}
