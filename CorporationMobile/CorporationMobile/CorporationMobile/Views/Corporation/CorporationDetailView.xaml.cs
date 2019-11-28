using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CorporationMobile.Models;
using CorporationMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorporationMobile.Views.Corporation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorporationDetailView : ContentPage
    {
        private CorporationDetailViewModel _vm;
        public CorporationDetailView()
        {
            InitializeComponent();
            _vm = new CorporationDetailViewModel(this);
            BindingContext = _vm;
        }

        public CorporationDetailView(Models.Corporation corporation)
        {
            InitializeComponent();
            _vm = new CorporationDetailViewModel(this, corporation);
            BindingContext = _vm;
        }

        protected override async void OnAppearing()
        {
            try
            {
                await _vm.LoadAsync();
            }
            catch (System.Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                base.OnAppearing();
            }
        }
    }
}