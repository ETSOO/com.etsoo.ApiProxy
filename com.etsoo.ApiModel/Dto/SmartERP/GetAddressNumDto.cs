using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Get address data by Num
    /// 从数字编号获取地址信息
    /// </summary>
    [JsonDerivedType(typeof(PinDto))]
    public record GetAddressNumDto
    {
        /// <summary>
        /// Region or country id, like CN for China
        /// 地区或国家编号，比如 CN 表示中国
        /// </summary>
        public string? RegionId { get; init; }

        /// <summary>
        /// State
        /// 州省
        /// </summary>
        public string? State { get; init; }

        /// <summary>
        /// State id
        /// 州省编号
        /// </summary>
        public string? StateId { get; init; }

        /// <summary>
        /// City
        /// 城市
        /// </summary>
        public string? City { get; init; }

        /// <summary>
        /// City id
        /// 城市编号
        /// </summary>
        public int? CityId { get; init; }

        /// <summary>
        /// District
        /// 区县
        /// </summary>
        public string? District { get; init; }

        /// <summary>
        /// District id
        /// 区县编号
        /// </summary>
        public int? DistrictId { get; init; }

        /// <summary>
        /// Merged district
        /// 合并的区县名称
        /// </summary>
        public string? MergedDistrict { get; init; }
    }
}
