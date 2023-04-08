using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DirectionsController : Controller
	{
		private string _token = Environment.GetEnvironmentVariable("MAPBOX_TOKEN");

		private string _directionsUrl = "https://api.mapbox.com/directions/v5/mapbox/";
		static HttpClient _httpClient = new HttpClient();
		[HttpGet("{profile}/{coordinates}")]
		public IActionResult Get(string profile, string coordinates)
		{
			//profile = profile.Split("/")[1];
			var url = $"{_directionsUrl}{profile}/{coordinates}?access_token={_token}";
			Console.WriteLine(url);
			using var request = new HttpRequestMessage(HttpMethod.Get, url);
			using var response = _httpClient.SendAsync(request);
			var result = response.Result.Content.ReadAsStringAsync().Result;
			Console.WriteLine(result);
			return new JsonResult(result);
		}
	}
}
