using CorporationMobile.Models;
using CorporationMobile.Service.Api;
using CorporationMobile.Views.Corporation;
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
    public class CorporationDetailViewModel : INotifyPropertyChanged
    {

        private int _id;
        private string _uf;
        private string _nameFantasy;
        private string _cnpj;
        private CorporationDetailView _pageCorporationDetail;
        private IToastNotificator _notificator;
        private CorporationApi _corporationApi;
        private List<string> _states;
        private int _indexUF;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public int IndexUF
        {
            get { return _indexUF; }
            set
            {
                _indexUF = value;
                OnPropertyChanged();
            }
        }


        public List<string> States
        {
            get { return _states; }
            set
            {
                _states = value;
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

        public CorporationDetailViewModel(CorporationDetailView page)
        {
            _pageCorporationDetail = page;
            _notificator = DependencyService.Get<IToastNotificator>();
        }

        public CorporationDetailViewModel(CorporationDetailView page, Corporation corporation)
        {
            _pageCorporationDetail = page;
            _notificator = DependencyService.Get<IToastNotificator>();
            ID = corporation.ID;
            CNPJ = corporation.CNPJ;
            NameFantasy = corporation.NameFantasy;
            UF = corporation.UF;
        }

        public ICommand SaveCorporationCommand => new Command(SaveCorporation);

        public async void SaveCorporation()
        {
            try
            {
                UF = States[IndexUF];
                Corporation corporation = new Corporation();
                corporation.CNPJ = CNPJ;
                corporation.NameFantasy = NameFantasy;
                corporation.UF = UF;
                corporation.ID = ID;
                if (ID > 0)
                {
                    bool status = await _corporationApi.Update(corporation.ID, corporation);
                    if (status)
                    {
                        await _notificator.Notify(ToastNotificationType.Success, ":)", "Empresa atualizada com sucesso", TimeSpan.FromSeconds(3));
                        await _pageCorporationDetail.Navigation.PopAsync();
                    }
                    else
                    {
                        await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Por favor tente novamente", TimeSpan.FromSeconds(3));
                    }
                }
                else
                {
                    bool status = await _corporationApi.Save(corporation);
                    if (status)
                    {
                        await _notificator.Notify(ToastNotificationType.Success, ":)", "Empresa cadastrada com sucesso", TimeSpan.FromSeconds(3));
                        await _pageCorporationDetail.Navigation.PopAsync();
                    }
                    else
                    {
                        await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Por favor tente novamente", TimeSpan.FromSeconds(3));
                    }
                }
            }
            catch (Exception)
            {
                await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Por favor tente criar novamente.", TimeSpan.FromSeconds(3));
            }
        }

        public async Task LoadAsync()
        {
            try
            {
                if (_corporationApi == null)
                    _corporationApi = new CorporationApi();
                States = Corporation.States();
                IndexUF = States.FindIndex(a => a == UF);
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
