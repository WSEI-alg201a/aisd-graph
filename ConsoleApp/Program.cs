﻿using System;
using kmolenda.aisd.GraphLib;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            TestGraphUnidirectedNonWeightedAdjacencyList();
        }

        static void TestGraphUnidirectedNonWeightedAdjacencyList()
        {
            var vertices = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};

            EdgeNonWeighted<int>[] edges = { (1, 1), (1, 2), (1, 3), (2, 4), (3,5), (3,6), (4,7), (5,7), (5,8), (5,6), (8,9), (9,10) };
            
            var graph = new GraphNonWeightedAdjacencyList<int, EdgeNonWeighted<int> >(vertices, edges );
            Console.WriteLine( graph.ToString<int>() );

                        string s = "Traverse depth-first:   ";
            foreach( var vertex in graph.TraverseDepthFirst(start: 1) )
                s += vertex + " ";
            Console.WriteLine(s);

            s = "Traverse breadth-first: ";
            foreach( var vertex in graph.TraverseBreadthFirst(start: 1) )
                s += vertex + " ";
            Console.WriteLine(s);

            int a = 1, b = 4;
            var path = graph.ShortestPath(start: a, end: b);
            Console.WriteLine( $"Shortest path from {a} to {b}: {string.Join(", ", path)}" );

            foreach( var vertex in graph.Vertices )
            {
                var fun = graph.ShortestPathFunc(start: a);
                Console.WriteLine( $"Shortest path from {a} to {vertex}: {string.Join(", ", fun(vertex))}" );
            }
        }
    }
}
