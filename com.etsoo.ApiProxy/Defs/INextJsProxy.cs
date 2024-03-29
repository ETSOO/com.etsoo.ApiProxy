﻿using com.etsoo.Utils.Actions;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// Next.js API proxy
    /// https://nextjs.org/docs/basic-features/data-fetching/incremental-static-regeneration
    /// </summary>
    public interface INextJsProxy : IProxy
    {
        /// <summary>
        /// Async on demand revalidataion
        /// 异步按需重新验证
        /// </summary>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <param name="urls">Urls to revalidate</param>
        /// <returns>Result</returns>
        Task<IActionResult> OnDemandRevalidateAsync(CancellationToken cancellationToken, params string[] urls);

        /// <summary>
        /// Async on demand revalidataion
        /// 异步按需重新验证
        /// </summary>
        /// <param name="urls">Urls to revalidate</param>
        /// <param name="cancellationToken">Cancellation token</param>
        /// <returns>Result</returns>
        Task<IActionResult> OnDemandRevalidateAsync(IEnumerable<string> urls, CancellationToken cancellationToken = default);
    }
}
