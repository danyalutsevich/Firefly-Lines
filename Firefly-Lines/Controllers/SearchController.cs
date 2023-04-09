using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers
{
	[ApiController]
	[Route("[controller]")]
	public class SearchController : Controller
	{
		[HttpGet("{profile}/{coordinates}")]
		public IActionResult Get()
		{
			return View();
		}
	}
}
