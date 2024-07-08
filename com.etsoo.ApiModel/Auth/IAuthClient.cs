using com.etsoo.Utils.Actions;
using Microsoft.AspNetCore.Http;

namespace com.etsoo.ApiModel.Auth
{
    /// <summary>
    /// OAuth2 client interface
    /// OAuth2 客户端接口
    /// </summary>
    public interface IAuthClient
    {
        /// <summary>
        /// Get server auth URL, for back-end processing
        /// 获取服务器授权URL，用于后端处理
        /// </summary>
        /// <param name="state">Request state</param>
        /// <param name="scope">Scope</param>
        /// <param name="offline">Is offline mode to generate refresh token</param>
        /// <param name="loginHint">Login hint</param>
        /// <returns>URL</returns>
        string GetServerAuthUrl(string state, string scope, bool offline = false, string? loginHint = null);

        /// <summary>
        /// Get script auth URL, for front-end page
        /// 获取脚本授权URL，用于前端页面
        /// </summary>
        /// <param name="state">Request state</param>
        /// <param name="scope">Scope</param>
        /// <param name="loginHint">Login hint</param>
        /// <returns>URL</returns>
        string GetScriptAuthUrl(string state, string scope, string? loginHint = null);

        /// <summary>
        /// Get user info from callback request
        /// 从回调请求获取用户信息
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="state">Request state</param>
        /// <returns>Action result & user information</returns>
        ValueTask<(IActionResult result, AuthUserInfo? userInfo)> GetUserInfoAsync(HttpRequest request, string state);

        /// <summary>
        /// Get user info from callback request
        /// 从回调请求获取用户信息
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="stateCallback">Callback to verify request state</param>
        /// <returns>Action result & user information</returns>
        ValueTask<(IActionResult result, AuthUserInfo? userInfo)> GetUserInfoAsync(HttpRequest request, Func<string, bool> stateCallback);
    }
}