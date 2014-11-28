using System.Web.Mvc;
using NUnit.Framework;

namespace FlashHelper.Tests
{
    public class HtmlOutputTests
    {
        private HtmlHelper helper = new HtmlHelper(new ViewContext(), new ViewPage());

        [Test]
        public void DivIsGenerated()
        {
            var actual = helper.Flash();

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
            helper.ViewData.Add(key, expected);

            var actual = helper.Flash();

            StringAssert.Contains(expected, actual);
        }

        [Test]
        [TestCase("success", "alert alert-success")]
        [TestCase("info", "alert alert-info")]
        [TestCase("warn", "alert alert-wanring")]
        [TestCase("error", "alert alert-danger")]
        public void DivClass_IsDependentOnalertType(string key, string expectedClass)
        {
            helper.ViewData.Add(key, "test");

            var actual = helper.Flash();

            StringAssert.Contains(expectedClass, actual);
        }

        [Test]
        [TestCase("success", "test_success")]
        [TestCase("info", "test_info")]
        [TestCase("warn", "test_warn")]
        public void ErrorIsMostImportant(string key, string value)
        {
            var expected = "this should appear";
            helper.ViewData.Add("error", expected);
            helper.ViewData.Add(key, value);

            var actual = helper.Flash();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }

        [Test]
        [TestCase("info", "test_info")]
        [TestCase("warn", "test_warn")]
        public void SuccessIsSecondMostImportant(string key, string value)
        {
            var expected = "this should appear";
            helper.ViewData.Add("success", expected);
            helper.ViewData.Add(key, value);

            var actual = helper.Flash();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }

        [Test]
        [TestCase("info", "test_info")]
        public void WarningIsThirdMostImportant(string key, string value)
        {
            var expected = "this should appear";
            helper.ViewData.Add("warn", expected);
            helper.ViewData.Add(key, value);

            var actual = helper.Flash();

            StringAssert.Contains(expected, actual);
            StringAssert.DoesNotContain(value, actual);
        }
    }
}
