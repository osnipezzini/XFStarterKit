using XFStarterKit.Core.Helpers;
using XFStarterKit.Core.ViewModels;
using Xamarin.Forms;

namespace XFStarterKit.Core.Views
{
    public partial class LoginView : ContentPage
    {
        public LoginView()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            MessagingCenter.Subscribe<LoginViewModel>(this, MessengerKeys.SignInRequested, OnSignInRequested);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);
        }

        void OnSignInRequested(LoginViewModel loginViewModel)
        {
            if(!loginViewModel.IsValid)
            {
                VisualStateManager.GoToState(UsernameEntry, "Invalid");
                VisualStateManager.GoToState(PasswordEntry, "Invalid");
            }
        }
    }
}