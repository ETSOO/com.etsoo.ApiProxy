using com.etsoo.ApiProxy.Defs;
using com.etsoo.Utils.Actions;
using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// Next.js API proxy
    /// Next.js 接口代理
    /// </summary>
    public class NextJsProxy : INextJsProxy
    {
        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        public NextJsProxy(HttpClient httpClient, ILogger<NextJsProxy> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public static void Setup(HttpClient client, string token, string? domain = null)
        {
            if (string.IsNullOrEmpty(domain)) domain = "http://localhost";

            client.BaseAddress = new Uri(domain);
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("NextJsToken", token);
        }

        /// <summary>
        /// Async on demand revalidataion
        /// 异步按需重新验证
        /// </summary>
        /// <param name="urls">Urls to revalidate</param>
        /// <returns>Result</returns>
        public async Task<IActionResult> OnDemandRevalidateAsync(params string[] urls)
        {
            try
            {
                var p = string.Join('&', urls.Select(url => $"url={HttpUtility.UrlEncode(url)}"));
                var response = await _httpClient.GetAsync($"api/revalidate?{p}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<IActionResult>() ?? new ActionResult { Title = "No Content" };
                }
                else
                {
                    return await ActionResult.FromAsync(response);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Next.js On-demand Revalidation failed / 按需重新验证失败");
                return ActionResult.From(ex);
            }
        }
    }
}
