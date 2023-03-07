using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Proxy;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.Testing.Mocks;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System.Net;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class BridgeProxyTests
    {
        private readonly BridgeProxy proxy;

        public BridgeProxyTests()
        {
            var httpClient = new HttpClient(new HttpMessageHandlerMock((request) =>
            {
                var uri = request.RequestUri;
                // When BaseAddress is "https://localhost/api" then works
                // When is "https://localhost/api/" then should be "/api//Google/TranslateText"
                if (uri?.PathAndQuery == "/Google/TranslateText")
                {
                    return new HttpResponseMessage
                    {
                        StatusCode = HttpStatusCode.OK,
                        Content = new StringContent(@"China"),
                    };
                }
                return new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NotFound
                };
            }));
            proxy = new BridgeProxy(httpClient, Mock.Of<ILogger<BridgeProxy>>(), new OptionsWrapper<BridgeOptions>(new()
            {
                BaseAddress = "https://localhost/api"
            }), Mock.Of<IDistributedCache>());
        }

        [TestMethod]
        public async Task TranslateTextAsyncSuccessTests()
        {
            var rq = new TranslateTextRQ { Text = "中国" };
            var result = await proxy.TranslateTextAsync(rq);
            Assert.AreEqual("China", result);
        }
    }
}
