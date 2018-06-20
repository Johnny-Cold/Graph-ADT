using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    /// <summary>
    /// Implementation of an undirected graph.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public class UndirectedGraph<V> : Graph<V, UndirectedEdge<V>>
    {
        protected List<V> vertices;
        protected List<UndirectedEdge<V>> edges;
        
        /// <summary>
        /// Class constructor.
        /// Creates an empty undirected graph.
        /// </summary>
        public UndirectedGraph()
        {
            vertices = new List<V>();
            edges = new List<UndirectedEdge<V>>();
        }
        
        /// <summary>
        /// Class constructor.
        /// Creates an undirected graph.
        /// </summary>
        public UndirectedGraph(List<V> vertices, List<UndirectedEdge<V>> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }
        
        public bool isEmpty()
        {
            return vertices.Count == 0;
        }

        public int getNumVertices()
        {
            return vertices.Count;
        }

        public int getNumEdges()
        {
            return edges.Count;
        }

        public int getDegree(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).Count();
        }

        public virtual void addEdge(UndirectedEdge<V> edge)
        {
            edges.Add(edge);
            V[] endpoints = edge.getEndpoints();

            // If the list of vertices does not already have a vertex in the new edge, add the vertex to the list.
            foreach(V v in endpoints)
            {
                if(!vertices.Contains(v))
                {
                    vertices.Add(v);
                }
            }
        }

        public void addEdge(V vertex, V neighbour)
        {
            addEdge(new UndirectedEdge<V>(vertex, neighbour));
        }

        public virtual void addVertex(V vertex, V neighbour)
        {
            addEdge(new UndirectedEdge<V>(vertex, neighbour));
        }

        public virtual List<UndirectedEdge<V>> getEdges(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).ToList<UndirectedEdge<V>>();
        }

        public virtual void removeEdge(UndirectedEdge<V> edge)
        {
             edges.Remove(edge);
        }

        public void removeEdge(V v, V u)
        {
            removeEdge(new UndirectedEdge<V>(v, u));
        }

        public virtual void removeEdgeAndEndpoints(UndirectedEdge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();
            edges.Remove(edge);
            vertices.Remove(endpoints[0]);
            vertices.Remove(endpoints[1]);
        }

        public virtual void addVertex(V vertex)
        {
            vertices.Add(vertex);
        }
        
        public V getVertex(V vertex)
        {
            return vertices.Where(v => v.Equals(vertex)).SingleOrDefault();
        }
        
        public V[] getEdgeEndpoints(UndirectedEdge<V> edge)
        {
            return edge.getEndpoints(); 
        }
        
        public virtual void removeVertex(V vertex)
        {
            vertices.Remove(vertex);
        
            // Removing the removed vertex from all the edges where it is an endpoint.    
            foreach(UndirectedEdge<V> edge in edges)
            {
                if(edge.hasVertex(vertex))
                {
                    V[] endpoints = edge.getEndpoints();

                    for(int i = 0; i < 2; i++)
                    {
                        if(endpoints[i].Equals(vertex))
                        {
                            endpoints[i] = default(V);
                        }
                    }

                    edge.setEndpoints(endpoints);
                }
            }
        }
       
        public virtual void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
