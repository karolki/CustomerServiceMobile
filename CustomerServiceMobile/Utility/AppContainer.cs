using Autofac;
using CustomerServiceMobile.Contracts.Data;
using CustomerServiceMobile.Contracts.Other;
using CustomerServiceMobile.Services.Data;
using CustomerServiceMobile.Services.Other;
using CustomerServiceMobile.ViewModels;
using CustomerServiceMobile.ViewModels.Base;
using System;

namespace CustomerServiceMobile.Utility
{
    public class AppContainer
    {
        private static IContainer _container;

        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();

            //XamarinDependency
            Xamarin.Forms.DependencyService.Register<IPhoneService>();
            Xamarin.Forms.DependencyService.Register<IToastService>();
            //ViewModels
            builder.RegisterType<ViewModelBase>().SingleInstance();
            builder.RegisterType<CustomerDetailsViewModel>().SingleInstance();
            builder.RegisterType<CustomerListViewModel>().SingleInstance();

            //Services
            //Data
            builder.RegisterType<GenericRepository>().As<IGenericRepository>();
            builder.RegisterType<CustomerDataService>().As<ICustomerDataService>();
            //Other
            builder.RegisterType<ExitingService>().As<IExitingService>();
            builder.RegisterType<MessagingService>().As<IMessagingService>();
            builder.RegisterType<NavigationService>().As<INavigationService>();
            builder.RegisterInstance(Xamarin.Forms.DependencyService.Get<IPhoneService>());
            builder.RegisterInstance(Xamarin.Forms.DependencyService.Get<IToastService>());
            _container = builder.Build();
        }

        public static object Resolve(Type typeName)
        {
            return _container.Resolve(typeName);
        }

        public static T Resolve<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
