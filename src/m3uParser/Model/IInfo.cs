using System;
using System.Collections.Generic;
using System.Text;

namespace m3uParser.Model
{
    public interface IInfo
    {
        string Source { get; set; }
        IEnumerable<string> Attributes { get; set; }
        string Type { get; set; }
        string Value { get; set; }
    }
}
