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
using System.Text;
using Xunit;


namespace FoodRecipe.xUnitTestProject
{
    /// <remarks>
    ///     Bad insertion data scenarios:
    ///     - Name is NULL
    ///     - Name is EMPTY STRING
    ///     - Name contains more characters than what is allowed
    ///     - NULL Category object
    ///     
    ///     LIMITATIONS OF WORKING WITH InMemory Database
    ///     - Relationships between Tables are not supported.
    ///     - EF Core DataAnnotation Validations are not supported.
    /// </remarks>

    public partial class FoodCategoriesApiTests
    {
        [Fact]
        public void InsertCategory_OkResult()
        {
            // ARRANGE
            var dbName = nameof(FoodCategoriesApiTests.InsertCategory_OkResult);
            var logger = Mock.Of<ILogger<FoodCategoriesController>>();
            using var dbContext = DbContextMocker.GetApplicationDbContext(dbName);      // Disposable!
            var apiController = new FoodCategoriesController(dbContext, logger);
           FoodCategory categoryToAdd = new FoodCategory
            {
                FoodCategoryId = 13,
                FoodCategoryName = "New Category"             // IF = null, then: INVALID!  CategoryName is REQUIRED
            };

            // ACT
            IActionResult actionResultPost = apiController.PostFoodCategory(categoryToAdd).Result;

            // ASSERT - check if the IActionResult is Ok
            Assert.IsType<OkObjectResult>(actionResultPost);

            // ASSERT - check if the Status Code is (HTTP 200) "Ok", (HTTP 201 "Created")
            int expectedStatusCode = (int)System.Net.HttpStatusCode.OK;
            var actualStatusCode = (actionResultPost as OkObjectResult).StatusCode.Value;
            Assert.Equal<int>(expectedStatusCode, actualStatusCode);

            // Extract the result from the IActionResult object.
            var postResult = actionResultPost.Should().BeOfType<OkObjectResult>().Subject;

            // ASSERT - if the result is a CreatedAtActionResult
            Assert.IsType<CreatedAtActionResult>(postResult.Value);

            // Extract the inserted Category object
            FoodCategory actualCategory = (postResult.Value as CreatedAtActionResult).Value
                                      .Should().BeAssignableTo<FoodCategory>().Subject;

            // ASSERT - if the inserted Category object is NOT NULL
            Assert.NotNull(actualCategory);

            Assert.Equal(categoryToAdd.FoodCategoryId, actualCategory.FoodCategoryId);
            Assert.Equal(categoryToAdd.FoodCategoryName, actualCategory.FoodCategoryName);
        }
    }
}