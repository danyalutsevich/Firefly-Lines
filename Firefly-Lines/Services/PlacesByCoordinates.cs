namespace Firefly_Lines.Services;

public class PlacesByCoordinates
{
    private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

    private const string baseUrl = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
    private readonly HttpClient _httpClient;

    public PlacesByCoordinates(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> GetPlaces(string coordinates)
    {
        var url = $"{baseUrl}{coordinates}.json?access_token={_token}";
        Console.WriteLine(url);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        return result;
    }
}