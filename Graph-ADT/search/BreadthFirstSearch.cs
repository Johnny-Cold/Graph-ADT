using Graph_ADT.graph;
using Graph_ADT.map;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.search
{
    public class BreadthFirstSearch<T>
    {
        public static void search(Graph<Vertex<T>> graph, Vertex<T> node, HashSet<Vertex<T>> known, HashMap<Vertex<T>, Edge<Vertex<T>>> forest)
        {
            LinkedList<Vertex<T>> level = new LinkedList<Vertex<T>>(); // List of vertices in the current graph level.
            known.Add(node); // We add the start point to the set of known nodes.
            level.AddLast(node); // The first level includes only the node "node".

            while(level.Count > 0)
            {
                LinkedList<Vertex<T>> nextLevel = new LinkedList<Vertex<T>>(); // List of vertices in the following graph level.

                foreach(Vertex<T> vertex in level)
                {
                    foreach(Edge<Vertex<T>> edge in graph.getEdges(vertex))
                    {
                        Vertex<T>[] endpoints = edge.getEndpoints();

                        // Since breadth-first search expands OUTWARDLY from the current node, we only want to deal with outgoing edges. 
                        if(!endpoints[0].Equals(vertex))
                        {
                            break;
                        }

                        Vertex<T> v = endpoints[1];

                        if (v != null)
                        {
                            if (!known.Contains(v))
                            {
                                known.Add(v);
                                forest.put(v, edge);
                                nextLevel.AddLast(v);
                            }
                        }
                    }

                    level = nextLevel; // Proceeding to next level in graph.
                }
            }
        }
    }
}
