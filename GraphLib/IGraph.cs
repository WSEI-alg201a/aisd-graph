using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Definiuje elementarną koncepcję grafu
    /// </summary>
    /// <typeparam name="V">vertex - typ reprezentujący węzeł</typeparam>
    /// <typeparam name="E">edge - typ reprezentujący krawędź</typeparam>
    public interface IGraph<V, E> where E : IEdge<V>
    {

        #region  === Constructors ===
        // konstruktor bezparametrowy, tworzony jest pusty graf

        // konstruktor z parametrami `vertices` i `edges`, tworzony jest graf 
        // z podanymi węzłami `IEnumerable<V>` i krawędziami `IEnumerable<IEdge<V>>`
        # endregion === Constructors ===

        #region === Vertices ===
        // dodaje węzeł do grafu, zwraca `true`, jeśli węzeł został dodany
        // jeśli węzeł już istnieje, nadpisuje, zwraca `false` (nie zgłasza wyjątku)
        bool AddVertex(V vertex);

        // usuwa węzeł z grafu, zwraca `true`, jeśli węzeł został usunięty
        // jeśli węzeł nie istnieje, zwraca `false` (nie zgłasza wyjątku)
        bool RemoveVertex(V vertex);

        // sprawdza, czy węzeł jest w grafie
        bool ContainsVertex(V vertex);

        // zwraca iterator/kolekcję węzłów połączonych z podanym
        IEnumerable<V> Neighbours(V vertex);

        // zwraca iterator/kolekcję wszystkich węzłów
        IEnumerable<V> Vertices { get; }
        #endregion === Vertices ===

        #region === Edges ===
        // dodaje krawędź do grafu, zwraca `true`, jeśli krawędź została dodana
        // jeśli krawędź już istnieje, nadpisuje, zwraca `false` (nie zgłasza wyjątku)
        // jeśli którykolwiek z wierzchołków nie istnieje, zwraca `false` (nie zgłasza wyjątku)
        bool AddEdge(E edge);

        // zwraca iterator/kolekcję wszystkich krawędzi
        IEnumerable< E > Edges {get;}
        #endregion === Edges ===
    }
}
