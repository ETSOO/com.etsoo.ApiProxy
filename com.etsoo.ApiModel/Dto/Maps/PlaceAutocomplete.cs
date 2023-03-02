namespace com.etsoo.ApiModel.Dto.Maps
{
    /// <summary>
    /// Place autocomplete data
    /// 地址自动完成数据
    /// </summary>
    public record PlaceAutocomplete
    {
        /// <summary>
        /// Place id
        /// 地点编号
        /// </summary>
        public required string PlaceId { get; init; }

        /// <summary>
        /// Place description
        /// 地名描述
        /// </summary>
        public required string Description { get; init; }
    }
}