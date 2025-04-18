﻿using com.etsoo.ApiModel.Dto.Recaptcha;
using com.etsoo.ApiModel.RQ.Recaptcha;
using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class RecaptchaProxyTests
    {
        private readonly RecaptchaProxy proxy;

        public RecaptchaProxyTests()
        {
            var httpClient = new HttpClient();
            proxy = new RecaptchaProxy(httpClient, Mock.Of<ILogger<RecaptchaProxy>>(), new OptionsWrapper<RecaptchaOptions>(new()
            {
                Secret = "abc"
            }));
        }

        [TestMethod]
        public async Task SiteVerifyAsyncFailureTests()
        {
            var rq = new SiteVerifyRQ { Response = "123", RemoteIp = "66.249.64.199" };
            var result = await proxy.SiteVerifyAsync(rq);
            Assert.IsTrue(result.ErrorCodes?.Contains(SiteVerifyDto.InvalidInputSecret) is true || result.ErrorCodes?.Contains(SiteVerifyDto.InvalidInputResponse) is true);
        }
    }
}
