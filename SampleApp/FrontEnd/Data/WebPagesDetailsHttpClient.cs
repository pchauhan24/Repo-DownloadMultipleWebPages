using System;

namespace FrontEnd.Data;

public class WebPagesDetailsHttpClient
{
    private HttpClient _httpClient;
    private ILogger<WebPagesDetailsHttpClient> _logger;

    public WebPagesDetailsHttpClient(HttpClient httpClient, ILogger<WebPagesDetailsHttpClient> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    // public async Task<WebPagesDetails[]> GetForecastAsync(DateTime? startDate)
    //     => await _httpClient.GetFromJsonAsync<WebPagesDetails[]>($"WeatherForecast?startDate={startDate}") ?? [];


    public async Task<string> GetWebPageStringAsync(string webPageURL)
    {
        HttpResponseMessage response = await _httpClient.GetAsync(webPageURL);
        string output;

        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("File found");

            // Get the data
            byte[] data = await response.Content.ReadAsByteArrayAsync();
            // Save it to a file
            //FileStream fStream = File.Create(webPageURL + ".html");
            //await fStream.WriteAsync(data, 0, data.Length);
            //fStream.Close();

            Console.WriteLine("File download Completed!");

            output = "File download Completed!";
        }
        else
        {
            output = "File download Failed";
        }

        return output;
    }
}
