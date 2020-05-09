using System.Collections.Generic;

namespace AirlineNetworks
{
    public interface ISelection<T> : IEnumerable<T>
    {
        bool IsEmpty();
        int GetSize(); 
    }
}