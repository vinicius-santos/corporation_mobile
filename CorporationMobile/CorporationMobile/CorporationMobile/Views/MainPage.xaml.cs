using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using CorporationMobile.Models;
using CorporationMobile.Views.Corporation;
using CorporationMobile.Views.Provider;

namespace CorporationMobile.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();
            MasterBehavior = MasterBehavior.Popover;
            MenuPages.Add((int)MenuItemType.Browse, (NavigationPage)Detail);
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.Home:
                        MenuPages.Add(id, new NavigationPage(new HomeView()));
                        break;
                    case (int)MenuItemType.Corporation:
                        MenuPages.Add(id, new NavigationPage(new CorporationView()));
                        break;
                    case (int)MenuItemType.Provider:
                        MenuPages.Add(id, new NavigationPage(new ProviderView()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(50);

                IsPresented = false;
            }
        }
    }
}