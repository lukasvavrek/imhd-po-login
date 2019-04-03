using System;
using System.Net.Http;
using System.Text;

namespace imhd_po
{
    class Program
    {
        static void Main(string[] args)
        {
            var handler = new HttpClientHandler();
            handler.UseCookies = false;
            handler.AllowAutoRedirect = false; 

            using (var httpClient = new HttpClient(handler))
            {
                using (var request = new HttpRequestMessage(new HttpMethod("POST"), "https://imhd.sk/po/prihlasenie.php?target=prihlasenie"))
                {
                    request.Headers.TryAddWithoutValidation("Cache-Control", "max-age=0");
                    request.Headers.TryAddWithoutValidation("Connection", "keep-alive");
                    request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml;q=0.9,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3");
                    request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate, br");
                    request.Headers.TryAddWithoutValidation("Accept-Language", "sk-SK,sk;q=0.9,en-US;q=0.8,en;q=0.7,cs;q=0.6");
                    request.Headers.TryAddWithoutValidation("Referer", "https://imhd.sk/po/prihlasenie");
                    request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_14_4) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/73.0.3683.86 Safari/537.36");
                    request.Headers.TryAddWithoutValidation("Origin", "https://imhd.sk");
                    request.Headers.TryAddWithoutValidation("Upgrade-Insecure-Requests", "1");
                    request.Headers.TryAddWithoutValidation("Cookie", "testCookie=1; _ga=GA1.2.84820506.1554305513; _gid=GA1.2.1519801519.1554305513; testCookie=1; __gfp_64b=6Ee31rcnaM7QbPsVd88sP4w6RNkQGI8LDWvB9SWxwSr.Z7; cookie_notice=1; default_web=po; PHPSESSID=r411c2uih7co52idgpg45n0ns4; _gat=1"); 

                    request.Content = new StringContent("login=plavcik30&heslo=PLzEZRhL8RZLw5K", Encoding.UTF8, "application/x-www-form-urlencoded"); 

                    var response = httpClient.SendAsync(request).Result;
                    foreach (var header in response.Headers)
                    {
                        Console.WriteLine($"{header.Key}"); 
                        foreach (var value in header.Value)
                        {
                            Console.WriteLine($"\t{value}"); 
                        }
                    }
                }
            }
        }
    }
}
