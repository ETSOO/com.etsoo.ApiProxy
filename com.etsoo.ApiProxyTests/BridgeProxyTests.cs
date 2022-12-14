using com.etsoo.ApiModel.RQ.Bridge;
using com.etsoo.ApiProxy.Proxy;
using com.etsoo.Testing.Mocks;
using Microsoft.Extensions.Logging;
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
            }))
            {
                BaseAddress = new Uri("https://localhost/api")
            };
            proxy = new BridgeProxy(httpClient, Mock.Of<ILogger<BridgeProxy>>());
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
