using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using RestaurantApi.Enums;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;

namespace RestaurantApi.Controllers;

[ApiController]
[Route("api/restaurant")]
public class RestaurantController : ControllerBase
{
    [HttpPost]
    public IActionResult RestaurantCommonReturn(
        [FromBody] JObject restaurantJson,
        [FromServices] IRestaurantBuilderReturnService service
        )
    {
        var result = service.BuilderReturn(restaurantJson);
        
        return Ok(result);
    }
    
    [HttpPost("formatter")]
    public IActionResult RestaurantCommonFormatterReturn(
        [FromBody] RestaurantObjectCommon restaurantJson,
        [FromServices] IRestaurantBuilderReturnService service
    )
    {
        var result = service.RestaurantFormatter(restaurantJson);
        
        return Ok(result);
    }
}