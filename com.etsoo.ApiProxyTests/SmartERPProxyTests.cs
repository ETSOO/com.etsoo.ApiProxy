using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiModel.Utils;
using com.etsoo.ApiProxy.Options;
using com.etsoo.ApiProxy.Proxy;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class SmartERPProxyTests
    {
        private readonly SmartERPProxy proxy;

        public SmartERPProxyTests()
        {
            var httpClient = new HttpClient();
            proxy = new SmartERPProxy(httpClient, Mock.Of<ILogger<SmartERPProxy>>(), new OptionsWrapper<SmartERPOptions>(new()
            {
                BaseAddress = "http://localhost/com.etsoo.SmartERPApi/api/"
            }));
        }

        [TestMethod]
        public async Task GetCurrenciesAsyncTests()
        {
            var currencies = await proxy.GetCurrenciesAsync("en");
            Assert.AreEqual("US Dollar", currencies?.FirstOrDefault(r => r.Id == "USD")?.Label);

            if (currencies != null)
            {
                var ea = new ExchangeAmount(currencies);
                var amount1 = ea.Calc(100, "USD");
                Assert.IsTrue(amount1 > 600);

                var amount2 = ea.Calc(100, "USD", "EUR");
                Assert.IsTrue(amount2 < 150);
            }
        }

        [TestMethod]
        public async Task ExchangeRateAsyncTests()
        {
            var rate = await proxy.ExchangeRateAsync("USD");
            Assert.IsNotNull(rate);
        }

        [TestMethod]
        public async Task QRCodeAsyncTests()
        {
            var qrcode = await proxy.QRCodeAsync(new QRCodeOptions { Content = "https://www.etsoo.com" });
            Assert.IsTrue(qrcode.StartsWith("data:image/png;base64,"));
        }

        [TestMethod]
        public async Task RegionListAsyncTests()
        {
            var regions = await proxy.RegionListAsync();
            Assert.AreEqual("CNY", regions?.FirstOrDefault(r => r.Id == "CN")?.Currency);
        }

        [TestMethod]
        public async Task StateListAsyncTests()
        {
            var states = await proxy.StateListAsync(new StateListRQ { RegionId = "CN", Language = "zh-CN" });
            Assert.AreEqual("鲁", states?.FirstOrDefault(r => r.Label == "山东")?.Abbr);
        }
    }
}
