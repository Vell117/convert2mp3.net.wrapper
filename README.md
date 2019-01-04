# convert2mp3.net.wrapper
Convert2mp3.net .NET Wrapper

**.NET Framework 4.0 required**

![image](https://user-images.githubusercontent.com/25367511/50703749-cedb6b00-105d-11e9-97ae-b8fe36b271da.png)

# Library Usage
```csharp
// 1. Create Converter instance, set events and start process
string url = "http://www.youtube.com/watch?v=Vhh_GeBPOhs";
string format = "mp3";
c2mp3 = new convert2mp3.Converter(url, format);
c2mp3.ConvertStart += C2mp3_ConvertStart;
c2mp3.WhenConverted += C2mp3_WhenConverted;
c2mp3.StartConverting();

...
// Events
private void C2mp3_ConvertStart()
{
  // Converting process started
}
private void C2mp3_WhenConverted(bool ok, string[] artist, string[] name, string album, bool cover, string playSrc)
{
  if(ok)
  {
    // Completed
  }
  else
  {
    // Error
  }
}
...

// 2. After process, we should apply tags and get final file link

bool UseAlbumCover = true;
var result = c2mp3.Finalize("Artist", "Name", "Album", UseAlbumCover);

string DownloadLink = result.Link;
string DownloadFileName = result.FileName;

// 3. Do everything you want with download link
using(WebClient client = new WebClient())
{
  client.DownloadFile(DownloadLink, DownloadFileName);
}
```

(C) Dz3n 2019

(C) [sudo ./hack.sh](https://www.youtube.com/channel/UCU40PNPpo8GBaWQwxtTCEQQ) 2019
