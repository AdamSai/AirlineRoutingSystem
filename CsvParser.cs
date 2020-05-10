using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace AirlineNetworks
{
    public class CsvParser
    {

        public static (List<Route>, Dictionary<string, int>) FileToRoutes(string csvFilePath)
        {
            var routes = new List<Route>();
            var routeIDs = new Dictionary<string, int>();
            using (var sr = File.OpenText(csvFilePath))
            {
                // Skip the CSV headers
                sr.ReadLine();
                
                var s = "";
                var count = 1;
                while ((s = sr.ReadLine()) != null)
                {
                    var line = s.Split(';');
                    //  AIRLINE_CODE;SOURCE_CODE;DESTINATION_CODE;DISTANCE;TIME
                    routeIDs.TryGetValue(line[1], out var sourceId);
                    routeIDs.TryGetValue(line[2], out var destinationId);
                    if(sourceId == 0)
                        routeIDs.Add(line[1], count++);
                    if(destinationId == 0)
                        routeIDs.Add(line[2], count++);

                    var route = new Route(line[0], line[1], line[2], double.Parse(line[3], CultureInfo.InvariantCulture), double.Parse(line[4], CultureInfo.InvariantCulture));
                    routes.Add(route);
                }
            }

            return (routes, routeIDs);
        }
    }
}