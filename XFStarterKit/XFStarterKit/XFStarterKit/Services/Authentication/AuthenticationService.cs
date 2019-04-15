using System.Threading.Tasks;
using XFStarterKit.Core.Models;

namespace XFStarterKit.Core.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        readonly IBrowserCookiesService browserCookiesService;
        readonly IAvatarUrlProvider avatarProvider;

        public AuthenticationService(
            IBrowserCookiesService browserCookiesService,
            IAvatarUrlProvider avatarProvider)
        {
            this.browserCookiesService = browserCookiesService;
            this.avatarProvider = avatarProvider;
        }

        public bool IsAuthenticated => AppSettings.User!=null;

        public User AuthenticatedUser => AppSettings.User;

        public Task<bool> LoginAsync(string email, string password)
        {
            var user = new Models.User
            {
                Email = email,
                Name = email,
                LastName = string.Empty,
                AvatarUrl = avatarProvider.GetAvatarUrl(email),
                Token = email,
                LoggedInWithMicrosoftAccount = false
            };

            AppSettings.User = user;

            return Task.FromResult(true);
        }
        public async Task LogoutAsync()
        {
            await browserCookiesService.ClearCookiesAsync();
        }
    }
}
