using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.graph
{
    public interface Graph<V,E>
    {
        /// <returns> The degree of the given vertex. </returns>
        int getDegree(V vertex);

        /// <summary>
        /// Adds a new edge to the graph.
        /// </summary>
        void addEdge(E edge);

        /// <summary>
        /// Adds a new edge to the graph implied by the addition of opposite vertices.
        /// </summary>
        void addEdge(V vertex, V neighbour);
        
        /// <returns> All the edges for which the specified vertex is an endpoint. </returns>
        List<E> getEdges(V vertex);

        /// <summary>
        /// Provides visualisation of the edges.
        /// </summary>
        void printEdges();

        /// <summary>
        /// Removes a specified edge.
        /// </summary>
        void removeEdge(E edge);

        /// <summary>
        /// Removes the edge that has the two given vertices as its endpoints.
        /// </summary>
        void removeEdge(V v, V u);

        /// <summary>
        /// Removes an edge and its endpoints.
        /// </summary>
        void removeEdgeAndEndpoints(E edge);

        void addVertex(V vertex);

        void removeVertex(V vertex);

        /// <summary>
        /// Clears the graph.
        /// </summary>
        void clear();
    }
}
