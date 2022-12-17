namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Next.js API options
    /// Next.js 接口代理配置
    /// </summary>
    public class NextJsOptions : IProxyOptions
    {
        public const string SectionName = "EtsooProxy:NextJs";

        public string? BaseAddress { get; init; }
        public string Token { get; init; } = default!;
    }
}