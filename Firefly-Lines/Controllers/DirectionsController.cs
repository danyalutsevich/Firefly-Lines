using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DirectionsController : Controller
	{
		[HttpGet("{profile}/{coordinates}")]
		public IActionResult Get(string profile, string coordinates)
		{

			Console.WriteLine(profile +" "+ coordinates);
			return new JsonResult(new { Message = "Hello from DirectionsController" });
		}
	}
}
