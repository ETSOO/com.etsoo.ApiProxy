namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// API service key data
    /// 接口服务键数据
    /// </summary>
    public record ApiServiceKey
    {
        /// <summary>
        /// Api id
        /// 接口编号
        /// </summary>
        public int ApiId { get; init; }

        /// <summary>
        /// Service
        /// 服务
        /// </summary>
        public string? Service { get; init; }

        /// <summary>
        /// Organization id
        /// 所属机构编号
        /// </summary>
        public required int Organization { get; init; }

        /// <summary>
        /// Current user id
        /// 当前用户编号
        /// </summary>
        public required string User { get; init; }

        /// <summary>
        /// Time ticks
        /// 时间刻度
        /// </summary>
        public long Ticks { get; init; } = DateTime.UtcNow.Ticks;
    }
}
