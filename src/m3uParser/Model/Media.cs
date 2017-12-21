using System;
using System.Collections.Generic;
using System.Text;

namespace m3uParser
{
    public class Media
    {
        public decimal Duration { get; set; }

        public Title Title { get; set; }

        public string MediaFile { get; set; }

        public bool IsStream { get { return this.Duration <= 0; } }

        public AttributeInfo AttributeInfo { get; set; }

        internal Media(decimal duration, IEnumerable<KeyValuePair<string, string>> attributes, Title title, string mediafile)
        {
            AttributeInfo = new AttributeInfo();
            Duration = duration;
            Title = title;
            MediaFile = mediafile;
            AttributeInfo.Attributes = attributes;
        }
    }
}