using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class SortingTest : TestBase<int[], string>
    {
        [Theory]
        [MemberData(nameof(SortingTestCases))]
        public void SelectiveSortTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Sorting();

                // Act
                var sut = algo.SelectiveSort(testCase.Input);
                results.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }

        [Theory]
        [MemberData(nameof(SortingTestCases))]
        public void BubbleSortTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Sorting();

                // Act
                var sut = algo.SelectiveSort(testCase.Input);
                results.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }

        [Theory]
        [MemberData(nameof(SortingTestCases))]
        public void InsertionSortTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Sorting();

                // Act
                var sut = algo.InsertionSort(testCase.Input);
                results.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }

        [Theory]
        [MemberData(nameof(SortingTestCases))]
        public void MergeSortTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Sorting();

                // Act
                var sut = algo.MergeSort(testCase.Input);
                results.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }

        public static IEnumerable<object[]> SortingTestCases => GenerateData(
            new TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, "123456"),
            new TestCase(new int[] { 1, 0, 5, 2, 4, 3 }, "012345"),
            new TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, "111111"),
            new TestCase(new int[] { 0, 0, 1, 0, 0, 1 }, "000011"),
            new TestCase(new int[] { 1, 0, 0, 1, 1, 1 }, "001111"),
            new TestCase(new int[] { 3, 2, 1, 5, 4, 6 }, "123456")
        );
    }
}