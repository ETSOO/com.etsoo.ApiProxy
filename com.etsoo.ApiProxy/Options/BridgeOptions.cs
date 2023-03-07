namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Bridge service proxy options
    /// 桥接服务代理配置
    /// </summary>
    public class BridgeOptions : IProxyOptions
    {
        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        public const string Name = "Bridge";

        /// <summary>
        /// Configuration section name
        /// 配置节名称
        /// </summary>
        public const string SectionName = "EtsooProxy:Bridge";

        /// <summary>
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        public string? BaseAddress { get; init; }

        /// <summary>
        /// Cache hours
        /// 缓存小时数
        /// </summary>
        public double CacheHours { get; init; } = 24;
    }
}