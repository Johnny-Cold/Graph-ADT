using Graph_ADT.graph;
using Graph_ADT.map;
using Graph_ADT.mod;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.search.uninformed
{
    public class DepthFirstSearch<T>
    {
        public static Vertex<T> search(Graph<Vertex<T>> graph, Vertex<T> startPoint, HashSet<Vertex<T>> visited, HashMap<Vertex<T>, Edge<Vertex<T>>> forest)
        {
            Vertex<T> vertex = null;

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

            return vertex;
        }
    }
}
