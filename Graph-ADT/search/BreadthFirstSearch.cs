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
    /// <summary>
    /// Given a graph G = (V,E) and a distinguished source vertex s, breadth-first search systematically explores the 
    /// edges of G to “discover” every vertex that is reachable from s.
    /// </summary>
    /// <typeparam name="T"> Type name for vertex entries. </typeparam>
    public class BreadthFirstSearch<T>
    {
        public static void search(Graph<Vertex<T>> graph, Vertex<T> startNode, HashSet<Vertex<T>> known, HashMap<Vertex<T>, Edge<Vertex<T>>> forest)
        {
            LinkedList<Vertex<T>> level = new LinkedList<Vertex<T>>(); // List of vertices in the current graph level.
            known.Add(startNode); // We add the start point to the set of known nodes.
            level.AddLast(startNode); // The first level includes only the source node.

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
                }
                
                level = nextLevel; // Proceeding to next level in graph.
            }
        }
    }
}
