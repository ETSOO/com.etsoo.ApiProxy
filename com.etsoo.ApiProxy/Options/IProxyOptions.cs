namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Proxy configuration interface
    /// 代理配置接口
    /// 
    /// </summary>
    public interface IProxyOptions
    {
        /// <summary>
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        string? BaseAddress { get; set; }
    }
}
