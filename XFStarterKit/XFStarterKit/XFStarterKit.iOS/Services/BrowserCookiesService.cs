using Foundation;
using XFStarterKit.Core.Services.Authentication;
using System.Threading.Tasks;

namespace XFStarterKit.iOS.Services
{
    public class BrowserCookiesService : IBrowserCookiesService
    {
        public Task ClearCookiesAsync()
        {
            var storage = NSHttpCookieStorage.SharedStorage;

            foreach (var cookie in storage.Cookies)
            {
                storage.DeleteCookie(cookie);
            }

            return Task.FromResult(true);
        }
    }
}