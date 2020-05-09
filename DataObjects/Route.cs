namespace AirlineNetworks
{
    public class Route
    {
        public string Airline;
        public string Source;
        public string Destination;
        public double Distance, Time;

        public Route(string airline, string destination, double distance, double time)
        {
            Airline = airline;
            Destination = destination;
            Distance = distance;
            Time = time;
        }        
        public Route(string airline, string source, string destination, double distance, double time)
        {
            Airline = airline;
            Source = source;
            Destination = destination;
            Distance = distance;
            Time = time;
        }

        public override string ToString()
        {
            return $"{Airline} {Source} {Destination} {Distance} {Time}";
        }
    }
}