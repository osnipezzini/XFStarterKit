using XFStarterKit.Core.ViewModels.Base;
using Xamarin.Forms;

namespace XFStarterKit.Core.Views
{
    public partial class MenuView : ContentPage
	{
		public MenuView ()
		{
			InitializeComponent ();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

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