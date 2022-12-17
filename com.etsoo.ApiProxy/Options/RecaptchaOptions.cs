namespace com.etsoo.ApiProxy.Configs
{
    /// <summary>
    /// reCaptcha API proxy options
    /// reCaptcha 接口代理配置
    /// </summary>
    public class RecaptchaOptions : IProxyOptions
    {
        public const string SectionName = "EtsooProxy:Recaptcha";

        public string? BaseAddress { get; init; }

        /// <summary>
        /// The shared key between your site and reCAPTCHA
        /// </summary>
        public string Secret { get; init; } = default!;

    }
}