using System;
using System.Collections.Generic;
using System.Linq;
using AlgorithmTools;

namespace AirlineNetworks.Graph
{
    public class KruskalMST
    {
        private Queue<Edge> _mst;

        public KruskalMST(EdgeWeightedGraph G)
        {
            _mst = new Queue<Edge>();
            var pq = new MinPQ<Edge>(G.Edges().Count());
            var uf = new WeightedQuickUnion(G.V);
            foreach (var edge in G.Edges())
            {
                if(edge is null) continue;
                pq.Insert(edge);
            }
            while (!pq.IsEmpty && _mst.Count() < G.V - 1)
            {
                var e = pq.DelMin(); // Get min weight edge on pq
                var v = e.Either(); 
                var w = e.Other(v); // and its vertices.
                if (uf.Connected(v, w)) continue; // Ignore ineligible edges.
                uf.Union(v, w); // Merge components.
                _mst.Enqueue(e); // Add edge to mst.
            }
        }

        public Queue<Edge> Edges()
        {
            return _mst;
        }

   
    }
}