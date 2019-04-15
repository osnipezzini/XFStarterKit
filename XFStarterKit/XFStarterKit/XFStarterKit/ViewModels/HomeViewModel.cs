using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFStarterKit.Core.Common.Exceptions;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.Services.File;
using XFStarterKit.Core.ViewModels.Base;

namespace XFStarterKit.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        readonly IAuthenticationService authenticationService;
        readonly IFileService fileService;

        public HomeViewModel(
            IAuthenticationService authenticationService,
            IFileService fileService)
        {
            this.authenticationService = authenticationService;
            this.fileService = fileService;
        }

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                var authenticatedUser = authenticationService.AuthenticatedUser;
            }
            catch (ConnectivityException cex)
            {
                Debug.WriteLine($"[Home] Connectivity Error: {cex}");
                await DialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Home] Error: {ex}");
                //await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }
    }
}