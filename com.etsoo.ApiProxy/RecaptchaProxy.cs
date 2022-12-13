using com.etsoo.ApiModel.Dto.Recaptcha;
using com.etsoo.ApiModel.RQ.Recaptcha;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy
{
    /// <summary>
    /// reCaptcha API proxy
    /// https://developers.google.com/recaptcha/docs/v3
    /// </summary>
    public class RecaptchaProxy
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        public RecaptchaProxy(HttpClient httpClient, ILogger<RecaptchaProxy> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Site verification
        /// 站点验证
        /// </summary>
        /// <param name="rq">Rquest data</param>
        /// <returns></returns>
        public async Task<SiteVerifyDto> SiteVerifyAsync(SiteVerifyRQ rq)
        {
            var data = new Dictionary<string, string>
            {
                [nameof(rq.Secret).ToLower()] = rq.Secret,
                [nameof(rq.Response).ToLower()] = rq.Response
            };

            if (!string.IsNullOrEmpty(rq.RemoteIp))
            {
                data[nameof(rq.RemoteIp).ToLower()] = rq.RemoteIp;
            }

            var response = await _httpClient.PostAsync("siteverify", new FormUrlEncodedContent(data));
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<SiteVerifyDto>();
            if (result == null)
            {
                throw new ApplicationException("No Data Returned");
            }

            return result;
        }
    }
}
