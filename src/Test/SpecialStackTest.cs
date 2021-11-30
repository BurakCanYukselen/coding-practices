using System;
using System.Collections.Generic;
using Algoritms;
using Xunit;
using Xunit.Abstractions;

namespace Test
{
    public class SpecialStackTest : TestBase<int[], string>
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public SpecialStackTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Theory]
        [MemberData(nameof(SpecialStackMethodsTestCases))]
        public void SpecialStackMethodsTest(TestCase testCase)
        {
            // Arrange
            var stack = new SpecialStack();
            foreach (var input in testCase.Input)
                stack.Push(input);

            var minList = new List<int?>();
            for (int i = 0; i < testCase.Input.Length; i++)
            {
                minList.Add(stack.GetMin());
                stack.Pop();
            }

            // Act
            var sut = string.Join(",", minList);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> SpecialStackMethodsTestCases => GenerateData(
            new TestCase(new int[] { 5, 3, -1, 10, -20, 0, 10 }, "-20,-20,-20,-1,-1,3,5")
        );
    }
}