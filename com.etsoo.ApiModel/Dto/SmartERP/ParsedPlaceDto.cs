namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// Parsed place data
    /// 解析的地址数据
    /// </summary>
    public record ParsedPlaceDto
    {
        /// <summary>
        /// Language
        /// 语言
        /// </summary>
        public required string Language { get; init; }

        /// <summary>
        /// Region or country name, like China
        /// 地区或国家名称，如中国
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// Region id
        /// 地区编号
        /// </summary>
        public string? RegionId { get; init; }

        /// <summary>
        /// State or province
        /// 州 / 省
        /// </summary>
        public string? State { get; init; }

        /// <summary>
        /// State id
        /// 州省
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
    }
}
