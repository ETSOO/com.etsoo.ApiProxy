using com.etsoo.ApiModel.RQ.Google;
using com.etsoo.ApiProxy;
using com.etsoo.Testing.Mocks;
using Microsoft.Extensions.Logging;
using Moq;
using System.Net;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class GoogleProxyTests
    {
        private readonly GoogleProxy proxy;

        public GoogleProxyTests()
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
            proxy = new GoogleProxy(httpClient, Mock.Of<ILogger<GoogleProxy>>());
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
