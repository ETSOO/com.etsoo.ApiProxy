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
        /// Get login in URL
        /// 获取登录URL
        /// </summary>
        /// <param name="state">Request state</param>
        /// <param name="loginHint">Login hint</param>
        /// <returns>URL</returns>
        string GetLogInUrl(string state, string? loginHint = null);

        /// <summary>
        /// Get sign up URL
        /// 获取注册URL
        /// </summary>
        /// <param name="state">Request state</param>
        /// <returns>URL</returns>
        string GetSignUpUrl(string state);

        /// <summary>
        /// Get server auth URL, for back-end processing
        /// 获取服务器授权URL，用于后端处理
        /// </summary>
        /// <param name="action">Action of the request</param>
        /// <param name="state">Request state</param>
        /// <param name="scope">Scope</param>
        /// <param name="offline">Is offline mode to generate refresh token</param>
        /// <param name="loginHint">Login hint</param>
        /// <returns>URL</returns>
        string GetServerAuthUrl(string action, string state, string scope, bool offline = false, string? loginHint = null);

        /// <summary>
        /// Get script auth URL, for front-end page
        /// 获取脚本授权URL，用于前端页面
        /// </summary>
        /// <param name="action">Action of the request</param>
        /// <param name="state">Request state</param>
        /// <param name="scope">Scope</param>
        /// <param name="loginHint">Login hint</param>
        /// <returns>URL</returns>
        string GetScriptAuthUrl(string action, string state, string scope, string? loginHint = null);

        /// <summary>
        /// Get user info from callback request
        /// 从回调请求获取用户信息
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="state">Request state</param>
        /// <param name="action">Request action</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Action result & user information & actual state</returns>
        ValueTask<(IActionResult result, AuthUserInfo? userInfo, string? state)> GetUserInfoAsync(HttpRequest request, string state, string? action = null, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get user info from callback request
        /// 从回调请求获取用户信息
        /// </summary>
        /// <param name="request">Callback request</param>
        /// <param name="stateCallback">Callback to verify request state</param>
        /// <param name="action">Request action</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Action result & user information & actual state</returns>
        ValueTask<(IActionResult result, AuthUserInfo? userInfo, string? state)> GetUserInfoAsync(HttpRequest request, Func<string, bool> stateCallback, string? action = null, CancellationToken cancellationToken = default);
    }
}