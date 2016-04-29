//using HtmlAgilityPack;
//using System.Collections.Generic;
//using System.Text;

//namespace WebCrawlerDataPrev.Infrastructure
//{
//    /// <summary>
//    /// Represents a combined list and collection of Form Elements.
//    /// </summary>
//    public class FormElementCollection : Dictionary<string, string>
//    {
//        /// <summary>
//        /// Constructor. Parses the HtmlDocument to get all form input elements. 
//        /// </summary>
//        public FormElementCollection(HtmlDocument htmlDoc)
//        {
//            var inputs = htmlDoc.DocumentNode.Descendants("input");
//            foreach (var element in inputs)
//            {
//                string name = element.GetAttributeValue("name", "undefined");
//                string value = element.GetAttributeValue("value", "");
//                if (!name.Equals("undefined")) Add(name, value);
//            }
//        }

//        /// <summary>
//        /// Assembles all form elements and values to POST. Also html encodes the values.  
//        /// </summary>
//        public string AssemblePostPayload()
//        {
//            StringBuilder sb = new StringBuilder();
//            foreach (var element in this)
//            {
//                Microsoft.Extensions.WebEncoders.UrlEncoder t = new Microsoft.Extensions.WebEncoders.UrlEncoder();

//                string value = t.UrlEncode(element.Value);
//                sb.Append("&" + element.Key + "=" + value);
//            }
//            return sb.ToString().Substring(1);
//        }
//    }
//}
