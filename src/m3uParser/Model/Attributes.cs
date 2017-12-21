using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m3uParser
{
    /// <summary>
    /// https://en.wikipedia.org/wiki/M3U
    /// https://github.com/sprache/Sprache
    /// https://tools.ietf.org/html/draft-pantos-http-live-streaming-23#section-4.2
    /// http://ss-iptv.com/en/users/documents/m3u
    /// https://developer.apple.com/library/content/technotes/tn2288/_index.html
    /// </summary>
    public class AttributeInfo
    {
        public IEnumerable<KeyValuePair<string, string>> Attributes { get; set; }
        public string GroupTitle { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "group-title").Value; } }
        public string GuideTimeShiftingTV { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "tvg-shift").Value; } }
        public string GuideIdentifierTV { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "tvg-name").Value; } }
        public string Logo { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "tvg-logo").Value; } }
        public string AudioTrack { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "audio-track").Value; } }
        public string AspectRatio { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "aspect-ratio").Value; } }
        public string Id { get { return this.Attributes.FirstOrDefault(w => w.Key.ToLower().Trim() == "tvg-id").Value; } }
    }
}