using System.Text;
using Newtonsoft.Json;

namespace Firefly_Lines.Services;

public class PlacesByName
{
    private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

    private const string DirectionsUrl = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
    private readonly HttpClient _httpClient;

    public PlacesByName(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> GetPlaces(string searchText)
    {
        var url = $"{DirectionsUrl}{searchText}.json?access_token={_token}";
        Console.WriteLine(url);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = await _httpClient.SendAsync(request);
        var byteResult = await response.Content.ReadAsByteArrayAsync();
        string result = Encoding.UTF8.GetString(byteResult);
        return result;
    }
}