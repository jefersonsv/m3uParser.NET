using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m3uParser
{
    public class Attributes
    {
        internal Attributes(IEnumerable<KeyValuePair<string, string>> attributes)
        {
            this.AttributeList = attributes;

            // Obsoletes
            this.GuideTimeShiftingTV = GetOrNull("tvgshift");
            this.GuideIdentifierTV = GetOrNull("tvgname");
            this.Logo = GetOrNull("tvglogo");
            this.Id = GetOrNull("tvgid");

            this.GroupTitle = GetOrNull(nameof(this.GroupTitle));
            this.TvgShift = GetOrNull(nameof(this.TvgShift));
            this.TvgName = GetOrNull(nameof(this.TvgName));
            this.TvgLogo = GetOrNull(nameof(this.TvgLogo));
            this.AudioTrack = GetOrNull(nameof(this.AudioTrack));
            this.AspectRatio = GetOrNull(nameof(this.AspectRatio));
            this.TvgId = GetOrNull(nameof(this.TvgId));
            this.UrlTvg = GetOrNull(nameof(this.UrlTvg));
            this.M3UAutoLoad = ConvertIntOrNull(GetOrNull(nameof(this.M3UAutoLoad)));
            this.Cache = ConvertIntOrNull(GetOrNull(nameof(this.Cache)));
            this.Deinterlace = ConvertIntOrNull(GetOrNull(nameof(this.Deinterlace)));
            this.Refresh = ConvertIntOrNull(GetOrNull(nameof(this.Refresh)));
            this.ChannelNumber = ConvertIntOrNull(GetOrNull(nameof(this.ChannelNumber)));
        }

        string GetOrNull(string name)
        {
            return this.AttributeList?
                .FirstOrDefault(w => w.Key?.ToLower()?.Replace("-", string.Empty) == name.ToLower())
                .Value;
        }

        int? ConvertIntOrNull(string value)
        {
            int num;
            if (int.TryParse(value, out num))
                return num;

            return null;
        }

        public IEnumerable<KeyValuePair<string, string>> AttributeList { get; private set; }
        public string GroupTitle { get; private set; }

        [Obsolete("Change to: TvgShift property")]
        public string GuideTimeShiftingTV { get; private set; }
        public string TvgShift { get; private set; }

        [Obsolete("Change to: TvgName property")]
        public string GuideIdentifierTV { get; private set; }
        public string TvgName { get; private set; }

        [Obsolete("Change to: TvgLogo property")]
        public string Logo { get; private set; }
        public string TvgLogo { get; private set; }

        public string AudioTrack { get; private set; }
        public string AspectRatio { get; private set; }
        [Obsolete("Change to: TvgId property")]
        public string Id { get; private set; }

        public string TvgId { get; private set; }
        public string UrlTvg { get; private set; }
        public int? M3UAutoLoad { get; private set; }
        public int? Cache { get; private set; }
        public int? Deinterlace { get; private set; }
        public int? Refresh { get; private set; }
        public int? ChannelNumber { get; private set; }
    }
}