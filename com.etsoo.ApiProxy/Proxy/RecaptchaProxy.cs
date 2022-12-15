using com.etsoo.ApiModel.Dto.Recaptcha;
using com.etsoo.ApiModel.RQ.Recaptcha;
using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Defs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// reCaptcha API proxy
    /// https://developers.google.com/recaptcha/docs/v3
    /// </summary>
    public class RecaptchaProxy : IRecaptchaProxy
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly string secret;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        public RecaptchaProxy(HttpClient httpClient, ILogger<RecaptchaProxy> logger, IOptions<RecaptchaOptions> options)
        {
            secret = options.Value.Secret;
            Setup(httpClient, options.Value);

            _httpClient = httpClient;
            _logger = logger;
        }

        public static void Setup(HttpClient client, RecaptchaOptions options)
        {
            var domain = options.BaseAddress;
            if (string.IsNullOrEmpty(domain) || domain == "G") domain = "www.google.com";
            else if (domain == "R") domain = "www.recaptcha.net";

            client.BaseAddress = new Uri($"https://{domain}/recaptcha/api/");
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
                [nameof(secret)] = secret,
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
