using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using Foundation;
using UIKit;
using XFStarterKit.Core;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.ViewModels.Base;
using XFStarterKit.iOS.Services;

namespace XFStarterKit.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            CarouselViewRenderer.Init();
            Renderers.Calendar.Init();
            Xamarin.FormsMaps.Init();
            InitXamanimation();
            Rg.Plugins.Popup.Popup.Init();

            RegisterPlatformDependencies();

            LoadApplication(new XFStarterKit.Core.App());

            base.FinishedLaunching(app, options);

            UINavigationBar.Appearance.SetBackgroundImage(new UIImage(), UIBarMetrics.Default);
            UINavigationBar.Appearance.ShadowImage = new UIImage();
            UINavigationBar.Appearance.BackgroundColor = UIColor.Clear;
            UINavigationBar.Appearance.TintColor = UIColor.White;
            UINavigationBar.Appearance.BarTintColor = UIColor.Clear;
            UINavigationBar.Appearance.Translucent = true;

            return true;
        }

        void RegisterPlatformDependencies() => Locator.Instance.Register<IBrowserCookiesService, BrowserCookiesService>();
        static void InitXamanimation()
        {
            var t2 = typeof(Xamanimation.AnimationBase);
        }
    }
}
