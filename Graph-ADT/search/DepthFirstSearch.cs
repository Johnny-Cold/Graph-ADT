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
    /// Depth-first search explores edges out of the most recently discovered vertex (v) that still has unexplored outgoing edges.
    /// Once all of v’s edges have been explored, the search “backtracks” to explore edges leaving the vertex from which v was 
    /// discovered. This process continues until all the vertices that are reachable from the original source vertex have been discovered. 
    /// If any undiscovered vertices remain, then depth-first search selects one of them as a new source, and it repeats 
    /// the search from that source. The algorithm repeats this entire process until it has discovered every vertex.
    /// </summary>
    /// <typeparam name="T"> Type name for vertex entries. </typeparam>
    public class DepthFirstSearch<T>
    {
        public static HashMap<Vertex<T>, Edge<Vertex<T>>> search(Graph<Vertex<T>> graph, Vertex<T> startPoint, HashSet<Vertex<T>> visited, HashMap<Vertex<T>, Edge<Vertex<T>>> forest)
        {
            visited.Add(startPoint);

            foreach(Edge<Vertex<T>> edge in graph.getEdges())
            {
                Vertex<T> neighbour = edge.getEndpoints()[1];

                if(!visited.Contains(neighbour))
                {
                    forest.put(neighbour, edge);
                    search(graph, neighbour, visited, forest);
                }
            }

            return forest;
        }
    }
}
