using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
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
            proxy = new NextJsProxy(httpClient, Mock.Of<ILogger<NextJsProxy>>(), new OptionsWrapper<NextJsOptions>(new()
            {
                BaseAddress = "http://localhost:3000",
                Token = "abc"
            }));
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
