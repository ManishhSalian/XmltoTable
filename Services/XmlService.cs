using System.Net.Http;
using System.Xml.Linq;

namespace MyXmlMvcApp.Services
{
    public class XmlService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public XmlService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public List<(string Element, string Description)> GetXmlData(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var response = client.GetStringAsync(url).Result;
            var xDocument = XElement.Parse(response);

            // Extract data with annotation/documentation
            var data = xDocument
                .Descendants()
                .Where(e => e.Name.LocalName == "simpleType" || e.Name.LocalName == "enumeration")
                .Select(e => (
                    Element: e.Attribute("name")?.Value ?? e.Attribute("value")?.Value ?? "Unknown",
                    Description: e.Descendants()
                                  .FirstOrDefault(d => d.Name.LocalName == "documentation")?.Value
                                  ?? "No documentation provided"
                ))
                .Where(item => item.Description != "No documentation provided") // Only include entries with documentation
                .ToList();

            return data;
        }
    }
}