using System;
using System.Collections.Generic;

namespace Algoritms
{
    public class DijkstrasAlgorithm
    {
        public int Dijkstras(int[,] map, int from, int to)
        {
            var adjNodes = new Dictionary<int, int>();
            adjNodes.Add(from, 0);
            var travelledNodes = new List<int>();

            while (from != to)
            {
                travelledNodes.Add(from);

                for (var i = 0; i < map.GetLength(1); i++)
                {
                    if (map[from, i] == 0 || travelledNodes.Contains(i))
                        continue;

                    var nextNodePathValue = map[from, i];
                    var nextNodePathValueSum = adjNodes[from] + nextNodePathValue;

                    if (adjNodes.ContainsKey(i))
                    {
                        if (nextNodePathValueSum >= adjNodes[i])
                            continue;
                        else
                            adjNodes[i] = nextNodePathValueSum;
                    }
                    else
                        adjNodes.Add(i, nextNodePathValueSum);
                }

                var minValueOfTravelledNode = -1;
                foreach (var node in adjNodes)
                {
                    if (travelledNodes.Contains(node.Key))
                        continue;
                    if (minValueOfTravelledNode < 0 || minValueOfTravelledNode > node.Value)
                    {
                        minValueOfTravelledNode = node.Value;
                        from = node.Key;
                    }
                }
            }

            var min = adjNodes[from];

            return min;
        }
    }
}