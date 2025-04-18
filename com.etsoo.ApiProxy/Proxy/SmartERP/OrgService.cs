using com.etsoo.ApiModel;
using com.etsoo.ApiModel.Dto.SmartERP.MessageQueue;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.Utils.Actions;
using com.etsoo.Utils.Serialization;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy.Proxy.SmartERP
{
    /// <summary>
    /// Organization service
    /// 机构服务
    /// </summary>
    public class OrgService : IOrgService
    {
        private readonly HttpClient _httpClient;

        public OrgService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Format HTML content
        /// 格式化网页内容
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="content">HTML content</param>
        /// <param name="cancellationToken"></param>
        /// <returns>Result</returns>
        public async Task<string> FormatHtmlContentAsync(TokenAuthRQ auth, string content, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "Org/FormatHtmlContent")
            {
                Content = new StringContent(content),
                Headers = {
                    Authorization = auth.AddAuthorization()
                }
            };

            var response = await _httpClient.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadAsStringAsync(cancellationToken);
            if (string.IsNullOrEmpty(result)) result = content;

            return result;
        }

        /// <summary>
        /// Send email
        /// 发送邮件
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="message">Email message</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<ActionResult<StringIdData>?> SendEmailAsync(TokenAuthRQ auth, SendEmailMessage message, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "Org/SendEmail")
            {
                Content = JsonContent.Create(message, ApiModelJsonSerializerContext.Default.SendEmailMessage),
                Headers = {
                    Authorization = auth.AddAuthorization()
                }
            };

            var response = await _httpClient.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(CommonJsonSerializerContext.Default.ActionResultStringIdData, cancellationToken);
        }

        /// <summary>
        /// Send SMS
        /// 发送短信
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="message">SMS message</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<ActionResult<StringIdData>?> SendSMSAsync(TokenAuthRQ auth, SendSMSMessage message, CancellationToken cancellationToken = default)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "Org/SendSMS")
            {
                Content = JsonContent.Create(message, ApiModelJsonSerializerContext.Default.SendSMSMessage),
                Headers = {
                    Authorization = auth.AddAuthorization()
                }
            };

            var response = await _httpClient.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(CommonJsonSerializerContext.Default.ActionResultStringIdData, cancellationToken);
        }
    }
}