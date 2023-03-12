using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// Parse place request data
    /// 解析地址请求数据
    /// </summary>
    public record ParsePlaceRQ
    {
        /// <summary>
        /// Region or country name, like China
        /// 地区或国家名称，如中国
        /// </summary>
        [StringLength(50)]
        public string? Region { get; init; }

        /// <summary>
        /// State or province
        /// 州 / 省
        /// </summary>
        [StringLength(50)]
        public string? State { get; init; }

        /// <summary>
        /// City
        /// 城市
        /// </summary>
        [StringLength(128)]
        public string? City { get; init; }

        /// <summary>
        /// 区县
        /// District
        /// </summary>
        [StringLength(128)]
        public string? District { get; init; }
    }
}
