using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Trie_ContactsTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void ContactsTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Trie_Contacts();

                // Act
                var sut = algo.Operate(testCase.Inputs);
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
                            Inputs = new string[]
                            {
                                "4",
                                "add hack",
                                "add hackerrank",
                                "find hac",
                                "find hak"
                            },
                            Outputs = new int[]
                            {
                                2,
                                0
                            }
                        },
                        new TestCase()
                        {
                            Inputs = new string[]
                            {
                                "7",
                                "add ed",
                                "add eddie",
                                "add edward",
                                "find ed",
                                "add edwina",
                                "find edw",
                                "find a"
                            },
                            Outputs = new int[]
                            {
                                3,
                                2,
                                0
                            }
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public string[] Inputs { get; set; }
            public int[] Outputs { get; set; }
        }
    }
}