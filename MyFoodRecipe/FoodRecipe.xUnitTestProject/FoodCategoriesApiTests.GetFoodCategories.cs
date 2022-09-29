using Castle.Core.Logging;
using FluentAssertions;
using FoodRecipe.Controllers;
using FoodRecipe.Models;
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
        public void GetFoodCategories_OkResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetFoodCategories_OkResult);
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

        [Fact]
        public void GetFoodCategories_CheckCorrectResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetFoodCategories_OkResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            var dbContext = DbContextMocker.GetApplicationDbContext(dbName);
            var apiController = new FoodCategoriesController(dbContext, logger);


            // ACT
            IActionResult actionResult = apiController.GetFoodCategories().Result;

            // ---ASSERT: Check if actionResult is the type okObjectResult
            Assert.IsType<OkObjectResult>(actionResult);

            // ACT: Extract the okResult result
            var okResult = actionResult.Should().BeOfType<OkObjectResult>().Subject;

            // ASSERT: if okRessult contains the object of correct type
            Assert.IsAssignableFrom<List<FoodCategory>>(okResult.Value);

            // ACT: Extract the Food Categories fromthe result of action
            var foodCategoriesFrmAPI = okResult.Value.Should().BeAssignableTo<List<FoodCategory>>().Subject;

            // ASSERT - If foodCategories is NOT NULL
            Assert.NotNull(foodCategoriesFrmAPI);

            //ASSERT: if number of foodcategories in DbContext is same as number in API Result
            Assert.Equal<int> (expected: DbContextMocker.TestData_FoodCategories.Length,
                actual: foodCategoriesFrmAPI.Count);


            //ASSERT: Test data received from the API against seed data
            int ndx = 0;
            foreach (FoodCategory foodCategory in DbContextMocker.TestData_FoodCategories)
            {
                //ASSERT: Check if the FoodCategory ID is correct
                Assert.Equal<int>(expected: foodCategory.FoodCategoryId,
                                actual: foodCategoriesFrmAPI[ndx].FoodCategoryId);

                //ASSERT: Check if the FoodCategory Name is correct
                Assert.Equal(expected: foodCategory.FoodCategoryName,
                                actual: foodCategoriesFrmAPI[ndx].FoodCategoryName);

                _testOutputHelper.WriteLine($"Compared Row # {ndx} Successfully");
                ndx++;
            }

        }


    }
}
