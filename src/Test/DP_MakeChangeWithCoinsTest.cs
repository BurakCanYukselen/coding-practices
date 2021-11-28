using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class DP_MakeChangeWithCoinsTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void MakeChangeWithCoins(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new DP_MakeChangeWithCoins();

                // Act
                var sut = algo.MakeChangeWithCoins(testCase.Input.Value, testCase.Input.Key);
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
                        new TestCase()
                        {
                            Input = new KeyValuePair<int, int[]>(7, new[] { 1, 2, 5 }),
                            Output = 6
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public KeyValuePair<int, int[]> Input { get; set; }
            public int Output { get; set; }
        }
    }
}