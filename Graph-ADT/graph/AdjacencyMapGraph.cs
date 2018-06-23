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
        private List<SeparateChainingHashMap<V, Edge<V>>> adjacencyMap;

        public AdjacencyMapGraph(bool isDirected) : base(isDirected)
        {
            adjacencyMap = new List<SeparateChainingHashMap<V, Edge<V>>>();
        }

        public AdjacencyMapGraph(bool isDirected, List<V> vertices, List<Edge<V>> edges) : base(isDirected, vertices, edges)
        {
            adjacencyMap = new List<SeparateChainingHashMap<V, Edge<V>>>();
            arrangeMap(this.vertices, this.edges);
        }

        /// <summary>
        /// Implements a graph using the adjacency map approach.
        /// </summary>
        private void arrangeMap(List<V> v, List<Edge<V>> e)
        {
            for (int k = 0; k < v.Count; k++)
            {
                SeparateChainingHashMap<V, Edge<V>> hashMap = new SeparateChainingHashMap<V, Edge<V>>();
                List<Edge<V>> v_edges = getEdges(v[k]);

                if (v_edges != null)
                {
                    foreach (Edge<V> edge in v_edges)
                    {
                        V neighbour = edge.getEndpoints().Where(vert => !(vert.Equals(v[k]))).SingleOrDefault();
                        hashMap.put(neighbour, edge);
                    }
                }

                adjacencyMap.Add(hashMap);
            }
        }

        public override void addEdge(V v, V u)
        {
            Edge<V> edge = new Edge<V>(isDirected, v, u);
            SeparateChainingHashMap<V, Edge<V>> hashMap = new SeparateChainingHashMap<V, Edge<V>>();
            hashMap.put(u, edge);
            adjacencyMap.Add(hashMap);
            base.addEdge(edge);
        }

        public override void removeEdge(Edge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();

            foreach (SeparateChainingHashMap<V, Edge<V>> map in adjacencyMap)
            {
                map.remove(endpoints[0]);
                map.remove(endpoints[1]);
            }

            base.removeEdge(endpoints[0], endpoints[1]);
        }

        public override void removeEdge(V v, V u)
        {
            removeEdge(new Edge<V>(isDirected, v, u));
        }

        public override void removeEdges(V vertex)
        {
            int vertIndex = vertices.IndexOf(vertex);
            adjacencyMap[vertIndex].remove(vertex);

            foreach (SeparateChainingHashMap<V, Edge<V>> map in adjacencyMap)
            {
                map.remove(vertex);
            }

            base.removeEdges(vertex);
        }

        public override void removeEdgeAndEndpoints(Edge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();
            int i1 = vertices.IndexOf(endpoints[0]);
            int i2 = vertices.IndexOf(endpoints[1]);

            adjacencyMap.RemoveAt(i1);
            adjacencyMap.RemoveAt(i2);
            removeEdge(edge);
            base.removeEdgeAndEndpoints(edge);
        }

        public override void addVertex(V vertex)
        {
            base.addVertex(vertex);
            adjacencyMap.Add(new SeparateChainingHashMap<V, Edge<V>>());
        }

        public override void removeVertex(V vertex)
        {
            int indexOfVertex = vertices.IndexOf(vertex);
            adjacencyMap.RemoveAt(indexOfVertex);
            adjacencyMap[indexOfVertex] = null;

            base.removeVertex(vertex);
        }

        public override void printEdges()
        {
            if (isEmpty())
            {
                Console.WriteLine("The graph is empty.");
            }

            
            {
                for (int u = 0; u < adjacencyMap.Count; u++)
                {
                    Console.WriteLine(vertices[u].ToString().ToUpper() + ": \n");
                    List<KeyValuePair<V,Edge<V>>> content = adjacencyMap[u].entrySet();

                    for(int i = 0; i < content.Count; i++)
                    {
                        if (isDirected == false)
                        {
                            Console.WriteLine(vertices[u].ToString() + " ----------------------  " + content[i].Key.ToString());
                        }
                        else
                        {
                            Console.WriteLine(vertices[u].ToString() + " *---------------------->  " + content[i].Key.ToString());
                        }
                    }
                }
            }
        } 
    }
}
