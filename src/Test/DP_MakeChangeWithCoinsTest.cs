using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class DP_MakeChangeWithCoinsTest : TestBase<KeyValuePair<int, int[]>, int>
    {
        [Theory]
        [MemberData(nameof(MakeChangeWithCoinsTestCases))]
        public void MakeChangeWithCoinsTest(TestCase testCase)
        {
            // Arrange
            var algo = new DP_MakeChangeWithCoins();

            // Act
            var sut = algo.MakeChangeWithCoins(testCase.Input.Value, testCase.Input.Key);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> MakeChangeWithCoinsTestCases => GenerateData(
            new TestCase()
            {
                Input = new KeyValuePair<int, int[]>(7, new[] { 1, 2, 5 }),
                Output = 6
            });
    }
}