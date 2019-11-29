using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporationMobile.Models;
using CorporationMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorporationMobile.Views.Provider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProviderDetailView : ContentPage
    {
        private Models.Provider item;
        private List<Models.Corporation> corporations;
        private ProviderDetailViewModel _vm;
        public event EventHandler<SelectedItemChangedEventArgs> SelectedOrToggled;

        public ProviderDetailView(List<Models.Corporation> corporations, string type)
        {

            InitializeComponent();
            _vm = new ProviderDetailViewModel(this, corporations, type);
            BindingContext = _vm;

            Init();

        }

        public ProviderDetailView(Models.Provider item, List<Models.Corporation> corporations)
        {
            InitializeComponent();
            this.item = item;
            this.corporations = corporations;
            _vm = new ProviderDetailViewModel(this, corporations, item);
            BindingContext = _vm;
            Init();
        }


        //OnApering not called in first time bug..
        private async void Init()
        {
            await _vm.LoadAsync();
        }

        protected override async void OnAppearing()
        {
            await _vm.LoadAsync();
            base.OnAppearing();
        }
    }
}