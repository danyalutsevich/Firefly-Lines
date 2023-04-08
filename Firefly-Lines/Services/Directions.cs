using System.Text;

namespace Firefly_Lines.Services
{
	public class Directions
	{
		private readonly string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

		private const string DirectionsUrl = "https://api.mapbox.com/directions/v5/mapbox/";
		private readonly HttpClient _httpClient;

		public Directions(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetDirections(string profile, string coordinates)
		{
			var url = $"{DirectionsUrl}{profile}/{coordinates}?access_token={_token}";
			Console.WriteLine(url);
			using var request = new HttpRequestMessage(HttpMethod.Get, url);
			using var response = await _httpClient.SendAsync(request);
			var result = await response.Content.ReadAsStringAsync();
			return result;
		}
	}
}
