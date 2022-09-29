using Castle.Core.Logging;
using FluentAssertions;
using FoodRecipe.Controllers;
using FoodRecipe.Models;
using FoodRecipe.xUnitTestProject;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;


namespace FoodRecipe.xUnitTestProject
{
    public partial class FoodCategoriesApiTests
    {
        [Fact]
        public void GetCategoryById_NotFoundResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetCategoryById_NotFoundResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();

            // using (var db = DbContextMocker.GetApplicationDbContext(dbName))
            // {
            // }           // db.Dispose(); implicitly called when you exit the USING Block

            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var apiController = new FoodCategoriesController(dbContext, logger);
            int findCategoryID = 879;

            // ACT
            IActionResult actionResultGet = apiController.GetFoodCategory(findCategoryID).Result;

            // ASSERT - check if the IActionResult is NotFound 
            Assert.IsType<NotFoundResult>(actionResultGet);

            // ASSERT - check if the Status Code is (HTTP 404) "NotFound"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.NotFound;
            var actualStatusCode = (actionResultGet as NotFoundResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_BadRequestResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetCategoryById_BadRequestResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var controller = new FoodCategoriesController(dbContext, logger);
            int? findCategoryID = null;

            // ACT
            IActionResult actionResultGet = controller.GetFoodCategory(findCategoryID).Result;

            // ASSERT - check if the IActionResult is BadRequest
            Assert.IsType<BadRequestResult>(actionResultGet);

            // ASSERT - check if the Status Code is (HTTP 400) "BadRequest"
            int expectedStatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            var actualStatusCode = (actionResultGet as BadRequestResult).StatusCode;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_OkResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var controller = new FoodCategoriesController(dbContext, logger);
            int findCategoryID = 2;

            // ACT
            IActionResult actionResultGet = controller.GetFoodCategory(findCategoryID).Result;

            // ASSERT - if IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultGet);

            // ASSERT - if Status Code is HTTP 200 (Ok)
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionResultGet as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);
        }

        [Fact]
        public void GetCategoryById_CorrectResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.GetCategoryById_OkResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var controller = new FoodCategoriesController(dbContext, logger);
            int findCategoryID = 2;
            FoodCategory expectedCategory = DbContextMocker.TestData_FoodCategories
                                        .SingleOrDefault(c => c.FoodCategoryId == findCategoryID);

            // ACT
            IActionResult actionResultGet = controller.GetFoodCategory(findCategoryID).Result;

            // ASSERT - if IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultGet);

            // ASSERT - if IActionResult (i.e., OkObjectResult) contains an object of the type Category
            OkObjectResult okResult = actionResultGet.Should().BeOfType<OkObjectResult>().Subject;
            Assert.IsType<FoodCategory>(okResult.Value);

            // Extract the category object from the result.
            FoodCategory actualCategory = okResult.Value.Should().BeAssignableTo<FoodCategory>().Subject;
            _testOutputHelper.WriteLine($"Found: CategoryID == {actualCategory.FoodCategoryId}");

            // ASSERT - if category is NOT NULL
            Assert.NotNull(actualCategory);

            // ASSERT - if the CategoryId is containing the expected data.
            Assert.Equal<int>(expected: expectedCategory.FoodCategoryId,
                              actual: actualCategory.FoodCategoryId);

            // ASSERT - if the CateogoryName is correct 
            Assert.Equal(expected: expectedCategory.FoodCategoryName,
                         actual: actualCategory.FoodCategoryName);
        }
    }
}