using com.etsoo.ApiModel.Dto.Recaptcha;
using com.etsoo.ApiModel.RQ.Recaptcha;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// reCaptcha API proxy interface
    /// https://developers.google.com/recaptcha/docs/v3
    /// </summary>
    public interface IRecaptchaProxy : IProxy
    {
        /// <summary>
        /// Site verification
        /// 站点验证
        /// </summary>
        /// <param name="rq">Rquest data</param>
        /// <returns></returns>
        Task<SiteVerifyDto> SiteVerifyAsync(SiteVerifyRQ rq);
    }
}
