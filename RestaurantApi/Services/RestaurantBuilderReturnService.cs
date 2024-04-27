using Microsoft.OpenApi.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestaurantApi.Enums;
using RestaurantApi.Interfaces;
using RestaurantApi.Models;
using RestaurantApi.StringResources;

namespace RestaurantApi.Services;

public class RestaurantBuilderReturnService : IRestaurantBuilderReturnService
{
    public RestaurantCommonReturn BuilderReturn(JObject restaurantJson)
    {
        var result = new RestaurantCommonReturn();
    
        try
        {
            result.Data = restaurantJson.ToObject<dynamic>();
            result.Success = true;
            result.Message = StringResource.OkMessage;
        }
        catch (JsonReaderException)
        {
            result.Success = false;
            result.Message = StringResource.BadMessage;
        }
        return result;
    }
    public Restaurant RestaurantFormatter(RestaurantObjectCommon data)
    {
        return data.RestaurantType switch
        {
            RestaurantTypeEnum.RestaurantOne => ConvertToRestaurant1(data.Payload),
            RestaurantTypeEnum.RestaurantTwo => ConvertToRestaurant2(data.Payload),
            RestaurantTypeEnum.RestaurantThree => ConvertToRestaurant3(data.Payload),
            RestaurantTypeEnum.RestaurantFour => ConvertToRestaurant4(data.Payload),  
            RestaurantTypeEnum.RestaurantFive => ConvertToRestaurant5(data.Payload),
            _ => throw new Exception("Formato de restaurante não suportado.")
        };
    }
    
    private static Restaurant ConvertToRestaurant1(JObject data)
    {
        var restaurant = new Restaurant
        {
            Ingredients = new List<Ingredient>
            {
                new()
                {
                    Name = data["ingredientes"]["nome"].ToString(),
                    Quantity = data["ingredientes"]["quantidade"].ToString()
                }
            },
            PreparationMethod = data["modoPreparo"].ToString()
        };
        return restaurant;
    }
    private static Restaurant ConvertToRestaurant2(JObject data)
    {
        var restaurant = new Restaurant();
        foreach (var ingredient in data["recipe"]["ingredients"])
        {
            restaurant.Ingredients.Add(new Ingredient
            {
                Name = ingredient["nome"].ToString(),
                Quantity = ingredient["quantity"].ToString()
            });
        }
        restaurant.PreparationMethod = data["recipe"]["instructions"].ToString();
        return restaurant;
    }
    private static Restaurant ConvertToRestaurant3(JObject data)
    {
        var restaurant = new Restaurant();
        foreach (var ingredient in data["recipeRestaurant"]["ingredients"])
        {
            restaurant.Ingredients.Add(new Ingredient
            {
                Name = ingredient["nomeReceita"].ToString(),
                Quantity = ingredient["quantidade"].ToString()
            });
        }
        restaurant.PreparationMethod = data["recipeRestaurant"]["instructions"].ToString();
        restaurant.Classification = data["recipeRestaurant"]["classification"].Value<int>();
        restaurant.PreparationTime = data["recipeRestaurant"]["time"].Value<double>();
        return restaurant;
    }
    private static Restaurant ConvertToRestaurant4(JObject data)
    {
        var restaurant = new Restaurant();
        foreach (var ingredient in data["recipe"]["ingredientes"])
        {
            restaurant.Ingredients.Add(new Ingredient
            {
                Name = ingredient["nome"].ToString(),
                Quantity = ingredient["quantity"].ToString()
            });
        }
        restaurant.PreparationMethod = data["recipe"]["metodoDePreparo"].ToString();
        restaurant.Classification = data["recipe"]["avaliacao"].Value<int>();
        restaurant.PreparationTime = data["recipe"]["tempoDePreparo"].Value<double>();
        return restaurant;
    }
    private static Restaurant ConvertToRestaurant5(JObject data)
    {
        var restaurant = new Restaurant();
        foreach (var ingredient in data["ingredientList"])
        {
            restaurant.Ingredients.Add(new Ingredient
            {
                Name = ingredient["fullName"].ToString(),
                Quantity = ingredient["qtd"].ToString()
            });
        }
        restaurant.PreparationMethod = data["instructions"].ToString();
        restaurant.Classification = data["assessment"].Value<int>();
        restaurant.PreparationTime = data["timeOfPreparation"].Value<double>();
        return restaurant;
    }
}