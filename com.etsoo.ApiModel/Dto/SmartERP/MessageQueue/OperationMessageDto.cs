namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// Operation message respone
    /// 操作信息响应
    /// </summary>
    public record OperationMessageResponse
    {
        /// <summary>
        /// App id
        /// 程序编号
        /// </summary>
        public required string AppId { get; init; }

        /// <summary>
        /// User id
        /// 用户编号
        /// </summary>
        public required int UserId { get; init; }

        /// <summary>
        /// Target object id
        /// 目标对象编号
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Operation type
        /// 操作类型
        /// </summary>
        public required string OperationType { get; init; }
    }

    /// <summary>
    /// Operation message data
    /// 操作信息数据
    /// </summary>
    public record OperationMessageDto : OperationMessageResponse
    {
        /// <summary>
        /// Organization id
        /// 机构编号
        /// </summary>
        public required int OrganizationId { get; init; }
    }
}
