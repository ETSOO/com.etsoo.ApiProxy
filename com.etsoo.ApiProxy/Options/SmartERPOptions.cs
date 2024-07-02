using com.etsoo.ApiProxy.Configs;

namespace com.etsoo.ApiProxy.Options
{
    /// <summary>
    /// SmartERP service proxy options
    /// SmartERP 服务代理配置
    /// </summary>
    public class SmartERPOptions : IProxyOptions
    {
        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        public const string Name = "SmartERP";

        /// <summary>
        /// Configuration section name
        /// 配置节名称
        /// </summary>
        public const string SectionName = "EtsooProxy:SmartERP";

        /// <summary>
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        public string? BaseAddress { get; set; }

        /// <summary>
        /// Cache hours
        /// 缓存小时数
        /// </summary>
        public double CacheHours { get; set; } = 24;
    }
}
