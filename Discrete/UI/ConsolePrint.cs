using System;
using System.Collections.Generic;
using System.Linq;
using  Discrete.Flow;

namespace  Discrete.UI
{
    /// <summary>
    /// Represents some fancy console output methods
    /// </summary>
    public static class ConsolePrint
    {
        /// <summary>
        /// Headers the print.
        /// </summary>
        /// <param name="content">The content.</param>
        public static void HeaderPrint(string content)
        {
            System.Console.WriteLine($"{"".PadRight(100, '-')}");
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine($"{"".PadRight(100, '-')}");
        }

        /// <summary>
        /// Prints the graph.
        /// </summary>
        /// <param name="list">The list.</param>
        public static void PrintGraph(Graph graph)
        {
            System.Console.WriteLine($"Number of edges: {graph.EdgesCount}");
            System.Console.WriteLine($"Number of nodes: {graph.VerticesCount}");

            string content = "Edges";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine($"\nSource\tDestination\tWeight of edge");
            for (int i = 0; i < graph.EdgesCount; i++)
            {
                System.Console.WriteLine($"{graph.Edges[i].Source}\t\t{graph.Edges[i].Destination}\t\t{graph.Edges[i].Weight}");
            }
            System.Console.WriteLine("\n");
        }

        public static void ShowAdditionalEdges(Graph oldGraph, Graph newGraph)
        {
            string content = "Additional edges to graph";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");

            var differencesCount = newGraph.EdgesCount - oldGraph.EdgesCount;
            var differences = newGraph.Edges.TakeLast(differencesCount);

            System.Console.WriteLine($"New graph edges count: {newGraph.EdgesCount}");
            System.Console.WriteLine($"\nSource\tDestination\tWeight of edge");
            foreach (var item in differences)
            {
                System.Console.WriteLine($"{item.Source}\t\t{item.Destination}\t\t{item.Weight}");
            }
        }

        public static void PrintNodes(Node[] oldNodes, Node[] newNodes)
        {
            string content = "Nodes";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine($"Node id  \tOld Rank  \tNew Rank");
            for (int i = 0; i < oldNodes.Length; i++)
            {
                System.Console.WriteLine($"  {oldNodes[i].Id}\t\t{oldNodes[i].Rank}\t\t{newNodes.First(x => x.Id == oldNodes[i].Id).Rank}");
            }
            System.Console.WriteLine();
        }

        public static void PrintPath(Node[] nodes)
        {
            string content = "Path";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine();
            for (int i = 0; i < nodes.Length; i++)
            {
                System.Console.Write($"{nodes[i].Id} => ");
            }
            System.Console.Write($"\n");
        }

        public static void PrintPath(Edge[] edges)
        {
            string content = "Path";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine();
            for (int i = 0; i < edges.Length; i++)
            {
                System.Console.Write($"{edges[i].Source} => {edges[i].Destination} => ");
            }
            System.Console.WriteLine("\n");
        }

        public static void PrintFlow(Edge[] edges, FlowModel[] flows)
        {
            string content = "Path";
            System.Console.WriteLine($"{"".PadRight(50 - content.Length / 2, ' ')}{content}");
            System.Console.WriteLine();
            for (int i = 0; i < edges.Length; i++)
            {
                System.Console.Write($"{edges[i].Source} =({flows.First(x => x.Edge.Source == edges[i].Source && x.Edge.Destination == edges[i].Destination).Flow}/{edges[i].Weight})=> {edges[i].Destination}\n");
            }
            System.Console.WriteLine("\n");
        }
    }
}