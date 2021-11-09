using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Tree_LevelOrderTraversalTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void LevelOrderTraversalTest(List<TestCase> testCases)
        {
            var result = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Tree_LevelOrderTraversal();

                // Act
                var sut = algo.LevelOrderTraversal(testCase.Input);
                result.Add(testCase.Output == sut);
            }

            //Assert
            Assert.True(result.All(p => p == true));
        }

        // Case 1
        // => 2 5 3 1 7 4 6
        //
        //           2
        //          / \
        //         5   3
        //        / \
        //       1   7
        //      /     \
        //     4       6
        
        // Case 2
        // => 8 6 2 3 9 5 7 1 4 0
        //
        //           8
        //          / \
        //         6   2
        //        / \
        //       3   9
        //      /     \
        //     5       7
        //    / \     /
        //   1   4   0
        
        // Case 3
        // 1
        
        // Case 4
        // 
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
                            Input = new Tree_LevelOrderTraversal.Node(2)
                            {
                                Left = new Tree_LevelOrderTraversal.Node(5)
                                {
                                    Left = new Tree_LevelOrderTraversal.Node(1)
                                    {
                                        Left = new Tree_LevelOrderTraversal.Node(4)
                                    },
                                    Right = new Tree_LevelOrderTraversal.Node(7)
                                    {
                                        Right = new Tree_LevelOrderTraversal.Node(6)
                                    }
                                },
                                Right = new Tree_LevelOrderTraversal.Node(3)
                            },
                            Output = "2 5 3 1 7 4 6",
                        },
                        new TestCase()
                        {
                            Input = new Tree_LevelOrderTraversal.Node(8)
                            {
                                Left = new Tree_LevelOrderTraversal.Node(6)
                                {
                                    Left = new Tree_LevelOrderTraversal.Node(3)
                                    {
                                        Left = new Tree_LevelOrderTraversal.Node(5)
                                        {
                                            Left = new Tree_LevelOrderTraversal.Node(1),
                                            Right = new Tree_LevelOrderTraversal.Node(4)
                                        }
                                    },
                                    Right = new Tree_LevelOrderTraversal.Node(9)
                                    {
                                        Right = new Tree_LevelOrderTraversal.Node(7)
                                        {
                                            Left = new Tree_LevelOrderTraversal.Node(0)
                                        },
                                    }
                                },
                                Right = new Tree_LevelOrderTraversal.Node(2)
                            },
                            Output = "8 6 2 3 9 5 7 1 4 0",
                        },
                        new TestCase()
                        {
                            Input = new Tree_LevelOrderTraversal.Node(1),
                            Output = "1",
                        },
                        new TestCase()
                        {
                            Input = null,
                            Output = string.Empty,
                        },
                    }
                };
            }
        }

        public class TestCase
        {
            public Tree_LevelOrderTraversal.Node Input { get; set; }
            public string Output { get; set; }
        }
    }
}