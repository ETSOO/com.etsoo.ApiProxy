namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// Send email data
    /// 发送邮件信息
    /// </summary>
    public record SendEmailDto
    {
        /// <summary>
        /// Message Type
        /// 消息类型
        /// </summary>
        public const string MessageType = "SMARTERP-SENDEMAIL";

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
        /// Recipients
        /// 收件人
        /// </summary>
        public required IEnumerable<int> Users { get; init; }

        /// <summary>
        /// Delivery time
        /// 发送时间
        /// </summary>
        public DateTime? DeliveryTime { get; init; }
    }
}
