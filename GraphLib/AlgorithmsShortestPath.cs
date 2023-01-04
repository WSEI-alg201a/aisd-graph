using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Dostarcza metody rozszerzające interfejs `IGraph` o algorytmy szukania najkrótszej ścieżki
    /// </summary>
    public static class AlgorithmsShortestPath
    {
 
        /// <summary>
        /// Zwraca funkcję, która zwraca najkrótsze ścieżki od węzła start (najkrótsze, w sensie liczby krawędzi)
        /// </summary>
        /// <remarks>
        /// Wykorzystuje dowolną implementację grafu, opartą na interfejsie `IGraph`.
        /// Wykorzystuje koncepcję przeglądania BFS. Wychodząc od początkowego wierzchołka, zapamiętuje
        /// w słowniku `previous` jak dojść do każdego węzła. Aby znaleźć najkrószą ścieżkę
        /// wyszukujemy poprzedni węzeł dla węzła docelowego i kontynuujemy przeglądanie
        /// wszystkich poprzednich węzłów, aż dotrzemy do węzła początkowego.
        /// Otrzymana ścieżka jest w kolejności odwrotnej, dlatego `Reverse();`
        /// </remarks>
        /// <usage>var path = graph.ShortestPathFunc<int>(start: 1)(4); // dla węzłów typu `int`.</usage>
        /// <param name="graph">graf, w dowolnej implementacji</param>
        /// <param name="start">wierzchołek od którego rozpoczynane jest przeglądanie</param>
        /// <typeparam name="V">vertex - typ wierzchołka</typeparam>
        /// <returns>Funkcję, która dla określonego węzła zwraca najkrótszą ścieżkę prowadzącą od węzła start</returns>
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

            // funkcja lokalna, wewnętrzna, zwracająca najkrótszą ścieżkę
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
        
        /// <summary>
        /// Zwraca iterator, który zwraca kolejne węzły będące najkrótszą ścieżką między węzłami start i end
        /// </summary>
        /// <remarks>Jest opakowaniem funkcji ShortestPathFunc</remarks>
        /// <param name="graph">graf, dowolna implementacja</param>
        /// <param name="start">wierzchołek początkowy</param>
        /// <param name="end">wierzchołek końcowy</param>
        /// <typeparam name="V">vertex - typ wierzchołka</typeparam>
        /// <returns>Zwraca iterator, który zwraca kolejne węzły będące najkrótszą ścieżką między węzłami start i end</returns>
        public static IEnumerable<V> ShortestPath<V>(this IGraph<V, IEdge<V>> graph, V start, V end)
            => graph.ShortestPathFunc<V>(start)(end);
            
    }
}