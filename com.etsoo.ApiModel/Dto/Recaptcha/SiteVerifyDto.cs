using System.Text.Json.Serialization;

namespace com.etsoo.ApiModel.Dto.Recaptcha
{
    /// <summary>
    /// Site verification result data
    /// 站点验证结果数据
    /// </summary>
    public class SiteVerifyDto
    {
        public const string MissingInputSecret = "missing-input-secret";
        public const string InvalidInputSecret = "invalid-input-secret";
        public const string MissingInputResponse = "missing-input-response";
        public const string InvalidInputResponse = "invalid-input-response";
        public const string BadRequest = "bad-request";
        public const string TimeoutOrDuplicate = "timeout-or-duplicate";

        public bool Success { get; init; }

        /// <summary>
        /// Timestamp of the challenge load (ISO format yyyy-MM-dd'T'HH:mm:ssZZ)
        /// </summary>
        [JsonPropertyName("challenge_ts")]
        public string ChallengeTs { get; init; } = default!;

        /// <summary>
        /// The hostname of the site where the reCAPTCHA was solved
        /// </summary>
        public string? Hostname { get; init; }

        /// <summary>
        /// The package name of the app where the reCAPTCHA was solved
        /// </summary>
        public string? ApkPackageName { get; init; }

        [JsonPropertyName("error-codes")]
        public IEnumerable<string>? ErrorCodes { get; init; }
    }
}
