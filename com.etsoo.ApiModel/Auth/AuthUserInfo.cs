namespace com.etsoo.ApiModel.Auth
{
    /// <summary>
    /// Auth user information
    /// 授权用户信息
    /// </summary>
    public record AuthUserInfo
    {
        /// <summary>
        /// User unique identifier
        /// 用户唯一标识
        /// </summary>
        public required string OpenId { get; init; }

        /// <summary>
        /// Name
        /// 姓名
        /// </summary>
        public required string Name { get; init; }

        /// <summary>
        /// Given name
        /// 名
        /// </summary>
        public string? GivenName { get; init; }

        /// <summary>
        /// Family name
        /// 姓
        /// </summary>
        public string? FamilyName { get; init; }

        /// <summary>
        /// Picture URL
        /// 头像URL
        /// </summary>
        public string? Picture { get; init; }

        /// <summary>
        /// Email
        /// 电子邮箱
        /// </summary>
        public string? Email { get; init; }

        /// <summary>
        /// Is email verified
        /// 电子邮箱是否已验证
        /// </summary>
        public bool? EmailVerified { get; init; }
    }
}
