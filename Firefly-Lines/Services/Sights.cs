namespace Firefly_Lines.Services;

public class Sights
{
    private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

    private const string DirectionsUrl = "https://api.mapbox.com/directions/v5/mapbox/";
    private readonly HttpClient _httpClient;

    public Sights(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
}