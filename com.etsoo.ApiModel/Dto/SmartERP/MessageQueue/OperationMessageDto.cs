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
        /// Global user id
        /// 全局用户编号
        /// </summary>
        public required int UserId { get; init; }

        /// <summary>
        /// Current device id, set 0 when not existing
        /// 当前设备编号，不存在可设置为0
        /// </summary>
        public required int DeviceId { get; init; }

        /// <summary>
        /// Target object id
        /// 目标对象编号
        /// </summary>
        public long? Id { get; init; }

        /// <summary>
        /// Related fields to pass more data
        /// 相关字段，便于传递更多数据
        /// </summary>
        public IEnumerable<object>? Fields { get; set; }

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
