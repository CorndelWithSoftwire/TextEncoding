using System;
using System.IO;
using System.Net;
using System.Text;

namespace TextEncoding
{
  class Program
  {
    static void Main(string[] args)
    {
      var client = new WebClient {Encoding = Encoding.UTF8};
      var htmlText = client.DownloadString("https://en.wikipedia.org/wiki/Unicode");

      File.WriteAllText("Unicode.1.html", htmlText, Encoding.Unicode);

      /*
       * It's interesting to compare the file sizes of this lot:
       * 
      File.WriteAllText("Unicode.ASCII.html", htmlText, Encoding.ASCII);
      File.WriteAllText("Unicode.UTF8.html", htmlText, Encoding.UTF8);
      File.WriteAllText("Unicode.UTF16.html", htmlText, Encoding.Unicode);
      File.WriteAllText("Unicode.UTF32.html", htmlText, Encoding.UTF32);
      File.WriteAllText("Unicode.Latin1.html", htmlText, Encoding.GetEncoding("Latin1"));
      */

      var fileBytes = File.ReadAllBytes("Unicode.1.html");
      var shorterFileBytes = new byte[fileBytes.Length - 2];
      Array.Copy(fileBytes, 2, shorterFileBytes, 0, shorterFileBytes.Length);
      File.WriteAllBytes("Unicode.2.html", shorterFileBytes);

      var finalText = File.ReadAllText("Unicode.2.html", Encoding.UTF8);
      File.WriteAllText("Unicode.3.html", finalText, Encoding.Unicode);
    }
  }
}
