﻿using XFStarterKit.Core.Controls;
using XFStarterKit.UWP.Extensions;
using XFStarterKit.UWP.Renderers;
using System.ComponentModel;
using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.UWP;

[assembly: ExportRenderer(typeof(ExtendedEntry), typeof(ExtendedEntryRenderer))]
namespace XFStarterKit.UWP.Renderers
{
    public class ExtendedEntryRenderer : EntryRenderer
    {
        public ExtendedEntry ExtendedEntryElement => Element as ExtendedEntry;

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null)
            {
                if (Control != null)
                {
                    Control.Style = App.Current.Resources["FormTextBoxStyle"] as Windows.UI.Xaml.Style;
                }

                Control.Loaded -= OnControlLoaded;
                Control.Loaded += OnControlLoaded;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName.Equals(nameof(ExtendedEntry.LineColor)))
            {
                UpdateLineColor();
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (Control != null)
            {
                Control.Loaded -= OnControlLoaded;
            }

            base.Dispose(disposing);
        }

        void UpdateLineColor()
        {
            var border = Control.FindVisualChildren<Border>()      
                .Where(c => c.Name == "BorderElement")
                .FirstOrDefault();

            if (border != null)
            {
                border.BorderBrush = new SolidColorBrush(ExtendedEntryElement.LineColor.ToUwp());
            }
        }

        void OnControlLoaded(object sender, RoutedEventArgs e) => UpdateLineColor();
    }
}
