using com.etsoo.ApiModel.Dto.SmartERP;
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
        /// Get exchange rate
        /// 获取汇率
        /// </summary>
        /// <param name="currency">Currency, like USD, CNY</param>
        /// <returns>Task</returns>
        Task<ExchangeRateDto?> ExchangeRateAsync(string currency);

        /// <summary>
        /// Get supported currencies
        /// 获取支持的币种
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Task</returns>
        Task<IEnumerable<CurrencyDto>?> GetCurrenciesAsync(string? language = null);

        /// <summary>
        /// Get QRCode image Base64 string
        /// 获取QRCode图片的Base64字符串
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Base64 string</returns>
        Task<string> QRCodeAsync(QRCodeOptions rq);

        /// <summary>
        /// Region list
        /// 地区列表
        /// </summary>
        /// <param name="language">Language</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressRegionDto>?> RegionListAsync(string? language = null);

        /// <summary>
        /// State list
        /// 省州列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressStateDto>?> StateListAsync(StateListRQ rq);

        /// <summary>
        /// City list
        /// 城市列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressCityDto>?> CityListAsync(CityListRQ rq);

        /// <summary>
        /// District list
        /// 区县列表
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Task</returns>
        Task<IEnumerable<AddressDistrictDto>?> DistrictListAsync(DistrictListRQ rq);
    }
}