using System;
using System.Collections.Generic;
using System.Text;
using Xunit.Abstractions;

namespace FoodRecipe.xUnitTestProject
{
    public partial class FoodCategoriesApiTests
    {
        private readonly ITestOutputHelper _testoutputHelper;

        public FoodCategoriesApiTests(ITestOutputHelper testoutputHelper)
        {
            _testoutputHelper = testoutputHelper;
        }
    }
}
