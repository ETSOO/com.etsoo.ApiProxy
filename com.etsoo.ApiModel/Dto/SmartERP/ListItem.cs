namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// List item with label
    /// 带标签的列表项
    /// </summary>
    public record ListItem
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public required string Label { get; init; }
    }

    /// <summary>
    /// List item with string id and label
    /// 带文本编号和标签的列表项
    /// </summary>
    public record ListItem1
    {
        /// <summary>
        /// Id
        /// 编号
        /// </summary>
        public required string Id { get; init; }

        /// <summary>
        /// Label
        /// 标签
        /// </summary>
        public required string Label { get; init; }
    }
}
