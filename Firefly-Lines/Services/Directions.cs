using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace Firefly_Lines.Services
{
	public class Directions
	{
		private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

		private const string BaseUrl = "https://api.mapbox.com/directions/v5/mapbox/";
		private readonly HttpClient _httpClient;

		public Directions(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<object> GetDirections(string profile, string coordinates)
		{
			var url = $"{BaseUrl}{profile}/{coordinates}?alternatives=true&access_token={_token}";
			Console.WriteLine(url);
			using var request = new HttpRequestMessage(HttpMethod.Get, url);
			using var response = await _httpClient.SendAsync(request);
			var result = await response.Content.ReadAsStringAsync();
			return result;


		}
	}
}
