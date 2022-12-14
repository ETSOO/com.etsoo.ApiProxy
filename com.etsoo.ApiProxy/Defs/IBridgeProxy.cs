using com.etsoo.ApiModel.RQ.Bridge;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// Bridge service proxy interface
    /// 桥接服务代理接口
    /// </summary>
    public interface IBridgeProxy : IProxy
    {
        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Translated text</returns>
        Task<string> TranslateTextAsync(TranslateTextRQ rq);
    }
}
