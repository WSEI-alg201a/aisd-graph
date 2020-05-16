using System;

namespace kmolenda.aisd.GraphLib
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="V">vertex - typ węzła</typeparam>
    public interface IEdge<V>
    {
        V From {get; set;}
        V To {get; set;}        
    }
}
