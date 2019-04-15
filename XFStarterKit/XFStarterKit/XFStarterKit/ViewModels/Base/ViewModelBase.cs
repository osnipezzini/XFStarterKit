using System.Threading.Tasks;
using XFStarterKit.Core.Services.Dialog;
using XFStarterKit.Core.Services.Navigation;

namespace XFStarterKit.Core.ViewModels.Base
{
    public abstract class ViewModelBase : MvvmHelpers.BaseViewModel
    {
        protected readonly IDialogService DialogService;
        protected readonly INavigationService NavigationService;

        public ViewModelBase()
        {
            DialogService = Locator.Instance.Resolve<IDialogService>();
            NavigationService = Locator.Instance.Resolve<INavigationService>();
        }

        public virtual Task InitializeAsync(object navigationData) => Task.FromResult(false);
    }
}