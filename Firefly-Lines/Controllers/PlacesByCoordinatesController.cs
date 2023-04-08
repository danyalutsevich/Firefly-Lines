using Firefly_Lines.Services;
using Microsoft.AspNetCore.Mvc;

namespace Firefly_Lines.Controllers;

[ApiController]
[Route("[controller]")]
public class PlacesByCoordinatesController : Controller
{
    private readonly PlacesByCoordinates _placesByCoordinates;

    public PlacesByCoordinatesController(PlacesByCoordinates placesByCoordinates)
    {
        _placesByCoordinates = placesByCoordinates;
    }
    
    [HttpGet("{coordinates}")]
    public async Task<IActionResult> Get(string coordinates)
    {
        //profile = profile.Split("/")[1];
        var result = await _placesByCoordinates.GetPlaces(coordinates);
        return new JsonResult(result);
    }
}