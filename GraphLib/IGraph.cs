using System;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="V">vertex - typ reprezętujący węzeł</typeparam>
    /// <typeparam name="E">edge - typ reprezentujący krawędź</typeparam>
    public interface IGraph<V, E> where E : IEdge<V>
    {

    }
}
