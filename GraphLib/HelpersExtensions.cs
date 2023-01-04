using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{      
    /// <summary>
    /// Dostarcza pomocnicze metody rozszerzające klasy z biblioteki GraphLib.
    /// </summary>
    public static class HelpersExtensions
    {

        /// <summary>
        /// Zwraca listę sąsiadów dla każdego wierzchołka grafu.
        /// </summary>
        public static string ToString<V>(this IGraph<V, IEdge<V>> graph)
        {
            var wynik = new System.Text.StringBuilder("{");
            foreach (var vertex in graph.Vertices)
            {
                wynik.Append($" {vertex}->{{{string.Join(", ", graph.Neighbours(vertex))}}};"); //To output a { you use {{ and to output a } you use }}.
            }
            wynik[wynik.Length - 1] = ' ';
            return wynik.Append('}').ToString();
        }
    }
}