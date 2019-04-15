using XFStarterKit.Core.ViewModels.Base;
using System.Threading.Tasks;

namespace XFStarterKit.Core.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        MenuViewModel menuViewModel;

        public MainViewModel(MenuViewModel menuViewModel)
        {
            this.menuViewModel = menuViewModel;
        }

        public MenuViewModel MenuViewModel
        {
            get => menuViewModel;

            set
            {
                menuViewModel = value;
                OnPropertyChanged();
            }
        }

        public override Task InitializeAsync(object navigationData) => Task.WhenAll
                (
                    menuViewModel.InitializeAsync(navigationData),
                    NavigationService.NavigateToAsync<HomeViewModel>()
                );
    }
}