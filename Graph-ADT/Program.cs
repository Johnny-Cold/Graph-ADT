using Graph_ADT.graph;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT
{
    class Program
    {
        static void Main(string[] args)
        {
            AdjacencyListGraph<Vertex<string>> graph = new AdjacencyListGraph<Vertex<string>>(true);

            List<Vertex<string>> vertices = new List<Vertex<string>>();
            vertices.Add(new Vertex<string>("Aquemini"));
            vertices.Add(new Vertex<string>("ATLiens"));
            vertices.Add(new Vertex<string>("Stankonia"));
            vertices.Add(new Vertex<string>("Speakerboxxx/The Love Below"));
            
            graph.addEdge(new DirectedEdge<Vertex<string>>(vertices[0], vertices[1]));
            graph.addEdge(new DirectedEdge<Vertex<string>>(vertices[0], vertices[3]));
            graph.addEdge(new DirectedEdge<Vertex<string>>(vertices[2], vertices[3]));
            graph.addEdge(new DirectedEdge<Vertex<string>>(vertices[1], vertices[2]));
            graph.addEdge(new DirectedEdge<Vertex<string>>(vertices[0], vertices[2]));
            graph.printEdges();

            Console.WriteLine("Number of vertices: " +  graph.numVertices());
            Console.WriteLine("Number of edges: " + graph.numEdges());
            Console.WriteLine("Degree of Aquemini: " + graph.getDegree(vertices[0]));
            Console.WriteLine("In-degree of Aquemini: " + graph.getInDegree(vertices[0]));
            Console.WriteLine("Out-degree of Aquemini: " + graph.getOutDegree(vertices[0]));
            Console.WriteLine("\n");

            graph.removeEdge(new DirectedEdge<Vertex<string>>(vertices[0], vertices[2]));
            Console.WriteLine("Number of vertices: " + graph.numVertices());
            Console.WriteLine("Number of edges: " + graph.numEdges());
            Console.WriteLine("Degree of Aquemini: " + graph.getDegree(vertices[0]));
            Console.WriteLine("In-degree of Aquemini: " + graph.getInDegree(vertices[0]));
            Console.WriteLine("Out-degree of Aquemini: " + graph.getOutDegree(vertices[0]));
            Console.WriteLine("\n");
            
            graph.clear();
            Console.WriteLine("Number of vertices: " + graph.numVertices());
            Console.WriteLine("Number of edges: " + graph.numEdges());
            Console.WriteLine("Degree of Aquemini: " + graph.getDegree(vertices[0]));
            Console.WriteLine("In-degree of Aquemini: " + graph.getInDegree(vertices[0]));
            Console.WriteLine("Out-degree of Aquemini: " + graph.getOutDegree(vertices[0]));

            Console.ReadLine();
        }
    }
}
