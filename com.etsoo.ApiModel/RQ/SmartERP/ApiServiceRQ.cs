using com.etsoo.ApiModel.Dto.SmartERP;

namespace com.etsoo.ApiModel.RQ.SmartERP
{
    /// <summary>
    /// API service request data
    /// 接口服务请求数据
    /// </summary>
    public record ApiServiceRQ
    {
        /// <summary>
        /// API
        /// 接口
        /// </summary>
        public ApiServiceEnum Api { get; init; }

        /// <summary>
        /// Global organization id
        /// 全局机构编号
        /// </summary>
        public int OrganizationId { get; init; }

        /// <summary>
        /// Global user id
        /// 全局用户编号
        /// </summary>
        public int UserId { get; init; }
    }
}
