using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface ISearchLocation<T> where T : class
    {
        T GetLocations(double latitude, double longitude, int maxDistance, int maxResults, T searchResult);
    }
}
