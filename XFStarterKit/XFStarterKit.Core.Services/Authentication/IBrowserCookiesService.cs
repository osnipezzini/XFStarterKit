using System.Threading.Tasks;

namespace XFStarterKit.Core.Services.Authentication
{
    public interface IBrowserCookiesService
    {
        Task ClearCookiesAsync();
    }
}
