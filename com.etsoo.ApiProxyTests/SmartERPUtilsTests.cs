using com.etsoo.ApiModel.Dto.SmartERP;
using com.etsoo.ApiModel.Utils;

namespace com.etsoo.ApiProxyTests
{
    [TestClass]
    public class SmartERPUtilsTests
    {
        [TestMethod]
        public void ApiServiceToTypeTests()
        {
            var type = SmartERPUtils.ApiServiceToType(ApiService.SMTPDelegation);
            Assert.AreEqual(SmartERPUtils.SmartERPApiPrefix + nameof(ApiService.SMTPDelegation), type);
        }

        [TestMethod]
        public void TypeToApiServiceTests()
        {

        }
    }
}
