using System;
using System.Collections.Generic;
using System.Text;
using Sprache;

namespace m3uParser
{
    public class Media
    {
        public decimal Duration { get; set; }

        public Title Title { get; set; }

        public string MediaFile { get; set; }

        public bool IsStream { get { return this.Duration <= 0; } }

        public Attributes Attributes { get; set; }

        internal Media(string source)
        {
            var media = LinesSpecification.Extinf.Parse(source);

            this.Duration = media.Duration;
            this.Title = media.Title;
            this.MediaFile = media.MediaFile;
            this.Attributes = media.Attributes;
        }

        internal Media(decimal duration, IEnumerable<KeyValuePair<string, string>> attributes, Title title, string mediafile)
        {
            Duration = duration;
            Title = title;
            MediaFile = mediafile;
            Attributes = new Attributes(attributes);
        }
    }
}