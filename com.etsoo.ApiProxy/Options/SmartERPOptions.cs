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
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        public string? BaseAddress { get; set; }
    }
}
