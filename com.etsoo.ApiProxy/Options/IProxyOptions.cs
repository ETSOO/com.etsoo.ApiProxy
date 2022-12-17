namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Proxy configuration interface
    /// 代理配置接口
    /// 
    /// </summary>
    public interface IProxyOptions
    {
        string? BaseAddress { get; init; }
    }
}
