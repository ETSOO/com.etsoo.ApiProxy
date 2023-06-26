namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// API service enum
    /// 接口服务枚举
    /// </summary>
    public enum ApiService : int
    {
        /// <summary>
        /// SMTP
        /// 邮件发送
        /// </summary>
        SMTP = 1,

        /// <summary>
        /// SMTP delegation
        /// 邮件发送代理
        /// </summary>
        SMTPDelegation = 2,

        /// <summary>
        /// SMS
        /// 短信发送
        /// </summary>
        SMS = 3,

        /// <summary>
        /// Wechat service account
        /// 微信服务号
        /// </summary>
        Wechat = 4,

        /// <summary>
        /// Business Wechat
        /// 企业微信
        /// </summary>
        WechatBusiness = 5
    }
}
