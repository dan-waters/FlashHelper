using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace FlashHelper
{
    public static class FlashHelper
    {
        public static MvcHtmlString Flash(this HtmlHelper helper)
        {
            var message = "";
            var className = "";
            if (helper.ViewContext.TempData["error"] != null)
            {
                message = helper.ViewContext.TempData["error"].ToString();
                className = "alert alert-danger";
            }
            else if (helper.ViewContext.TempData["success"] != null)
            {
                message = helper.ViewContext.TempData["success"].ToString();
                className = "alert alert-success";
            }
            
            else if (helper.ViewContext.TempData["warn"] != null)
            {
                message = helper.ViewContext.TempData["warn"].ToString();
                className = "alert alert-warning";
            }
            else if (helper.ViewContext.TempData["info"] != null)
            {
                message = helper.ViewContext.TempData["info"].ToString();
                className = "alert alert-info";
            }

            var tagBuilder = new TagBuilder("div");
            tagBuilder.AddCssClass(className);
            tagBuilder.SetInnerText(message);

            return MvcHtmlString.Create(tagBuilder.ToString(TagRenderMode.Normal));
        }
    }
}
