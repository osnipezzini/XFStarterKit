using System.Threading.Tasks;

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
