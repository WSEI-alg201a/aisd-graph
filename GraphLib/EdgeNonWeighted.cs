using System;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Implementacja krawędzi grafu skierowanego, nieważonego
    /// </summary>
    /// <typeparam name="V">vertex - typ wierzchołka grafu</typeparam>
    public class EdgeNonWeighted<V> : IEdge<V>
    {
        public V From { get; set; }
        public V To { get; set; }
        
        // public EdgeNonWeighted() { From = default; To = default; }
        // komentujemy, ponieważ nie chcemy tworzyć krawędzi bez wierzchołków

        public EdgeNonWeighted(V from, V to)
        {
            if(from == null || to == null)
                throw new ArgumentNullException("from or to is null");
            From = from;
            To = to;
        }

        public EdgeNonWeighted(ValueTuple<V,V> value) : this(value.Item1, value.Item2) {}
        
        #region conversions
        public static implicit operator ValueTuple<V,V>(EdgeNonWeighted<V> e) => (e.From, e.To);
        public static implicit operator EdgeNonWeighted<V>(ValueTuple<V,V> value) => new EdgeNonWeighted<V>(value);
        #endregion

        public override string ToString() => $"{From} -> {To}";
    }
}
