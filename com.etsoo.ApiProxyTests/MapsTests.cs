using com.etsoo.ApiModel.Dto.Maps;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class MapsTests
    {
        [TestMethod]
        public void LocationTests()
        {
            var location = new Location(3.14f, -4.18f);
            Assert.AreEqual("3.14,-4.18", location.ToString());
            Assert.AreEqual("POINT(3.14 -4.18)", location.ToSqlGeography());
        }
    }
}
