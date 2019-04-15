using MvvmHelpers;
using XFStarterKit.Core.Models;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.Services.OpenUri;
using XFStarterKit.Core.ViewModels.Base;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFStarterKit.Core.ViewModels
{
    public class MenuViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        const string skype = "Skype";

        ObservableRangeCollection<Models.MenuItem> menuItems;

        readonly IAuthenticationService authenticationService;
        readonly IOpenUriService openUrlService;

        public MenuViewModel(
            IAuthenticationService authenticationService,
            IOpenUriService openUrlService)
        {
            this.authenticationService = authenticationService;
            this.openUrlService = openUrlService;

            MenuItems = new ObservableRangeCollection<Models.MenuItem>();

            InitMenuItems();
        }

        public string UserName => AppSettings.User?.Name;

        public string UserAvatar => AppSettings.User?.AvatarUrl;

        public ObservableRangeCollection<Models.MenuItem> MenuItems
        {
            get => menuItems;
            set
            {
                menuItems = value;
                OnPropertyChanged();
            }
        }

        public ICommand MenuItemSelectedCommand => new Command<Models.MenuItem>(OnSelectMenuItem);

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view) => Task.FromResult(true);

        void InitMenuItems()
        {
            MenuItems.Add(new Models.MenuItem
            {
                Title = "Home",
                MenuItemType = MenuItemType.Home,
                ViewModelType = typeof(MainViewModel),
                IsEnabled = true
            });

            MenuItems.Add(new Models.MenuItem
            {
                Title = "Logout",
                MenuItemType = MenuItemType.Logout,
                ViewModelType = typeof(LoginViewModel),
                IsEnabled = true,
                AfterNavigationAction = RemoveUserCredentials
            });
        }

        async void OnSelectMenuItem(Models.MenuItem item)
        {
            if (item.IsEnabled && item.ViewModelType != null)
            {
                item.AfterNavigationAction?.Invoke();
                await NavigationService.NavigateToAsync(item.ViewModelType, item);
            }
        }

        Task RemoveUserCredentials()
        {
            return authenticationService.LogoutAsync();
        }

        void SetMenuItemStatus(MenuItemType type, bool enabled)
        {
            var menuItem = MenuItems.FirstOrDefault(m => m.MenuItemType == type);

            if (menuItem != null)
            {
                menuItem.IsEnabled = enabled;
            }
        }
    }
}