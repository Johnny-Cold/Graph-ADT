using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    public class DirectedGraph<V> : Graph<V, DirectedEdge<V>>
    {
        protected List<V> vertices;
        protected List<DirectedEdge<V>> edges;

        public DirectedGraph()
        {
            vertices = new List<V>();
            edges = new List<DirectedEdge<V>>();
        }

        public DirectedGraph(List<V> vertices, List<DirectedEdge<V>> edges)
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

        /// <returns> The incoming degree of the given vertex. </returns>
        public int getInDegree(V vertex)
        {
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }

        /// <returns> The outgoing degree of the given vertex. </returns>
        public int getOutDegree(V vertex)
        {
            return edges.Where(e => e.getEndpoints()[0].Equals(vertex)).Count();
        }
        
        public void addEdge(DirectedEdge<V> edge)
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

        public void addEdge(V vertex, V neighbour)
        {
            addEdge(new DirectedEdge<V>(vertex, neighbour));
        }
        
        public void addVertex(V vertex, V neighbour)
        {
            addEdge(new DirectedEdge<V>(vertex, neighbour));
        }

        public List<DirectedEdge<V>> getEdges(V vertex)
        {
            return edges.Where(e => e.hasVertex(vertex)).ToList<DirectedEdge<V>>();
        }

        /// <returns> A list of all the edges in which the given vertex is the destiantion. </returns>
        public List<DirectedEdge<V>> getInEdges(V vertex)
        {
            return edges.Where(e => e.getDestination().Equals(vertex)).ToList<DirectedEdge<V>>();
        }

        /// <returns> A list of all the edges in which the given vertex is the origin. </returns>
        public List<DirectedEdge<V>> getOutEdges(V vertex)
        {
            return edges.Where(e => e.getOrigin().Equals(vertex)).ToList<DirectedEdge<V>>();
        }

        public virtual void removeEdge(DirectedEdge<V> edge)
        {
            edges.Remove(edge);
        }

        public void removeEdge(V v, V u)
        {
            removeEdge(new DirectedEdge<V>(v, u));
        }

        public virtual void removeEdgeAndEndpoints(DirectedEdge<V> edge)
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
        
        public void clear()
        {
            vertices.Clear();
            edges.Clear();
        }
    }
}
