﻿using System.Threading.Tasks;
using XFStarterKit.Core.Models;

namespace XFStarterKit.Core.Services.Authentication
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get; }
        User AuthenticatedUser { get; }

        Task<bool> LoginAsync(string email, string password);

        Task LogoutAsync();
    }
}
