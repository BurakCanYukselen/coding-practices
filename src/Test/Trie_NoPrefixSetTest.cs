using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Trie_NoPrefixSetTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void NoPrefixSetTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Trie_NoPrefixSet();

                // Act
                var sut = algo.NoPrefixSet(testCase.Input);
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
                            Input = new string[] { "aab", "defgab", "abcde", "aabcde", "bbbbbbbbbb", "jabjjjad" },
                            Output = "BAD SET: aabcde"
                        },
                        new TestCase()
                        {
                            Input = new string[] { "aab", "aac", "aacghgh", "aabghgh" },
                            Output = "BAD SET: aacghgh"
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public string[] Input { get; set; }
            public string Output { get; set; }
        }
    }
}