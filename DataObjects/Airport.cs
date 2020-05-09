namespace AirlineNetworks
{
    public class Airport
    {
        private string Code, City, Country, Latitude, Longitude;
        private Route _route;
        
        public Airport(string code, string city, string country, string latitude, string l)
        {
            Code = code;
            City = city;
            Country = country;
            Latitude = latitude;
            Longitude = l;
        }

        public Airport(string code, Route route)
        {
            Code = code;
            _route = route;
        }
    }
}