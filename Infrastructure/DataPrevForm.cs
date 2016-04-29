using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;

namespace WebCrawlerDataPrev.Infrastructure
{
    public class DataPrevForm
    {
        public string JIdt { get; private set; }
        public string Token { get; private set; }
        public string SessionId { get; private set; }
        public string ViewState { get; private set; }

        public void Init()
        {
            var htmlDoc = new HtmlDocument();
            htmlDoc.LoadHtml(new WebClient().DownloadString("http://www8.dataprev.gov.br/SipaINSS/pages/hiscre/hiscreInicio.xhtml"));

            GetJIdt(htmlDoc.DocumentNode);
            GetToken(htmlDoc.DocumentNode);
            GetSessionId(htmlDoc.DocumentNode);
            GetViewState(htmlDoc.DocumentNode);
        }

        private void GetViewState(HtmlNode node)
        {
            var field_ViewState = node
                .Descendants("input")
                .Where(n => n.GetAttributeValue("name", "").Contains("javax.faces.ViewState"))
                .FirstOrDefault();

            ViewState = "javax.faces.ViewState=" + field_ViewState.GetAttributeValue("value", "");
        }

        private void GetSessionId(HtmlNode node)
        {
            //var urls = document.DocumentNode.Descendants("img")
            //                    .Select(e => e.GetAttributeValue("src", null))
            //                    .Where(s => !String.IsNullOrEmpty(s));


            var field_ViewState = node
                .Descendants("img")
                .Select(n => n.GetAttributeValue("src", null))
                .Where(s => !String.IsNullOrEmpty(s))
                .FirstOrDefault();

            //ViewState = "javax.faces.ViewState=" + field_ViewState.GetAttributeValue("value", "");
        }

        private void GetToken(HtmlNode node)
        {
            var field_Token = node
                .Descendants("input")
                .Where(n => n.GetAttributeValue("name", "").Contains("DTPINFRA_TOKEN"))
                .FirstOrDefault();

            Token = field_Token.GetAttributeValue("value", "");
        }

        private void GetJIdt(HtmlNode node)
        {
            var field_jIdt = node
                .Descendants("input")
                .Where(n => n.GetAttributeValue("value", "").Contains("j_idt"))
                .FirstOrDefault();

            JIdt = field_jIdt.GetAttributeValue("value", "");
        }
    }
}