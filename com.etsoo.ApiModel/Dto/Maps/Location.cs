﻿namespace com.etsoo.ApiModel.Dto.Maps
{
    /// <summary>
    /// Location
    /// 位置
    /// </summary>
    /// <param name="Lat">Latitude, 纬度</param>
    /// <param name="Lng">Longitude, 经度</param>
    public record Location(float Lat, float Lng)
    {
        public override string ToString()
        {
            return $"{Lat},{Lng}";
        }

        public string ToSqlGeography()
        {
            return $"POINT({Lat} {Lng})";
        }
    }
}