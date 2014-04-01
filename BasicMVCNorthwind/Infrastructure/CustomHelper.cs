using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicMVCNorthwind.Infrastructure
{
    public static class CustomHelper
    {
        public static MvcHtmlString ListArrayItems(this HtmlHelper html, string[] list)
        {
            TagBuilder tag = new TagBuilder("ul");

            foreach(string str in list)
            {
                TagBuilder itemTag = new TagBuilder("li");
                itemTag.SetInnerText(str);
                tag.InnerHtml += itemTag.ToString();
            }

            return new MvcHtmlString(tag.ToString());
        }

        public static MvcHtmlString DisplayMsg(this HtmlHelper html, string msg)
        {
            string encodedMsg = html.Encode(msg);
            string result = string.Format("This is the message: <p>{0}</p>", encodedMsg);

            return new MvcHtmlString(result);
        }
    }
}