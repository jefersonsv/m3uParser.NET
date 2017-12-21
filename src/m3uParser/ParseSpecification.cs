using Sprache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace m3uParser
{
    internal static class ParseSpecification
    {
        public static readonly Parser<Root> root =
                from header in Parse.String("#EXTM3U").Text()
                from endOfLine in Parse.LineEnd.Once().Optional()
                from blankLine in Parse.String(Environment.NewLine).Optional()
                from info in extinf.AtLeastOnce()
                select new Root(header, info);

        // https://stackoverflow.com/questions/21414309/sprache-parse-signed-integer
        public static readonly Parser<Media> extinf =
            from open in Parse.String("#EXTINF:").Text()
            from duration in decimalSigned.Once()
            from space in Parse.WhiteSpace.Once()
            from param in attributes.Many()
            from space1 in Parse.Char(',').Once()
            from title in title.Once()
            from newLine1 in Parse.LineEnd.Once()
            from media in Parse.CharExcept(Environment.NewLine).Many().Text()
            from ignore in Parse.CharExcept('#').Many()
            select new Media(duration.First(), param, title.First(), media);

        public static readonly Parser<Title> title =
            from raw in Parse.CharExcept(Environment.NewLine).Many().Text()
            select new Title(raw, raw);

        public static readonly Parser<string> key =
            from key in Parse.AnyChar.Except(Parse.Char('=').Or(Parse.Char(','))).Many().Text()
            select key.Trim();

        public static readonly Parser<string> value =
            from open in Parse.Char('"').Once()
            from value in Parse.CharExcept('"').Many().Text()
            from close in Parse.Char('"').Once()
            select value;

        // https://gitter.im/sprache/Sprache/archives/2017/02/20
        public static readonly Parser<KeyValuePair<string, string>> attributes =
            from key in key
            from assignment in Parse.Char('=')
            from value in value
            select new KeyValuePair<string, string>(key, value);

        public static readonly Parser<decimal> decimalSigned =
            from op in Parse.Optional(Parse.Char('-').Token())
            from num in Parse.Decimal
            select decimal.Parse(num) * (op.IsDefined ? -1 : 1);
    }
}