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

            Console.WriteLine("E: " + ewg.E);
            Console.WriteLine("V: " + ewg.V);
            Console.WriteLine("Edges: " + ewg.Edges().Count());
            var adj = GetAdjacents("TUN");
            Console.WriteLine("Adjacents: ");
            Console.WriteLine(adj.Count());
            foreach (var route in adj)
            {
                var source = GetAirportName(route.V);
                var dest = GetAirportName(route.W);
                Console.WriteLine($"{source};{dest} {route.Weight:N2}");
            }

            IEnumerable<Edge> GetAdjacents(string key)
            {
                routeIds.TryGetValue(key, out int val);
                return ewg.Adjacents(val - 1);
                
            }

            string GetAirportName(int id)
            {
                return routeIds.FirstOrDefault(x => x.Value == id + 1).Key;
            }
        }
    }
}