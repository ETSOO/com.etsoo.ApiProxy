using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.Maps;
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
using System.Web;

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
        private readonly string _apiBase;

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
            _apiBase = Setup(httpClient, options);

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

        private string Setup(HttpClient client, SmartERPOptions options)
        {
            var domain = options.BaseAddress;

            if (string.IsNullOrEmpty(domain)) domain = "cn";
            if (domain.Length < 6) domain = $"https://{domain}api.etsoo.com/api/";

            client.BaseAddress = new Uri(domain);

            return domain;
        }

        /// <summary>
        /// Async authorize API service
        /// 异步授权接口服务
        /// </summary>
        /// <param name="serviceId">Service id</param>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<string?> AuthorizeApiServiceAsync(int serviceId, string rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"Public/AuthorizeApiService/{serviceId}", rq, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        /// <summary>
        /// Async authorize API services
        /// 异步授权接口服务
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<string?>?> AuthorizeApiServicesAsync(AuthorizeApiServicesRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync($"Public/AuthorizeApiServices", rq, cancellationToken);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<IEnumerable<string?>>(SharedUtils.JsonDefaultSerializerOptions, cancellationToken);
        }

        /// <summary>
        /// Place autocomplete
        /// 地址自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<PlaceAutocomplete>?> AutocompleteAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Address/AutoComplete", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<PlaceAutocomplete>>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get organization avatar URL
        /// 获取机构图像网址
        /// </summary>
        /// <param name="id">Organization id</param>
        /// <returns>Result</returns>
        public string GetOrgAvatar(int id)
        {
            return $"{_apiBase}Storage/OrgAvatar/{id}";
        }

        /// <summary>
        /// Get place details
        /// 获取地点细节
        /// </summary>
        /// <param name="replaceId">Place id</param>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<PlaceCommon?> GetPlaceDetailsAsync(string replaceId, string? language = null, CancellationToken cancellationToken = default)
        {
            return await _httpClient.GetFromJsonAsync<PlaceCommon>($"Address/GetPlaceDetails/{HttpUtility.UrlEncode(replaceId)}/{(language == null ? string.Empty : HttpUtility.UrlEncode(language))}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken);
        }

        /// <summary>
        /// Parse place
        /// 解析地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<ParsedPlaceDto?> ParsePlaceAsync(ParsePlaceRQ rq, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(ParsePlaceAsync)}.{rq}",
                async () =>
                {
                    var response = await _httpClient.PostAsJsonAsync("Address/ParsePlace", rq, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadFromJsonAsync<ParsedPlaceDto>(cancellationToken: cancellationToken);
                },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(7)
                }, cancellationToken
            );
        }

        /// <summary>
        /// Search place
        /// 查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<PlaceCommon>?> SearchPlaceAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Address/SearchPlace", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<PlaceCommon>>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Parse PIN
        /// 解析身份证号码
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        public async ValueTask<PinDto?> ParsePinAsync(ParsePinRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Public/ParsePin", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<PinDto>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get supported currencies
        /// 获取支持的币种
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<CurrencyDto>?> GetCurrenciesAsync(string? language = null, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(GetCurrenciesAsync)}.{language}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<CurrencyDto>>($"Public/GetCurrencies?language={language}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                }, cancellationToken);
        }

        /// <summary>
        /// Get exchange rate
        /// 获取汇率
        /// </summary>
        /// <param name="currency">Currency, like USD, CNY</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<ExchangeRateDto?> ExchangeRateAsync(string currency, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(ExchangeRateAsync)}.{currency}",
                () => _httpClient.GetFromJsonAsync<ExchangeRateDto>($"Public/ExchangeRate/{currency}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                }, cancellationToken);
        }

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Base64 string</returns>
        public async Task<string> QRCodeAsync(QRCodeOptions rq, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoStringAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(QRCodeAsync)}.{rq}",
                async () =>
                {
                    var response = await _httpClient.PostAsJsonAsync("Public/QRCode", rq, SharedUtils.JsonDefaultSerializerOptions, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
                }, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Region list
        /// 地区列表
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressRegionDto>?> RegionListAsync(string? language = null, CancellationToken cancellationToken = default)
        {
            var key = $"language={language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(RegionListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressRegionDto>>($"Address/RegionList?{key}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// State list
        /// 省州列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressStateDto>?> StateListAsync(StateListRQ rq, CancellationToken cancellationToken = default)
        {
            var key = $"{nameof(rq.RegionId)}={rq.RegionId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(StateListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressStateDto>>($"Address/StateList?{key}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// City list
        /// 城市列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressCityDto>?> CityListAsync(CityListRQ rq, CancellationToken cancellationToken = default)
        {
            var key = $"{nameof(rq.StateId)}={rq.StateId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(CityListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressCityDto>>($"Address/CityList?{key}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// District list
        /// 区县列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        public async Task<IEnumerable<AddressDistrictDto>?> DistrictListAsync(DistrictListRQ rq, CancellationToken cancellationToken = default)
        {
            var key = $"{nameof(rq.CityId)}={rq.CityId}&{nameof(rq.Language)}={rq.Language}";
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(DistrictListAsync)}.{key}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<AddressDistrictDto>>($"Address/DistrictList?{key}", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Get supported cultures
        /// 获取所有支持的文化
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<ListItem1>?> SupportedCulturesAsync(CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(SupportedCulturesAsync)}",
                () => _httpClient.GetFromJsonAsync<IEnumerable<ListItem1>>("Public/SupportedCultures", SharedUtils.JsonDefaultSerializerOptions, cancellationToken),
                cancellationToken: cancellationToken);
        }
    }
}
