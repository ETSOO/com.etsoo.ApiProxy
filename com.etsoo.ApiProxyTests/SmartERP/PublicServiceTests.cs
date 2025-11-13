using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.RQ.Maps;
using com.etsoo.ApiModel.RQ.SmartERP;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.ApiProxy.Options;
using com.etsoo.ApiProxy.Proxy;
using System.Drawing;

namespace com.etsoo.ApiProxyTests.SmartERP
{
    [TestClass]
    public class PublicServiceTests
    {
        private readonly IPublicService _service;

        public PublicServiceTests()
        {
            var httpClient = new HttpClient();
            var options = new SmartERPOptions
            {
                BaseAddress = "https://localhost:9001/api/"
            };
            var proxy = new SmartERPProxy(httpClient, options);
            _service = proxy.Public;
        }

        [TestMethod]
        public async Task QRCodeAsyncTests()
        {
            var qrcode = await _service.CreateBarcodeAsync(new BarcodeSimpleOptions { Foreground = Color.Red, Content = "https://www.etsoo.com" }, TestContext.CancellationToken);
            Assert.StartsWith("data:image/png;base64,", qrcode);
        }

        [TestMethod]
        public async Task GetCurrenciesAsyncTests()
        {
            var ids = new[] { "CNY", "NZD", "USD", "EUR" };
            var currencies = await _service.GetCurrenciesAsync(ids);
            CollectionAssert.AreEqual(currencies.Select(c => c.Id).ToArray(), ids);
        }

        [TestMethod]
        public async Task GetPinyinAsyncTests()
        {
            var rq = new PinyinRQ
            {
                Input = "重庆，长沙",
                Format = PinyinFormatType.Full
            };
            var pinyin = await _service.GetPinyinAsync(rq);
            Assert.AreEqual("Chong Qing Chang Sha", pinyin);
        }

        [TestMethod]
        public async Task GetRegionsAsyncTests()
        {
            var ids = new[] { "CN", "US", "AU" };
            var regions = await _service.GetRegionsAsync(ids);
            CollectionAssert.AreEqual(regions.Select(c => c.Id).ToArray(), ids);
        }

        [TestMethod]
        public async Task ParseChinaPinTests()
        {
            var pin = "110101199003071225";
            var data = await _service.ParseChinaPinAsync(pin);
            Assert.IsNotNull(data);
            Assert.AreEqual("1990-03-07", data?.Birthday.ToString("yyyy-MM-dd"));
            Assert.AreEqual("11", data?.StateNum);
            Assert.AreEqual("1101", data?.CityNum);
            Assert.AreEqual("110101", data?.DistrictNum);
            Assert.IsTrue(data?.IsFemale);
        }

        [TestMethod]
        public async Task QueryPlaceAsyncTests()
        {
            var rq = new PlaceQueryRQ
            {
                Query = "青岛玫瑰庭院",
                Region = "CN",
                Provider = ApiProvider.Baidu
            };
            var places = await _service.QueryPlaceAsync(rq, TestContext.CancellationToken);
            Assert.IsTrue(places?.Any(p => p.FormattedAddress.Equals("山东省青岛市崂山区清溪路88号玫瑰庭院")));
        }

        public TestContext TestContext { get; set; }
    }
}
