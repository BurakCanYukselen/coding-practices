using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Stack_BalancedBracketsTest : TestBase<string, string>
    {
        [Theory]
        [MemberData(nameof(BalancedBracketsTestCases))]
        public void BalancedBrackets_v1(TestCase testCase)
        {
            // Arrange
            var algo = new Stack_BalancedBrackets();

            // Act
            var sut = algo.CheckBracketBalance_V1(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        [Theory]
        [MemberData(nameof(BalancedBracketsTestCases))]
        public void BalancedBrackets_v2(TestCase testCase)
        {
            // Arrange
            var algo = new Stack_BalancedBrackets();

            // Act
            var sut = algo.CheckBracketBalance_V2(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> BalancedBracketsTestCases => GenerateData(
            new TestCase("{[()]}", "YES"),
            new TestCase("{[(])}", "NO"),
            new TestCase("{{[[(())]]}}", "YES")
        );
    }
}