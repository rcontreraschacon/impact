using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml;
using Application.Interfaces;
using Newtonsoft.Json;
using Formatting = Newtonsoft.Json.Formatting;

namespace Infrastructure.Feeds
{
    public class FeedAccessor : IFeedAccessor
    {
        private readonly HttpClient _client;

        public FeedAccessor()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetFeeds(string url)
        {
            string result = null;

            try
            {
                var response = await _client.GetAsync(url);
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var feedString = await response.Content.ReadAsStringAsync();
                    XmlDocument doc = new XmlDocument();
                    doc.LoadXml(feedString);
                    var nodes = doc.SelectSingleNode("rss/channel");
                    result = JsonConvert.SerializeXmlNode(nodes, Formatting.None, true);
                }
                else
                {
                    return result;
                }
            }
            catch (System.Exception)
            {
                
            }


            return result;
        }
    }
}
