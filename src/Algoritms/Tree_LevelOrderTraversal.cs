using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Algoritms
{
    public class Tree_LevelOrderTraversal
    {
        public class Node
        {
            public int Data { get; set; }
            public Node Left { get; set; }
            public Node Right { get; set; }

            public Node(int data)
            {
                Data = data;
            }
        };

        // => 2 5 3 1 7 4 6
        //
        //           2
        //          / \
        //         5   3
        //        / \
        //       1   7
        //      /     \
        //     4       6
        //
        //
        public string LevelOrderTraversal(Node root)
        {
            if (root == null)
                return string.Empty;

            var queue = new Queue<Node>();
            queue.Enqueue(root);

            var traversal = new List<int>();
            while (queue.Any())
            {
                var currentNode = queue.Dequeue();
                traversal.Add(currentNode.Data);
                if (currentNode.Left != null)
                    queue.Enqueue(currentNode.Left);
                if (currentNode.Right != null)
                    queue.Enqueue(currentNode.Right);
            }

            return string.Join(" ", traversal);
        }
    }
}