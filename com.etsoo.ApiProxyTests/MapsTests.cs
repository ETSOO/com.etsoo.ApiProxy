using com.etsoo.ApiModel.Dto.Maps;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class MapsTests
    {
        [TestMethod]
        public void LocationTests()
        {
            var location = new Location(3.14, 4.18);
            Assert.AreEqual("3.14,4.18", location.ToString());
        }
    }
}
