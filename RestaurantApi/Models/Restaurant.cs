namespace RestaurantApi.Models;

public class Restaurant
{
    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
    public string PreparationMethod { get; set; }
    public int Classification { get; set; }
    public double PreparationTime { get; set; }
}