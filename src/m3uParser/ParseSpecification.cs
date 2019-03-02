using m3uParser.Model;
using Sprache;

using System;
using System.Collections.Generic;
using System.Linq;

namespace m3uParser
{
    public static class PrimitiveSpecification
    {
        public static readonly Parser<string> ValueNumber =
            from value in Parse.Number.Text()
            select value;

        public static readonly Parser<string> ValueStringQuoted =
            from open in Parse.Char('"').Once()
            from value in Parse.CharExcept('"').Many().Text()
            from close in Parse.Char('"').Once()
            select value;

        public static readonly Parser<decimal> DecimalSigned =
            from op in Parse.Optional(Parse.Char('-').Token())
            from num in Parse.Decimal
            select decimal.Parse(num) * (op.IsDefined ? -1 : 1);
    }

    public static class PairsSpecification
    {
        public static readonly Parser<string> KeyAttribute =
            from key in Parse.AnyChar.Except(Parse.Char(' ').Or(Parse.Char('=')).Or(Parse.Char(','))).Many().Text()
            select key;

        public static readonly Parser<KeyValuePair<string, string>> Attribute =
            from space in Parse.WhiteSpace.Optional()
            from key in KeyAttribute
            from assignment in Parse.Char('=')
            from value in PrimitiveSpecification.ValueStringQuoted.Optional().Or(PrimitiveSpecification.ValueNumber.Optional())
            from space2 in Parse.WhiteSpace.Optional()
            select new KeyValuePair<string, string>(key, value.GetOrDefault());

        // https://gitter.im/sprache/Sprache/archives/2017/02/20
        public static readonly Parser<List<KeyValuePair<string, string>>> Attributes =
            from space in Parse.WhiteSpace.Optional()
            from att in PairsSpecification.Attribute.Many()
            from space2 in Parse.WhiteSpace.Optional()
            select new List<KeyValuePair<string, string>>(att);
    }

    public static class LinesSpecification
    {
        public static readonly Parser<List<KeyValuePair<string, string>>> HeaderLine =
                from header in Parse.String("#EXTM3U").Text()
                from param in PairsSpecification.Attributes.Token()
                from endOfLine in Parse.LineEnd.Optional()
                select new List<KeyValuePair<string, string>>(param);

        // https://stackoverflow.com/questions/21414309/sprache-parse-signed-integer
        public static readonly Parser<Media> ExtinfFirstLine =
            from open in Parse.String("#EXTINF:").Text()
            from duration in PrimitiveSpecification.DecimalSigned.Once()
            from param in PairsSpecification.Attributes.Token()
            from space2 in Parse.Char(',').Optional()
            from title in Title.Token()
            select new Media(duration.First(), param, title, null);

        public static readonly Parser<Title> Title =
            from raw in Parse.CharExcept(Environment.NewLine).Many().Text()
            select new Title(raw, raw);

        // https://stackoverflow.com/questions/21414309/sprache-parse-signed-integer
        public static readonly Parser<Media> Extinf =
            from first in LinesSpecification.ExtinfFirstLine.Token()
            from media in Parse.CharExcept(Environment.NewLine).Many().Text()
            from ignore in Parse.CharExcept('#').Many()
            select new Media(first.Duration, first.AttributeInfo.Attributes, first.Title, first.MediaFile);
    }

    public static class ParseSpecification
    {
        public static readonly Parser<Root> root =
                from header in LinesSpecification.HeaderLine.Token()
                from blankLine in Parse.String(Environment.NewLine).Optional()
                from info in LinesSpecification.Extinf.AtLeastOnce()
                select new Root(string.Empty, info, new AttributeInfo(header));
    }

    public static class GenericSpecification
    {
        public static readonly Parser<InfoSet> InfoSet =
                from header in Parse.Chars(new char[] { '\r', '\n', '#' }).Once()
                from content in Parse.CharExcept(new char[] { '#' }).Many().Text()
                select new InfoSet(string.Concat(content));

        public static readonly Parser<IEnumerable<InfoSet>> InfoSetCollection =
                from collection in InfoSet.Many()
                select collection;

        public static readonly Parser<Extm3u> Init =
                from collection in InfoSet.Many()
                select new Extm3u();
    }
}