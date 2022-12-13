using com.etsoo.ApiModel.RQ.Google;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy
{
    /// <summary>
    /// Google service proxy
    /// 谷歌服务代理
    /// </summary>
    public class GoogleProxy
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        public GoogleProxy(HttpClient httpClient, ILogger<GoogleProxy> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
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