namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// Send email data
    /// 发送邮件信息
    /// </summary>
    public record SendEmailDto
    {
        /// <summary>
        /// Subject
        /// 主题
        /// </summary>
        public required string Subject { get; init; }

        /// <summary>
        /// Body
        /// 主体
        /// </summary>
        public required string Body { get; init; }

        /// <summary>
        /// User Recipients
        /// 用户收件人
        /// </summary>
        public IEnumerable<int>? Users { get; init; }

        /// <summary>
        /// User reply to address, may email address or GUID or INT user id
        /// 回复用户，可以是邮箱地址，用户全局编号(GUID or INT)
        /// </summary>
        public string? ReplyTo { get; init; }

        /// <summary>
        /// To recipients
        /// 收件人
        /// </summary>
        public IEnumerable<string>? To { get; init; }

        /// <summary>
        /// Delivery time
        /// 发送时间
        /// </summary>
        public DateTime? DeliveryTime { get; init; }

        /// <summary>
        /// Priority
        /// 优先级
        /// </summary>
        public MessagePriority? Priority { get; init; }
    }
}
