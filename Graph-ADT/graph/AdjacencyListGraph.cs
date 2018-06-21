using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    /// <summary>
    /// Implementation of a graph using adjacency lists.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public class AdjacencyListGraph<V,E> 
    {
        private Graph<V, E> graph;
        private List<V> vertices;
        private List<E> edges;
        private List<List<V>> adjacencyList;
        private bool isDirected;

        public AdjacencyListGraph()
        {
            adjacencyList = new List<List<V>>();
            graphDirectionalty();
            
            if (isDirected == true)
            {
               graph = new DirectedGraph<V>();
                DirectedGraph<V,E> g = graph;
            }
            else
            {
                graph = new UndirectedGraph<V>();
            }

            vertices = graph.getVertices();
            edges = graph.getEdges();
        }
        
        public AdjacencyListGraph(List<V> vertices, List<Edge<V>> edges) 
        {
            adjacencyList = new List<List<V>>();
            graphDirectionalty();

            if(isDirected == true)
            {
                graph = new DirectedGraph<V>(vertices, edges);
            }
            else
            {
                graph = new UndirectedGraph<V>(vertices, edges);
            }

            this.vertices = graph.getVertices();
            this.edges = graph.getEdges();

            createAdjacencyLists(vertices, edges);    
        }

        /// <summary>
        /// Determines whether or not the graph has directed or undirected edges.
        /// </summary>
        private void graphDirectionalty()
        {
            Type edgeType = typeof(E);
            isDirected = (edgeType == typeof(DirectedEdge<V>)) ? true : false;
        }

        /// <summary>
        /// Creates adjacency lists for a list of vertices.
        /// </summary>
        /// <param name="v"> List of vertices to use. </param>
        /// <param name="e"> List of edges to use. </param>
        private void createAdjacencyLists(List<V> v, List<Edge<V>> e)
        {
            for(int k = 0; k < v.Count; k++)
            {
                adjacencyList.Add(new List<V>());
            }

            foreach (Edge<V> edge in e)
            {
                adjacencyList[vertices.IndexOf(edge.getEndpoints()[0])].Add(edge.getEndpoints()[1]);
            }
        }

        public void addEdge(E edge)
        {
            // Ensuring the correct type of edge is used.
            if((edge is DirectedEdge<V>) && isDirected == false)
            {
                throw new InvalidOperationException("Undirected graph does not take directed edges.");
            }

            int[] indices = new int[2];
            edges.Add(edge);
            V[] endpoints = edge.getEndpoints();
            
            for(int k = 0; k <= 1; k++)
            {
                V v = endpoints[k];

                if(!vertices.Contains(v))
                {
                    vertices.Add(v);
                    adjacencyList.Add(new List<V>());
                }

                indices[k] = vertices.IndexOf(v);
            }
            
            adjacencyList[indices[0]].Add(vertices[indices[1]]);
            adjacencyList[indices[1]].Add(vertices[indices[0]]);
        }

        /// <summary>
        /// Removes the specified edge from the graph.
        /// Removes all occurrences of the edge in the adjacency lists.
        /// </summary>
        /// <param name="edge"> The edge to remove. </param>
        public void removeEdge(E edge)
        {
            adjacencyList.RemoveAll(e => e.Equals(edge));
            graph.removeEdge(edge);
        }

        public void removeEdgeAndEndpoints(E edge)
        {
            V[] endpoints = edge.getEndpoints();
            int i1 = vertices.IndexOf(endpoints[0]);
            int i2 = vertices.IndexOf(endpoints[1]);

            // Removing corresponding adjacency lists.
            adjacencyList.RemoveAll(e => e.Equals(edge));
            adjacencyList.RemoveAt(i1);
            adjacencyList.RemoveAt(i2);
            
            graph.removeEdgeAndEndpoints(edge);
        }

        public void addVertex(V vertex)
        {
            vertices.Add(vertex);
            adjacencyList.Add(new List<V>());
        }

        public void addVertex(V vertex, V neighbour)
        {
            if(isDirected == true)
            {
                addEdge(new DirectedEdge<V>(vertex, neighbour));
            }
            else
            {
                addEdge(new UndirectedEdge<V>(vertex, neighbour));
            }
        }

        /// <summary>
        /// Removes a vertex from the list of vertices and from the edges where it is an endpoint.
        /// Removes the corresponding adjacency list for the vertex to remove.
        /// </summary>
        /// <param name="vertex"> The vertex to remove. </param>
        public void removeVertex(V vertex)
        {
            int indexOfVertex = vertices.IndexOf(vertex);
            adjacencyList.Remove(adjacencyList[indexOfVertex]);
            graph.removeVertex(vertex);
        }

        /// <summary>
        /// Prints all the vertices and edges of the graph.
        /// Prints edges differently based on their direction (if the graph is in fact directed).
        /// </summary>
        public void printEdges()
        {
            if(graph.getNumVertices() == 0)
            {
                Console.WriteLine("The graph is empty.");
            }

            if (isDirected == false)
            {
                for (int u = 0; u < adjacencyList.Count; u++)
                {
                    Console.WriteLine(getVertex(vertices[u]).ToString().ToUpper() + ": ");

                    for (int j = 0; j < adjacencyList[u].Count; j++)
                    {
                        Console.WriteLine(vertices[u].ToString() + " ----------------------  " + (adjacencyList[u])[j]);
                    }

                    Console.WriteLine();
                }
            }
            else
            {
                for (int u = 0; u < adjacencyList.Count; u++)
                {
                    Console.WriteLine(getVertex(vertices[u]).ToString().ToUpper() + ": ");

                    for (int j = 0; j < adjacencyList[u].Count; j++)
                    {
                        V vertex = vertices[u];
                        V neighbour = (adjacencyList[u])[j];
                        DirectedEdge<V> edge = (DirectedEdge<V>)edges.Where(e => e.hasVertices(vertex, neighbour)).SingleOrDefault();

                        if(edge.getOrigin().Equals(vertex))
                        {
                            Console.WriteLine(vertex.ToString() + " *---------------------> " + neighbour.ToString());
                        }
                        else if(edge.getDestination().Equals(vertex))
                        {
                            Console.WriteLine(vertex.ToString() + " <---------------------* " + neighbour.ToString());
                        }
                    }

                    Console.WriteLine();
                }
            }
        }
        
        public void clear()
        {
            graph.clear();
            adjacencyList.Clear();
        }
    }
}
