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
    public class AdjacencyListGraph<V> : Graph<V>
    {
        private List<List<V>> adjacencyList = new List<List<V>>();

        public AdjacencyListGraph() : base() { }

        public AdjacencyListGraph(bool isDirected) : base(isDirected) { }

        public AdjacencyListGraph(bool isDirected, List<V> vertices, List<Edge<V>> edges) : base(isDirected, vertices, edges)
        {
            createAdjacencyLists(vertices, edges);
        }

        /// <summary>
        /// Creates adjacency lists for a list of vertices.
        /// </summary>
        /// <param name="v"> List of vertices to use. </param>
        /// <param name="e"> List of edges to use. </param>
        private void createAdjacencyLists(List<V> v, List<Edge<V>> e)
        {
            for (int k = 0; k < v.Count; k++)
            {
                adjacencyList.Add(new List<V>());
            }

            foreach (Edge<V> edge in e)
            {
                adjacencyList[vertices.IndexOf(edge.getEndpoints()[0])].Add(edge.getEndpoints()[1]);
            }
        }

        public override void addEdge(V v, V u)
        {
            int[] indices = new int[2];
            Edge<V> edge = new Edge<V>(isDirected, v, u);
            edges.Add(edge);
            V[] endpoints = edge.getEndpoints();

            for (int k = 0; k <= 1; k++)
            {
                V endpoint = endpoints[k];

                if (!vertices.Contains(endpoint))
                {
                    vertices.Add(endpoint);
                    adjacencyList.Add(new List<V>());
                }

                indices[k] = vertices.IndexOf(endpoint);
            }

            adjacencyList[indices[0]].Add(vertices[indices[1]]);
            adjacencyList[indices[1]].Add(vertices[indices[0]]);
        }

        /// <summary>
        /// Removes the specified edge from the graph.
        /// Removes all occurrences of the edge in the adjacency lists.
        /// </summary>
        /// <param name="edge"> The edge to remove. </param>
        public override void removeEdge(Edge<V> edge)
        {
            adjacencyList.RemoveAll(e => e.Equals(edge));
            base.removeEdge(edge);
        }

        public override void removeEdge(V v, V u)
        {
            removeEdge(new Edge<V>(isDirected, v, u));
        }

        public override void removeEdges(V vertex)
        {
            foreach (Edge<V> edge in edges)
            {
                for (int a = 0; a < adjacencyList.Count; a++)
                {
                    if (adjacencyList[a].Equals(edge))
                    {
                        adjacencyList.Remove(adjacencyList[a]);
                    }
                }
            }

            base.removeEdges(vertex);
        }

        public override void removeEdgeAndEndpoints(Edge<V> edge)
        {
            V[] endpoints = edge.getEndpoints();
            int i1 = vertices.IndexOf(endpoints[0]);
            int i2 = vertices.IndexOf(endpoints[1]);

            // Removing corresponding adjacency lists.
            adjacencyList.RemoveAt(i1);
            adjacencyList.RemoveAt(i2);

            base.removeEdgeAndEndpoints(edge);
        }

        public override void addVertex(V vertex)
        {
            base.addVertex(vertex);
            adjacencyList.Add(new List<V>());
        }

        /// <summary>
        /// Removes a vertex from the list of vertices and from the edges where it is an endpoint.
        /// Removes the corresponding adjacency list for the vertex to remove.
        /// </summary>
        /// <param name="vertex"> The vertex to remove. </param>
        public override void removeVertex(V vertex)
        {
            int indexOfVertex = vertices.IndexOf(vertex);
            adjacencyList.Remove(adjacencyList[indexOfVertex]);
            adjacencyList[indexOfVertex] = null;
            base.removeVertex(vertex);
        }

        public override void printEdges()
        {
            if (isEmpty())
            {
                Console.WriteLine("The graph is empty.");
            }
            
            {
                for (int u = 0; u < adjacencyList.Count; u++)
                {
                    Console.WriteLine(vertices[u].ToString().ToUpper() + ": \n");

                    for (int j = 0; j < adjacencyList[u].Count; j++)
                    {
                        if (isDirected == false)
                        {
                            Console.WriteLine(vertices[u].ToString() + " ---------------------- " + (adjacencyList[u])[j]);
                        }
                        else
                        {
                            Console.WriteLine(vertices[u].ToString() + " *----------------------> " + (adjacencyList[u])[j]);
                        }
                    }

                    Console.WriteLine();
                }
            }
        }

        public override void clear()
        {
            base.clear();
            adjacencyList.Clear();
        }
    }
}
