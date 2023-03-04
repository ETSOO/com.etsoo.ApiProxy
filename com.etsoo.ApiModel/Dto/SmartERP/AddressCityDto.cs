namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Address city data
    /// 城市地址数据
    /// </summary>
    public record AddressCityDto
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// Num Id
        /// 数字编号
        /// </summary>
        public string? Num { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public required string Label { get; init; }
    }
}
