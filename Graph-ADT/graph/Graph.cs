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
        protected List<V> vertices;
        protected List<Edge<V>> edges;
        protected bool isDirected = false; // Dictates the directionality of the graph. The graph is undirected by default.

        /// <summary>
        /// Creates an empty undirected graph.
        /// </summary>
        public Graph()
        {
            vertices = new List<V>();
            edges = new List<Edge<V>>();
        }

        /// <summary>
        /// Creates an empty graph with specified directionality.
        /// </summary>
        public Graph(bool isDirected)
        {
            this.isDirected = isDirected;
            vertices = new List<V>();
            edges = new List<Edge<V>>();
        }

        /// <summary>
        /// Creates a graph with specified directionality, vertices, and edges.
        /// </summary>
        public Graph(bool isDirected, List<V> vertices, List<Edge<V>> edges)
        {
            this.isDirected = isDirected;
            this.vertices = vertices;
            this.edges = edges;
        }

        /// <returns> A boolean indication that the graph is empty (has no vertices). </returns>
        public bool isEmpty()
        {
            return getNumVertices() == 0;
        }
        
        public int getNumVertices()
        {
            return vertices.Count;
        }

        public int getNumEdges()
        {
            return edges.Count;
        }

        /// <returns> The degree of the given vertex. </returns>
        public int getDegree(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).Count();
        }

        /// <returns> The incoming degree of the given vertex. </returns>
        public int getInDegree(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Invalid operation for an undirected graph."); }
            return edges.Where(e => e.getDestination().Equals(vertex)).Count();
        }

        /// <returns> The outgoing degree of the given vertex. </returns>
        public int getOutDegree(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Invalid operation for an undirected graph."); }
            return edges.Where(e => e.getOrigin().Equals(vertex)).Count();
        }
        
        /// <summary>
        /// Adds a new edge with a value.
        /// </summary>
        /// <param name="v"> Edge endpoint. </param>
        /// <param name="u"> Edge endpoint. </param>
        /// <param name="value"> A value contained by the edge. </param>
        public virtual void addEdge(V v, V u, object value)
        {
            Edge<V> edge = new Edge<V>(isDirected, v, u, value);
            edges.Add(edge);
            V[] endpoints = edge.getEndpoints();

            // If the list of vertices does not already have a vertex in the new edge, add the vertex to the list.
            foreach (V endpoint in endpoints)
            {
                if (!vertices.Contains(endpoint))
                {
                    vertices.Add(endpoint);
                }
            }
        }

        /// <summary>
        /// Adds a new edge that has no value.
        /// </summary>
        public virtual void addEdge(V v, V u)
        {
            addEdge(v, u, null);
        }

        public virtual void addEdge(Edge<V> edge)
        {
            addEdge(edge.getEndpoints()[0], edge.getEndpoints()[1], edge.getValue());
        }
        
        /// <returns> All the edges in the graph. </returns>
        public List<Edge<V>> getEdges()
        {
            return edges;
        }

        /// <returns> All the edges for which the specified vertex is an endpoint. </returns>
        public List<Edge<V>> getEdges(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).ToList<Edge<V>>();
        }
        
        /// <returns> A list of all the edges in which the given vertex is the destiantion. </returns>
        public List<Edge<V>> getInEdges(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Invalid operation for an undirected graph."); }
            return edges.Where(e => e.getDestination().Equals(vertex)).ToList<Edge<V>>();
        }

        /// <returns> A list of all the edges in which the given vertex is the origin. </returns>
        public List<Edge<V>> getOutEdges(V vertex)
        {
            if (isDirected == false) { throw new InvalidOperationException("Invalid operation for an undirected graph."); }
            return edges.Where(e => e.getOrigin().Equals(vertex)).ToList<Edge<V>>();
        }

        /// <returns> the edge that has the given vertices as its endpoints. </returns>
        protected Edge<V> getEdge(V v, V u)
        {
            return edges.Where(e => e.hasVertices(v, u)).SingleOrDefault();
        }
        
        /// <summary>
        /// Removes a specified edge.
        /// </summary>
        public virtual void removeEdge(Edge<V> edge)
        {
            edges.Remove(edge);
        }

        /// <summary>
        /// Removes an edge with the provided endpoints.
        /// </summary>
        public virtual void removeEdge(V v, V u)
        {
            removeEdge(new Edge<V>(isDirected, v, u));
        }

        /// <summary>
        /// Removes all the edges that have a specified vertex as an endpoint.
        /// </summary>
        /// <param name="vertex"></param>
        public virtual void removeEdges(V vertex)
        {
            edges.RemoveAll(e => e.hasVertex(vertex));
        }

        /// <summary>
        /// Removes an edge and its endpoints.
        /// </summary>
        public virtual void removeEdgeAndEndpoints(Edge<V> edge)
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

        /// <returns> All the vertices in the graph. </returns>
        public List<V> getVertices()
        {
            return vertices;
        }
        
        public virtual void removeVertex(V vertex)
        {
            vertices.Remove(vertex);

            // Removing the removed vertex from all the edges where it is an endpoint.    
            foreach (Edge<V> edge in edges)
            {
                if (edge.hasVertex(vertex))
                {
                    V[] endpoints = edge.getEndpoints();

                    for (int i = 0; i < 2; i++)
                    {
                        if (endpoints[i].Equals(vertex))
                        {
                            endpoints[i] = default(V);
                        }
                    }

                    edge.setEndpoints(endpoints);
                }
            }
        }

        /// <summary>
        /// Prints all the vertices and edges of the graph.
        /// Prints edges differently based on their direction (if the graph is in fact directed).
        /// </summary>
        public virtual void printEdges()
        {
            if (isEmpty())
            {
                Console.WriteLine("The graph is empty.");
            }

            foreach (V vertex in vertices)
            {
                List<Edge<V>> v_edges = getEdges(vertex);
                Console.WriteLine(vertex.ToString().ToUpper() + ": \n");

                foreach(Edge<V> edge in v_edges)
                {
                    Console.WriteLine(edge.ToString());
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// Clears the graph.
        /// </summary>
        public virtual void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
