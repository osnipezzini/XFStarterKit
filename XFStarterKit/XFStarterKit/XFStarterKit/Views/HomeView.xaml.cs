using XFStarterKit.Core.Helpers;
using XFStarterKit.Core.ViewModels.Base;
using Xamarin.Forms;

namespace XFStarterKit.Core.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(true);

            if (BindingContext is IHandleViewAppearing viewAware)
            {
                await viewAware.OnViewAppearingAsync(this);
            }
        }

        protected override async void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IHandleViewDisappearing viewAware)
            {
                await viewAware.OnViewDisappearingAsync(this);
            }
        }
    }
}