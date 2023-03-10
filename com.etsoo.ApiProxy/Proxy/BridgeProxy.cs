using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Defs;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Maps.Place;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using com.etsoo.Utils.Serialization;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.DependencyInjection;
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
        private const string identifier = $"{nameof(Proxy)}.{nameof(BridgeProxy)}";

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
        public BridgeProxy(HttpClient httpClient, ILogger logger, BridgeOptions options, IDistributedCache cache)
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
        public BridgeProxy(HttpClient httpClient, ILogger<BridgeProxy> logger, IOptions<BridgeOptions> options, IDistributedCache cache)
            : this(httpClient, logger, options.Value, cache)
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
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Google/AutoComplete", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<AutocompleteResponse>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Async find place
        /// 异步查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<FindPlaceResponse?> FindPlaceAsync(FindPlaceRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Google/FindPlace", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<FindPlaceResponse>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Google/SearchPlace", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<SearchPlaceResponse>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Async search common place
        /// 异步查询通用地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<PlaceCommon>?> SearchCommonPlaceAsync(SearchPlaceRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Google/SearchCommonPlace", rq, cancellationToken);
            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<IEnumerable<PlaceCommon>>(cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Async get place details
        /// 异步获取地点细节
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<GetDetailsResponse?> GetPlaceDetailsAsync(GetDetailsRQ rq, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(GetPlaceDetailsAsync)}.{rq.CreateKey()}",
                async () =>
                {
                    var response = await _httpClient.PostAsJsonAsync("Google/GetPlaceDetails", rq, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadFromJsonAsync<GetDetailsResponse>(cancellationToken: cancellationToken);
                }, cancellationToken: cancellationToken);
        }

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Translated text</returns>
        public async Task<string> TranslateTextAsync(TranslateTextRQ rq, CancellationToken cancellationToken = default)
        {
            return await CacheFactory.DoStringAsync(
                _cache,
                _cacheHours,
                () => $"{identifier}.{nameof(TranslateTextAsync)}.{rq.Text}.{rq.TargetLanguageCode}",
                async () =>
                {
                    var response = await _httpClient.PostAsJsonAsync("Google/TranslateText", rq, cancellationToken);
                    response.EnsureSuccessStatusCode();

                    return await response.Content.ReadAsStringAsync(cancellationToken: cancellationToken);
                }, cancellationToken: cancellationToken);
        }
    }
}