using System;
using System.Collections.Generic;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// Implementacja krawędzi grafu nieskierowanego, nieważonego
    /// </summary>
    /// <remarks>Implementacja `IEquatable` wymusza równość `(u, v) == (v, u)`</remarks>
    /// <typeparam name="V">vertex - typ wierzchołka grafu</typeparam>
    public class EdgeUndirectedNonWeighted<V> : EdgeNonWeighted<V>, IEquatable<EdgeUndirectedNonWeighted<V>>
    {     
        public EdgeUndirectedNonWeighted() : base() {}

        public EdgeUndirectedNonWeighted(V from, V to) : base(from, to) {}
        
        public EdgeUndirectedNonWeighted(ValueTuple<V,V> value) : base(value) {}
 
        public override string ToString() => $"{From} -- {To}";

        #region === Equals, GetHashCode ===
        public override bool Equals(object obj) => (obj is null)? false : Equals(obj as EdgeUndirectedNonWeighted<V>);

        public override int GetHashCode() => HashCode.Combine(From, To);

        public bool Equals(EdgeUndirectedNonWeighted<V> other) => 
            (other is null)? false :       
                EqualityComparer<V>.Default.Equals(From, other.To)
                &&
                EqualityComparer<V>.Default.Equals(To, other.From);
        
        public static bool operator ==(EdgeUndirectedNonWeighted<V> left, EdgeUndirectedNonWeighted<V> right) =>
            (left is null)? right is null : left.Equals(right);
        
        public static bool operator !=(EdgeUndirectedNonWeighted<V> left, EdgeUndirectedNonWeighted<V> right) 
            => !(left == right);
        #endregion === Equals, GetHashCode ===

        #region === Conversions ===
        public static implicit operator ValueTuple<V,V>(EdgeUndirectedNonWeighted<V> e) => (e.From, e.To);
        public static implicit operator EdgeUndirectedNonWeighted<V>(ValueTuple<V,V> value) => new EdgeUndirectedNonWeighted<V>(value);
        #endregion === Conversions ===
    }
}
