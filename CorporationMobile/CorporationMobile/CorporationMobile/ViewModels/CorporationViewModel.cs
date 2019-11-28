using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CorporationMobile.Views.Corporation;
using Xamarin.Forms;
using System.Windows.Input;
using static CorporationMobile.Helpers.Annotations;
using Plugin.Toasts;
using CorporationMobile.Service.Api;
using CorporationMobile.Models;
using System.Diagnostics;

namespace CorporationMobile.ViewModels
{
    public class CorporationViewModel : INotifyPropertyChanged
    {
        private CorporationView _pageCorporation;
        private IToastNotificator _notificator;
        private CorporationApi _corporationApi;
        private List<Corporation> _corporations;


        public List<Corporation> Corporations
        {
            get { return _corporations; }
            set
            {
                _corporations = value;
                OnPropertyChanged();
            }
        }


        public CorporationViewModel(CorporationView page)
        {
            _pageCorporation = page;
            _notificator = DependencyService.Get<IToastNotificator>();
        }


        public ICommand NewCorporationCommand => new Command(NewCorporation);

        public async void NewCorporation()
        {
            try
            {
                await _pageCorporation.Navigation.PushAsync(new CorporationDetailView());
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(","Ops! Por favor tente criar novamente.", TimeSpan.FromSeconds(3));
            }
        }

        public async void EditCorporation(Corporation item)
        {
            try
            {
                await _pageCorporation.Navigation.PushAsync(new CorporationDetailView(item));
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente editar novamente.", TimeSpan.FromSeconds(3));
            }
        }

        public async Task LoadAsync()
        {
            try
            {
                if (_corporationApi == null)
                    _corporationApi = new CorporationApi();


                Corporations = await _corporationApi.GetAll();
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
