using com.etsoo.ApiModel;
using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.Utils.Serialization;
using com.etsoo.Utils.Serialization.Country;
using System.Net.Http.Json;

namespace com.etsoo.ApiProxy.Proxy.SmartERP
{
    /// <summary>
    /// Public service
    /// 公共服务
    /// </summary>
    public class PublicService : IPublicService
    {
        private readonly HttpClient _httpClient;

        public PublicService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Base64 string</returns>
        public async Task<string> CreateBarcodeAsync(BarcodeSimpleOptions rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Public/CreateBarcodeSimple", rq, ApiModelJsonSerializerContext.Default.BarcodeSimpleOptions, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        /// <summary>
        /// Get currencies
        /// 获取货币定义
        /// </summary>
        /// <param name="ids">Ids to include and sort by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<CurrencyItem>> GetCurrenciesAsync(IEnumerable<string>? ids = null, CancellationToken cancellationToken = default)
        {
            var response = ids == null
                ? await _httpClient.PostAsync("Public/GetCurrencies", null, cancellationToken)
                : await _httpClient.PostAsJsonAsync("Public/GetCurrencies", ids, CommonJsonSerializerContext.Default.IEnumerableString, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(CommonJsonSerializerContext.Default.IEnumerableCurrencyItem, cancellationToken) ?? [];
        }

        /// <summary>
        /// Get Chinese Pinyin
        /// 获取汉字拼音
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<string> GetPinyinAsync(PinyinRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Public/GetPinyin", rq, ApiModelJsonSerializerContext.Default.PinyinRQ, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadAsStringAsync(cancellationToken);
        }

        /// <summary>
        /// Get regions
        /// 获取地区
        /// </summary>
        /// <param name="ids">Ids to include and sort by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<RegionItem>> GetRegionsAsync(IEnumerable<string>? ids = null, CancellationToken cancellationToken = default)
        {
            var response = ids == null
                ? await _httpClient.PostAsync("Public/GetRegions", null, cancellationToken)
                : await _httpClient.PostAsJsonAsync("Public/GetRegions", ids, CommonJsonSerializerContext.Default.IEnumerableString, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(CommonJsonSerializerContext.Default.IEnumerableRegionItem, cancellationToken) ?? [];
        }

        /// <summary>
        /// Parse China Pin
        /// 解析中国身份证
        /// </summary>
        /// <param name="pin">PIN</param>
        /// <returns>Result</returns>
        public async Task<ChinaPinData?> ParseChinaPinAsync(string pin, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.GetAsync($"Public/ParseChinaPin/{pin}", cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(ApiModelJsonSerializerContext.Default.ChinaPinData, cancellationToken);
        }

        /// <summary>
        /// Query place
        /// 查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        public async Task<IEnumerable<PlaceCommon>?> QueryPlaceAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default)
        {
            var response = await _httpClient.PostAsJsonAsync("Public/QueryPlace", rq, ApiModelJsonSerializerContext.Default.PlaceQueryRQ, cancellationToken);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync(ApiModelJsonSerializerContext.Default.IEnumerablePlaceCommon, cancellationToken);
        }
    }
}
