using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

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
    }
}