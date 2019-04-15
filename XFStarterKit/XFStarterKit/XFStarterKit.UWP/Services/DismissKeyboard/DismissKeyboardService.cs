using XFStarterKit.Core.Services.DismissKeyboard;
using XFStarterKit.UWP.Services.DismissKeyboard;
using Windows.UI.ViewManagement;

[assembly: Xamarin.Forms.Dependency(typeof(DismissKeyboardService))]
namespace XFStarterKit.UWP.Services.DismissKeyboard
{
    class DismissKeyboardService : IDismissKeyboardService
    {
        public void DismissKeyboard() => InputPane.GetForCurrentView().TryHide();
    }
}