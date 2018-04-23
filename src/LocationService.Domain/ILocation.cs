using LocationService.Domain.Models;
using System.Threading.Tasks;

namespace LocationService.Domain
{
    public interface ILocation
    {
        Task<Location> GetLocationByNameAsync(string name);
    }
}
