using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Tree_InOrderTraversalTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void InOrderTraversalTest(List<TestCase> testCases)
        {
            var result = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Tree_InOrderTraversal();

                // Act
                var sut = algo.InOrderTraversal(testCase.Input);
                result.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(result.All(p => p == true));
        }

        public class TestCase
        {
            public Tree_InOrderTraversal.Node Input { get; set; }
            public string Output { get; set; }
        }
        
        public class TestCaseGenerator : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[]
                {
                    new List<TestCase>()
                    {
                        /* 9,3,7,1,8,12,10,20,15,18,5
                         * 
                         *          1
                         *        /   \
                         *      3      5
                         *     / \    /
                         *    9   7  8
                         *            \
                         *             10
                         *            /  \
                         *          12    15
                         *               /  \
                         *             20    18
                         * 
                         */
                        new TestCase()
                        {
                            Input = new Tree_InOrderTraversal.Node(1)
                            {
                                Left = new Tree_InOrderTraversal.Node(3)
                                {
                                    Left = new Tree_InOrderTraversal.Node(9),
                                    Right = new Tree_InOrderTraversal.Node(7)
                                },
                                Right = new Tree_InOrderTraversal.Node(5)
                                {
                                    Left = new Tree_InOrderTraversal.Node(8)
                                    {
                                        Right = new Tree_InOrderTraversal.Node(10)
                                        {
                                            Left = new Tree_InOrderTraversal.Node(12),
                                            Right = new Tree_InOrderTraversal.Node(15)
                                            {
                                                Left = new Tree_InOrderTraversal.Node(20),
                                                Right = new Tree_InOrderTraversal.Node(18)
                                            }
                                        }
                                    }
                                }
                            },
                            Output = "9,3,7,1,8,12,10,20,15,18,5"
                        },
                        /* 4,9,12,7,2,5,1,6,10,8,11,3
                         * 
                         *          1
                         *        /   \
                         *      2      3
                         *     / \    /
                         *    4   5  6
                         *     \      \
                         *      7      8
                         *     /      /  \
                         *    9      10   11
                         *     \       
                         *      12
                         * 
                         */
                        new TestCase()
                        {
                            Input = new Tree_InOrderTraversal.Node(1)
                            {
                                Left = new Tree_InOrderTraversal.Node(2)
                                {
                                    Left = new Tree_InOrderTraversal.Node(4)
                                    {
                                        Right = new Tree_InOrderTraversal.Node(7)
                                        {
                                            Left = new Tree_InOrderTraversal.Node(9)
                                            {
                                                Right = new Tree_InOrderTraversal.Node(12)
                                            }
                                        }
                                    },
                                    Right = new Tree_InOrderTraversal.Node(5)
                                },
                                Right = new Tree_InOrderTraversal.Node(3)
                                {
                                    Left = new Tree_InOrderTraversal.Node(6)
                                    {
                                        Right = new Tree_InOrderTraversal.Node(8)
                                        {
                                            Left = new Tree_InOrderTraversal.Node(10),
                                            Right = new Tree_InOrderTraversal.Node(11)
                                        }
                                    }
                                }
                            },
                            Output = "4,9,12,7,2,5,1,6,10,8,11,3"
                        }
                    },
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}