using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class DirectionsController : Controller
	{
		[HttpGet(Name = "GetDirections")]
		public IActionResult Get()
		{
			return new JsonResult(new { Message = "Hello from DirectionsController" });
		}
	}
}
