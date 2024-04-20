using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Project
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of vertices in the graph:");
            var vertices = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter the density of the graph (a value between 0 and 100):");
            var density = double.Parse(Console.ReadLine()) / 100;

            var edges = GraphGenerator.GenerateGraph(vertices, density);
            var adjacencyMatrix = GraphGenerator.GenerateAdjacencyMatrix(edges, vertices);
            var adjacencyList = GraphGenerator.GenerateAdjacencyList(edges, vertices);

            var vertexNames = new List<int>(); // змінено
            for (int i = 1; i <= vertices; i++) // змінено
            {
                vertexNames.Add(i); // змінено
            }

            Print.PrintMatrix(adjacencyMatrix, vertexNames, "Adjacency Matrix:");

            Console.WriteLine("\nAdjacency List:");
            Print.PrintAdjacencyList(adjacencyList, vertexNames);

            var random = new Random();
            var startNode = random.Next(1, vertices + 1);

            Console.WriteLine($"\nStart Node for DFS: {startNode}");

            var stopwatchDFS = Stopwatch.StartNew();
            var reachabilityMatrixDFS = DFSSolver.GenerateReachabilityMatrix(adjacencyList, vertices);
            stopwatchDFS.Stop();

            Print.PrintMatrix(reachabilityMatrixDFS, vertexNames, "DFS Reachability Matrix:");

            Console.WriteLine($"\nTime taken for DFS: {stopwatchDFS.ElapsedMilliseconds} milliseconds");

            Console.WriteLine($"\nStart Node for BFS: {startNode}");

            var stopwatchBFS = Stopwatch.StartNew();
            var reachabilityMatrixBFS = BFSsolver.GenerateReachabilityMatrix(adjacencyList, vertices);
            stopwatchBFS.Stop();

            Print.PrintMatrix(reachabilityMatrixBFS, vertexNames, "BFS Reachability Matrix:");

            Console.WriteLine($"\nTime taken for BFS: {stopwatchBFS.ElapsedMilliseconds} milliseconds");
        }
    }
}
