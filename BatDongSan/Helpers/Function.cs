using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace BatDongSan.Helpers
{
    public static class Functions
    {
        // Convert text to unsigned characters (remove diacritics and special characters)
        public static string ConvertToUnSign(string text)
        {
            // Removing characters based on ASCII ranges
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            
            text = text.Replace(" ", "-");

            // Normalize and remove diacritics
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(NormalizationForm.FormD);
            return regex.Replace(strFormD, string.Empty)
                        .Replace('\u0111', 'd')
                        .Replace('\u0110', 'D');
        }

        // Custom helper method to create an action link without HTML encoding
        public static IHtmlContent NoEncodeActionLink(this IHtmlHelper htmlHelper,
            string text, string title, string action,
            string controller,
            object routeValues = null,
            object htmlAttributes = null)
        {
            // Create an instance of the UrlHelper to generate the URL
            var urlHelper = new UrlHelper(htmlHelper.ViewContext);

            // Create a tag builder for an anchor tag
            var builder = new TagBuilder("a");
            builder.InnerHtml.AppendHtml(text); // Append the inner HTML (text or HTML content)
            builder.Attributes["title"] = title;
            builder.Attributes["href"] = urlHelper.Action(action, controller, routeValues);

            // Merge attributes from the provided HTML attributes object
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            // Return the result as raw HTML string
            return builder;
        }
    }
}
