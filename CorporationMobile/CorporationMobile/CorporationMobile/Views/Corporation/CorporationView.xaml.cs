using CorporationMobile.ViewModels;
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
            Init();
        }


        //OnApering not called in first time bug..
        private async void Init()
        {
            await _vm.LoadAsync();
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


        public void OnItemSelected(object sender, ItemTappedEventArgs args)
        {
            var corporation = args.Item as Models.Corporation;
            list.SelectedItem = null;
            if (corporation != null)
            {
                _vm.EditCorporation(corporation);
            }
        }
    }
}