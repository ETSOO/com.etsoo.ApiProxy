using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel.Dto.Maps
{
    /// <summary>
    /// Place base data
    /// 地点基础数据
    /// </summary>
    [JsonDerivedType(typeof(PlaceCommon))]
    public record PlaceBase
    {
        /// <summary>
        /// Location
        /// 位置
        /// </summary>
        public Location? Location { get; set; }

        /// <summary>
        /// Region
        /// 地区
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// State
        /// 州省
        /// </summary>
        public string? State { get; init; }

        /// <summary>
        /// City
        /// 城市
        /// </summary>
        public string? City { get; init; }

        /// <summary>
        /// District
        /// 区县
        /// </summary>
        public string? District { get; init; }

        /// <summary>
        /// Route
        /// 线路
        /// </summary>
        public string? Route { get; init; }

        /// <summary>
        /// Street and house number
        /// 街道和门牌号
        /// </summary>
        public string? Street { get; init; }

        /// <summary>
        /// Postal code
        /// 邮政编码
        /// </summary>
        public string? PostalCode { get; init; }
    }

    /// <summary>
    /// Common place data
    /// 通用地点数据
    /// </summary>
    public record PlaceCommon : PlaceBase
    {
        /// <summary>
        /// Place id
        /// 地点编号
        /// </summary>
        public required string PlaceId { get; init; }

        /// <summary>
        /// Place name
        /// 地名
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Location
        /// 位置
        /// </summary>
        public new required Location Location { get; init; }

        /// <summary>
        /// Formatted address
        /// 格式化地址
        /// </summary>
        public required string FormattedAddress { get; init; }
    }
}
