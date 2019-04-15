﻿using Windows.UI;

namespace XFStarterKit.UWP.Extensions
{
    static class ColorExtensions
    {
        public static Color ToUwp(this Xamarin.Forms.Color color) => Color.FromArgb((byte)(color.A * 255),      
            (byte)(color.R * 255),
            (byte)(color.G * 255),
            (byte)(color.B * 255));
    }
}
