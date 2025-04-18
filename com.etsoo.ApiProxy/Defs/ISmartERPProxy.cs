using com.etsoo.ApiProxy.Defs.SmartERP;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// SmartERP service proxy interface
    /// SmartERP 服务代理接口
    /// </summary>
    public interface ISmartERPProxy : IProxy
    {
        /// <summary>
        /// Public service
        /// 公共服务
        /// </summary>
        IPublicService Public { get; }

        /// <summary>
        /// Organization service
        /// 机构服务
        /// </summary>
        IOrgService Org { get; }
    }
}