using System.Collections.Generic;
using System.Linq;

namespace Algoritms
{
    public class Tree_InOrderTraversal
    {
        /* 9,3,7,1,8,12,10,20,15,18,5
        * 
        *          1
        *        /   \
        *       3     5
        *      / \   /
        *     9   7 8
        *            \
        *             10
        *            /  \
        *          12    15
        *               /  \
        *             20    18
        * 
        */
        public string InOrderTraversal(Node root)
        {
            var result = new HashSet<int>();
            var stack = new Stack<Node>();
            stack.Push(root);
            Travel(stack, result);

            return string.Join(",", result);
        }

        public void Travel(Stack<Node> nodeStack, HashSet<int> result)
        {
            var currentNode = nodeStack.Peek();
            if (currentNode.Left != null && !result.Contains(currentNode.Left.Value))
            {
                nodeStack.Push(currentNode.Left);
            }
            else if (currentNode.Right != null && !result.Contains(currentNode.Right.Value))
            {
                currentNode = nodeStack.Pop();
                result.Add(currentNode.Value);
                nodeStack.Push(currentNode.Right);
            }
            else
            {
                currentNode = nodeStack.Pop();
                result.Add(currentNode.Value);
            }

            if (nodeStack.Any())
                Travel(nodeStack, result);
        }

        public class Node
        {
            public int Value { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int value)
            {
                Value = value;
            }
        }
    }
}