using com.etsoo.Utils.Actions;
using com.etsoo.Utils.Models;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// Timestamp and Key request data
    /// 时间戳和键请求数据
    /// </summary>
    public record TimestampKeyRQ : IModelValidator
    {
        /// <summary>
        /// Timestamp
        /// 时间戳
        /// </summary>
        public long Timestamp { get; init; }

        /// <summary>
        /// Key
        /// 键
        /// </summary>
        public required string Key { get; init; }

        /// <summary>
        /// Validate the model
        /// 验证模块
        /// </summary>
        /// <returns>Result</returns>
        public virtual IActionResult? Validate()
        {
            if (Key.Length is not (>= 1 and <= 256))
            {
                return new ActionResult { Type = "NoData", Field = nameof(Key) };
            }

            return null;
        }
    }
}
