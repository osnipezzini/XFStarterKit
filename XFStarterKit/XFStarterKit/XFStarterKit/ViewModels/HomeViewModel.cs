using MvvmHelpers;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFStarterKit.Core.Exceptions;
using XFStarterKit.Core.Models;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.Services.File;
using XFStarterKit.Core.Services.Notification;
using XFStarterKit.Core.ViewModels.Base;

namespace XFStarterKit.Core.ViewModels
{
    public class HomeViewModel : ViewModelBase, IHandleViewAppearing, IHandleViewDisappearing
    {
        bool hasBooking;
        ObservableRangeCollection<Notification> notifications;

        readonly INotificationService notificationService;
        readonly IAuthenticationService authenticationService;
        readonly IFileService fileService;

        public HomeViewModel(
            INotificationService notificationService,
            IAuthenticationService authenticationService,
            IFileService fileService)
        {
            this.notificationService = notificationService;
            this.authenticationService = authenticationService;
            this.fileService = fileService;

            notifications = new ObservableRangeCollection<Notification>();
        }

        public bool HasBooking
        {
            get => hasBooking;
            set => SetProperty(ref hasBooking, value);
        }

        public ObservableRangeCollection<Notification> Notifications
        {
            get => notifications;
            set => SetProperty(ref notifications, value);
        }

        const string greetingMessageLastShownFileName = "GreetingMessageLastShownDate.txt";
        const string greetingMessageEmbeddedResourceName = "XFStarterKit.Core.Resources.GreetingMessage.txt";

        public ICommand NotificationsCommand => new AsyncCommand(OnNotificationsAsync);

        public override async Task InitializeAsync(object navigationData)
        {
            try
            {
                IsBusy = true;

                HasBooking = AppSettings.HasBooking;

                var authenticatedUser = authenticationService.AuthenticatedUser;
                var notifications = await notificationService.GetNotificationsAsync(3, authenticatedUser.Token);
                Notifications = new ObservableRangeCollection<Notification>(notifications);

                ShowGreetingMessage();
            }
            catch (ConnectivityException cex)
            {
                Debug.WriteLine($"[Home] Connectivity Error: {cex}");
                await DialogService.ShowAlertAsync("There is no Internet conection, try again later.", "Error", "Ok");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[Home] Error: {ex}");
                //await DialogService.ShowAlertAsync(Resources.ExceptionMessage, Resources.ExceptionTitle, Resources.DialogOk);
            }
            finally
            {
                IsBusy = false;
            }
        }

        void ShowGreetingMessage()
        {
            // Check the last time the greeting message was showed. That date is saved in a File.
            // If the file does not exists, or the date in the file is in the past, don't show the greeting-
            if (fileService.ExistsInLocalAppDataFolder(greetingMessageLastShownFileName))
            {
                var textFromFile = fileService.ReadStringFromLocalAppDataFolder(greetingMessageLastShownFileName);
                long.TryParse(textFromFile, out var lastShownTicks);

                if (lastShownTicks < DateTime.Now.Ticks)
                {
                    return;
                }
            }

            // Show greeting message
            var greetingMessage = fileService.ReadStringFromAssemblyEmbeddedResource(greetingMessageEmbeddedResourceName);
            DialogService.ShowToast(greetingMessage);

            // Save last shown date
            var stringTicks = DateTime.Now.Ticks.ToString();
            fileService.WriteStringToLocalAppDataFolder(greetingMessageLastShownFileName, stringTicks);
        }

        public Task OnViewAppearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        public Task OnViewDisappearingAsync(VisualElement view)
        {
            return Task.FromResult(true);
        }

        Task OnNotificationsAsync() => NavigationService.NavigateToAsync(typeof(NotificationsViewModel), Notifications);

    }
}