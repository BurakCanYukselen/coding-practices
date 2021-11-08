using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class BFS_ShortestReachInGraphTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void ShortestReachInGraphTest(List<TestCase> testCases)
        {
            var results = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new BFS_ShortestReachInGraph(6);
                var graph = algo.GenerateGraphMatrixes(testCase.Input);

                // Act
                var sut = algo.Path(graph);

                for (int i = 0; i < testCase.Output.Count; i++)
                    results.Add(testCase.Output[i] == sut[i]);
            }

            // Assert
            Assert.True(results.All(p => p == true));
        }

        public class TestCase
        {
            public List<string> Input { get; set; }
            public List<string> Output { get; set; }
        }

        public class TestCaseGenerator : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new List<TestCase>()
                    {
                        new TestCase()
                        {
                            Input = new List<string>()
                            {
                                "1",
                                "5 3",
                                "2 1",
                                "2 4",
                                "4 5",
                                "2",
                            },
                            Output = new List<string>()
                            {
                                "6 -1 6 12"
                            }
                        },
                        new TestCase()
                        {
                            Input = new List<string>()
                            {
                                "1",
                                "6 4",
                                "1 5",
                                "1 2",
                                "2 3",
                                "3 4",
                                "1"
                            },
                            Output = new List<string>()
                            {
                                "6 12 18 6 -1"
                            }
                        },
                        new TestCase()
                        {
                            Input = new List<string>()
                            {
                                "2",
                                "4 2",
                                "1 2",
                                "1 3",
                                "1",
                                "3 1",
                                "2 3",
                                "2",
                            },
                            Output = new List<string>()
                            {
                                "6 6 -1",
                                "-1 6"
                            }
                        },
                    }
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}