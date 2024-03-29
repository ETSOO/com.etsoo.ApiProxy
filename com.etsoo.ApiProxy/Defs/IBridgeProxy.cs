﻿using com.etsoo.ApiModel.Dto.Maps;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Maps.Place;
using com.etsoo.GoogleApi.Maps.Place.RQ;

namespace com.etsoo.ApiProxy.Defs
{
    /// <summary>
    /// Bridge service proxy interface
    /// 桥接服务代理接口
    /// </summary>
    public interface IBridgeProxy : IProxy
    {
        /// <summary>
        /// Async autocomplete
        /// 异步自动填充
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<AutocompleteResponse?> AutoCompleteAsync(AutocompleteRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Async find place
        /// 异步查找地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<FindPlaceResponse?> FindPlaceAsync(FindPlaceRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Async search place
        /// 异步查询地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<SearchPlaceResponse?> SearchPlaceAsync(SearchPlaceRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Async search common place
        /// 异步查询通用地点
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<IEnumerable<PlaceCommon>?> SearchCommonPlaceAsync(SearchPlaceRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Async get place details
        /// 异步获取地点细节
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Result</returns>
        Task<GetDetailsResponse?> GetPlaceDetailsAsync(GetDetailsRQ rq, CancellationToken cancellationToken = default);

        /// <summary>
        /// Translate short text
        /// 翻译短文本
        /// </summary>
        /// <param name="rq">Request data</param>
        /// <returns>Translated text</returns>
        Task<string> TranslateTextAsync(TranslateTextRQ rq, CancellationToken cancellationToken = default);
    }
}
