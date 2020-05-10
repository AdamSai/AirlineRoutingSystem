using System;

namespace AirlineNetworks.Graph
{
    public class Edge : IComparable<Edge>
    {
        public int V { get; private set; }
        public int W { get; private set; }
        public double Weight { get; private set; }

        public int Either()
        {
            return V;
        }
        
        public Edge(int v, int w, double weight)
        {
            V = v;
            W = w;
            Weight = weight;
        }

        public int Other(int vertex)
        {
            return vertex == V ? W : V;
        }
        

        public int CompareTo(Edge other)
        {
            if (Weight < other.Weight) return -1;
            if (Weight > other.Weight) return 1;
            return 0;
        }


        public override string ToString()
        {
            return $"{V}-{W}, {Weight:N2}";
        }
        
    }
}