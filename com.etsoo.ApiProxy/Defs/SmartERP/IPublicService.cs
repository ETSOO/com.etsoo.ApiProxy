using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.Utils.Serialization.Country;

namespace com.etsoo.ApiProxy.Defs.SmartERP
{
    /// <summary>
    /// Public service interface
    /// 公共服务接口
    /// </summary>
    public interface IPublicService
    {
        /// <summary>
        /// Create barcode image Base64 string
        /// 创建条形码图像 Base64 字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Base64 string</returns>
        Task<string> CreateBarcodeAsync(BarcodeSimpleOptions rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get currencies
        /// 获取货币定义
        /// </summary>
        /// <param name="ids">Ids to include and sort by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<IEnumerable<CurrencyItem>> GetCurrenciesAsync(IEnumerable<string>? ids = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get Chinese Pinyin
        /// 获取汉字拼音
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<string> GetPinyinAsync(PinyinRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get regions
        /// 获取地区
        /// </summary>
        /// <param name="ids">Ids to include and sort by</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<IEnumerable<RegionItem>> GetRegionsAsync(IEnumerable<string>? ids = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Parse China Pin
        /// 解析中国身份证
        /// </summary>
        /// <param name="pin">PIN</param>
        /// <returns>Result</returns>
        Task<ChinaPinData?> ParseChinaPinAsync(string pin, CancellationToken cancellationToken = default);

        /// <summary>
        /// Query place
        /// 查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<IEnumerable<PlaceCommon>?> QueryPlaceAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default);
    }
}
