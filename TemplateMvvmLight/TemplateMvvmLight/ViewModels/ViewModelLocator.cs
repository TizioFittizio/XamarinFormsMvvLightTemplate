﻿using TemplateMvvmLight.Services;
using Xamarin.Forms.Popups;
using CommonServiceLocator;
using TemplateMvvmLight.IServices;
using GalaSoft.MvvmLight.Ioc;
using TemplateMvvmLight.IViewModels;
using Xamarin.Forms.Internals;
using Xamarin.Forms.Navigation;

namespace TemplateMvvmLight.ViewModels
{
    public class ViewModelLocator
    {
        [Preserve]
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register<IHomeViewModel, HomeViewModel>();
            SimpleIoc.Default.Register<IDetailsViewModel, DetailsViewModel>();
            SimpleIoc.Default.Register<ILoginViewModel, LoginViewModel>();

            SimpleIoc.Default.Register<IUserServices, UserServices>();
            SimpleIoc.Default.Register<IPopupsService, PopupsService>();
            SimpleIoc.Default.Register<INavigationService, NavigationService>();
            SimpleIoc.Default.Register<IConnectivityServices, ConnectivityServices>();
            SimpleIoc.Default.Register<IAuthenticationServices, AuthenticationServices>();
            SimpleIoc.Default.Register<IUserDialogsServices, UserDialogsServices>();
            SimpleIoc.Default.Register<IStorageServices, StorageServices>();
        }

        public IHomeViewModel Home
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IHomeViewModel>();
            }
        }

        public IDetailsViewModel Details
        {
            get
            {
                return ServiceLocator.Current.GetInstance<IDetailsViewModel>();
            }
        }

        public ILoginViewModel Login
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ILoginViewModel>();
            }
        }
    }
}
