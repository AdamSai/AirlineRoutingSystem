namespace AirlineNetworks
{
    public class Aircraft
    {
        private string Code, Name, Category;

        public Aircraft(string code, string name, string category)
        {
            this.Code = code;
            this.Name = name;
            this.Category = category;
        }
    }
}