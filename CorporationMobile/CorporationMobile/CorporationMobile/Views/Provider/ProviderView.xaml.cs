using CorporationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorporationMobile.Views.Provider
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProviderView : ContentPage
    {
        private ProviderViewModel _vm;

        public ProviderView()
        {
            InitializeComponent();
            _vm = new ProviderViewModel(this);
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


        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var provider = args.Item as Models.Provider;
            list.SelectedItem = null;
            if (provider != null)
            {
                _vm.EditProvider(provider);
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = _vm.Providers;
            }

            else
            {
                if (_vm.Providers != null && _vm.Providers.Count > 0)
                {
                    list.ItemsSource = _vm.Providers.Where(x => x.Name.ToUpper().StartsWith(e.NewTextValue.ToUpper()));
                }
            }
        }
        private void SearchBar_CPFCNPJChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = _vm.Providers;
            }

            else
            {
                if (_vm.Providers != null && _vm.Providers.Count > 0)
                {
                    list.ItemsSource = _vm.Providers.Where(x => x.CPF != null && x.CPF.StartsWith(e.NewTextValue.ToUpper()) || x.CNPJ != null && x.CNPJ.StartsWith(e.NewTextValue.ToUpper()));
                }
            }
        }

        private void SearchBar_DataChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                list.ItemsSource = _vm.Providers;
            }

            else
            {
                if (_vm.Providers != null && _vm.Providers.Count > 0)
                {
                    list.ItemsSource = _vm.Providers.Where(x => x.DateRegister.ToShortDateString().StartsWith(e.NewTextValue));
                }
            }
        }
    }
}