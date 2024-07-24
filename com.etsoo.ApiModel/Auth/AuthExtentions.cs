using Microsoft.AspNetCore.Http;

namespace com.etsoo.ApiModel.Auth
{
    /// <summary>
    /// Auth extentions
    /// 授权扩展
    /// </summary>
    public static class AuthExtentions
    {
        /// <summary>
        /// Log in action
        /// 登录动作
        /// </summary>
        public const string LogInAction = "LogIn";

        /// <summary>
        /// Sign up action
        /// 注册动作
        /// </summary>
        public const string SignUpAction = "SignUp";

        /// <summary>
        /// Get request action
        /// 获取请求动作
        /// </summary>
        /// <param name="request">HTTP Request</param>
        /// <returns>Action</returns>
        public static string GetRequestAction(this HttpRequest request)
        {
            var action = request.RouteValues.LastOrDefault().Value?.ToString()
                ?? request.Path.Value?.TrimEnd('/').Split('/').LastOrDefault() ?? string.Empty;
            return action.Trim('/');
        }
    }
}
