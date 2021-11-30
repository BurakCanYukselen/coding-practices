using System.Collections.Generic;
using Algoritms;
using Xunit;

namespace Test
{
    public class Heap_FindTheRunningMedianTest : TestBase<int[], string>
    {
        [Theory]
        [MemberData(nameof(FindTheRunningMedianTestCases))]
        public void FindTheRunningMedianTest(TestCase testCase)
        {
            // Arrange
            var algo = new Heap_FindTheRunningMedian();

            // Act
            var sut = algo.GetRunningMedian(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> FindTheRunningMedianTestCases => GenerateData(
            new TestCase(new[] { 12, 4, 5, 3, 8, 7 }, "12,8,5,4.5,5,6"),
            new TestCase(new[] { 7, 3, 5, 2 }, "7,5,5,4")
        );
    }
}