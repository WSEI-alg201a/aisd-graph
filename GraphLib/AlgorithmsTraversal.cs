using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Dostarcza metody przeglądania grafu: DFS i BFS
    /// </summary>
    public static class AlgorithmsTraversal
    {
        /// <summary>
        /// Przegląda graf metodą DFS
        /// </summary>
        /// <remarks>Wykorzystuje dowolną implementację grafu, opartą na interfejsie `IGraph`</remarks>
        /// <param name="graph">implementacja grafu</param>
        /// <param name="start">wierzchołek od którego rozpoczyna się przeglądanie</param>
        /// <typeparam name="V">vertex - typ wierzchołka</typeparam>
        /// <returns>Zwraca iterator odwiedzanych wierzchołków</returns>        
        public static IEnumerable<V> TraverseDepthFirst<V>(this IGraph<V,IEdge<V>> graph, V start)
        {
            var visited = new HashSet<V>();

            if (!graph.ContainsVertex(start))
                yield break;

            var stack = new Stack<V>();
            stack.Push(start);

            while (stack.Count > 0)
            {
                var current = stack.Pop();

                if (visited.Contains(current))
                    continue;

                yield return current;

                visited.Add(current);

                foreach (var neighbour in graph.Neighbours(current))
                    if (!visited.Contains(neighbour))
                        stack.Push(neighbour);
            }

            yield break;
        }

        /// <summary>
        /// Przegląda graf metodą BFS
        /// </summary>
        /// <remarks>Wykorzystuje dowolną implementację grafu, opartą na interfejsie `IGraph`</remarks>
        /// <param name="graph">implementacja grafu</param>
        /// <param name="start">wierzchołek od którego rozpoczyna się przeglądanie</param>
        /// <typeparam name="V">vertex - typ wierzchołka</typeparam>
        /// <returns>Zwraca iterator odwiedzanych wierzchołków</returns>     
        public static IEnumerable<V> TraverseBreadthFirst<V>(this IGraph<V,IEdge<V>> graph, V start)
        {
            var visited = new HashSet<V>();

            if (!graph.ContainsVertex(start))
                yield break;

            var queue = new Queue<V>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var current = queue.Dequeue();

                if (visited.Contains(current))
                    continue;

                yield return current;

                visited.Add(current);

                foreach (var neighbour in graph.Neighbours(current))
                    if (!visited.Contains(neighbour))
                        queue.Enqueue(neighbour);
            }

            yield break;
        }
    }
}
