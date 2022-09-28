using Castle.Core.Logging;
using FoodRecipe.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FoodRecipe.xUnitTestProject
{
    public partial class FoodCategoriesApiTests
    {
        [Fact]
        public void GetFoodCategories_okResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetFoodCategories_okResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var controller = new FoodCategoriesController(dbContext, logger);


            // ACT
            IActionResult actualResult =  controller.GetFoodCategories().Result;

            // ASSERT
            Assert.IsType<OkObjectResult>(actualResult);

            //
           
        }
    }
}
