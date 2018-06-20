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
    public class UndirectedGraph<V>
    {
        protected List<V> vertices = new List<V>();
        private List<UndirectedEdge<V>> edges = new List<UndirectedEdge<V>>();

        /// <summary>
        /// Class constructor.
        /// Creates an empty graph.
        /// </summary>
        public UndirectedGraph(){}
        
        /// <summary>
        /// Class contructor.
        /// Creates a graph with certain vertices and edges.
        /// </summary>
        /// <param name="vertices"> A list of vertices to add to the graph. </param>
        /// <param name="edges"> A list of vertices t add to the graph. </param>
        public UndirectedGraph(List<V> vertices, List<UndirectedEdge<V>> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }
        
        public bool isEmpty()
        {
            return vertices.Count == 0;
        }

        public int numVertices()
        {
            return vertices.Count;
        }

        public virtual int numEdges()
        {
            return edges.Count;
        }

        /// <summary>
        /// Adds a new edge to the graph.
        /// </summary>
        /// <param name="edge"> The new edge  to add. </param>
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

        /// <summary>
        /// Adds a new edge to the graph.
        /// Edge addition is implied by the specification of a neighbouring edge.
        /// </summary>
        /// <param name="vertex"> A vertex to add. </param>
        /// <param name="neighbour"> An opposite vertex to add. </param>
        public virtual void addVertex(V vertex, V neighbour)
        {
            addEdge(new UndirectedEdge<V>(vertex, neighbour));
        }

        /// <returns> A list of edges for which the given vertex is an endpoint. </returns>
        public virtual List<UndirectedEdge<V>> getEdges(V vertex)
        {
            List<UndirectedEdge<V>> v_edges = new List<UndirectedEdge<V>>();
            
            foreach(UndirectedEdge<V> edge in edges)
            {
                if(edge.hasVertex(vertex))
                {
                    v_edges.Add(edge);
                }
            }

            return v_edges;
        }
        
        /// <summary>
        /// Removes an edge.
        /// </summary>
        /// <param name="edge"> The edge to remove from the graph. </param>
        public virtual void removeEdge(UndirectedEdge<V> edge)
        {
             edges.Remove(edge);
        }

        /// <summary>
        /// Removes an edge as well as its endpoint vertices.
        /// </summary>
        /// <param name="edge"> The edge to remove from the graph. </param>
        public virtual void removeEdgeAndEndpoints(UndirectedEdge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();
            edges.Remove(edge);
            vertices.Remove(endpoints[0]);
            vertices.Remove(endpoints[1]);
        }

        /// <summary>
        /// Adds a new vertex to the graph, but to no specific edge.
        /// </summary>
        /// <param name="vertex"> The new vertex to add. </param>
        public virtual void addVertex(V vertex)
        {
            vertices.Add(vertex);
        }
        
        protected V getVertex(V vertex)
        {
            return vertices.Where(v => v.Equals(vertex)).SingleOrDefault();
        }

        /// <returns> Gets the vertex opposite a given vertex on a specified edge. </returns>
        public V getNeighbour(V vertex, UndirectedEdge<V> edge)
        {
            return edges.Where(e => e.Equals(edge)).SingleOrDefault().getEndpoints().Where(v => !v.Equals(vertex)).SingleOrDefault();
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
        
        /// <returns> The degree of the given vertex. </returns>
        public int getDegree(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).Count();
        }

        public virtual void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
