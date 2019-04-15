﻿using XFStarterKit.Core;
using Windows.Foundation;
using Windows.Foundation.Metadata;
using Windows.UI;
using Windows.UI.ViewManagement;

namespace XFStarterKit.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            InitializeComponent();

            FFImageLoading.Forms.Platform.CachedImageRenderer.Init();
            Renderers.Calendar.Init();
            Xamarin.FormsMaps.Init(AppSettings.BingMapsApiKey);
            LoadApplication(new XFStarterKit.Core.App());
            NativeCustomize();
        }

        void NativeCustomize()
        {
            ApplicationView.GetForCurrentView().SetPreferredMinSize(new Size(500, 500));

            // PC Customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.ApplicationView"))
            {
                var titleBar = ApplicationView.GetForCurrentView().TitleBar;
                if (titleBar != null)
                {
                    titleBar.BackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
                    titleBar.ButtonBackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
                }
            }

            // Mobile Customization
            if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
            {
                //var statusBar = StatusBar.GetForCurrentView();
                //if (statusBar != null)
                //{
                //    statusBar.BackgroundOpacity = 1;
                //    statusBar.BackgroundColor = (Color)App.Current.Resources["NativeAccentColor"];
                //}
            }

            // Launch in Window Mode
            var currentView = ApplicationView.GetForCurrentView();
            if (currentView.IsFullScreenMode)
            {
                currentView.ExitFullScreenMode();
            }
        }
    }
}