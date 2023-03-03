using com.etsoo.WebUtils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// City list request data
    /// 城市列表请求数据
    /// </summary>
    public record CityListRQ
    {
        /// <summary>
        /// State id
        /// 省州编号
        /// </summary>
        [StringLength(4, MinimumLength = 4)]
        [Required]
        public required string StateId { get; init; }

        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        [LanguageCode]
        public string? Language { get; init; }
    }
}
