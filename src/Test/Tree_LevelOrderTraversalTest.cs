using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Algoritms;
using Xunit;

namespace Test
{
    public class Tree_LevelOrderTraversalTest : TestBase<Tree_LevelOrderTraversal.Node, string>
    {
        [Theory]
        [MemberData(nameof(LevelOrderTraversalTestCases))]
        public void LevelOrderTraversalTest(TestCase testCase)
        {
            // Arrange
            var algo = new Tree_LevelOrderTraversal();

            // Act
            var sut = algo.LevelOrderTraversal(testCase.Input);

            //Assert
            Assert.Equal(testCase.Output, sut);
        }

        public static IEnumerable<object[]> LevelOrderTraversalTestCases => GenerateData(
            /* => 2 5 3 1 7 4 6
             *
             *           2
             *          / \
             *         5   3
             *        / \
             *       1   7
             *      /     \
             *     4       6
             */
            new TestCase(new Tree_LevelOrderTraversal.Node(2)
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
            }, "2 5 3 1 7 4 6"),
            /* => 8 6 2 3 9 5 7 1 4 0
             *           8
             *          / \
             *         6   2
             *        / \
             *       3   9
             *      /     \
             *     5       7
             *    / \     /
             *   1   4   0
             */
            new TestCase(new Tree_LevelOrderTraversal.Node(8)
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
            }, "8 6 2 3 9 5 7 1 4 0"),
            /* => 1
             *    1
             */
            new TestCase(new Tree_LevelOrderTraversal.Node(1), "1"),
            /* => Empty String
             *    null
             */
            new TestCase(null, string.Empty)
        );
    }
}