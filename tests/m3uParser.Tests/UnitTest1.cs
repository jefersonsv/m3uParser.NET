using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;

namespace m3uParser.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SimpleTest()
        {
            var m3u = M3U.ParseBytes(Sample.simple_vod_playlist);
        }
    }
}