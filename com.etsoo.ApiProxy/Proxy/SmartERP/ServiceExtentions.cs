using com.etsoo.ApiModel.RQ.SmartERP;
using System.Net.Http.Headers;

namespace com.etsoo.ApiProxy.Proxy.SmartERP
{
    internal static class ServiceExtentions
    {
        /// <summary>
        /// Add authorization header
        /// 添加授权头
        /// </summary>
        /// <param name="auth">Token authorization request data</param>
        /// <returns>Result</returns>
        public static AuthenticationHeaderValue AddAuthorization(this TokenAuthRQ auth)
        {
            return new AuthenticationHeaderValue(auth.TokenScheme ?? "Bearer", auth.AccessToken);
        }
    }
}
