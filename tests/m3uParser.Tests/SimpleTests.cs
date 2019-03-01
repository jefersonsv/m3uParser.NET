using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Sprache;

namespace m3uParser.Tests
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void SimpleParseTest()
        {
            var m3u = M3U.ParseBytes(Sample.simple_vod_playlist);
        }

        [TestMethod]
        public void HeaderWithParametersTest()
        {
            var m3u = M3U.ParseText(Sample.header_with_parameters);
        }

        [TestMethod]
        public void ExtinfTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"#EXTINF:-1 tvgname=""Первый_канал"" tvglogo=""Первый канал"" grouptitle=""Каналы ЦЭТВ РТРС"" ,Первый канал");
            sb.AppendLine("http://192.168.1.1:4022/udp/225.77.225.2:5000");
            var res = LinesSpecification.Extinf.Parse(sb.ToString());
        }

        [TestMethod]
        public void ExtinfFirstLineTest()
        {
            var line = @"#EXTINF:-1 tvgname=""Первый_канал"" tvglogo=""Первый канал"" grouptitle=""Каналы ЦЭТВ РТРС"" ,Первый канал";
            var res = LinesSpecification.ExtinfFirstLine.Parse(line);
        }

        [TestMethod]
        public void HeaderTest()
        {
            var line = @"#EXTM3U url-tvg=""http://www.teleguide.info/download/new3/jtv.zip"" m3uautoload=1 cache=500 deinterlace=1 tvg-shift=0";
            var res = LinesSpecification.HeaderLine.Parse(line);
        }

        [TestMethod]
        public void AttributesTest()
        {
            var line = @"url-tvg=""http://www.teleguide.info/download/new3/jtv.zip"" m3uautoload=1 cache=500 deinterlace=1 tvg-shift=0";
            var res = PairsSpecification.Attributes.Parse(line);
        }

        [TestMethod]
        public void AttributeStringTest()
        {
            var line = @"url-tvg=""http://www.teleguide.info/download/new3/jtv.zip"" ";
            var res = PairsSpecification.Attribute.Parse(line);
        }

        [TestMethod]
        public void AttributeNumberTest()
        {
            var line = @"m3uautoload=1 ";
            var res = PairsSpecification.Attribute.Parse(line);
        }

        [TestMethod]
        public void NumberTest()
        {
            var line = @"231";
            var res = PrimitiveSpecification.ValueNumber.Parse(line);
        }

        [TestMethod]
        public void StringQuotedTest()
        {
            var line = @"""231 sdsdasdsadf """;
            var res = PrimitiveSpecification.ValueStringQuoted.Parse(line);
        }

        [TestMethod]
        public void DecimalSignedTest()
        {
            var line = @"-2";
            var res = PrimitiveSpecification.DecimalSigned.Parse(line);
        }
    }
}