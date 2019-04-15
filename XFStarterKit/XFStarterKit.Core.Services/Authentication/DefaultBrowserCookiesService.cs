using System.Threading.Tasks;

namespace XFStarterKit.Core.Services.Authentication
{
    public class DefaultBrowserCookiesService : IBrowserCookiesService
    {
        public Task ClearCookiesAsync() => Task.FromResult(true);
    }
}
