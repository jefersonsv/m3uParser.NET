using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using m3uParser.Model;
using Sprache;

namespace m3uParser.tool
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var simpleVodM3u = M3U.Parse(simpleVod);
            var headerParameterM3u = M3U.Parse(headerParameter);

            var urls = new List<string>();
            urls.Add("https://pastebin.com/raw/gavXcCcQ");
            urls.Add("http://bit.ly/2F3aZVH");
            urls.Add("http://bit.ly/despotes455");
            urls.Add("http://bit.ly/pastebintvaaa");
            urls.Add("http://bit.ly/googletv55");
            urls.Add("http://bit.ly/graduelas55");
            urls.Add("http://bit.ly/srvista");
            urls.Add("http://bit.ly/tpiptv456");
            urls.Add("http://bit.ly/extraiptv85");
            urls.Add("http://bit.ly/gstatic85");
            urls.Add("http://bit.ly/listaiptvtv58");
            urls.Add("http://bit.ly/iptvstreaming56");

            var lists = new List<Extm3u>();
            urls.ToList().ForEach(a => {
                try
                {
                    lists.Add(M3U.ParseFromUrlAsync(a).Result);
                }
                catch { }
            });
        }

        static readonly string simpleVod = @"#EXTM3U
#EXT-X-PLAYLIST-TYPE:VOD
#EXT-X-TARGETDURATION:10
#EXT-X-VERSION:3

##COMMENT

#EXT-X-MEDIA-SEQUENCE:0
#EXTINF:10.0,
http://example.com/movie1/fileSequenceA.ts
#EXTINF:10.0,
http://example.com/movie1/fileSequenceB.ts



#EXTINF:10.0,
http://example.com/movie1/fileSequenceC.ts


#EXTINF:9.0,

http://example.com/movie1/fileSequenceD.ts

#EXT-X-ENDLIST";

            static readonly string headerParameter = @"#EXTM3U url-tvg=""http://www.teleguide.info/download/new3/jtv.zip"" m3uautoload=1 cache=500 deinterlace=1 tvg-shift=0
#EXTINF:-1 tvgname=""Первый_канал"" tvglogo=""Первый канал"" grouptitle=""Каналы ЦЭТВ РТРС"" ,Первый канал
http://192.168.1.1:4022/udp/225.77.225.1:5000
#EXTINF:-1 tvg-name=""Россия_1"" tvg-logo=""Россия"" ,Россия
http://192.168.1.1:4022/udp/225.77.225.2:5000
#EXTINF:-1 tvg-name=""Матч!"" tvg-logo=""Матч ТВ"" ,Матч ТВ
http://192.168.1.1:4022/udp/225.77.225.3:5000";
    }
}