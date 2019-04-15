using Android.App;
using Android.Views.InputMethods;
using XFStarterKit.Core.Services.DismissKeyboard;
using XFStarterKit.Droid.Services.DismissKeyboard;

[assembly: Xamarin.Forms.Dependency(typeof(DismissKeyboardService))]
namespace XFStarterKit.Droid.Services.DismissKeyboard
{
    public class DismissKeyboardService : IDismissKeyboardService
    {
        public void DismissKeyboard()
        {
            var inputMethodManager = InputMethodManager.FromContext(Android.App.Application.Context);

            inputMethodManager.HideSoftInputFromWindow(
                ((Activity)Xamarin.Forms.Forms.Context).Window.DecorView.WindowToken, HideSoftInputFlags.NotAlways);
        }
    }
}