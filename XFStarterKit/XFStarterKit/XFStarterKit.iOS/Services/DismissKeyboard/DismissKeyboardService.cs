using XFStarterKit.Core.Services.DismissKeyboard;
using XFStarterKit.iOS.Services.DismissKeyboard;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(DismissKeyboardService))]
namespace XFStarterKit.iOS.Services.DismissKeyboard
{
    public class DismissKeyboardService : IDismissKeyboardService
    {
        public void DismissKeyboard() => UIApplication.SharedApplication.InvokeOnMainThread(() =>
                                       {
                                           var window = UIApplication.SharedApplication.KeyWindow;
                                           var vc = window.RootViewController;
                                           while (vc.PresentedViewController != null)
                                           {
                                               vc = vc.PresentedViewController;
                                           }

                                           vc.View.EndEditing(true);
                                       });
    }
}