using com.etsoo.ApiModel.RQ.Bridge;
using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Defs;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// Bridge service proxy
    /// 桥接服务代理
    /// </summary>
    public class BridgeProxy : IBridgeProxy
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        public BridgeProxy(HttpClient httpClient, ILogger logger, BridgeOptions options)
        {
            Setup(httpClient, options);

            _httpClient = httpClient;
            _logger = logger;
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        public BridgeProxy(HttpClient httpClient, ILogger<BridgeProxy> logger, IOptions<BridgeOptions> options)
            : this(httpClient, logger, options.Value)
        {
        }

        private void Setup(HttpClient client, BridgeOptions options)
        {
            var domain = options.BaseAddress;

            if (string.IsNullOrEmpty(domain)) domain = "hk";
            if (domain.Length < 6) domain = $"https://{domain}api.etsoo.com/api/";

            client.BaseAddress = new Uri(domain);
        }

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Translated text</returns>
        public async Task<string> TranslateTextAsync(TranslateTextRQ rq)
        {
            var response = await _httpClient.PostAsJsonAsync("Google/TranslateText", rq);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}