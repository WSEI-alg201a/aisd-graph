using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Undirected, strict (without multi-edges), non-weighted graph, implemented as adjacency list. 
    /// Self-connections allowed.
    /// </summary>
    /// <typeparam name="V">type of vertex</typeparam>
    /// <typeparam name="E">type of edge, as class</typeparam>
    public class GraphNonWeightedAdjacencyList<V, E> : IGraph<V, IEdge<V>>
        where E : IEdge<V>, new()
    {
        // Dictionary: { 1 -> {1, 2, 3}, 2 -> {1}, 3 -> {1} }
        public Dictionary<V, HashSet<V>> AdjacencyList { get; }
                                    = new Dictionary<V, HashSet<V>>();

        #region === Constructors ===
        public GraphNonWeightedAdjacencyList() { }

        public GraphNonWeightedAdjacencyList(int initialSize)
        {
            AdjacencyList = new Dictionary<V, HashSet<V>>(initialSize);
        }

        public GraphNonWeightedAdjacencyList(IEnumerable<V> vertices, IEnumerable<E> edges)
        {
            foreach (var vertex in vertices) AddVertex(vertex);
            foreach (var edge in edges) AddEdge(edge);
        }
        #endregion === Constructors ===


        #region === Add vertices, edges ===

        public bool AddVertex(V vertex)
        {
            if (ContainsVertex(vertex))
                return false;

            AdjacencyList[vertex] = new HashSet<V>();
            return true;
        }

        public bool AddEdge(V from, V to) => AddEdge( new E(){From = from, To = to} );

        public bool AddEdge(IEdge<V> edge)
        {
            if (AdjacencyList.ContainsKey(edge.From) && AdjacencyList.ContainsKey(edge.To))
            {
                AdjacencyList[edge.From].Add(edge.To);
                AdjacencyList[edge.To].Add(edge.From);
                return true;
            }
            return false;
        }        
        #endregion === Add vertices, edges ===

        public IEnumerable<V> Vertices => AdjacencyList.Keys;

        public IEnumerable<IEdge<V>> Edges 
        {
            get
            {
                foreach (var vertex in Vertices)
                    foreach (var neighbour in Neighbours(vertex))
                        yield return  new E() {From = vertex, To = neighbour};
            }
        }

        public bool ContainsVertex(V vertex) => AdjacencyList.ContainsKey(vertex);

        public IEnumerable<V> Neighbours(V vertex) => AdjacencyList[vertex];

        public bool RemoveVertex(V vertex) => throw new NotImplementedException();
        
        public bool RemoveEdge(IEdge<V> edge) => throw new NotImplementedException();
        public bool ContainsEdge(IEdge<V> edge) =>
            ContainsVertex(edge.From) && AdjacencyList[edge.From].Contains(edge.To);        
    }
}
