using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Heap_FindTheRunningMedianTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void FindTheRunningMedian(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Heap_FindTheRunningMedian();

                // Act
                var sut = algo.GetRunningMedian(testCase.Inputs);
                var result = true;
                for (int i = 0; i < testCase.Outputs.Length; i++)
                    if (testCase.Outputs[i] != sut[i])
                    {
                        result = false;
                        break;
                    }

                results.Add(result);
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
                        new TestCase()
                        {
                            Inputs = new[] { 6, 12, 4, 5, 3, 8, 7 },
                            Outputs = new double[] { 12.0, 8.0, 5.0, 4.5, 5.0, 6.0 },
                        },
                        new TestCase()
                        {
                            Inputs = new[] { 4, 7, 3, 5, 2 },
                            Outputs = new double[] { 7.0, 5.0, 5.0, 4.0 },
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public int[] Inputs { get; set; }
            public double[] Outputs { get; set; }
        }
    }
}