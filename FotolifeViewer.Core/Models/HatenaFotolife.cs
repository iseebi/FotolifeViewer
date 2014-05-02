using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FotolifeViewer.Core.Models
{
    public static class HatenaFotolife
    {
        const string rssNs = "{http://purl.org/rss/1.0/}";
        const string contentNs = "{http://purl.org/rss/1.0/modules/content/}";
        const string dcNs = "{http://purl.org/dc/elements/1.1/}";
        const string hatenaNs = "{http://www.hatena.ne.jp/info/xmlns#}";

        public static async Task<IEnumerable<HatenaFotolifeItem>> FetchHotfotosAsync()
        {
            var client = new HttpClient();
            using (var stream = await client.GetStreamAsync("http://f.hatena.ne.jp/hotfoto?mode=rss"))
            {
                var root = XElement.Load(stream);
                return root.Descendants(rssNs + "item").Select(e => new HatenaFotolifeItem {
                    Title = e.Element(rssNs + "title").Value,
                    Link = e.Element(rssNs + "link").Value,
                    Description = e.Element(rssNs + "description").Value,
                    Content = e.Element(contentNs + "encoded").Value,
                    Date = e.Element(dcNs + "date").Value,
                    ImageUrl = e.Element(hatenaNs + "imageurl").Value,
                    ImageUrlSmall = e.Element(hatenaNs + "imageurlsmall").Value,
                    ImageUrlMedium = e.Element(hatenaNs + "imageurlmedium").Value,
                    Syntax = e.Element(hatenaNs + "syntax").Value,
                    Colors = e.Element(hatenaNs + "colors").Descendants(hatenaNs + "color").Select(c => c.Value)
                });
            }
        }

    }
}

