using System;
using System.Linq;
using kmolenda.aisd.GraphLib;

namespace ConsoleApp
{
    partial class Program
    {
        static void Main(string[] args)
        {
            TestGraphUndirectedNonWeightedAdjacencyList();
        }


        /// <summary>
        /// Przykład grafu nieskierowanego, nieważonego, reprezentowanego za pomocą listy sąsiedztwa.
        /// Etykietami wierzchołków są liczby całkowite.
        /// Wydruk grafu, przeglądanie grafu DFS i BFS, szukanie najkrótszej ścieżki.
        /// </summary>
        static void TestGraphUndirectedNonWeightedAdjacencyList()
        {
            var vertices = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            EdgeUndirectedNonWeighted<int>[] edges = { (1, 1), (1, 2), (1, 3), (2, 4), (3, 5), (3, 6), (4, 7), (5, 7), (5, 8), (5, 6), (8, 9), (9, 10) };

            var graph = new GraphNonWeightedAdjacencyList<int, EdgeUndirectedNonWeighted<int>>(vertices, edges);
            Console.WriteLine("Graf: " + graph.ToString<int>());

            Console.WriteLine("Wierzchołki: " + string.Join(", ", graph.Vertices));

            var edges2 = graph.Edges.ToList();
            Console.WriteLine("Krawędzie: " + string.Join(", ", edges2));

            string s = "Traverse depth-first:   ";
            foreach (var vertex in graph.TraverseDepthFirst(start: 1))
                s += vertex + " ";
            Console.WriteLine(s);

            s = "Traverse breadth-first: ";
            foreach (var vertex in graph.TraverseBreadthFirst(start: 1))
                s += vertex + " ";
            Console.WriteLine(s);

            int a = 1, b = 4;
            var path = graph.ShortestPath(start: a, end: b);
            Console.WriteLine($"Shortest path from {a} to {b}: {string.Join(", ", path)}");

            Console.WriteLine($"All shortest paths from {a} to all vertices:");
            foreach (var vertex in graph.Vertices)
            {
                var fun = graph.ShortestPathFunc(start: a);
                Console.WriteLine($"Shortest path from {a} to {vertex}: {string.Join(", ", fun(vertex))}");
            }
        }
    }
}
