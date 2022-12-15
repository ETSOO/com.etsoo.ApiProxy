namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Bridge service proxy options
    /// 桥接服务代理配置
    /// </summary>
    public class BridgeOptions : IProxyOptions
    {
        public static string SectionName => "EtsooProxy:Bridge";

        public string? BaseAddress { get; init; }
    }
}