using CorporationMobile.Models;
using CorporationMobile.Service.Api;
using CorporationMobile.Views.Provider;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static CorporationMobile.Helpers.Annotations;

namespace CorporationMobile.ViewModels
{
    public class ProviderViewModel : INotifyPropertyChanged
    {

        private ProviderView _pageProvider;
        private IToastNotificator _notificator;
        private CorporationApi _corporationApi;
        private ProviderApi _providerApi;
        private List<Corporation> _corporations;
        private List<Provider> _providers;


        public List<Provider> Providers
        {
            get { return _providers; }
            set
            {
                _providers = value;
                OnPropertyChanged();
            }
        }


        public List<Corporation> Corporations
        {
            get { return _corporations; }
            set
            {
                _corporations = value;
                OnPropertyChanged();
            }
        }







        public async void EditProvider(Provider item)
        {
            try
            {
                await _pageProvider.Navigation.PushAsync(new ProviderDetailView(item, Corporations));
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente editar novamente.", TimeSpan.FromSeconds(3));
            }
        }

        public ICommand ButtonClickCommand { get; private set; }

        public ProviderViewModel(ProviderView page)
        {
            _pageProvider = page;
            _notificator = DependencyService.Get<IToastNotificator>();
            ButtonCommand();
        }

        public  async void ButtonCommand()
        {
            ButtonClickCommand = new Command(
             async (parameter) =>
             {
                 if (parameter == "Person")
                 {
                     try
                     {
                         await _pageProvider.Navigation.PushAsync(new ProviderDetailView(Corporations, parameter.ToString()));
                     }
                     catch (Exception)
                     {
                         await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente criar novamente.", TimeSpan.FromSeconds(3));
                     }
                 }
                 else if (parameter == "Legal")
                 {
                     try
                     {
                         await _pageProvider.Navigation.PushAsync(new ProviderDetailView(Corporations, parameter.ToString()));
                     }
                     catch (Exception)
                     {
                         await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente criar novamente.", TimeSpan.FromSeconds(3));
                     }
                 }
             });
        }

        public async Task LoadAsync()
        {
            try
            {
                if (_corporationApi == null)
                    _corporationApi = new CorporationApi();

                if (_providerApi == null)
                    _providerApi = new ProviderApi();



                Corporations = await _corporationApi.GetAll();
                Providers = await _providerApi.GetAll();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
