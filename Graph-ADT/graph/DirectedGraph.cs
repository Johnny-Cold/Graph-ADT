using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    public class DirectedGraph<V> : UndirectedGraph<V>
    {
        private List<DirectedEdge<V>> edges = new List<DirectedEdge<V>>();

        public DirectedGraph() { }

        public DirectedGraph(List<V> vertices, List<DirectedEdge<V>> edges)
        {
            this.vertices = vertices;
            this.edges = edges;
        }

        public virtual int numEdges()
        {
            return edges.Count;
        }

        /// <returns> The outgoing degree of the given vertex. </returns>
        public int getOutDegree(V vertex)
        {
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }

        /// <returns> The incoming degree of the given vertex. </returns>
        public int getInDegree(V vertex)
        {
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }

        /// <summary>
        /// Adds a new edge to the graph.
        /// </summary>
        /// <param name="edge"> The new edge  to add. </param>
        public override void addEdge(DirectedEdge<V> edge)
        {
            edges.Add(edge);
            V[] endpoints = edge.getEndpoints();

            // If the list of vertices does not already have a vertex in the new edge, add the vertex to the list.
            foreach (V v in endpoints)
            {
                if (!vertices.Contains(v))
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
        public override void addVertex(V vertex, V neighbour)
        {
            addEdge(new DirectedEdge<V>(vertex, neighbour));
        }

        /// <returns> A list of edges for which the given vertex is an endpoint. </returns>
        public List<DirectedEdge<V>> getEdges(V vertex)
        {
            List<DirectedEdge<V>> v_edges = new List<DirectedEdge<V>>();

            foreach (DirectedEdge<V> edge in edges)
            {
                if (edge.hasVertex(vertex))
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
        public virtual void removeEdge(DirectedEdge<V> edge)
        {
            edges.Remove(edge);
        }

        /// <summary>
        /// Removes an edge as well as its endpoint vertices.
        /// </summary>
        /// <param name="edge"> The edge to remove from the graph. </param>
        public virtual void removeEdgeAndEndpoints(DirectedEdge<V> edge)
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
        public V getNeighbour(V vertex, DirectedEdge<V> edge)
        {
            return edges.Where(e => e.Equals(edge)).SingleOrDefault().getEndpoints().Where(v => !v.Equals(vertex)).SingleOrDefault();
        }

        public V[] getEdgeEndpoints(DirectedEdge<V> edge)
        {
            return edge.getEndpoints();
        }

        public virtual void removeVertex(V vertex)
        {
            vertices.Remove(vertex);

            // Removing the removed vertex from all the edges where it is an endpoint.    
            foreach (DirectedEdge<V> edge in edges)
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
        
        public override void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
