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

        // Funkcja zwracająca funkcję, która zwraca najkrószą ścieżkę (w sensie liczby krawędzi)
        // między wskazanymi wezłami
        // Użycie: `var path = graph.ShortestPathFunc<int>(start: 1)(4);` dla węzłów typu `int`.
        // Wykorzystuje koncepcję BFS. Wychodząc od początkowego wierzchołka, zapamiętuje
        // w słowniku `previous` jak dojść do każdego węzła. aby znaleźć najkrószą ścieżkę
        // wyszukujemy poprzedni węzeł dla węzła docelowego i kontynuujemy przeglądanie
        // wszystkich poprzednich węzłów, aż dotrzemy do węzła początkowego.
        // Otrzymana ścieżka jest w kolejności odwrotnej, dlatego `Reverse();`
        public static Func<V, IEnumerable<V>> ShortestPathFunc<V>(this IGraph<V, IEdge<V>> graph, V start)
        {
            var previous = new Dictionary<V, V>();

            var queue = new Queue<V>();
            queue.Enqueue(start);

            while (queue.Count > 0)
            {
                var vertex = queue.Dequeue();
                foreach (var neighbour in graph.Neighbours(vertex))
                {
                    if (previous.ContainsKey(neighbour))
                        continue;

                    previous[neighbour] = vertex;
                    queue.Enqueue(neighbour);
                }
            }

            Func<V, IEnumerable<V>> shortestPath = v =>
            {
                var path = new List<V> { };

                var current = v;
                while (!current.Equals(start))
                {
                    path.Add(current);
                    current = previous[current];
                };

                path.Add(start);
                path.Reverse(); //można zakomentować, jeśli nie przeszkadza odwrotny porządek
                                //zawsze można później odwrócić przechwycony wynik

                return path;
            };

            return shortestPath;
        } // koniec ShortestPathFunc

        // Funkcja zwracająca sekwencję węzłów będacych najkrószą ścieżką (w sensie liczby krawędzi)
        // między wskazanymi węzłami
         public static IEnumerable<V> ShortestPath<V>(this IGraph<V, IEdge<V>> graph, V start, V end)
            => graph.ShortestPathFunc<V>(start)(end);
            

    }
}
