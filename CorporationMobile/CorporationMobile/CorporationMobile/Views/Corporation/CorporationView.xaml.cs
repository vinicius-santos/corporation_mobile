﻿using CorporationMobile.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CorporationMobile.Views.Corporation
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CorporationView : ContentPage
    {
        private CorporationViewModel _vm;
        public CorporationView()
        {
            InitializeComponent();
            _vm = new CorporationViewModel(this);
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