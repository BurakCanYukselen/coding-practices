using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class SortingTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
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
        [ClassData(typeof(TestCaseGenerator))]
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
        [ClassData(typeof(TestCaseGenerator))]
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
        [ClassData(typeof(TestCaseGenerator))]
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

        public class TestCaseGenerator : IEnumerable<object[]>
        {
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new List<TestCase>()
                    {
                        new TestCase(new int[] { 1, 2, 3, 4, 5, 6 }, "123456"),
                        new TestCase(new int[] { 1, 0, 5, 2, 4, 3 }, "012345"),
                        new TestCase(new int[] { 1, 1, 1, 1, 1, 1 }, "111111"),
                        new TestCase(new int[] { 0, 0, 1, 0, 0, 1 }, "000011"),
                        new TestCase(new int[] { 1, 0, 0, 1, 1, 1 }, "001111"),
                        new TestCase(new int[] { 3, 2, 1, 5, 4, 6 }, "123456"),
                    }
                };
            }
        }

        public class TestCase
        {
            public int[] Input { get; set; }
            public string Output { get; set; }

            public TestCase(int[] input, string output)
            {
                Input = input;
                Output = output;
            }
        }
    }
}