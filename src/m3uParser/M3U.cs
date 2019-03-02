using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace m3uParser
{
    /// <summary>
    /// https://developer.apple.com/documentation/http_live_streaming/example_playlists_for_http_live_streaming/event_playlist_construction
    /// https://tools.ietf.org/html/draft-pantos-http-live-streaming-23#page-12
    /// </summary>
    public static class M3U
    {
        public static Root ParseText(string text)
        {
            // Clear comments
            Regex commentRegex = new Regex("##{1,}.*");
            text = commentRegex.Replace(text, string.Empty);

            // Parse EXTINF
            return ParseSpecification.root.Parse(text);
        }

        public static Root ParseBytes(byte[] byteArr)
        {
            return ParseText(Encoding.Default.GetString(byteArr));
        }

        public static Root ParseFromFile(string file)
        {
            return ParseText(System.IO.File.ReadAllText(file));
        }

        public static async Task<Root> ParseFromUrlAsync(string requestUri)
        {
            return await ParseFromUrlAsync(requestUri, new HttpClient());
        }

        public static async Task<Root> ParseFromUrlAsync(string requestUri, HttpClient client)
        {
            var get = await client.GetAsync(requestUri);
            var content = await get.Content.ReadAsStringAsync();
            return ParseText(content);
        }
    }
}