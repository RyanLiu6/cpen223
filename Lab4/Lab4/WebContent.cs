// Use this file as is. 

using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab4
{
    class WebContent
    {
        private readonly string responseBody;
        static readonly HttpClient client = new HttpClient();
        public WebContent(string url)
        {
            try
            {
                responseBody = GetURLContent(url).Result;
            }
            catch(ArgumentException ae)
            {
                Console.WriteLine($"Is the url correct? Exception: {ae.Message}");
            }
            catch(AggregateException ae)
            {
                Console.WriteLine($"Aggregate Exception: {ae.Message}");
            }
        }

        static async Task<string> GetURLContent(string url)
        {
            string response = "";
            try
            {
                response = await client.GetStringAsync(url);

                //uncomment this WriteLine if you want to see the document content
                //Console.WriteLine(response); 
            }
            catch (HttpRequestException hre)
            {
                Console.WriteLine("Problem with requesting the document: Exception Caught!");
                Console.WriteLine($"Exception Message: {hre.Message}");
            }
            return response;
        }
        public string GetWebContent()
        {
            return responseBody;
        }

    }
}
