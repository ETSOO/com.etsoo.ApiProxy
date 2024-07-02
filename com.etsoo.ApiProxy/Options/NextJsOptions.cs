namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// Next.js API options
    /// Next.js 接口代理配置
    /// </summary>
    public class NextJsOptions : IProxyOptions
    {
        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        public const string Name = "NextJs";

        /// <summary>
        /// Configuration section name
        /// 配置节名称
        /// </summary>
        public const string SectionName = "EtsooProxy:NextJs";

        /// <summary>
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        public string? BaseAddress { get; set; }

        /// <summary>
        /// Token
        /// 令牌
        /// </summary>
        public string Token { get; set; } = string.Empty;
    }
}