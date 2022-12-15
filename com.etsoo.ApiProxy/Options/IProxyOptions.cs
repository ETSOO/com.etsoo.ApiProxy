namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Proxy configuration interface
    /// 代理配置接口
    /// 
    /// </summary>
    public interface IProxyOptions
    {
        static abstract string SectionName { get; }

        string? BaseAddress { get; init; }
    }
}
