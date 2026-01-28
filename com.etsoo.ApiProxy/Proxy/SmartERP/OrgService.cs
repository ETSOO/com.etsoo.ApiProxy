using com.etsoo.ApiModel;
using com.etsoo.ApiModel.Dto.SmartERP.MessageQueue;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.Utils.Actions;
using com.etsoo.Utils.Serialization;
using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;
using static Google.Cloud.Iam.V1.AuditConfigDelta.Types;
using static Google.Rpc.Context.AttributeContext.Types;

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

        /// <summary>
        /// Upload files
        /// 上传文件
        /// </summary>
        /// <param name="auth">Token authorization</param>
        /// <param name="files">Files to upload</param>
        /// <param name="id">Identifier</param>
        /// <param name="folder">Folder name</param>
        /// <param name="sign">Signature</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IActionResult?> UploadFilesAsync(TokenAuthRQ auth, IFormFileCollection files, long id, string folder, string sign, CancellationToken cancellationToken = default)
        {
            var form = new MultipartFormDataContent
            {
                { new StringContent(sign), nameof(sign) }
            };

            foreach (var file in files)
            {
                var streamContent = new StreamContent(file.OpenReadStream());
                if(file.Headers != null)
                {
                    foreach (var header in file.Headers)
                    {
                        streamContent.Headers.TryAddWithoutValidation(header.Key, [.. header.Value]);
                    }
                }

                form.Add(streamContent, nameof(file), file.FileName);
            }

            var request = new HttpRequestMessage(HttpMethod.Post, $"Org/UploadFiles/{folder}/{id}")
            {
                Content = form,
                Headers = {
                    Authorization = auth.AddAuthorization()
                }
            };

            var response = await _httpClient.SendAsync(request, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(CommonJsonSerializerContext.Default.ActionResult, cancellationToken);
        }
    }
}