using com.etsoo.ApiProxy.Configs;
using com.etsoo.ApiProxy.Defs;
using com.etsoo.ApiProxy.Proxy;
using com.etsoo.GoogleApi.Cloud.RQ;
using com.etsoo.GoogleApi.Maps.Place.RQ;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class BridgeIntegrationProxyTests
    {
        private readonly IBridgeProxy proxy;

        public BridgeIntegrationProxyTests()
        {
            var httpClient = new HttpClient();
            proxy = new BridgeProxy(httpClient, Mock.Of<ILogger<BridgeProxy>>(), new OptionsWrapper<BridgeOptions>(new()
            {
                BaseAddress = "https://hkapi.etsoo.com/api/"
            }), Mock.Of<IDistributedCache>());
        }

        [TestMethod]
        public async Task AutoCompleteAsyncTest()
        {
            var result = await proxy.AutoCompleteAsync(new AutocompleteRQ { Input = "12a Cranbrook" });
            Assert.IsNotNull(result);

            var prediction = result.Predictions.FirstOrDefault(p => p.Description.Contains("Auckland"));
            Assert.IsNotNull(prediction);
            Assert.IsNotNull(prediction.PlaceId);

            var place = await proxy.GetPlaceDetailsAsync(new GetDetailsRQ { PlaceId = prediction.PlaceId });
            Assert.IsNotNull(place?.Result);

            Assert.IsTrue(place.Result?.AddressComponents?.Any(ac => ac.Types.Contains("country") && ac.ShortName.Equals("NZ")));
        }

        [TestMethod]
        public async Task FindPlaceAsyncTest()
        {
            var result = await proxy.FindPlaceAsync(new FindPlaceRQ { Input = "12a Cranbrook" });
            Assert.IsTrue(result?.Candidates.Any());
        }

        [TestMethod]
        public async Task SearchPlaceAsyncTest()
        {
            var result = await proxy.SearchPlaceAsync(new SearchPlaceRQ { Query = "12a Cranbrook" });
            Assert.IsTrue(result?.Results.Any());
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
