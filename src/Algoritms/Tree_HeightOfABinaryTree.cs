using System;

namespace Algoritms
{
    public class Tree_HeightOfABinaryTree
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }
        };
        
        //     1
        //   1  1
        //  1  1  1
        // 1       1
        //          1
        
        public int LevelOfDepth(Node root)
        {
            var currentNode = root;
            if (currentNode.Left == null && currentNode.Right == null)
                return 0;

            var leftHeight = 0;
            var rightHeight = 0;
            if (currentNode.Left != null)
                leftHeight = LevelOfDepth(currentNode.Left) + 1;
            if(currentNode.Right != null)
                rightHeight = LevelOfDepth(currentNode.Right) + 1;

            return Math.Max(leftHeight, rightHeight);
        }
    }
}