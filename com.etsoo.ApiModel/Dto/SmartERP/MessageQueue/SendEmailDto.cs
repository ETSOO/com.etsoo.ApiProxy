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
        /// User reply to
        /// 回复用户
        /// </summary>
        public int? ReplyTo { get; init; }

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
    }
}
