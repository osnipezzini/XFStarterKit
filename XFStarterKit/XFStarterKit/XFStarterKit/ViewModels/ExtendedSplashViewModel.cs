using System.Threading.Tasks;
using XFStarterKit.Core.ViewModels.Base;

namespace XFStarterKit.Core.ViewModels
{
    public class ExtendedSplashViewModel : ViewModelBase
    {
        public override async Task InitializeAsync(object navigationData)
        {
            IsBusy = true;

            await NavigationService.InitializeAsync();

            IsBusy = false;
        }
    }
}
