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
    /// Class containing methods to test a graph.
    /// </summary>
    public class GraphTest
    {
        private Graph<Vertex<string>> graph;
        private List<Vertex<string>> vertices = new List<Vertex<string>>();
        private bool isDirected;

        public GraphTest(bool isDirected)
        {
            this.isDirected = isDirected;
            graph = new Graph<Vertex<string>>(isDirected);

            vertices.Add(new Vertex<string>("MIA")); //0
            vertices.Add(new Vertex<string>("JFK")); //1
            vertices.Add(new Vertex<string>("SFO")); //2
            vertices.Add(new Vertex<string>("ORD")); //3
            vertices.Add(new Vertex<string>("LAX")); //4
            vertices.Add(new Vertex<string>("DFW")); //5
            vertices.Add(new Vertex<string>("BOS")); //6
        }

        private void populateGraph()
        {
            graph.addEdge(vertices[6], vertices[0]);
            graph.addEdge(vertices[1], vertices[0]);
            graph.addEdge(vertices[0], vertices[5]);
            graph.addEdge(vertices[0], vertices[4]);
            graph.addEdge(vertices[5], vertices[4]);
            graph.addEdge(vertices[3], vertices[5]);
            graph.addEdge(vertices[5], vertices[3]);
            graph.addEdge(vertices[1], vertices[2]);
            graph.addEdge(vertices[6], vertices[1]);
            graph.addEdge(vertices[1], vertices[5]);
            graph.addEdge(vertices[4], vertices[3]);
            graph.printEdges();
        }

        private void addEdge()
        {
            Edge<Vertex<string>> edge = new Edge<Vertex<string>>(isDirected, vertices[6], vertices[2], 81);
            Console.WriteLine("Adding edge " + edge.ToString() + "\n");
            graph.addEdge(edge);
            graph.printEdges();
        }

        private void removeEdge()
        {
            Edge<Vertex<string>> edge = new Edge<Vertex<string>>(isDirected, vertices[1], vertices[2], 81);
            Console.WriteLine("Removing edge " + edge.ToString() + "\n");
            graph.removeEdge(edge);
            graph.printEdges();
        }

        private void removeEdgeAndEndpoints()
        {
            Edge<Vertex<string>> edge = new Edge<Vertex<string>>(isDirected, vertices[6], vertices[2]);
            Console.WriteLine("Removing edge " + edge.ToString() + " and its endpoints" + "\n");
            graph.removeEdgeAndEndpoints(edge);
            graph.printEdges();
        }

        public void runTest()
        {
            populateGraph();
            addEdge();
            removeEdge();
            removeEdgeAndEndpoints();
        }
    }
}
