using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Tree_HeightOfABinaryTreeTest : TestBase<Tree_HeightOfABinaryTree.Node, int>
    {
        [Theory]
        [MemberData(nameof(HeightOfABinaryTreeTestCases))]
        public void HeightOfABinaryTreeTest(TestCase testCase)
        {
            // Arrange
            var algo = new Tree_HeightOfABinaryTree();

            // Act
            var sut = algo.LevelOfDepth(testCase.Input);

            // Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> HeightOfABinaryTreeTestCases = GenerateData(
            new TestCase(new Tree_HeightOfABinaryTree.Node()
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
            }, 4),
            new TestCase(new Tree_HeightOfABinaryTree.Node()
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
            }, 5)
        );
    }
}