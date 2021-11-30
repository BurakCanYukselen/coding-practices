using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class DP_FindKthPermutationTest : TestBase<KeyValuePair<int, int[]>, string>
    {
        [Theory]
        [MemberData(nameof(FindKthPermutationTestCases))]
        public void FindKthPermutationTest(TestCase testCase)
        {
            // Arrange
            var algo = new DP_FindKthPermutation();

            // Act
            var sut = algo.FindKthPermutation(testCase.Input.Value, testCase.Input.Key);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> FindKthPermutationTestCases => GenerateData(
            /*
             * 1,2,3
             * 1: 123
             * 2: 132
             * 3: 213
             * 4: 231
             * 5: 312
             * 6: 321
            */
            new TestCase()
            {
                Input = new KeyValuePair<int, int[]>(4, new[] { 1, 2, 3 }),
                Output = "231"
            });
    }
}