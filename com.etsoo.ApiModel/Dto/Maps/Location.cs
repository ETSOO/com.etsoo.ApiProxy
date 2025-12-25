namespace com.etsoo.ApiModel.Dto.Maps
{
    /// <summary>
    /// Location
    /// 位置
    /// </summary>
    /// <param name="Lat">Latitude, 纬度</param>
    /// <param name="Lng">Longitude, 经度</param>
    public record Location(float Lat, float Lng)
    {
        /// <summary>
        /// To LatLng string
        /// 转换为 LatLng 字符串
        /// </summary>
        /// <returns>Result</returns>
        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }

        /// <summary>
        /// To LngLat string
        /// 转换为 LngLat 字符串
        /// </summary>
        /// <returns>Result</returns>
        public string ToLngLatString()
        {
            return $"{Lng},{Lat}";
        }

        /// <summary>
        /// To SQL Geography format
        /// 转换为 SQL Geography 格式
        /// </summary>
        /// <returns>Result</returns>
        public string ToSqlGeography()
        {
            return $"POINT({Lat} {Lng})";
        }
    }
}