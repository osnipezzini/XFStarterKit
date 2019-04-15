using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using XFStarterKit.Core.Common.Exceptions;
using XFStarterKit.Core.Models;
using XFStarterKit.Core.Services.Analytic;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.Validations;
using XFStarterKit.Core.ViewModels.Base;

namespace XFStarterKit.Core.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        readonly IAnalyticService analyticService;
        readonly IAuthenticationService authenticationService;

        ValidatableObject<string> userName;
        ValidatableObject<string> password;

        public bool IsValid { get; set; }

        public LoginViewModel(
            IAnalyticService analyticService,
            IAuthenticationService authenticationService)
        {
            this.analyticService = analyticService;
            this.authenticationService = authenticationService;

            userName = new ValidatableObject<string>();
            password = new ValidatableObject<string>();

            AddValidations();
        }

        public ValidatableObject<string> UserName
        {
            get => userName;
            set => SetProperty(ref userName, value);
        }

        public ValidatableObject<string> Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public ICommand SignInCommand => new AsyncCommand(SignInAsync);

        async Task SignInAsync()
        {
            IsBusy = true;

            IsValid = Validate();           

            if (IsValid)
            {
                var isAuth = await authenticationService.LoginAsync(UserName.Value, Password.Value);

                if (isAuth)
                {
                    IsBusy = false;

                    analyticService.TrackEvent("SignIn");
                    await NavigationService.NavigateToAsync<MainViewModel>();
                }
            }

            MessagingCenter.Send(this, MessengerKeys.SignInRequested);

            IsBusy = false;
        }

        

        void AddValidations()
        {
            userName.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Username should not be empty" });
            userName.Validations.Add(new EmailRule());
            password.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "Password should not be empty" });
        }

        bool Validate()
        {
            var isValidUser = userName.Validate();
            var isValidPassword = password.Validate();

            return isValidUser && isValidPassword;
        }
    }
}
