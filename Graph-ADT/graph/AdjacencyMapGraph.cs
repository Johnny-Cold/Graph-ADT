using Graph_ADT.map;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    /// <summary>
    /// Implementation of a graph using an adjacency map.
    /// </summary>
    public class AdjacencyMapGraph<V> : Graph<V>
    {
        private SeparateChainingHashMap<V, Edge<V>> hashMap;
        
        /// <summary>
        /// Class constructor.
        /// Creates an empty graph and initialises the hash map.
        /// </summary>
        public AdjacencyMapGraph(bool isDirected) : base(isDirected)
        {
            hashMap = new SeparateChainingHashMap<V, Edge<V>>();
        }
        
        /// <summary>
        /// Implements a graph using the adjacency map approach.
        /// </summary>
        private void arrangeMap()
        {
            for(int v = 0; v < vertices.Count; v++)
            {
                for(int e = 0; e < edges.Count; e++)
                {
                    if (edges[e].hasVertex(vertices[v]))
                    {
                        hashMap.put(vertices[v], edges[e]);
                    }
                }
            }
        }
    }
}
