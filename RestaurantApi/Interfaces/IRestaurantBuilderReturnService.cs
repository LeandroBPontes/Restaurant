using Newtonsoft.Json.Linq;
using RestaurantApi.Models;

namespace RestaurantApi.Interfaces;

public interface IRestaurantBuilderReturnService
{
    RestaurantCommonReturn BuilderReturn(JObject data);
    Restaurant RestaurantFormatter(RestaurantObjectCommon data);
}