using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    public class Graph<V>
    {
        protected bool isDirected; 
        protected List<V> vertices = new List<V>();
        protected List<Edge<V>> edges = new List<Edge<V>>();

        /// <summary>
        /// Class constructor.
        /// Creates an empty graph.
        /// </summary>
        public Graph(bool isDirected)
        {
            this.isDirected = isDirected;
        }
        
        /// <summary>
        /// Class contructor.
        /// Creates a graph with certain vertices and edges.
        /// </summary>
        /// <param name="vertices"> A list of vertices to add to the graph. </param>
        /// <param name="edges"> A list of vertices t add to the graph. </param>
        public Graph(bool isDirected, List<V> vertices, List<Edge<V>> edges)
        {
            this.isDirected = isDirected;
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

        public int numEdges()
        {
            return edges.Count;
        }

        public virtual void addEdge(Edge<V> edge)
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
        
        /// <returns> A list of edges for which the given vertex is an endpoint. </returns>
        public List<Edge<V>> getEdges(V vertex)
        {
            List<Edge<V>> v_edges = new List<Edge<V>>();

            foreach(Edge<V> edge in edges)
            {
                if(edge.hasVertex(vertex))
                {
                    v_edges.Add(edge);
                }
            }

            return v_edges;
        }

        /// <returns> A list of edges for which the given vertex is a destination. </returns>
        public List<Edge<V>> getInEdges(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected geaph has no incoming degree."); }

            List<Edge<V>> v_edges = new List<Edge<V>>();

            foreach(DirectedEdge<V> edge in edges)
            {
                if(edge.getDestination().Equals(vertex))
                {
                    v_edges.Add(edge);
                }
            }

            return v_edges;
        }

        /// <returns> A list of edges for which the given vertex is an origin. </returns>
        public List<Edge<V>> getOutEdges(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected geaph has no outgoing degree."); }

            List<Edge<V>> v_edges = new List<Edge<V>>();

            foreach (DirectedEdge<V> edge in edges)
            {
                if (edge.getOrigin().Equals(vertex))
                {
                    v_edges.Add(edge);
                }
            }

            return v_edges;
        }

        /// <summary>
        /// Removes an edge as well as its endpoint vertices.
        /// </summary>
        /// <param name="edge"> The edge to remove from the graph. </param>
        public virtual void removeEdge(Edge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();
            
            foreach (V v in endpoints)
            {
                if (vertices.Contains(v))
                {
                    vertices.Remove(v);
                }
            }

            edges.Remove(edge);
        }

        public virtual void addVertex(V vertex)
        {
            vertices.Add(vertex);
        }

        public virtual void addVertex(V vertex, V neighbour)
        {
            if(isDirected == false)
            {
                addEdge(new UndirectedEdge<V>(vertex, neighbour));
            }
            else
            {
                addEdge(new DirectedEdge<V>(vertex, neighbour));
            }
        }

        protected V getVertex(V vertex)
        {
            return vertices.Where(v => v.Equals(vertex)).SingleOrDefault();
        }

        /// <returns> Gets the vertex opposite a given vertex on a specified edge. </returns>
        public V getNeighbour(V vertex, Edge<V> edge)
        {
            return edges.Where(e => e.Equals(edge)).SingleOrDefault().getEndpoints().Where(v => !v.Equals(vertex)).SingleOrDefault();
        }

        public V[] getEdgeEndpoints(Edge<V> edge)
        {
            return edge.getEndpoints(); 
        }
        
        public void removeVertex(V vertex)
        {
            vertices.Remove(vertex);
        
            // Removing the removed vertex from all the edges where it is an endpoint.    
            foreach(Edge<V> edge in edges)
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

        /// <returns> The outgoing degree of the given vertex. </returns>
        public int getOutDegree(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected geaph has no outgoing degree."); }
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }

        /// <returns> The incoming degree of the given vertex. </returns>
        public int getInDegree(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected geaph has no incoming degree."); }
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }

        public virtual void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
