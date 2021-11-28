using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class DP_FindKthPermutationTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void FindKthPermutation(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new DP_FindKthPermutation();

                // Act
                var sut = algo.FindKthPermutation(testCase.Input.Value, testCase.Input.Key);
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
                        /*
                            1,2,3
                            1: 123
                            2: 132
                            3: 213
                            4: 231
                            5: 312
                            6: 321
                         */
                        new TestCase()
                        {
                            Input = new KeyValuePair<int, int[]>(4, new[] { 1, 2, 3 }),
                            Output = "231"
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public KeyValuePair<int, int[]> Input { get; set; }
            public string Output { get; set; }
        }
    }
}