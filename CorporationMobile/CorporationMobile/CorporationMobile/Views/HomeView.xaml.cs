using CorporationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorporationMobile.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HomeView : ContentPage
    {
        private HomeViewModel _vm;
        public HomeView()
        {
            InitializeComponent();
            _vm = new HomeViewModel(this);
            BindingContext = _vm;
        }


        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
    }
}