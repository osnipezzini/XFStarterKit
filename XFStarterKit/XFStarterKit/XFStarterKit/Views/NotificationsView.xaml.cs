using XFStarterKit.Core.Helpers;
using Xamarin.Forms;

namespace XFStarterKit.Core.Views
{
    public partial class NotificationsView : ContentPage
    {
        public NotificationsView()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            StatusBarHelper.Instance.MakeTranslucentStatusBar(false);
        }
    }
}