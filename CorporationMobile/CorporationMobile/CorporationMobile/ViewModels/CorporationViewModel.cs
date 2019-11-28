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

        private string _name;
        public int _id;
        public string _uf;
        public string _nameFantasy;
        public string _cnpj;
        private IToastNotificator _notificator;
        private CorporationApi _corporationApi;
        public List<Corporation> _corporations;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public string UF
        {
            get { return _uf; }
            set
            {
                _uf = value;
                OnPropertyChanged();
            }
        }

        public string NameFantasy
        {
            get { return _nameFantasy; }
            set
            {
                _nameFantasy = value;
                OnPropertyChanged();
            }
        }

        public string CNPJ
        {
            get { return _cnpj; }
            set
            {
                _cnpj = value;
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


        public CorporationViewModel(CorporationView page)
        {
            _pageCorporation = page;
            _notificator = DependencyService.Get<IToastNotificator>();
        }

        public async Task LoadAsync()
        {
            try
            {
                //IsBusy = true;
                if (_corporationApi == null)
                    _corporationApi = new CorporationApi();


                //var _vouchersFromApi = await _voucherApi.GetByArticleAsync(App.Instance.CurrentUser.Id, _currentArticle.Id);
                //IsBusy = false;
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
