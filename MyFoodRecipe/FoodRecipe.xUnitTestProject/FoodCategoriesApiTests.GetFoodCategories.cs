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
            var apiController = new FoodCategoriesController(dbContext, logger);


            // ACT
            IActionResult actualResult =  apiController.GetFoodCategories().Result;

            // ASSERT
            // ---- check if ActionResult is the type OkObjectResult
            Assert.IsType<OkObjectResult>(actualResult);

            // ---check if HTTP Response Code is 200 "Ok"
            int expectedStatusCode = (int) System.Net.HttpStatusCode.OK;
            int actualStatusCode = (actualResult as OkObjectResult).StatusCode.Value;
            Assert.Equal(expectedStatusCode, actualStatusCode);
           
        }

        //public void GetFoodCategories_CheckCorrectResult()
        //{
        //    // ARRANGE
        //    var dbName = nameof(FoodCategoriesApiTests.GetFoodCategories_okResult);
        //    var logger = Mock.Of<ILogger<FoodCategoriesController>>();
        //    var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
        //    var apiController = new FoodCategoriesController(dbContext, logger);


        //    // ACT
        //    IActionResult actualResult = apiController.GetFoodCategories().Result;

        //}


    }
}
