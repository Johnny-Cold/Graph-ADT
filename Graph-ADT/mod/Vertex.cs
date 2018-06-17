using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graph_ADT.mod
{
    public class Vertex<T>
    {
        T element;
        List<Vertex<T>> neighbours; // A list of the vertices that are the neighbour of the current vertex.

        public Vertex(T element)
        {
            this.element = element;
            neighbours = new List<Vertex<T>>();
        }

        public T getElement()
        {
            return element;
        }

        public void addNeighbour(Vertex<T> neighbour)
        {
            neighbours.Add(neighbour);
        }

        public List<Vertex<T>> getNeighbours()
        {
            return neighbours;
        }

        public void removeNeighbour(Vertex<T> neighbour)
        {
            neighbours.Remove(neighbour);
        }

        public int getDegree()
        {
            return neighbours.Count;
        }

        public override string ToString()
        {
            return element.ToString();
        }
    }
}
