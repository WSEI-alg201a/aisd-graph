using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="V">vertex - typ reprezętujący węzeł</typeparam>
    /// <typeparam name="E">edge - typ reprezentujący krawędź</typeparam>
    public interface IGraph<V, E> where E : IEdge<V>
    {
        // dodaje węzeł do grafu
        // jeśli węzeł już istnieje, nadpisuje
        bool AddVertex(V vertex);

        // sprawdza, czy węzeł jest w grafie
        bool ContainsVertex(V vertex);

        // zwraca kolekcję węzłów połączonych z podanym
        IEnumerable<V> Neighbours(V vertex);

        // zwraca kolekcję wszystkich węzłów
        IEnumerable<V> Vertices { get; }

        // dodaje krawędź do grafu
        bool AddEdge(E edge);

        // zwraca kolekcję wszystkich krawędzi
        IEnumerable< E > Edges {get;}

    }
}
