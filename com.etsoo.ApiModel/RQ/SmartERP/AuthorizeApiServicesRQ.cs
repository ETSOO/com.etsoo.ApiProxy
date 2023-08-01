namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// Authorize API services request data
    /// 授权接口服务请求数据
    /// </summary>
    public record AuthorizeApiServicesRQ
    {
        /// <summary>
        /// Service App id
        /// 服务程序编号
        /// </summary>
        public required int Id { get; init; }

        /// <summary>
        /// Include all keys
        /// 包含所有键
        /// </summary>
        public bool IncludeAll { get; init; }

        /// <summary>
        /// Key array
        /// 键值数组
        /// </summary>
        public required IEnumerable<string> Keys { get; init; }
    }
}
