using System.Collections.Concurrent;
using System.Collections.Generic;

namespace AirlineNetworks.Graph
{
    public class EdgeWeightedGraph
    {
        public readonly int V;
        public int E;
        private ConcurrentBag<Edge>[] adjacents;

        public EdgeWeightedGraph(int V)
        {
            this.V = V;
            E = 0;
            adjacents = new ConcurrentBag<Edge>[V];
            for (var v = 0; v < V; v++)
                adjacents[v] = new ConcurrentBag<Edge>();
        }

        public void AddEdge(Edge e)
        {
            var v = e.Either();
            var w = e.Other(v);

            adjacents[v].Add(e);
            adjacents[w].Add(e);
            E++;
        }

        public IEnumerable<Edge> Adjacents(int v)
        {
            return adjacents[v];
        }

        public IEnumerable<Edge> Edges()
        {
            var b = new ArrayBag<Edge>();
            for (var v = 0; v < V; v++)
                foreach (var e in adjacents[v])
                {
                    if (e.Other(v) > v)
                        b.Add(e);
                }

            return b;
        }
    }
}