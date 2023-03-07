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
        /// Place name
        /// 地名
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Other place data
        /// 其他地点数据
        /// </summary>
        public PlaceBase? Place { get; init; }
    }
}