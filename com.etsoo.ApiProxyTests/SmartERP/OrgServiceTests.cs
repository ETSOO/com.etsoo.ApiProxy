using com.etsoo.ApiModel.Dto.SmartERP.MessageQueue;
using com.etsoo.ApiProxy.Defs.SmartERP;
using com.etsoo.ApiProxy.Options;
using com.etsoo.ApiProxy.Proxy;

namespace com.etsoo.ApiProxyTests.SmartERP
{
    [TestClass]
    public class OrgServiceTests
    {
        private readonly IOrgService _service;

        public OrgServiceTests()
        {
            var httpClient = new HttpClient();
            var options = new SmartERPOptions
            {
                BaseAddress = "https://localhost:9001/api/"
            };
            var proxy = new SmartERPProxy(httpClient, options);
            _service = proxy.Org;
        }

        [TestMethod]
        public async Task FormatHtmlContentAsyncTests()
        {
            var original = "Hello, world! <b>How</b> do I use the <p>PipeReader for reading a JSON flatfile?</p><p><br/></p>";
            var result = await _service.FormatHtmlContentAsync(TestServiceExtentions.DefaultAuth, original);
            Assert.AreEqual("<p>Hello, world! <b>How</b> do I use the </p><p>PipeReader for reading a JSON flatfile?</p>", result);
        }

        [TestMethod]
        public async Task SendEmailAsyncTests()
        {
            var message = new SendEmailMessage
            {
                Subject = "亿速思维（ETSOO）接口测试邮件",
                Body = "<p>如果意外收到该邮件，请忽略。</p><p>If you received this email by accident, please ignore it.</p>",
                To = ["info@etsoo.com"]
            };
            var result = await _service.SendEmailAsync(TestServiceExtentions.DefaultAuth, message);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Ok);
        }

        [TestMethod]
        public async Task SendSMSAsyncTests()
        {
            var message = new SendSMSMessage
            {
                Kind = SendSMSMessage.KindCode,
                Culture = "zh-CN",
                Region = "CN",
                To = ["13853279130"],
                Body = "123456"
            };
            var result = await _service.SendSMSAsync(TestServiceExtentions.DefaultAuth, message);
            Assert.IsNotNull(result);
            Assert.IsTrue(result.Ok);
        }
    }
}
