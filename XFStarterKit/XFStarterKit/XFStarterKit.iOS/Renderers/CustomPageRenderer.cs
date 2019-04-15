using XFStarterKit.Core.Utils;
using XFStarterKit.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(Page), typeof(CustomPageRenderer))]
namespace XFStarterKit.iOS.Renderers
{
    public class CustomPageRenderer : PageRenderer
    {
        IElementController ElementController => Element as IElementController;

        public override void ViewWillAppear(bool animated)
        {
            base.ViewWillAppear(animated);

            // Force nav bar text color
            var color = NavigationBarAttachedProperty.GetTextColor(Element);
            NavigationBarAttachedProperty.SetTextColor(Element, color);
        }
    }
}