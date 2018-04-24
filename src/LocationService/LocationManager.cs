using LocationService.Domain;
using LocationService.Domain.Models;
using System;
using System.Threading.Tasks;

namespace LocationService
{
    public class LocationManager : ILocation
    {
        public Task<Location> GetLocationByNameAsync(string name)
        {
            throw new NotImplementedException();
        }
    }
}
