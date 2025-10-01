using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq; // Install Newtonsoft.Json via NuGet

class Program
{
    static async Task Main(string[] args)
    {
        string apiKey = "jWoqt380wa0xYaEWb4lrKbYBgaqM7N6U";

        // Example point in downtown Cincinnati (lat, lon)
        double latitude = 39.1031;
        double longitude = -84.5120;

        string url = $"https://api.tomtom.com/traffic/services/4/flowSegmentData/absolute/10/json?point={latitude},{longitude}&unit=KMPH&key={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();
                JObject data = JObject.Parse(jsonString);
                Console.WriteLine(data.ToString());
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode}");
                string errorDetails = await response.Content.ReadAsStringAsync();
                Console.WriteLine(errorDetails);
            }
        }
    }
}
