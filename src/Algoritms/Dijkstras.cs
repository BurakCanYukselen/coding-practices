using System;
using System.Collections.Generic;

namespace Algoritms
{
    public class Dijkstras
    {
        /*
         *   //A, B, C,  D,  E, F, G
         *   { 0, 4, 3,  0,  7, 0, 0 }, // A 
         *   { 4, 0, 6,  5,  0, 0, 0 }, // B 
         *   { 3, 6, 0,  11, 8, 0, 0 }, // C 
         *   { 0, 5, 11, 0,  2, 2, 10 }, // D 
         *   { 7, 0, 8,  2,  0, 0, 5 }, // E 
         *   { 0, 0, 0,  2,  0, 0, 3 }, // F 
         *   { 0, 0, 0,  10, 5, 3, 0 }, // G 
         */
        public int ShortestPath(int[,] map, int from, int to)
        {
            var adjNodes = new Dictionary<int, int>();
            adjNodes.Add(from, 0);
            var travelledNodes = new List<int>();

            while (from != to)
            {
                // collect visited nodes
                travelledNodes.Add(from);

                for (var i = 0; i < map.GetLength(1); i++)
                {
                    // if node does not have connection or already visited move to next
                    if (map[from, i] == 0 || travelledNodes.Contains(i))
                        continue;
                    
                    // cumulative sum of path value up to next node 
                    var nextNodePathValue = map[from, i];
                    var nextNodePathValueSum = adjNodes[from] + nextNodePathValue;

                    // check if cumulative sum of the next node path is cached
                    if (adjNodes.ContainsKey(i))
                    {
                        // if calculated value is higher than cached one move to next else update cached value
                        if (nextNodePathValueSum >= adjNodes[i])
                            continue;
                        else
                            adjNodes[i] = nextNodePathValueSum;
                    }
                    else
                        adjNodes.Add(i, nextNodePathValueSum);
                }

                // set current node which has minumum cumulative path value and skip already visited nodes  
                var minValueOfAdjacentNode = -1;
                foreach (var node in adjNodes)
                {
                    if (travelledNodes.Contains(node.Key))
                        continue;
                    if (minValueOfAdjacentNode < 0 || minValueOfAdjacentNode > node.Value)
                    {
                        minValueOfAdjacentNode = node.Value;
                        from = node.Key;
                    }
                }
            }

            // get the value of target node
            var shortestPath = adjNodes[to];

            return shortestPath;
        }
    }
}