using System;
using System.Collections.Generic;
using System.Text;

namespace m3uParser.Model
{
    public class InfoSet
    {
        public string Source { get; set; }

        public InfoSet(string source)
        {
            Source = source;
        }
    }
}
