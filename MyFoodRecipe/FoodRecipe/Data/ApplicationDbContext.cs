using Microsoft.EntityFrameworkCore;
using FoodRecipe.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace FoodRecipe.Data
{
    public class ApplicationDbContext
        : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
           : base(options)
        {

        }

        public DbSet<FoodRecipe.Models.FoodCategory> FoodCategory { get; set; }

        public DbSet<FoodRecipe.Models.FoodSubCategory> FoodSubCategory { get; set; }

        public DbSet<FoodRecipe.Models.AddFoodRecipe> AddFoodRecipe { get; set; }

    }
}
