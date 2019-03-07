# m3uParser
A dotnet parser for M3U file format

# Getting Started

> File: simple-vod.txt

```m3u
#EXTM3U
#EXT-X-PLAYLIST-TYPE:VOD
#EXT-X-TARGETDURATION:10
#EXT-X-VERSION:3
#EXT-X-MEDIA-SEQUENCE:0
#EXTINF:10.0,
http://example.com/movie1/fileSequenceA.ts
#EXTINF:10.0,
http://example.com/movie1/fileSequenceB.ts
#EXTINF:10.0,
http://example.com/movie1/fileSequenceC.ts
#EXTINF:9.0,
http://example.com/movie1/fileSequenceD.ts
#EXT-X-ENDLIST
```

> File: header-parameter.txt

```m3u
#EXTM3U url-tvg="http://www.website.com" m3uautoload=1 cache=500 deinterlace=1 tvg-shift=0
#EXTINF:-1 tvgname="name tv" tvglogo="logo tv" grouptitle="group" ,Title Raw
http://192.168.1.1:4022/udp/225.50.125.10:5000
```

```c#
var content = @"#EXTM3U

#EXTINF:123, Sample artist - Sample title
C:\Documents and Settings\I\My Music\Sample.mp3

#EXTINF:321,Example Artist - Example title
C:\Documents and Settings\I\My Music\Greatest Hits\Example.ogg
";

var contentM3u = M3U.Parse(content);
var simpleVodM3u = M3U.ParseFromFile("simpleVod.txt");
var simpleVodM3u = M3U.ParseFromFile("headerParameter.txt");
```

# Features

* Parse m3u settings: PlayListType, TargetDuration, Version, MediaSequence and attributes
* Parse m3u media list: Duration, Title, MediaFile, IsStream and attributes
* Every else will be parsed in warning list

# Nuget Package
[![NuGet](https://img.shields.io/nuget/v/m3uParser.NET.svg)](https://www.nuget.org/packages/m3uParser.NET) 

```
PM> Install-Package m3uParser.NET
```

# Code Size
Little size codebase

![GitHub code size in bytes](https://img.shields.io/github/languages/code-size/jefersonsv/m3uparser.svg)

# Build Status
![AppVeyor](https://img.shields.io/appveyor/ci/jefersonsv/m3uparser.svg)

# Licence
![GitHub](https://img.shields.io/github/license/jefersonsv/m3uparser.svg)

# Thanks
https://github.com/sprache/Sprache
https://cakebuild.net