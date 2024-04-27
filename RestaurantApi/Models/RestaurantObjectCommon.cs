using Newtonsoft.Json.Linq;
using RestaurantApi.Enums;

namespace RestaurantApi.Models;

public class RestaurantObjectCommon
{
    public JObject Payload { get; set; }
    
    public RestaurantTypeEnum RestaurantType { get; set; }

}