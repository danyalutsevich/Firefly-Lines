using System.Globalization;
using System.Text;
using Newtonsoft.Json;

namespace Firefly_Lines.Services;

public class PlacesByName
{
    private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

    private const string BaseUrl = "https://api.mapbox.com/geocoding/v5/mapbox.places/";
    private readonly HttpClient _httpClient;

    public PlacesByName(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<string> GetPlaces(string searchText)
    {
        var url = $"{BaseUrl}{searchText}.json?access_token={_token}";
        Console.WriteLine(url);
        using var request = new HttpRequestMessage(HttpMethod.Get, url);
        using var response = await _httpClient.SendAsync(request);
        var result = await response.Content.ReadAsStringAsync();
        //Console.Write(result);
        var places = JsonConvert.DeserializeObject<Root>(result);
        PlacesJson placesObj = new();
        placesObj.places = new();
        if (places == null)
        {
            return "";
        }

        foreach (var place in places.features)
        {
            placesObj.places.Add(new()
            {
                place_name = place.place_name,
                coordinates = place.center[0].ToString() + ',' + place.center[1].ToString()
            });
        }

        var placesJson = JsonConvert.SerializeObject(placesObj);
        return placesJson;
    }

    public class Place
    {
        public String place_name { get; set; }
        public String coordinates { get; set; }
    }

    public class PlacesJson
    {
        public List<Place> places { get; set; }
    }

    public class Context
    {
        public string id { get; set; }
        public string mapbox_id { get; set; }
        public string text { get; set; }
        public string wikidata { get; set; }
        public string short_code { get; set; }
    }

    public class Feature
    {
        public string id { get; set; }
        public string type { get; set; }
        public List<string> place_type { get; set; }
        public int relevance { get; set; }
        public Properties properties { get; set; }
        public string text { get; set; }
        public string place_name { get; set; }
        public List<double> center { get; set; }
        public Geometry geometry { get; set; }
        public List<Context> context { get; set; }
        public List<double> bbox { get; set; }
    }

    public class Geometry
    {
        public List<double> coordinates { get; set; }
        public string type { get; set; }
    }

    public class Properties
    {
        public string foursquare { get; set; }
        public bool landmark { get; set; }
        public string address { get; set; }
        public string category { get; set; }
        public string mapbox_id { get; set; }
        public string wikidata { get; set; }
    }

    public class Root
    {
        public string type { get; set; }
        public List<string> query { get; set; }
        public List<Feature> features { get; set; }
        public string attribution { get; set; }
    }


}