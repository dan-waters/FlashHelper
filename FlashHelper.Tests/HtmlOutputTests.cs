using System.Web.Mvc;
using NUnit.Framework;

namespace FlashHelper.Tests
{
    public class HtmlOutputTests
    {
        private HtmlHelper helper;

        [SetUp]
        public void Setup()
        {
            helper = new HtmlHelper(new ViewContext {TempData = new TempDataDictionary()}, new ViewPage());
        }

        [Test]
        public void DivIsGenerated()
        {
            var actual = helper.Flash().ToHtmlString();

            StringAssert.StartsWith("<div", actual);
            StringAssert.EndsWith("</div>", actual);
        }

        [Test]
        [TestCase("success", "test_success")]
        [TestCase("info", "test_info")]
        [TestCase("warn", "test_warn")]
        [TestCase("error", "test_error")]
        public void ContentsOfTempData_AreOutputToDiv(string key, string expected)
        {
            helper.ViewContext.TempData.Add(key, expected);

            var actual = helper.Flash().ToHtmlString();

            StringAssert.Contains(expected, actual);
        }

        [Test]
        [TestCase("success", "alert alert-success")]
        [TestCase("info", "alert alert-info")]
        [TestCase("warn", "alert alert-warning")]
        [TestCase("error", "alert alert-danger")]
        public void DivClass_IsDependentOnAlertType(string key, string expectedClass)
        {
            helper.ViewContext.TempData.Add(key, "test");

            var actual = helper.Flash().ToHtmlString();

            StringAssert.Contains(expectedClass, actual);
        }

        [Test]
        [TestCase("success", "test_success")]
        [TestCase("info", "test_info")]
        [TestCase("warn", "test_warn")]
        public void ErrorIsMostImportant(string key, string value)
        {
            const string expected = "this should appear";
            helper.ViewContext.TempData.Add("error", expected);
            helper.ViewContext.TempData.Add(key, value);

            var actual = helper.Flash().ToHtmlString();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }

        [Test]
        [TestCase("info", "test_info")]
        [TestCase("warn", "test_warn")]
        public void SuccessIsSecondMostImportant(string key, string value)
        {
            const string expected = "this should appear";
            helper.ViewContext.TempData.Add("success", expected);
            helper.ViewContext.TempData.Add(key, value);

            var actual = helper.Flash().ToHtmlString();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }

        [Test]
        [TestCase("info", "test_info")]
        public void WarningIsThirdMostImportant(string key, string value)
        {
            const string expected = "this should appear";
            helper.ViewContext.TempData.Add("warn", expected);
            helper.ViewContext.TempData.Add(key, value);

            var actual = helper.Flash().ToHtmlString();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }
    }
}
