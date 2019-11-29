using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CorporationMobile.Models;
using CorporationMobile.Service.Api;
using CorporationMobile.Views.Provider;
using Plugin.Toasts;
using Xamarin.Forms;
using static CorporationMobile.Helpers.Annotations;

namespace CorporationMobile.ViewModels
{
    public class ProviderDetailViewModel
    {
        private ProviderDetailView _providerDetailView;
        private List<Corporation> _corporations;
        private Provider item;
        private int _id;
        private string _cpf;
        private string _rg;
        private string _name;
        private string _cnpj;
        private Nullable<DateTime> _birthDate;
        private DateTime _dateRegister;
        private DateTime _hourRegister;
        private string _phone;
        private Corporation _corporation;
        private IToastNotificator _notificator;
        private ProviderApi _providerApi;
        private int _indexCorporation;
        private bool _isPerson;
        private bool _isCorporation;


        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }



        public bool IsPerson
        {
            get { return _isPerson; }
            set
            {
                _isPerson = value;
                OnPropertyChanged();
            }
        }

        public bool IsCorporation
        {
            get { return _isCorporation; }
            set
            {
                _isCorporation = value;
                OnPropertyChanged();
            }
        }

        public int IndexCorporation
        {
            get { return _indexCorporation; }
            set
            {
                _indexCorporation = value;
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

        public Corporation Corporation
        {
            get { return _corporation; }
            set
            {
                _corporation = value;
                OnPropertyChanged();
            }
        }

        public string CPF
        {
            get { return _cpf; }
            set
            {
                _cpf = value;
                OnPropertyChanged();
            }
        }

        public string RG
        {
            get { return _rg; }
            set
            {
                _rg = value;
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

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged();
            }
        }

        public Nullable<DateTime> BirthDate
        {
            get { return _birthDate; }
            set
            {
                _birthDate = value;
                OnPropertyChanged();
            }
        }

        public DateTime DateRegister
        {
            get { return _dateRegister; }
            set
            {
                _dateRegister = value;
                OnPropertyChanged();
            }
        }

        public DateTime HourRegister
        {
            get { return _hourRegister; }
            set
            {
                _hourRegister = value;
                OnPropertyChanged();
            }
        }


        public ProviderDetailViewModel(ProviderDetailView providerDetailView, List<Corporation> corporations, string type)
        {
            _notificator = DependencyService.Get<IToastNotificator>();
            _providerDetailView = providerDetailView;
            _corporations = corporations;
            if (type == "Person")
            {
                IsPerson = true;
                IsCorporation = false;
            }
            else
            {
                IsPerson = false;
                IsCorporation = true;
            }
        }

        public ProviderDetailViewModel(ProviderDetailView providerDetailView, List<Corporation> corporations, Provider provider)
        {
            _notificator = DependencyService.Get<IToastNotificator>();
            _providerDetailView = providerDetailView;
            _corporations = corporations;

            ID = provider.ID;
            BirthDate = provider.BirthDate;
            CNPJ = provider.CNPJ;
            Corporation = provider.Corporation;
            CPF = provider.CPF;
            DateRegister = provider.DateRegister;
            HourRegister = provider.HourRegister;
            Name = provider.Name;
            Phone = provider.Phone;
            RG = provider.RG;

            if (String.IsNullOrEmpty(CNPJ))
            {
                IsCorporation = false;
                IsPerson = true;
            }
            else
            {
                IsCorporation = true;
                IsPerson = false;
            }
        }

        public void SetVisibleElements()
        {

            if (!IsPerson)
            {
                RG = null;
                BirthDate = null;
                CPF = null;
                IsCorporation = true;
            }
            else
            {
                IsCorporation = false;
                CNPJ = null;
            }
        }

        public int CalcAge()
        {
            try
            {
                int years = DateTime.Now.Year - BirthDate.Value.Year;
                if (DateTime.Now.Month < BirthDate.Value.Month || (DateTime.Now.Month == BirthDate.Value.Month && DateTime.Now.Day < BirthDate.Value.Day))
                    years--;
                return years;
            }
            catch (Exception)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Por favor tente novamente e confira se inseriu todos os campos", TimeSpan.FromSeconds(3));
                });
                return -1;
            }
        }

        public ICommand SaveProviderCommand => new Command(SaveProvider);

        public async void SaveProvider()
        {
            try
            {
                if (IsPerson && !BirthDate.HasValue)
                {
                    await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Insira a sua idade para prosseguir", TimeSpan.FromSeconds(3));
                    return;
                }
                Provider provider = new Provider();
                provider.ID = ID;
                provider.BirthDate = BirthDate.Value;
                provider.CNPJ = CNPJ;
                provider.Corporation = Corporations[IndexCorporation];
                provider.CPF = CPF;
                provider.DateRegister = DateTime.Now;
                provider.HourRegister = DateTime.Now;
                provider.Name = Name;
                provider.Phone = Phone;
                provider.RG = RG;
                if(provider.Corporation == null)
                {
                    await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Não existe uma empresa associada.", TimeSpan.FromSeconds(3));
                    return;
                }
                if (provider.Corporation.UF == "PR")
                {
                    int res = CalcAge();
                    if (res < 18 || res <= -1)
                    {
                        await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Este estado não permite menores de idade", TimeSpan.FromSeconds(3));
                        return;
                    }
                }
                if (ID > 0)
                {
                    bool status = await _providerApi.Update(provider.ID, provider);
                    if (status)
                    {
                        await _notificator.Notify(ToastNotificationType.Success, ":)", "Fornecedor atualizado com sucesso", TimeSpan.FromSeconds(3));
                        await _providerDetailView.Navigation.PopAsync();
                    }
                    else
                    {
                        await _notificator.Notify(ToastNotificationType.Error, ":(", "Ops! Não foi possível salvar. Por favor tente novamente", TimeSpan.FromSeconds(3));
                    }
                }
                else
                {
                    bool status = await _providerApi.Save(provider);
                    if (status)
                    {
                        await _notificator.Notify(ToastNotificationType.Success, ":)", "Fornecedor cadastrado com sucesso", TimeSpan.FromSeconds(3));
                        await _providerDetailView.Navigation.PopAsync();
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
                if (_providerApi == null)
                    _providerApi = new ProviderApi();

                IndexCorporation = Corporations.FindIndex(a => a == Corporation);
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
