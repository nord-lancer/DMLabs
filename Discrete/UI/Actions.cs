using System.Collections.Generic;
using System.Linq;
using  Discrete.ChinesePostman;
using  Discrete.Flow;
using  Discrete.Salesman_problem;

namespace  Discrete.UI
{
    public static class Actions
    {
        public static void GetKruskal()
        {
            var graph = Initializing.CreateGraph(@"./_Kruskal.txt");
            var graphToReturn = KruskalAlgorithm.KruskalSolve(graph);
            
            System.Console.WriteLine("\n");
            ConsolePrint.HeaderPrint("Kruskal's method minimum spanning tree");
            ConsolePrint.PrintGraph(graph);
            ConsolePrint.PrintGraph(graphToReturn);
        }
        public static void GetSalesman()
        {
            var graph = Initializing.CreateGraph(@"./_SalesmanProblem.txt");
            var matrix = Initializing.CreateMatrix(@"./_SalesmanProblem.txt");

            BnB_matrix brunchAndBound = new BnB_matrix();

            var edges = brunchAndBound.BranchAndBound(matrix);

            System.Console.WriteLine("\n");
            ConsolePrint.HeaderPrint("Salesman problem");
            ConsolePrint.PrintGraph(graph);
            ConsolePrint.PrintPath(edges);
        }
        public static void GetChinesePostman()
        {
            var graph = Initializing.CreateGraph(@"./_ChinesePostman.txt");

            Graph newGraph = new Graph();
            if (!ChinesePostman.ChinesePostman.IsEvenDegree(graph.Nodes))
            {
                var oddNodes = OddFinder.FindOddNodes(graph.Nodes);
                newGraph = ChinesePostman.ChinesePostman.PairingOddVertices(graph, oddNodes);
            }
            var eulerianPath = ChinesePostman.ChinesePostman.FindEulerianPath(newGraph);
            // newGraph.Nodes = eulerianPath.ToArray();
            // List<Graph> fullResponse = new List<Graph> { graph, newGraph };

            System.Console.WriteLine("\n");
            ConsolePrint.HeaderPrint("Chinese postman problem");
            ConsolePrint.PrintGraph(graph);
            ConsolePrint.ShowAdditionalEdges(graph, newGraph);
            ConsolePrint.PrintNodes(graph.Nodes, newGraph.Nodes);
            ConsolePrint.PrintPath(eulerianPath.ToArray());
        }

        public static void GetMaxFlowByFF()
        {
            var graph = Initializing.CreateGraph(@"./_Flow.txt");

            FlowCalc flowCalc = new FlowCalc(graph);
            var flow = flowCalc.FindMaximumFlow();

            var maxFlow = flow.Where(e => e.Edge.Destination == graph.Nodes.Last().Id).Sum(x => x.Flow);

            System.Console.WriteLine("\n");
            ConsolePrint.HeaderPrint("Max flow");
            ConsolePrint.PrintGraph(graph);
            ConsolePrint.PrintFlow(graph.Edges, flow.ToArray());
            System.Console.WriteLine($"MAXIMUM FLOW = {maxFlow}");
        }
    }
}