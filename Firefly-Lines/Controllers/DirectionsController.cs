using Firefly_Lines.Services;
using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DirectionsController : Controller
	{
		private readonly Directions _directions;

		public DirectionsController(Directions directions)
		{
			_directions = directions;
		}
		[HttpGet("{profile}/{coordinates}")]
		public async Task<IActionResult> Get(string profile, string coordinates)
		{
			//profile = profile.Split("/")[1];
			var result = await _directions.GetDirections(profile, coordinates);
			return new JsonResult(result);
		}
	}
}
