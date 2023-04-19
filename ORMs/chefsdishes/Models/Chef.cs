#pragma warning disable CS8618
using System.ComponentModel.DataAnnotations;
namespace chefsdishes.Models;

public class Chef
{
    [Key]
    public int ChefId {get;set;}

    [Required]    
    public string Name {get;set;}

    [Required]
    public int Age { get; set; }

    List<Dish> AllDishes {get;set;} = new List<Dish>();
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
}