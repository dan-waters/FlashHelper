using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using NUnit.Framework;

namespace FlashHelper.Tests
{
    public class TempDataSettingTests
    {
        private Controller controller;

        [SetUp]
        public void Setup()
        {
            controller = new TestController {TempData = new TempDataDictionary()};
        }

        [Test]
        public void FlashWarning_SetsWarnKey()
        {
            const string expected = "test_error";

            controller.FlashWarning(expected);

            Assert.AreEqual(expected, controller.TempData["warn"]);
        }

        [Test]
        public void FlashSuccess_SetsSuccessKey()
        {
            const string expected = "test_error";

            controller.FlashSuccess(expected);

            Assert.AreEqual(expected, controller.TempData["success"]);
        }

        [Test]
        public void FlashInfo_SetsInfoKey()
        {
            const string expected = "test_error";

            controller.FlashInfo(expected);

            Assert.AreEqual(expected, controller.TempData["error"]);
        }

        [Test]
        public void FlashError_SetsErrorKey()
        {
            const string expected = "test_error";

            controller.FlashError(expected);

            Assert.AreEqual(expected, controller.TempData["error"]);
        }

        private class TestController : Controller
        {
        }
    }
}
