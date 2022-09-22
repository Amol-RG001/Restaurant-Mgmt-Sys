using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Major_Food_Recipe.Models;

namespace Major_Food_Recipe.Data
{
    public class ApplicationDbContext
        :IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<Major_Food_Recipe.Models.FoodCategory> FoodCategory { get; set; }

        public DbSet<Major_Food_Recipe.Models.FoodSubCategory> FoodSubCategory { get; set; }

        public DbSet<Major_Food_Recipe.Models.AddFoodRecipe> AddFoodRecipe { get; set; }

    }
}
