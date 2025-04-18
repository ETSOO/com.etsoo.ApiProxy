using com.etsoo.ApiModel.Dto.SmartERP.MessageQueue;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.Utils.Actions;

namespace com.etsoo.ApiProxy.Defs.SmartERP
{
    /// <summary>
    /// Organization service interface
    /// 机构服务接口
    /// </summary>
    public interface IOrgService
    {
        /// <summary>
        /// Format HTML content
        /// 格式化网页内容
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="content">HTML content</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Result</returns>
        Task<string> FormatHtmlContentAsync(TokenAuthRQ auth, string content, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send email
        /// 发送邮件
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="message">Email message</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<ActionResult<StringIdData>?> SendEmailAsync(TokenAuthRQ auth, SendEmailMessage message, CancellationToken cancellationToken = default);

        /// <summary>
        /// Send SMS
        /// 发送短信
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="message">SMS message</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<ActionResult<StringIdData>?> SendSMSAsync(TokenAuthRQ auth, SendSMSMessage message, CancellationToken cancellationToken = default);
    }
}
