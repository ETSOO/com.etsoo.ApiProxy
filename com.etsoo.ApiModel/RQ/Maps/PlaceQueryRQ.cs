using com.etsoo.ApiModel.Dto.Maps;

namespace com.etsoo.ApiModel.RQ.Maps
{
    /// <summary>
    /// Place query request data
    /// 地点查询请求数据
    /// </summary>
    public record PlaceQueryRQ
    {
        /// <summary>
        /// Query input
        /// 查询输入
        /// </summary>
        public required string Query { get; init; }

        /// <summary>
        /// Output type
        /// 输出类型
        /// </summary>
        public ApiOutput Output { get; init; } = ApiOutput.JSON;

        /// <summary>
        /// API provider
        /// 接口供应商
        /// </summary>
        public ApiProvider? Provider { get; init; }

        /// <summary>
        /// Language, like zh-CN
        /// 语言
        /// </summary>
        public string? Language { get; init; }

        /// <summary>
        /// Region or country id, like CN
        /// 地区或国家编号
        /// </summary>
        public string? Region { get; init; }

        /// <summary>
        /// Center location
        /// 中心位置
        /// </summary>
        public Location? Location { get; init; }

        /// <summary>
        /// Radius in meters
        /// 方圆距离，单位为米
        /// </summary>
        public int? Radius { get; init; }

        /// <summary>
        /// Specify the number of results to display per page
        /// 指定每页显示的结果数
        /// </summary>
        public int PageSize { get; init; }
    }
}
