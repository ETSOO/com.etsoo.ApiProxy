using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiModel.Utils;
using com.etsoo.ApiProxy.Defs;
using com.etsoo.ApiProxy.Options;
using com.etsoo.ApiProxy.Proxy;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class SmartERPProxyTests
    {
        private readonly ISmartERPProxy proxy;

        public SmartERPProxyTests()
        {
            var httpClient = new HttpClient();
            proxy = new SmartERPProxy(httpClient, Mock.Of<ILogger<SmartERPProxy>>(), new OptionsWrapper<SmartERPOptions>(new()
            {
                BaseAddress = "http://localhost/com.etsoo.SmartERPApi/api/"
            }), Mock.Of<IDistributedCache>());
        }

        [TestMethod]
        public async Task AuthorizeApiServiceAsyncTests()
        {
            var result = await proxy.AuthorizeApiServiceAsync(4, "api".PadLeft(64, 'A'));
            Assert.IsTrue(string.IsNullOrEmpty(result));
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
        public void GetOrgAvatarTests()
        {
            var url = proxy.GetOrgAvatar(1);
            Assert.AreEqual("http://localhost/com.etsoo.SmartERPApi/api/Storage/OrgAvatar/1", url, true);
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

        [TestMethod]
        public async Task CityListAsyncTests()
        {
            var cities = await proxy.CityListAsync(new CityListRQ { StateId = "CNHN", Language = "zh-CN" });

            var cs = cities?.FirstOrDefault(r => r.Label == "长沙市");
            Assert.IsNotNull(cs);

            Assert.AreEqual("4301", cs.Num);

            var districts = await proxy.DistrictListAsync(new DistrictListRQ { CityId = cs.Id, Language = "zh-CN" });
            Assert.IsTrue(districts?.Any(d => d.Label.StartsWith("宁乡")));
        }

        [TestMethod]
        public async Task ParsePlaceAsyncTests()
        {
            var result = await proxy.ParsePlaceAsync(new ParsePlaceRQ { City = "青岛", District = "崂山" });
            Assert.IsNotNull(result);

            Assert.AreEqual("崂山区", result.District);
        }

        [TestMethod]
        public async Task ParsePinAsyncTests()
        {
            var result = await proxy.ParsePinAsync(new ParsePinRQ { Language = "zh-CN", Pin = "430124199110276963" });
            Assert.IsNotNull(result);

            Assert.IsNotNull(result.Birthday);
            Assert.AreEqual(10, result.Birthday.Value.Month);
            Assert.AreEqual(27, result.Birthday.Value.Day);

            Assert.AreEqual("F", result.Gender);
            Assert.AreEqual("宁乡市", result.District);
            Assert.AreEqual("宁乡县", result.MergedDistrict);
            Assert.IsFalse(result.Valid);
        }
    }
}
