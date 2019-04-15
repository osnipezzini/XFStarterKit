using Xamarin.Essentials;
using XFStarterKit.Core.Models;
using XFStarterKit.Core.Utils;

namespace XFStarterKit.Core
{
	public static class AppSettings
    {
        //IF YOU DEPLOY YOUR OWN ENDPOINT REPLACE THE VALUEW BELOW

        //App Center
        const string defaultAppCenterAndroid = "b3b1403c-3f9d-4c77-805e-9c002de6ddf7";
        const string defaultAppCenteriOS = "7a2a290b-07b0-47dc-9dcd-15461e894e6d";
        const string defaultAppCenterUWP = "140a8550-c309-4bc1-a05d-e5a0f7e4df1d";

        // Maps
        const string defaultBingMapsApiKey = "AkSuJ-YtW4VDvIzErxK3ke2ILQD1muWwS2KN2QvhqHobx4YBEIYqkEVBLyx1LYby";
        public const string DefaultFallbackMapsLocation = "40.762246,-73.986943";

        // Fakes
        const bool defaultUseFakes = false;

        static AppSettings()
        {           
		}

        // Other settings

        public static string BingMapsApiKey
        {
            get => Preferences.Get(nameof(BingMapsApiKey), defaultBingMapsApiKey);
            set => Preferences.Set(nameof(BingMapsApiKey), value);
        }

        public static string FallbackMapsLocation
        {
            get => Preferences.Get(nameof(FallbackMapsLocation), DefaultFallbackMapsLocation);
            set => Preferences.Set(nameof(FallbackMapsLocation), value);
        }

        public static User User
        {
            get => PreferencesHelpers.Get(nameof(User), default(User));
            set => PreferencesHelpers.Set(nameof(User), value);
        }

        public static string AppCenterAnalyticsAndroid
        {
            get => Preferences.Get(nameof(AppCenterAnalyticsAndroid), defaultAppCenterAndroid);
            set => Preferences.Set(nameof(AppCenterAnalyticsAndroid), value);
        }

        public static string AppCenterAnalyticsIos
        {
            get => Preferences.Get(nameof(AppCenterAnalyticsIos), defaultAppCenteriOS);
            set => Preferences.Set(nameof(AppCenterAnalyticsIos), value);
        }

        public static string AppCenterAnalyticsWindows
        {
            get => Preferences.Get(nameof(AppCenterAnalyticsWindows), defaultAppCenterUWP);
            set => Preferences.Set(nameof(AppCenterAnalyticsWindows), value);
        }

        public static bool UseFakes
        {
            get => Preferences.Get(nameof(UseFakes), defaultUseFakes);
            set => Preferences.Set(nameof(UseFakes), value);
        }

        public static bool IsAuthenticated => User != null;

        public static Models.User AuthenticatedUser => User;

        public static void RemoveUserData() => Preferences.Remove(nameof(User));
    }
}
