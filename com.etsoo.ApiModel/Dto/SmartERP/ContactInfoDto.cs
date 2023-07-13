namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Contact info data
    /// 联系信息数据
    /// </summary>
    public record ContactInfoDto
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// Name
        /// 姓名
        /// </summary>
        public required string? Name { get; init; }

        /// <summary>
        /// Item
        /// 项目
        /// </summary>
        public required string Item { get; init; }
    }
}
