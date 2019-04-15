using XFStarterKit.Core.Models;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace XFStarterKit.Core.Services.Geolocator
{
    public interface ILocationService
    {
        Task<Location> GetPositionAsync();
    }
}