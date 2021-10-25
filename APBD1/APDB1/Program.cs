using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace APDB1
{
    public class Crawler
    {
        public static async Task Main(string[] args)
        {
            String url;
            try { 
                url = args[0];
            }catch (ArgumentNullException e) {
               Console.WriteLine("Brak argumentu");
               throw;
            }

            if (!CheckUrlValid(url))
            {
                throw new ArgumentException("Nieprawidlowy url");
            }
            HttpClient httpClient = new HttpClient(); 
            HttpResponseMessage response = await httpClient.GetAsync(url);
            if (!response.IsSuccessStatusCode) {
                Console.WriteLine("Błąd w czasie pobierania strony");
            }

            String content = await httpClient.GetStringAsync(url);
            httpClient.Dispose();
            const string matchEmailPattern =
                @"(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
                + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
                + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
                + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})";
            Regex rx = new Regex(matchEmailPattern,  RegexOptions.Compiled | RegexOptions.IgnoreCase);
            MatchCollection matches = rx.Matches(content);
            if (matches.Count == 0)
            {
                Console.WriteLine("nie znaleziono adresów email");
            }

            String copyChecker = "";
            foreach (Match match in matches)
            {
                if (!match.Value.Equals(copyChecker))
                {
                    Console.WriteLine(match.Value);   
                }
                copyChecker = match.Value;
            }
        }
        public static bool CheckUrlValid(string source) => Uri.TryCreate(source, UriKind.Absolute, out Uri uriResult) && uriResult.Scheme == Uri.UriSchemeHttps;
    }
}