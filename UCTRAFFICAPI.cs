using System;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Maui.Controls;

namespace UCTrafficApp;

public partial class MainPage : ContentPage
{
    // Your TomTom API Key
    private const string ApiKey = "jWoqt380wa0xYaEWb4lrKbYBgaqM7N6U";

    public MainPage()
    {
        InitializeComponent();
        LoadTrafficData();
    }

    private async void LoadTrafficData()
    {
        try
        {
            // Downtown Cincinnati coordinates
            double latitude = 39.1031;
            double longitude = -84.5120;

            string url = $"https://api.tomtom.com/traffic/services/4/flowSegmentData/absolute/10/json?point={latitude},{longitude}&unit=KMPH&key={ApiKey}";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                string jsonString = await response.Content.ReadAsStringAsync();

                // Parse JSON
                using JsonDocument doc = JsonDocument.Parse(jsonString);
                JsonElement root = doc.RootElement;

                // Display formatted JSON in the Label
                TrafficDataLabel.Text = JsonSerializer.Serialize(root, new JsonSerializerOptions { WriteIndented = true });
            }
            else
            {
                TrafficDataLabel.Text = $"Error: {response.StatusCode}\n{await response.Content.ReadAsStringAsync()}";
            }
        }
        catch (Exception ex)
        {
            TrafficDataLabel.Text = $"Exception: {ex.Message}";
        }
    }
}
