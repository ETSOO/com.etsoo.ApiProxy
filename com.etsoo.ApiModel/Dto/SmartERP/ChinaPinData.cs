namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// China PIN Data
    /// 中国身份证数据
    /// </summary>
    public record ChinaPinData
    {
        /// <summary>
        /// State num id
        /// 州省数字编号
        /// </summary>
        public required string StateNum { get; init; }

        /// <summary>
        /// City num id
        /// 城市数字编号
        /// </summary>
        public required string CityNum { get; init; }

        /// <summary>
        /// District number id
        /// 区县数字编号
        /// </summary>
        public required string DistrictNum { get; init; }

        /// <summary>
        /// Birthday
        /// 出生日期
        /// </summary>
        public required DateTimeOffset Birthday { get; init; }

        /// <summary>
        /// Is female
        /// 是否为女性
        /// </summary>
        public required bool IsFemale { get; init; }
    }
}
