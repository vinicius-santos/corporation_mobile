using CorporationMobile.Views;
using CorporationMobile.Views.Corporation;
using CorporationMobile.Views.Provider;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static CorporationMobile.Helpers.Annotations;

namespace CorporationMobile.ViewModels
{
    public class HomeViewModel : INotifyPropertyChanged
    {
        private string _imageCorporation;
        private string _imageProvider;
        private HomeView _pageHome;
        private IToastNotificator _notificator;



        public string ImageCorporation
        {
            get { return _imageCorporation; }
            set
            {
                _imageCorporation = value;
                OnPropertyChanged();
            }
        }


        public string ImageProvider
        {
            get { return _imageProvider; }
            set
            {
                _imageProvider = value;
                OnPropertyChanged();
            }
        }



        public ICommand OpenCorporationCommand => new Command(OpenCorporation);

        public async void OpenCorporation()
        {
            try
            {
                await _pageHome.Navigation.PushAsync(new CorporationView());
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente abrir novamente.", TimeSpan.FromSeconds(3));
            }
        }

        public ICommand OpenProviderCommand => new Command(OpenProvider);

        public async void OpenProvider()
        {
            try
            {
                await _pageHome.Navigation.PushAsync(new ProviderView());
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente abrir novamente.", TimeSpan.FromSeconds(3));
            }
        }


        public HomeViewModel(HomeView page)
        {
            _pageHome = page;
            _notificator = DependencyService.Get<IToastNotificator>();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
