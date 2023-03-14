namespace com.etsoo.ApiModel.Dto.SmartERP
{
    /// <summary>
    /// PIN data
    /// 身份证信息
    /// </summary>
    public record PinDto : GetAddressNumDto
    {
        /// <summary>
        /// Birthday
        /// 出生日期
        /// </summary>
        public DateTime? Birthday { get; init; }

        /// <summary>
        /// Gender
        /// 性别
        /// </summary>
        public string? Gender { get; init; }

        /// <summary>
        /// Whether the form is legal
        /// 是否形式合法
        /// </summary>
        public required bool Valid { get; init; }
    }
}
