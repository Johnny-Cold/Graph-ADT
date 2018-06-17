using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.mod
{
    /// <summary>
    /// Generic edge interface.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public interface Edge<V>
    {
        V[] getEndpoints();

        void setEndpoints(V u, V v);

        void setEndpoints(V[] endpoints);

        bool hasVertex(V vertex);

        bool hasVertices(V v, V u);
    }
}
