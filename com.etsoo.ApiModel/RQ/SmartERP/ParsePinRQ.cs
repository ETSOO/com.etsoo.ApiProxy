using com.etsoo.WebUtils.Attributes;
using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// Parse PIN request data
    /// 解析证件号码请求数据
    /// </summary>
    public record ParsePinRQ
    {
        /// <summary>
        /// Pin
        /// 证件号码
        /// </summary>
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public required string Pin { get; init; }

        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        [Required]
        [LanguageCode]
        public required string Language { get; init; }
    }
}
