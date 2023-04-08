using Firefly_Lines.Services;
using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers;

[ApiController]
[Route("[controller]")]
public class PlacesByNameController : Controller
{
    private readonly PlacesByName _placesByName;

    public PlacesByNameController(PlacesByName placesByName)
    {
        _placesByName = placesByName;
    }


    [HttpGet("{textSearch}")]
    public async Task<IActionResult> Get(string textSearch)
    {
        //profile = profile.Split("/")[1];
        var result = await _placesByName.GetPlaces(textSearch);
        return new JsonResult(result);
    }
}