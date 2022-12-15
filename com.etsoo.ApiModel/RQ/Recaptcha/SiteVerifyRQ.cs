using System.ComponentModel.DataAnnotations;

namespace com.etsoo.ApiModel.RQ.Recaptcha
{
    /// <summary>
    /// Site verification request data
    /// 站点验证请求数据
    /// </summary>
    public class SiteVerifyRQ
    {
        /// <summary>
        /// The user response token provided by the reCAPTCHA client-side integration on your site
        /// </summary>
        [Required]
        public string Response { get; init; } = default!;

        /// <summary>
        /// The user's IP address
        /// </summary>
        public string? RemoteIp { get; init; }
    }
}
