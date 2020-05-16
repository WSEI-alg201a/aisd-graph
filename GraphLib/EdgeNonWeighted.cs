using System;

namespace kmolenda.aisd.GraphLib
{
    public class EdgeNonWeighted<V> : IEdge<V>
    {
        public V From { get; set; }
        public V To { get; set; }

        public EdgeNonWeighted() { From = default; To = default; }

        public EdgeNonWeighted(V from, V to)
        {
            From = from;
            To = to;
        }

        public EdgeNonWeighted(ValueTuple<V,V> value)
        {
            (From, To) = value;
        }

        public static implicit operator ValueTuple<V,V>(EdgeNonWeighted<V> e) => (e.From, e.To);
        public static implicit operator EdgeNonWeighted<V>(ValueTuple<V,V> value) => new EdgeNonWeighted<V>(value);


        public override string ToString() => $"({From}, {To})";

    }
}
