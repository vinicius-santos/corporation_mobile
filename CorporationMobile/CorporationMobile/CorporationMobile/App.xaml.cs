using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CorporationMobile.Services;
using CorporationMobile.Views;
using Plugin.Toasts;
using System.Diagnostics;
using CorporationMobile.Service.Api;

namespace CorporationMobile
{
    public partial class App : Application
    {
        public static IToastNotificator Notificator;
        public App()
        {
            InitializeComponent();
            Notificator = DependencyService.Get<IToastNotificator>();
            DependencyService.Register<CorporationApi, CorporationApi>();
            MainPage = new MainPage();
        }
         
        public static void ShowToast(ToastNotificationType toastNotificationType, string title, string message, int? seconds = null)
        {
            try
            {
                Notificator.Notify(toastNotificationType, title, message, seconds != null ? TimeSpan.FromSeconds((int)seconds) : TimeSpan.FromSeconds(3));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
