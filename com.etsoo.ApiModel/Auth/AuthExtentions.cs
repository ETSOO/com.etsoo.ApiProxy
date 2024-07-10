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
        /// Sign in action
        /// 登录动作
        /// </summary>
        public const string SignInAction = "SignIn";

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
        public static string GetRequestAction(HttpRequest request)
        {
            var action = request.RouteValues.LastOrDefault().Value?.ToString()
                ?? (Uri.TryCreate(request.Path, UriKind.Absolute, out var uri) ? uri.Segments.Last() : string.Empty);
            return action.Trim('/');
        }
    }
}
