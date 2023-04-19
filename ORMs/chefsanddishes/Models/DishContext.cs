#pragma warning disable CS8618
using Microsoft.EntityFrameworkCore;
namespace chefsanddishes.Models;

public class DishContext : DbContext
{
    public DishContext(DbContextOptions options) : base(options) { }

    public DbSet<Chef> Chefs {get;set;}
    public DbSet<Dish> Dishes {get;set;}
}