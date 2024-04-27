using Newtonsoft.Json.Linq;
using RestaurantApi.Models;
using RestaurantApi.Services;
using Xunit;

namespace RestaurantApi.Tests;

public class RestaurantBuilderReturnServiceTests
{
    [Fact]
    public void BuilderReturn_ValidJson_ReturnsSuccess()
    {
        var service = new RestaurantBuilderReturnService();
        
        var json = JObject.Parse("{\n  \"ingredientes\": {\n    \"nome\": \"farinha\",\n    \"quantidade\": \"2\"\n  },\n  \"modoPreparo\": \"Deve se misturar...\"\n}");
        
        var result = service.BuilderReturn(json);

        Assert.True(result.Success);
    }

    [Fact]
    public void BuilderReturn_InvalidJson_ReturnsFailure()
    {
        var common = new RestaurantCommonReturn();
        
        var service = new RestaurantBuilderReturnService();

        try
        {
            var json = JObject.Parse("");
            common = service.BuilderReturn(json);
        }
        catch
        {
            common.Success = false;
        }
        
        Assert.False(common.Success);
    }
}