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
            Init();
        }


        //OnApering not called in first time bug..
        private async void Init()
        {
            await _vm.LoadAsync();
        }


        protected override async  void OnAppearing()
        {
            await _vm.LoadAsync();
            base.OnAppearing();
        }
    }
}