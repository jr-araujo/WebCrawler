using System.Collections.Generic;
using Microsoft.AspNet.Mvc;
using HtmlAgilityPack;
using System.Text;

namespace WebCrawlerDataPrev.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        public ValuesController()
        {
            //DataPrevForm dataPrevForm = new DataPrevForm();
            //dataPrevForm.Init();

            var html = new HtmlDocument();
            html.Load(@"C:\Users\jose.araujo\Desktop\Htmls DataPrev\Formulario DataPrev\FormularioDataPrev.html", Encoding.GetEncoding("Windows-1252"), true);
            var root = html.DocumentNode;

            //var htmlDoc = new HtmlDocument();
            //htmlDoc.LoadHtml(new WebClient().DownloadString("http://www8.dataprev.gov.br/SipaINSS/pages/hiscre/hiscreInicio.xhtml"));

            //var root = htmlDoc.DocumentNode;

            //var field_jIdt = htmlDoc.DocumentNode
            //    .Descendants("input")
            //    .Where(n => n.GetAttributeValue("value", "").Contains("j_idt"))
            //    .FirstOrDefault();
            //var valueJIdt = field_jIdt.GetAttributeValue("value", "");

            //var field_token = htmlDoc.DocumentNode
            //   .Descendants("input")
            //   .Where(n => n.GetAttributeValue("name", "").Contains("javax.faces.ViewState"))
            //   .FirstOrDefault();

            //var Token = "javax.faces.ViewState=" + field_token.GetAttributeValue("value", "");

            //var inputs = htmlDoc.DocumentNode
            //    .Descendants("input");
            //foreach (var element in inputs)
            //{
            //    string name = element.GetAttributeValue("name", "undefined");
            //    string value = element.GetAttributeValue("value", "");                
            //}

            //var html = htmlDoc.DocumentNode.InnerHtml;

            //return Ok(html.DocumentNode.InnerHtml);
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
