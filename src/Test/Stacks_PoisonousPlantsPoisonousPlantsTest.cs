using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Stacks_PoisonousPlantsPoisonousPlantsTest : TestBase<int[], int>
    {
        [Theory]
        [MemberData(nameof(PoisonousPlantsPoisonousPlantsTestCases))]
        public void PoisonousPlantsPoisonousPlantsTest(TestCase testCase)
        {
            // Arrange
            var algo = new Stacks_PoisonousPlantsPoisonousPlants();

            // Act
            var sut = algo.GetTheDay(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> PoisonousPlantsPoisonousPlantsTestCases => GenerateData(
            new TestCase(new int[] { 6, 5, 8, 4, 7, 10, 9 }, 2)
        );
    }
}