using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.mod
{
    /// <summary>
    /// Implementation of an undirected edge.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public class UndirectedEdge<V> : Edge<V>
    {
        private V[] endpoints;

        /// <summary>
        /// Class constructor.
        /// Creates an edge and sets its endpoints.
        /// </summary>
        /// <param name="u"> Edge endpoint. </param>
        /// <param name="v"> Edge endpoint. </param>
        public UndirectedEdge(V u, V v)
        {
            setEndpoints(u, v);
        }
        
        public bool hasVertex(V vertex)
        {
            return endpoints.Contains(vertex);
        }

        public bool hasVertices(V v, V u)
        {
            return endpoints.Contains(u) && endpoints.Contains(v);
        }

        public void setEndpoints(V u, V v)
        {
            endpoints = new V[2] { u, v };
        }

        public void setEndpoints(V[] endpoints)
        {
            this.endpoints = endpoints;
        }

        public V[] getEndpoints()
        {
            return endpoints;       
        }

        public override bool Equals(object obj)
        {
            return (base.Equals(obj)) && ((obj.ToString().Equals(this.ToString())));
        }

        public override string ToString()
        {
            return endpoints[0].ToString() + " ---------------- " + endpoints[1].ToString();
        }
    }
}
