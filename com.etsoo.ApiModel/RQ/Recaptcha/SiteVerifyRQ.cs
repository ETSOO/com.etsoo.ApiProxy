namespace com.etsoo.ApiModel.RQ.Recaptcha
{
    /// <summary>
    /// Site verification request data
    /// 站点验证请求数据
    /// </summary>
    public record SiteVerifyRQ
    {
        /// <summary>
        /// The user response token provided by the reCAPTCHA client-side integration on your site
        /// </summary>
        public required string Response { get; init; }

        /// <summary>
        /// The user's IP address
        /// </summary>
        public string? RemoteIp { get; init; }
    }
}
