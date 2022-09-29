using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace FoodRecipe.xUnitTestProject
{
    public partial class FoodCategoriesApiTests
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public FoodCategoriesApiTests(ITestOutputHelper testoutputHelper)
        {
            _testOutputHelper = testoutputHelper;
        }
    }
}
