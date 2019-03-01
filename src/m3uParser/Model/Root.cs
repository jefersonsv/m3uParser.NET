using Sprache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace m3uParser
{
    public class Root
    {
        public string Header { get; set; }

        public AttributeInfo HeaderAttributeInfo { get; set; }

        public IEnumerable<Media> Media { get; set; }

        internal Root(string header, IEnumerable<Media> media, AttributeInfo headerAttributeInfo)
        {
            Header = header;
            Media = media;
            HeaderAttributeInfo = headerAttributeInfo;
        }
    }
}