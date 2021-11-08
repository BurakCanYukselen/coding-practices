using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Tree_HeightOfABinaryTreeTest
    {
        [Theory]
        [ClassData(typeof(TestCaseGenerator))]
        public void HeightOfABinaryTreeTest(List<TestCase> testCases)
        {
            var result = new List<bool>();
            foreach (var testCase in testCases)
            {
                // Arrange
                var algo = new Tree_HeightOfABinaryTree();

                // Act
                var sut = algo.LevelOfDepth(testCase.Input);
                result.Add(testCase.Output == sut);
            }

            // Assert
            Assert.True(result.All(p => p == true));
        }

        public class TestCase
        {
            public Tree_HeightOfABinaryTree.Node Input { get; set; }
            public int Output { get; set; }
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
                            Input = new Tree_HeightOfABinaryTree.Node()
                            {
                                Left = new Tree_HeightOfABinaryTree.Node()
                                {
                                    Left = new Tree_HeightOfABinaryTree.Node()
                                    {
                                        Left = new Tree_HeightOfABinaryTree.Node()
                                    }
                                },
                                Right = new Tree_HeightOfABinaryTree.Node()
                                {
                                    Left = new Tree_HeightOfABinaryTree.Node(),
                                    Right = new Tree_HeightOfABinaryTree.Node()
                                    {
                                        Right = new Tree_HeightOfABinaryTree.Node()
                                        {
                                            Right = new Tree_HeightOfABinaryTree.Node()
                                        }
                                    }
                                }
                            },
                            Output = 4,
                        },
                        new TestCase()
                        {
                            Input = new Tree_HeightOfABinaryTree.Node()
                            {
                                Left = new Tree_HeightOfABinaryTree.Node()
                                {
                                    Left = new Tree_HeightOfABinaryTree.Node()
                                    {
                                        Right = new Tree_HeightOfABinaryTree.Node()
                                        {
                                            Right = new Tree_HeightOfABinaryTree.Node()
                                            {
                                                Left = new Tree_HeightOfABinaryTree.Node()
                                            }
                                        }
                                    }
                                },
                                Right = new Tree_HeightOfABinaryTree.Node()
                                {
                                    Left = new Tree_HeightOfABinaryTree.Node()
                                }
                            },
                            Output = 5
                        }
                    },
                };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}