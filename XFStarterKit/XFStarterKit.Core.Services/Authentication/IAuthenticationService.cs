using System.Threading.Tasks;

namespace XFStarterKit.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        Task<bool> LoginAsync(string email, string password);

        Task LogoutAsync();
    }
}
