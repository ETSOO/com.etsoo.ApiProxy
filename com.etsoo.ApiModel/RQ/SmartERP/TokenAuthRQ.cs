namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// Token authentication request data
    /// 令牌认证请求数据
    /// </summary>
    public record TokenAuthRQ
    {
        /// <summary>
        /// The access token to be used for authentication
        /// 用于认证的访问令牌
        /// </summary>
        public required string AccessToken { get; init; }

        /// <summary>
        /// The scheme of the token, e.g., "Bearer"
        /// 令牌的方案，例如 "Bearer"
        /// </summary>
        public string? TokenScheme { get; init; }
    }
}
