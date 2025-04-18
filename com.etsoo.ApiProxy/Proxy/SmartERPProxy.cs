using com.etsoo.ApiProxy.Defs;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.ApiProxy.Options;
using com.etsoo.ApiProxy.Proxy.SmartERP;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace com.etsoo.ApiProxy.Proxy
{
    /// <summary>
    /// SmartERP service proxy
    /// SmartERP 服务代理
    /// </summary>
    public class SmartERPProxy : ISmartERPProxy
    {
        private readonly Lazy<IPublicService> _lazyPublic;

        /// <summary>
        /// Public service
        /// 公共服务
        /// </summary>
        public IPublicService Public => _lazyPublic.Value;

        private readonly Lazy<IOrgService> _lazyOrg;

        /// <summary>
        /// Organization service
        /// 机构服务
        /// </summary>
        public IOrgService Org => _lazyOrg.Value;

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="options">Options</param>
        public SmartERPProxy(HttpClient httpClient, SmartERPOptions options)
        {
            if (!string.IsNullOrEmpty(options.BaseAddress))
            {
                httpClient.BaseAddress = new Uri(options.BaseAddress);
            }

            _lazyPublic = new(() => new PublicService(httpClient));
            _lazyOrg = new(() => new OrgService(httpClient));
        }

        /// <summary>
        /// Constructor
        /// 构造函数
        /// </summary>
        /// <param name="httpClient">HTTP client</param>
        /// <param name="options">Options</param>
        [ActivatorUtilitiesConstructor]
        public SmartERPProxy(HttpClient httpClient, IOptions<SmartERPOptions> options)
            : this(httpClient, options.Value)
        {
        }
    }
}
