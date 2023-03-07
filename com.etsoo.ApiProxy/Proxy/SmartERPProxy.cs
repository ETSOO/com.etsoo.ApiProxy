using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs;
using com.etsoo.ApiProxy.Options;
using com.etsoo.Utils;
using com.etsoo.Utils.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// SmartERP service proxy
    /// SmartERP 服务代理
    /// </summary>
    public class SmartERPProxy : ISmartERPProxy
    {
        const string identifier = $"{nameof(Proxy)}.{nameof(SmartERPProxy)}";

        private readonly ILogger _logger;
        private readonly HttpClient _httpClient;
        private readonly IDistributedCache _cache;
        private readonly double _cacheHours;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="logger">Logger</param>
        /// <param name="options">Options</param>
        /// <param name="cache">Cache</param>
        public SmartERPProxy(HttpClient httpClient, ILogger logger, SmartERPOptions options, IDistributedCache cache)
        {
            Setup(httpClient, options);

            _httpClient = httpClient;
            _logger = logger;
            _cache = cache;
            _cacheHours = options.CacheHours;
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
        public SmartERPProxy(HttpClient httpClient, ILogger<SmartERPProxy> logger, IOptions<SmartERPOptions> options, IDistributedCache cache)
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
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(GetCurrenciesAsync)}.{language}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<CurrencyDto>>($"Public/GetCurrencies?language={language}", SharedUtils.JsonDefaultSerializerOptions),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });
        }

        /// <summary>
        /// Get exchange rate
        /// 获取汇率
        /// </summary>
        /// <param name="currency">Currency, like USD, CNY</param>
        /// <returns>Task</returns>
        public async Task<ExchangeRateDto?> ExchangeRateAsync(string currency)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(ExchangeRateAsync)}.{currency}",
                () => _httpClient.GetFromJsonAsync<ExchangeRateDto>($"Public/ExchangeRate/{currency}", SharedUtils.JsonDefaultSerializerOptions),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });
        }

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Base64 string</returns>
        public async Task<string> QRCodeAsync(QRCodeOptions rq)
        {
            return await CacheFactory.DoStringAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(QRCodeAsync)}.{JsonSerializer.Serialize(rq)}",
                async () =>
                {
                    var response = await _httpClient.PostAsJsonAsync("Public/QRCode", rq, SharedUtils.JsonDefaultSerializerOptions);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync();
                });
        }

        /// <summary>
        /// Region list
        /// 地区列表
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressRegionDto>?> RegionListAsync(string? language = null)
        {
            var key = $"language={language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(RegionListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressRegionDto>>($"Address/RegionList?{key}", SharedUtils.JsonDefaultSerializerOptions));
        }

        /// <summary>
        /// State list
        /// 省州列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressStateDto>?> StateListAsync(StateListRQ rq)
        {
            var key = $"{nameof(rq.RegionId)}={rq.RegionId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(StateListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressStateDto>>($"Address/StateList?{key}", SharedUtils.JsonDefaultSerializerOptions));
        }

        /// <summary>
        /// City list
        /// 城市列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressCityDto>?> CityListAsync(CityListRQ rq)
        {
            var key = $"{nameof(rq.StateId)}={rq.StateId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(CityListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressCityDto>>($"Address/CityList?{key}", SharedUtils.JsonDefaultSerializerOptions));
        }

        /// <summary>
        /// District list
        /// 区县列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressDistrictDto>?> DistrictListAsync(DistrictListRQ rq)
        {
            var key = $"{nameof(rq.CityId)}={rq.CityId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(DistrictListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressDistrictDto>>($"Address/DistrictList?{key}", SharedUtils.JsonDefaultSerializerOptions));
        }
    }
}
