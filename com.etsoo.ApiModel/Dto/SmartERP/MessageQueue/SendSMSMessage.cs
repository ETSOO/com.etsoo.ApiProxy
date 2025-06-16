using com.etsoo.Utils.Serialization;

namespace com.etsoo.ApiModel.Dto.SmartERP.MessageQueue
{
    /// <summary>
    /// Send SMS message
    /// 发送短信消息
    /// </summary>
    public record SendSMSMessage : IMessageQueueMessage
    {
        /// <summary>
        /// Kind code
        /// 验证码类型
        /// </summary>
        public const string KindCode = "Code";

        public static string Type => "SendSMS";

        /// <summary>
        /// Kind
        /// 类型
        /// </summary>
        public required string Kind { get; init; }

        /// <summary>
        /// Culture
        /// 文化
        /// </summary>
        public required string Culture { get; init; }

        /// <summary>
        /// Region
        /// 地区
        /// </summary>
        public required string Region { get; init; }

        /// <summary>
        /// Mobiles
        /// 移动号码
        /// </summary>
        public required IEnumerable<string> To { get; init; }

        /// <summary>
        /// Template id
        /// 模板编号
        /// </summary>
        public string? TemplateId { get; init; }

        /// <summary>
        /// Body
        /// 内容
        /// </summary>
        public required string Body { get; init; }

        /// <summary>
        /// Organization ID
        /// 机构编号
        /// </summary>
        public int? OrgId { get; init; }
    }
}
