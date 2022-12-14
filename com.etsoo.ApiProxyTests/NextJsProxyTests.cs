using com.etsoo.ApiProxy.Proxy;
using Microsoft.Extensions.Logging;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class NextJsProxyTests
    {
        private readonly NextJsProxy proxy;

        public NextJsProxyTests()
        {
            var httpClient = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
            NextJsProxy.Setup(httpClient, "abc", "http://localhost:3000");
            proxy = new NextJsProxy(httpClient, Mock.Of<ILogger<NextJsProxy>>());
        }

        [TestMethod]
        public async Task OnDemandRevalidateAsyncTests()
        {
            var result = await proxy.OnDemandRevalidateAsync("/contact", "/about");
            Assert.IsFalse(result.Ok);
            if (result.Status != null) Assert.AreEqual(401, result.Status);
        }
    }
}
