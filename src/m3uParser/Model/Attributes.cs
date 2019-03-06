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
            this.GroupTitle = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "grouptitle").Value;
            this.GuideTimeShiftingTV = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "tvgshift").Value;
            this.GuideIdentifierTV = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "tvgname").Value;
            this.Logo = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "tvglogo").Value;
            this.AudioTrack = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "audiotrack").Value;
            this.AspectRatio = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "aspectratio").Value;
            this.Id = this.AttributeList.FirstOrDefault(w => w.Key.ToLower().Replace("-", string.Empty) == "tvgid").Value;
        }

        public IEnumerable<KeyValuePair<string, string>> AttributeList { get; private set; }
        public string GroupTitle { get; private set; }
        public string GuideTimeShiftingTV { get; private set; }
        public string GuideIdentifierTV { get; private set; }
        public string Logo { get; private set; }
        public string AudioTrack { get; private set; }
        public string AspectRatio { get; private set; }
        public string Id { get; private set; }
    }
}