using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using PhotosStore.WebUI.Models;

namespace PhotosStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
<<<<<<< HEAD
        //создание кнопок навигации
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,Func<int, string> pageUrl)
=======
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo,
                                              Func<int, string> pageUrl)
>>>>>>> 0d93b04c96dc8b48161553e5f14311a69b129dc6
        {
            StringBuilder result = new StringBuilder();
            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}