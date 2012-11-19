using System.Data.SqlClient;
using System.Data.Sql;
using System.Data;

namespace System.Web.Mvc
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// フォーム用の「必須」ラベルを生成する.
        /// </summary>
        /// <param name="helper"></param>
        /// <returns></returns>
        public static IHtmlString RequiredLabel(this HtmlHelper helper)
        {
            var builder = new TagBuilder("span");
            builder.MergeAttribute("class", "label label-warning");
            builder.InnerHtml = "必須";
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        /// <summary>
        /// 指定したラベルとonclick値を持つボタンを生成する.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="label"></param>
        /// <param name="onclick"></param>
        /// <returns></returns>
        public static IHtmlString Button(this HtmlHelper helper, string label, string onclick)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("value", label);
            if (onclick != null && onclick != "")
            {
                builder.MergeAttribute("onclick", onclick);
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.SelfClosing));
        }

        /// <summary>
        /// 指定したController, Actionを行う単一フォームのボタンを生成する.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="label"></param>
        /// <param name="action"></param>
        /// <param name="controller"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public static IHtmlString ActionButton(this HtmlHelper helper, string label, string action, string controller, object options)
        {
            var url = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
            TagBuilder builder = new TagBuilder("form");
            builder.MergeAttribute("action", url.Action(action, controller, options));
            builder.MergeAttribute("method", "get");
            IHtmlString btn = SubmitButton(helper, label, null);
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.StartTag) + btn + builder.ToString(TagRenderMode.EndTag));
        }

        /// <summary>
        /// Submitボタンを生成する.
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="label"></param>
        /// <param name="onclick"></param>
        /// <returns></returns>
        public static IHtmlString SubmitButton(this HtmlHelper helper, string label, string onclick)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "submit");
            builder.MergeAttribute("value", label);
            builder.MergeAttribute("class", "btn btn-primary");
            if (onclick != null && onclick != "")
            {
                builder.MergeAttribute("onclick", onclick);
            }
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        public static SelectListItem[] RatioDropDownListData()
        {
            SelectListItem[] data;
            using (SqlConnection connection = new SqlConnection(@"data source=.\SQLEXPRESS;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|aspnetdb.mdf;User Instance=true"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand();
                command.CommandType = Data.CommandType.Text;
                command.CommandText = "SELECT * FROM T_MASTER_RATIO ORDER BY CODE;";
                command.Connection = connection;
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    DataTable dt = new DataTable();
                    dt.Load(reader);
                    data = new SelectListItem[dt.Rows.Count];
                    int i = 0;
                    foreach (DataRow dr in dt.Rows)
                    {
                        data[i] = new SelectListItem();
                        data[i].Value = (string)dr["ID"];
                        data[i].Text = (string)dr["NAME"];
                        i++;
                    }
                }
            }
            return data;
        }

        // <img> タグ作成(String)
        public static string ImageString(HtmlHelper helper, string url, string alternateText)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", url);
            builder.MergeAttribute("alt", alternateText);
 
            return builder.ToString(TagRenderMode.SelfClosing);
        }
 
        // <img> タグ作成(IHtmlString)
        public static IHtmlString Image(this HtmlHelper helper, string url, string alternateText)
        {
            return MvcHtmlString.Create(ImageString(helper, url, alternateText));
        }
 
        // <a> タグ作成(IHtmlString)
        public static IHtmlString ActionImage(this HtmlHelper html, string actionName, string controllerName, string imagePath, string alternateText)
        {
            var url = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
 
            var builder = new TagBuilder("a");
            builder.MergeAttribute("href", url.Action(actionName, controllerName));
            builder.InnerHtml = ImageString(html, imagePath, alternateText);
 
            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
 
        }
    }

    public class DropDownListData
    {
        public DropDownListData(string _Value, string _Text)
        {
            Value = _Value;
            Text = _Text;
        }

        public string Value
        {
            get;
            set;
        }
        public string Text
        {
            get;
            set;
        }
    }
}
