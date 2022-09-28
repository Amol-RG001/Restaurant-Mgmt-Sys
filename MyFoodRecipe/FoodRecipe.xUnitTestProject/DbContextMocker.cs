using FoodRecipe.Data;
using FoodRecipe.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace FoodRecipe.xUnitTestProject
{
    public static class DbContextMocker
    {
        public static ApplicationDbContext GetApplicationDbContext(string dbName)
        {
            // Create fresh service provider for InMemory Database instance
            var serviceProvider = new ServiceCollection()
                                 .AddEntityFrameworkInMemoryDatabase()
                                 .BuildServiceProvider();

           // Create  new options instance telling the context to use InMemory database
           // with new service provider created above
           var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                         .UseInMemoryDatabase(dbName)
                         .UseInternalServiceProvider(serviceProvider)
                         .Options;

            //Create instance of DbContext
            var dbContext = new ApplicationDbContext(options);

            // Add entities to InMemory Database to seed the data
            dbContext.SeedData();

            return dbContext;

            
        }
        // Note: InMemory database do not support relationships and db constraints
        // so, seed Identity column values also.
        internal static readonly FoodCategory[] TestData_FoodCategories

        ={
                new FoodCategory
                {
                    FoodCategoryId = 1,
                    FoodCategoryName = "Punjabi Thali"
                },

                 new FoodCategory
                {
                    FoodCategoryId = 2,
                    FoodCategoryName = "Gujarati Thali"
                },

                  new FoodCategory
                {
                    FoodCategoryId = 3,
                    FoodCategoryName = "Maharashtrian Thali"
                },

        };

        // extension method for DbContext object to Seed the Tets Data
        private static void SeedData(this ApplicationDbContext context)
        {
            context.FoodCategory.AddRange(TestData_FoodCategories);

            //commit the changes to database
            context.SaveChanges();

        }
    }
}
