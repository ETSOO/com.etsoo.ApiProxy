using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.ApiModel.RQ.SmartERP;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// SmartERP service proxy interface
    /// SmartERP 服务代理接口
    /// </summary>
    public interface ISmartERPProxy : IProxy
    {
        /// <summary>
        /// Async authorize API service
        /// 异步授权接口服务
        /// </summary>
        /// <param name="serviceId">Service id</param>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<string?> AuthorizeApiServiceAsync(int serviceId, string rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Place autocomplete
        /// 地址自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<IEnumerable<PlaceAutocomplete>?> AutocompleteAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get place details
        /// 获取地点细节
        /// </summary>
        /// <param name="replaceId">Place id</param>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<PlaceCommon?> GetPlaceDetailsAsync(string replaceId, string? language = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Parse place
        /// 解析地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<ParsedPlaceDto?> ParsePlaceAsync(ParsePlaceRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Search place
        /// 查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<IEnumerable<PlaceCommon>?> SearchPlaceAsync(PlaceQueryRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Parse PIN
        /// 解析身份证号码
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns></returns>
        ValueTask<PinDto?> ParsePinAsync(ParsePinRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get exchange rate
        /// 获取汇率
        /// </summary>
        /// <param name="currency">Currency, like USD, CNY</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<ExchangeRateDto?> ExchangeRateAsync(string currency, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get supported currencies
        /// 获取支持的币种
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<IEnumerable<CurrencyDto>?> GetCurrenciesAsync(string? language = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Base64 string</returns>
        Task<string> QRCodeAsync(QRCodeOptions rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Region list
        /// 地区列表
        /// </summary>
        /// <param name="language">Language</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressRegionDto>?> RegionListAsync(string? language = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// State list
        /// 省州列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressStateDto>?> StateListAsync(StateListRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// City list
        /// 城市列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressCityDto>?> CityListAsync(CityListRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// District list
        /// 区县列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressDistrictDto>?> DistrictListAsync(DistrictListRQ rq, CancellationToken cancellationToken = default);
    }
}