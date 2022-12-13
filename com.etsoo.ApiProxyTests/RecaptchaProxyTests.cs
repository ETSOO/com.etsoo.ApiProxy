using com.etsoo.ApiModel.Dto.Recaptcha;
using com.etsoo.ApiModel.RQ.Recaptcha;
using com.etsoo.ApiProxy;
using Microsoft.Extensions.Logging;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class RecaptchaProxyTests
    {
        private readonly RecaptchaProxy proxy;

        public RecaptchaProxyTests()
        {
            var httpClient = new HttpClient()
            {
                BaseAddress = new Uri("https://www.google.com/recaptcha/api/")
            };
            proxy = new RecaptchaProxy(httpClient, Mock.Of<ILogger<RecaptchaProxy>>());
        }

        [TestMethod]
        public async Task SiteVerifyAsyncFailureTests()
        {
            var rq = new SiteVerifyRQ { Secret = "abc", Response = "123", RemoteIp = "66.249.64.199" };
            var result = await proxy.SiteVerifyAsync(rq);
            Assert.IsTrue(result.ErrorCodes?.Contains(SiteVerifyDto.InvalidInputSecret));
        }
    }
}
