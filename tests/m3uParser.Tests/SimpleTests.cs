using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using Sprache;
using System.Linq;

namespace m3uParser.Tests
{
    [TestClass]
    public class SimpleTests
    {
        [TestMethod]
        public void InfoSetTest()
        {
            var a1 = SegmentSpecification.SegmentCollection.Parse(Sample.simple_vod);
            var a2 = SegmentSpecification.SegmentCollection.Parse(Sample.header_with_parameters);

            a1.ToList().ForEach(a => Console.WriteLine(a));
        }

        [TestMethod]
        public void AllTests()
        {
            var simple_vod = M3U.Parse(Sample.simple_vod);
            Assert.AreEqual(simple_vod.PlayListType, "VOD");
            Assert.AreEqual(simple_vod.Medias.Last().Duration, 9);

            var format_specs = M3U.Parse(Sample.format_specs);
            Assert.AreEqual(format_specs.Medias.Last().MediaFile, "udp://225.55.55.4:1234");
            Assert.AreEqual(format_specs.Medias.Last().Title.RawTitle, "MTV");
            
            var sample_paste_bin = M3U.Parse(Sample.sample_paste_bin);
            Assert.AreEqual(sample_paste_bin.Medias.ElementAt(10).Attributes.TvgLogo, "http://greektv.pbworks.com/f/ANT1.png");

            var header_with_parameters = M3U.Parse(Sample.header_with_parameters);
            Assert.AreEqual(header_with_parameters.Attributes.Cache, 500);

            var iptv_sample = M3U.Parse(Sample.iptv_sample);
            Assert.AreEqual(iptv_sample.Medias.ElementAt(2).Attributes.TvgShift, "+1");

            var big_list = M3U.Parse(Sample.big_list);
            Assert.AreEqual(big_list.Medias.Count(), 902);
        }

        [TestMethod]
        public void HeaderWithParametersTest()
        {
            var m3u = M3U.Parse(Sample.header_with_parameters);
            Assert.AreEqual(m3u.Attributes.Cache, 500);
        }

        [TestMethod]
        public void ExtinfTest()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(@"-1 tvgname=""Первый_канал"" tvglogo=""Первый канал"" grouptitle=""Каналы ЦЭТВ РТРС"" ,Первый канал");
            sb.AppendLine("http://192.168.1.1:4022/udp/225.77.225.2:5000");
            var res = LinesSpecification.Extinf.Parse(sb.ToString());

            Assert.AreEqual(res.MediaFile, "http://192.168.1.1:4022/udp/225.77.225.2:5000");
            Assert.AreEqual(res.Duration, -1);
            Assert.AreEqual(res.IsStream, true);
            Assert.AreEqual(res.Title.InnerTitle, "Первый канал");
            Assert.AreEqual(res.Title.RawTitle, "Первый канал");
            Assert.AreEqual(res.Attributes.Logo, "Первый канал");
        }

        [TestMethod]
        public void ExtinfFirstLineTest()
        {
            var line = @"-1 tvgname=""Первый_канал"" tvglogo=""Первый канал"" grouptitle=""Каналы ЦЭТВ РТРС"" ,Первый канал";
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