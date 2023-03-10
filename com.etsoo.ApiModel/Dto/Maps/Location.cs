namespace com.etsoo.ApiModel.Dto.Maps
{
    /// <summary>
    /// Location
    /// 位置
    /// </summary>
    /// <param name="Lat">Latitude, 纬度</param>
    /// <param name="Lng">Longitude, 经度</param>
    public record Location(double Lat, double Lng)
    {
        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }
    }
}