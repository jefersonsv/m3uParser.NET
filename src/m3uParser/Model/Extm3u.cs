using System;
using System.Collections.Generic;
using System.Text;

namespace m3uParser.Model
{
    public class Extm3u
    {
        public string PlayListType { get; set; }
        public int? TargetDuration { get; set; }
        public int? Version { get; set; }
        public int? MeidaSequence { get; set; }
        public IEnumerable<KeyValuePair<string, string>> Attributes { get; set; }
        public IEnumerable<Media> Medias { get; set; }
    }
}
