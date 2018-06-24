using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.mod
{
    /// <summary>
    /// Implementation of an edge.
    /// </summary>
    /// <typeparam name="V"> Type name for vertices. </typeparam>
    public class Edge<V>
    {
        private V u, v;
        private bool isDirected; // Dictates edge directionality.
        private object value;

        /// <summary>
        /// Creates a directed edge.
        /// </summary>
        public Edge(bool isDirected, V u, V v)
        {
            this.isDirected = isDirected;
            this.u = u;
            this.v = v;
            value = null;
        }

        /// <summary>
        /// Creates a directed edge.
        /// </summary>
        public Edge(bool isDirected, V u, V v, object value)
        {
            this.isDirected = isDirected;
            this.u = u;
            this.v = v;
            this.value = value;
        }
        
        public bool hasVertex(V vertex)
        {
            return u.Equals(vertex) || v.Equals(vertex);
        }

        public bool hasVertices(V v, V u)
        {
            return (u.Equals(v) || (u.Equals(u))) && (v.Equals(v) || (v.Equals(u)));
        }

        public object getValue()
        {
            return value;
        }

        public void setDirectionality(bool isDirected)
        {
            this.isDirected = isDirected;
        }

        public void setEndpoints(V u, V v)
        {
            this.u = u;
            this.v = v;
        }

        public void setEndpoints(V[] endpoints)
        {
            u = endpoints[0];
            v = endpoints[1];
        }

        public V[] getEndpoints()
        {
            return new V[2] { u, v };
        }

        public void setOrigin(V u)
        {
            if(isDirected == false) { throw new InvalidOperationException("Undirected edge has no origin."); }
            this.u = u;
        }

        public void setDestination(V v)
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected edge has no destination."); }
            this.v = v;
        }

        public V getOrigin()
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected edge has no origin."); }
            return u;
        }

        public V getDestination()
        {
            if (isDirected == false) { throw new InvalidOperationException("Undirected edge has no destination."); }
            return v;
        }

        public override bool Equals(object obj)
        {
            return ((base.Equals(obj)) && (obj.ToString().Equals(this.ToString())) && ((isDirected == ((Edge<V>)obj).isDirected)) && (value == ((Edge<V>)obj).getValue()));
        }

        public override string ToString()
        {
            string output = "";

            if(value != null)
            {
                if (isDirected == false)
                {
                    output = u.ToString() + " -------- " + value.ToString() + " -------- " + v.ToString();
                }
                else
                {
                    output = u.ToString() + " *-------- " + value.ToString() + " --------> " + v.ToString();
                }
            }
            else
            {
                if (isDirected == false)
                {
                    output = u.ToString() + " ---------------- " + v.ToString();
                }
                else
                {
                    output = u.ToString() + " *----------------> " + v.ToString();
                }
            }

            return output;
        }
    }
}
