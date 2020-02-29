using System.IO;
using System.Net;
using System.Linq;
using System.Collections.Generic;

namespace Utility
{
  static class Tools
  {
    public static IEnumerable<string> Update(this IEnumerable<string> list)
    {
      var output = from x in list where !x.Any(char.IsDigit) select x;
      return output;
    }
    public static void WriteOnly(string partOfSpeech, string fileName)
    {
      var wc = new WebClient();
      var everyWord = wc.DownloadString("https://raw.githubusercontent.com/sujithps/Dictionary/master/Oxford%20English%20Dictionary.txt").SeperateBy("\n");
      var words = from x in everyWord where x.Contains(" " + partOfSpeech) && x.SeperateBy(" " + partOfSpeech + " ")[0].SeperateBy(" ").Count < 5 select x.SeperateBy(" " + partOfSpeech + " ")[0];
      File.WriteAllLines("partsofspeech/" + fileName + ".txt", words.Update());
    }
  }
}