using Graph_ADT.graph;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.test
{
    /// <summary>
    /// Class containing methods to test an adjacency list graph.
    /// </summary>
    /// <typeparam name="T"> Type name for vertex entries. </typeparam>
    public class AdjacencyListGraphTest
    {
        private AdjacencyListGraph<Vertex<string>> graph;
        private List<Vertex<string>> vertices = new List<Vertex<string>>();
        private bool isDirected = false;

        public AdjacencyListGraphTest(bool isDirected)
        {
            this.isDirected = isDirected;
            graph = new AdjacencyListGraph<Vertex<string>>(isDirected);

            vertices.Add(new Vertex<string>("MIA")); //0
            vertices.Add(new Vertex<string>("JFK")); //1
            vertices.Add(new Vertex<string>("SFO")); //2
            vertices.Add(new Vertex<string>("ORD")); //3
            vertices.Add(new Vertex<string>("LAX")); //4
            vertices.Add(new Vertex<string>("DFW")); //5
            vertices.Add(new Vertex<string>("BOS")); //6
        }

        #region Undirected graph

        private void populateUndirectedGraph()
        {
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[0], vertices[5]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[0], vertices[4]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[0], vertices[1]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[0], vertices[6]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[1], vertices[6]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[1], vertices[5]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[1], vertices[2]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[3], vertices[5]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[3], vertices[4]));
            graph.addEdge(new UndirectedEdge<Vertex<string>>(vertices[4], vertices[5]));
        }

        private void addUndirectedEdge()
        {
            UndirectedEdge<Vertex<string>> edge = new UndirectedEdge<Vertex<string>>(vertices[6], vertices[2]);
            Console.WriteLine("Adding edge " + edge.ToString());
            graph.addEdge(edge);
            graph.printEdges();
        }

        private void removeUndirectedEdge()
        {
            UndirectedEdge<Vertex<string>> edge = new UndirectedEdge<Vertex<string>>(vertices[1], vertices[2]);
            Console.WriteLine("Removing edge " + edge.ToString());
            graph.removeEdge(edge);
            graph.printEdges();
        }

        private void removeUndirectedEdgeAndEndpoints()
        {
            UndirectedEdge<Vertex<string>> edge = new UndirectedEdge<Vertex<string>>(vertices[6], vertices[2]);
            Console.WriteLine("Removing edge " + edge.ToString() + " and its endpoints");
            graph.removeEdgeAndEndpoints(edge);
            graph.printEdges();
        }

        public void runTest()
        {
            if (isDirected == false)
            {
                populateUndirectedGraph();
                addUndirectedEdge();
                removeUndirectedEdge();
                removeUndirectedEdgeAndEndpoints();
            }
        }
        #endregion

        #region Directed graph
        #endregion
    }
}
