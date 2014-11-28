using System.Web.Mvc;

namespace FlashHelper
{
    public static class FlashHelper
    {
        public static MvcHtmlString Flash(this HtmlHelper helper)
        {
            var message = "";
            var className = "";
            if (helper.ViewContext.TempData[ErrorKey] != null)
            {
                message = helper.ViewContext.TempData[ErrorKey].ToString();
                className = "alert alert-danger";
            }
            else if (helper.ViewContext.TempData[SuccessKey] != null)
            {
                message = helper.ViewContext.TempData[SuccessKey].ToString();
                className = "alert alert-success";
            }
            
            else if (helper.ViewContext.TempData[WarningKey] != null)
            {
                message = helper.ViewContext.TempData[WarningKey].ToString();
                className = "alert alert-warning";
            }
            else if (helper.ViewContext.TempData[InfoKey] != null)
            {
                message = helper.ViewContext.TempData[InfoKey].ToString();
                className = "alert alert-info";
            }

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass(className);
            tagBuilder.InnerHtml = message;

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }

        public static void FlashWarning(this Controller controller, string warning)
        {
            controller.TempData.Add("warn", warning);
        }

        public static void FlashInfo(this Controller controller, string info)
        {
            controller.TempData.Add("info", info);
        }

        public static void FlashSuccess(this Controller controller, string success)
        {
            controller.TempData.Add("success", success);
        }

        public static void FlashError(this Controller controller, string error)
        {
            controller.TempData.Add("error", error);
        }

        private const string WarningKey = "warn";
        private const string InfoKey = "info";
        private const string SuccessKey = "success";
        private const string ErrorKey = "error";
    }
}
