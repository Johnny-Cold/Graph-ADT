using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.mod
{
    /// <summary>
    /// Implementation of a directed edge.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public class DirectedEdge<V> : Edge<V>
    {
        V origin, destination;

        public DirectedEdge(V origin, V destination)
        {
            this.origin = origin;
            this.destination = destination;
        }

        public bool hasVertex(V vertex)
        {
            return origin.Equals(vertex) || destination.Equals(vertex);
        }

        public bool hasVertices(V v, V u)
        {
            return (origin.Equals(v) || (origin.Equals(u))) && (destination.Equals(v) || (destination.Equals(u)));
        }

        public void setEndpoints(V u, V v)
        {
            origin = u;
            destination = v;
        }

        public void setEndpoints(V[] endpoints)
        {
            origin = endpoints[0];
            destination = endpoints[1];
        }

        public V[] getEndpoints()
        {
            return new V[2] { origin, destination };
        }
        
        public void setOrigin(V origin)
        {
            this.origin = origin;
        }

        public void setDestination(V destination)
        {
            this.destination = destination;
        }

        public V getOrigin()
        {
            return origin;
        }

        public V getDestination()
        {
            return destination;
        }

        public override bool Equals(object obj)
        {
            return (base.Equals(obj)) && ((obj.ToString().Equals(this.ToString())));
        }

        public override string ToString()
        {
            return origin.ToString() + " ---------------- " + destination.ToString();
        }
    }
}
