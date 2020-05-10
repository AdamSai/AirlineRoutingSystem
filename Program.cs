using System;
using System.Collections.Generic;
using System.Linq;
using AirlineNetworks.Graph;

namespace AirlineNetworks
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var filePath = @"D:\Github\Algorithms\AirlineNetworks\airlines\routes.txt";
            var (routes, routeIds) = CsvParser.FileToRoutes(filePath);
            Console.WriteLine(routeIds.Count);
            var ewg = new EdgeWeightedGraph(routeIds.Count);
            foreach (var route in routes)
            {
                routeIds.TryGetValue(route.Source, out var source);
                routeIds.TryGetValue(route.Destination, out var destination);
                ewg.AddEdge(new Edge(source - 1, destination - 1, route.Distance));
            }

            var adj = GetAdjacents("TUN");
            foreach (var route in adj)
            {
                var source = GetAirportCode(route.V);
                var dest = GetAirportCode(route.W);
                Console.WriteLine($"{source};{dest} {route.Weight:N2}");
            }
            
            var mst = new KruskalMST(ewg);
            Console.WriteLine(mst);
            var Edges = mst.Edges();
            // foreach (var edge in Edges)
            // {
            //     
            //     Console.WriteLine(edge);
            // }

            IEnumerable<Edge> GetAdjacents(string key)
            {
                routeIds.TryGetValue(key, out int val);
                return ewg.Adjacents(val - 1);
                
            }

            string GetAirportCode(int id)
            {
                return routeIds.FirstOrDefault(x => x.Value == id + 1).Key;
            }
        }
    }
}