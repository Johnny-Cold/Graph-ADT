using Graph_ADT.graph;
using Graph_ADT.mod;
using Graph_ADT.test;
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
            Console.WriteLine("****************** ADJACENCY LIST GRAPH TEST ******************\n\n");
            AdjacencyListGraphTest listTest = new AdjacencyListGraphTest(false);
            listTest.runTest();
            Console.ReadLine();
        }
    }
}
