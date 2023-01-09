using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs;
using com.etsoo.ApiProxy.Options;
using com.etsoo.Utils;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// SmartERP service proxy
    /// SmartERP 服务代理
    /// </summary>
    public class SmartERPProxy : ISmartERPProxy
    {
        const string identifier = "com.etsoo.ApiProxy.Proxy.SmartERPProxy";

        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IMemoryCache? _cache;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        /// <param name="cache">Cache</param>
        public SmartERPProxy(HttpClient httpClient, ILogger logger, SmartERPOptions options, IMemoryCache? cache = null)
        {
            Setup(httpClient, options);

            _httpClient = httpClient;
            _logger = logger;
            _cache = cache;
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        /// <param name="cache">Cache</param>
        [ActivatorUtilitiesConstructor]
        public SmartERPProxy(HttpClient httpClient, ILogger<SmartERPProxy> logger, IOptions<SmartERPOptions> options, IMemoryCache? cache = null)
            : this(httpClient, logger, options.Value, cache)
        {
        }

        private void Setup(HttpClient client, SmartERPOptions options)
        {
            var domain = options.BaseAddress;

            if (string.IsNullOrEmpty(domain)) domain = "cn";
            if (domain.Length < 6) domain = $"https://{domain}api.etsoo.com/api/";

            client.BaseAddress = new Uri(domain);
        }

        /// <summary>
        /// Get supported currencies
        /// 获取支持的币种
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<CurrencyDto>?> GetCurrenciesAsync(string? language = null)
        {
            var key = $"{identifier}.GetCurrenciesAsync.{language}";
            if (_cache?.TryGetValue<IEnumerable<CurrencyDto>>(key, out var data) == true)
            {
                return data;
            }

            var response = await _httpClient.GetAsync($"Public/GetCurrencies?language={language}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<CurrencyDto>>(SharedUtils.JsonDefaultSerializerOptions);

            _cache?.Set(key, result);

            return result;
        }

        /// <summary>
        /// Get exchange rate
        /// 获取汇率
        /// </summary>
        /// <param name="currency">Currency, like USD, CNY</param>
        /// <returns>Task</returns>
        public async Task<ExchangeRateDto?> ExchangeRateAsync(string currency)
        {
            var key = $"{identifier}.ExchangeRateAsync.{currency}";
            if (_cache?.TryGetValue<ExchangeRateDto>(key, out var data) == true)
            {
                return data;
            }

            var response = await _httpClient.GetAsync($"Public/ExchangeRate/{currency}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<ExchangeRateDto>(SharedUtils.JsonDefaultSerializerOptions);

            _cache?.Set(key, result);

            return result;
        }

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Base64 string</returns>
        public async Task<string> QRCodeAsync(QRCodeOptions rq)
        {
            var response = await _httpClient.PostAsJsonAsync("Public/QRCode", rq, SharedUtils.JsonDefaultSerializerOptions);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        /// <summary>
        /// Region list
        /// 地区列表
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressRegionDto>?> RegionListAsync(string? language = null)
        {
            var key = $"{identifier}.RegionListAsync.{language}";
            if (_cache?.TryGetValue<IEnumerable<AddressRegionDto>>(key, out var data) == true)
            {
                return data;
            }

            var response = await _httpClient.GetAsync($"Address/RegionList?language={language}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<AddressRegionDto>>(SharedUtils.JsonDefaultSerializerOptions);

            _cache?.Set(key, result);

            return result;
        }

        /// <summary>
        /// State list
        /// 省州列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressStateDto>?> StateListAsync(StateListRQ rq)
        {
            if (_cache?.TryGetValue<IEnumerable<AddressStateDto>>(rq, out var data) == true)
            {
                return data;
            }

            var response = await _httpClient.GetAsync($"Address/StateList?{nameof(rq.RegionId)}={rq.RegionId}&{nameof(rq.Language)}={rq.Language}");
            response.EnsureSuccessStatusCode();

            var result = await response.Content.ReadFromJsonAsync<IEnumerable<AddressStateDto>>(SharedUtils.JsonDefaultSerializerOptions);

            _cache?.Set(rq, result);

            return result;
        }
    }
}
