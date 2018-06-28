using Graph_ADT.graph;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.test
{
    public class AdjacencyMapGraphTest
    {
        private AdjacencyMapGraph<Vertex<string>> graph;
        private List<Vertex<string>> vertices = new List<Vertex<string>>();
        private bool isDirected;

        public AdjacencyMapGraphTest(bool isDirected)
        {
            this.isDirected = isDirected;
            graph = new AdjacencyMapGraph<Vertex<string>>(isDirected);

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
            graph.addEdge(vertices[6], vertices[0], "DL 247");
            graph.addEdge(vertices[1], vertices[0], "AA 903");
            graph.addEdge(vertices[0], vertices[5], "AA 523");
            graph.addEdge(vertices[0], vertices[4], "AA 411");
            graph.addEdge(vertices[5], vertices[4], "AA 49");
            graph.addEdge(vertices[3], vertices[5], "UA 877");
            graph.addEdge(vertices[5], vertices[3], "AA 335");
            graph.addEdge(vertices[1], vertices[2], "SW 45");
            graph.addEdge(vertices[6], vertices[1], "NW 35");
            graph.addEdge(vertices[1], vertices[5], "AA 1387");
            graph.addEdge(vertices[4], vertices[3], "UA 120");
            graph.printEdges();
        }

        private void addEdge()
        {
            Edge<Vertex<string>> edge = new Edge<Vertex<string>>(isDirected, vertices[6], vertices[2], "AA 81");
            Console.WriteLine("Adding edge " + edge.ToString() + "\n");
            graph.addEdge(edge);
            graph.printEdges();
        }

        private void removeEdge()
        {
            Edge<Vertex<string>> edge = new Edge<Vertex<string>>(isDirected, vertices[1], vertices[2], "AA 81");
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
