namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// API service key data
    /// 接口服务键数据
    /// </summary>
    public record ApiServiceKey
    {
        /// <summary>
        /// Service
        /// 服务
        /// </summary>
        public string? Service { get; init; }

        /// <summary>
        /// Organization
        /// 所属机构
        /// </summary>
        public required string Organization { get; init; }

        /// <summary>
        /// Current user
        /// 当前用户
        /// </summary>
        public required string User { get; init; }

        /// <summary>
        /// Time ticks
        /// 时间刻度
        /// </summary>
        public long Ticks { get; init; } = DateTime.UtcNow.Ticks;
    }
}
