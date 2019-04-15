using Autofac;
using System;
using XFStarterKit.Core.Services.Analytic;
using XFStarterKit.Core.Services.Authentication;
using XFStarterKit.Core.Services.Dialog;
using XFStarterKit.Core.Services.File;
using XFStarterKit.Core.Services.Geolocator;
using XFStarterKit.Core.Services.Navigation;
using XFStarterKit.Core.Services.OpenUri;
using XFStarterKit.Core.Services.Request;

namespace XFStarterKit.Core.ViewModels.Base
{
    public class Locator
    {
        IContainer container;
        ContainerBuilder containerBuilder;

        public static Locator Instance { get; } = new Locator();

        public Locator()
        {
            containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<AnalyticService>().As<IAnalyticService>();
            containerBuilder.RegisterType<DialogService>().As<IDialogService>();
            containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            containerBuilder.RegisterType<AuthenticationService>().As<IAuthenticationService>();
            containerBuilder.RegisterType<LocationService>().As<ILocationService>();
            containerBuilder.RegisterType<OpenUriService>().As<IOpenUriService>();
            containerBuilder.RegisterType<RequestService>().As<IRequestService>();
            containerBuilder.RegisterType<DefaultBrowserCookiesService>().As<IBrowserCookiesService>();
            containerBuilder.RegisterType<GravatarUrlProvider>().As<IAvatarUrlProvider>();
            containerBuilder.RegisterType<FileService>().As<IFileService>();
            containerBuilder.RegisterType<HomeViewModel>();
            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<MainViewModel>();
            containerBuilder.RegisterType<MenuViewModel>();
            containerBuilder.RegisterType<ExtendedSplashViewModel>();
        }

        public T Resolve<T>() => container.Resolve<T>();

        public object Resolve(Type type) => container.Resolve(type);

        public void Register<TInterface, TImplementation>() where TImplementation : TInterface => containerBuilder.RegisterType<TImplementation>().As<TInterface>();

        public void Register<T>() where T : class => containerBuilder.RegisterType<T>();

        public void Build() => container = containerBuilder.Build();
    }
}