using com.etsoo.WebUtils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// District list request data
    /// 区县列表请求数据
    /// </summary>
    public record DistrictListRQ
    {
        /// <summary>
        /// City id
        /// 城市编号
        /// </summary>
        [Required]
        public required int CityId { get; init; }

        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        [LanguageCode]
        public string? Language { get; init; }
    }
}
