using System;
using Xunit;

namespace FoodRecipe.xUnitTestProject
{
     
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            // ARRANGE
            int a = 1, b=3;
            int expectedR = 4;
            int actualR;
            // ACT
            actualR = a+b;
            // ASSERT
            Assert.Equal(expectedR, actualR);   
        }
    }
}
