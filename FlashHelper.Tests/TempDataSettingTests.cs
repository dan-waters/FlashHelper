using System.Web.Mvc;
using NUnit.Framework;

namespace FlashHelper.Tests
{
    public class TempDataSettingTests
    {
        private Controller controller;
        private HtmlHelper helper;

        [SetUp]
        public void Setup()
        {
            var tempData = new TempDataDictionary();
            controller = new TestController {TempData = tempData};
            helper = new HtmlHelper(new ViewContext {TempData = tempData}, new ViewPage());
        }

        [Test]
        public void FlashWarning_SetsWarnKey()
        {
            const string expected = "test_warning";

            controller.FlashWarning(expected);

            StringAssert.Contains(expected, helper.Flash().ToHtmlString());
        }

        [Test]
        public void FlashSuccess_SetsSuccessKey()
        {
            const string expected = "test_success";

            controller.FlashSuccess(expected);

            StringAssert.Contains(expected, helper.Flash().ToHtmlString());
        }

        [Test]
        public void FlashInfo_SetsInfoKey()
        {
            const string expected = "test_info";

            controller.FlashInfo(expected);

            StringAssert.Contains(expected, helper.Flash().ToHtmlString());
        }

        [Test]
        public void FlashError_SetsErrorKey()
        {
            const string expected = "test_error";

            controller.FlashError(expected);

            StringAssert.Contains(expected, helper.Flash().ToHtmlString());
        }

        private class TestController : Controller
        {
        }
    }
}
