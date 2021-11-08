using System.Collections.Generic;

namespace Algoritms
{
    public class BFS_ShortestReachInGraph
    {
        public int PathWeight { get; set; }

        public class GraphMatrix
        {
            public int NodeCount { get; set; }
            public int EdgeCount { get; set; }
            public int[,] Nodes { get; set; }
            public int StartingNodeIndex { get; set; }
        }

        public BFS_ShortestReachInGraph(int pathWeight)
        {
            this.PathWeight = pathWeight;
        }

        public List<GraphMatrix> GenerateGraphMatrixes(List<string> inputs)
        {
            if (inputs.Count == 0)
                return null;

            var query = int.Parse(inputs[0]);
            if (query == 0)
                return null;

            var graphList = new List<GraphMatrix>();
            var nextQueryStart = 1;
            for (int i = 0; i < query; i++)
            {
                var graph = new GraphMatrix();
                for (int j = nextQueryStart; j < inputs.Count; j++)
                {
                    var singleInputPrevious = inputs[j - 1].Split(" ").Length < 2;
                    var singleInputCurrent = inputs[j].Split(" ").Length < 2;
                    var nodeAndEdgePairs = graph.NodeCount == 0 && graph.EdgeCount == 0;
                    if (singleInputPrevious && nodeAndEdgePairs)
                    {
                        var pairs = inputs[j].Split(" ");
                        graph.NodeCount = int.Parse(pairs[0]);
                        graph.EdgeCount = int.Parse(pairs[1]);
                        graph.Nodes = new int[graph.NodeCount, graph.NodeCount];
                    }
                    else if (singleInputCurrent && !nodeAndEdgePairs)
                    {
                        graph.StartingNodeIndex = int.Parse(inputs[j]) - 1;
                        nextQueryStart = j + 1;
                        break;
                    }
                    else
                    {
                        var pairs = inputs[j].Split(" ");
                        var parent = int.Parse(pairs[0]);
                        var child = int.Parse(pairs[1]);
                        graph.Nodes[child - 1, parent - 1] = PathWeight;
                        graph.Nodes[parent - 1, child - 1] = PathWeight;
                    }
                }

                graphList.Add(graph);
            }

            return graphList;
        }
        
        public List<string> Path(List<GraphMatrix> graphs)
        {
            var output = new List<string>();
            foreach (var graph in graphs)
            {
                var adjNodes = new Dictionary<int, int>();
                var from = graph.StartingNodeIndex;

                var travelledNodes = new List<int>();
                while (from <= graph.NodeCount && from != -1)
                {
                    // collect visited nodes
                    travelledNodes.Add(from);
                    
                    // keep track if all nodes are zero
                    var thisNodeNotHaveChild = true;
                    
                    for (int i = 0; i < graph.Nodes.GetLength(1); i++)
                    {
                        // if node does not have connection move next 
                        if (graph.Nodes[from, i] == 0)
                            continue;

                        // if node has connection then mark as it has a child
                        thisNodeNotHaveChild = false;
                        
                        // if current visited node cached 
                        if (adjNodes.ContainsKey(from))
                        {
                            // if adjacent node is already travelled then move next
                            // else cache cumulative weigth of the node
                            if (travelledNodes.Contains(i))
                                continue;
                            else
                                adjNodes.Add(i, graph.Nodes[from, i] + adjNodes[from]);
                        }
                        else
                        {
                            adjNodes.Add(i, graph.Nodes[from, i]);
                        }
                    }

                    // if node not connected to any node set visited node path value as -1 
                    if (thisNodeNotHaveChild)
                        adjNodes[from] = -1;

                    // set current node as min node index among unvisited nodes
                    var minIndex = -1;
                    for (var nodeIndex = 0; nodeIndex < graph.NodeCount; nodeIndex++)
                    {
                        if (travelledNodes.Contains(nodeIndex))
                            continue;
                        if (minIndex < 0 || nodeIndex < minIndex)
                            minIndex = nodeIndex;
                    }

                    from = minIndex;
                }

                // create output string in descending order
                var path = string.Empty;
                for (int i = 0; i < graph.NodeCount; i++)
                    if (adjNodes.ContainsKey(i))
                        path = $"{path} {adjNodes[i]}";

                output.Add(path.Trim());
            }

            return output;
        }
    }
}