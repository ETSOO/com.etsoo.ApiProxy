using com.etsoo.WebUtils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// State list request data
    /// 省州列表请求数据
    /// </summary>
    public record StateListRQ
    {
        /// <summary>
        /// Region id
        /// 地区编号
        /// </summary>
        [RegionId]
        [Required]
        public string RegionId { get; init; } = null!;

        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        [LanguageCode]
        public string? Language { get; init; }
    }
}
