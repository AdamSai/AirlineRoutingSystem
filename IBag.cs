namespace AirlineNetworks
{
    public interface IBag<T> : ISelection<T>
    {
        void Add(T item);
    }
}