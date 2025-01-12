using Microsoft.AspNetCore.Mvc;
using MyXmlMvcApp.Services;

namespace MyXmlMvcApp.Controllers
{
    public class XmlDataController : Controller
    {
        private readonly XmlService _xmlService;

        public XmlDataController(XmlService xmlService)
        {
            _xmlService = xmlService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var data = _xmlService.GetXmlData("https://receiptservice.egretail.cloud/ARTSPOSLogSchema/2.2.1");
            return View(data);
        }
    }
}