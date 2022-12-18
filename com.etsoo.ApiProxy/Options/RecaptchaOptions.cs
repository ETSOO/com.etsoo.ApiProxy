namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// reCaptcha API proxy options
    /// reCaptcha 接口代理配置
    /// </summary>
    public class RecaptchaOptions : IProxyOptions
    {
        /// <summary>
        /// Name
        /// 名称
        /// </summary>
        public const string Name = "RECAP";

        /// <summary>
        /// Configuration section name
        /// 配置节名称
        /// </summary>
        public const string SectionName = "EtsooProxy:Recaptcha";

        /// <summary>
        /// Base address of the client
        /// 客户端的基地址
        /// </summary>
        public string? BaseAddress { get; init; }

        /// <summary>
        /// The shared key between your site and reCAPTCHA
        /// </summary>
        public string Secret { get; init; } = default!;

    }
}