using com.etsoo.ApiModel.Dto.SmartERP;
using System.Diagnostics.CodeAnalysis;

namespace com.etsoo.ApiModel.Utils
{
    /// <summary>
    /// SmartERP utilities
    /// 司友云工具
    /// </summary>
    public static class SmartERPUtils
    {
        /// <summary>
        /// SmartERP API message type prefix
        /// </summary>
        public const string SmartERPApiPrefix = "SMARTERP-API-";

        /// <summary>
        /// API service to message type
        /// </summary>
        /// <param name="api">API</param>
        /// <returns>Message type</returns>
        public static string ApiServiceToType(ApiService api)
        {
            return $"{SmartERPApiPrefix}{api}";
        }

        /// <summary>
        /// Message type to API service
        /// </summary>
        /// <param name="type">Type</param>
        /// <param name="api">API</param>
        /// <returns>Result</returns>
        public static bool TypeToApiService(string type, [NotNullWhen(true)] out ApiService? api)
        {
            api = null;

            if (type.StartsWith(SmartERPApiPrefix) && Enum.TryParse<ApiService>(type[SmartERPApiPrefix.Length..], out var result))
            {
                api = result;
                return true;
            }

            return false;
        }
    }
}
