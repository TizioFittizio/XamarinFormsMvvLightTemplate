using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TemplateMvvmLight.IViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Navigation;
using Xamarin.Forms.Popups;

namespace TemplateMvvmLight.ViewModels
{
    public class LoginViewModel : BaseViewModel, ILoginViewModel
    {
        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                UpdateCanSubmit();
                OnPropertyChanged(nameof(Login));
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                UpdateCanSubmit();
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _canSubmit;
        public bool CanSubmit
        {
            get { return _canSubmit; }
            set
            {
                _canSubmit = value;
                OnPropertyChanged(nameof(CanSubmit));
            }
        }

        private bool _isAccessing;
        public bool IsAccessing
        {
            get { return _isAccessing; }
            set
            {
                _isAccessing = value;
                OnPropertyChanged(nameof(IsAccessing));
            }
        }

        public ICommand AccessCommand { get; set; }

        public LoginViewModel(INavigationService _iNavigationService, IPopupsService _iPopupsService)
        {
            this._iNavigationService = _iNavigationService;
            this._iPopupsService = _iPopupsService;
            CanSubmit = false;
            IsAccessing = false;
            AccessCommand = new Command(Access);
        }

        /// <summary>
        /// Abilita(disabilita il pulsante per il submit in base alle credenziali inserite
        /// </summary>
        private void UpdateCanSubmit()
        {
            CanSubmit = !String.IsNullOrEmpty(this.Login) && !String.IsNullOrEmpty(this.Password);
        }

        /// <summary>
        /// Prova ad effettuare l'accesso con le credenziali date
        /// </summary>
        private async void Access()
        {
            IsAccessing = true;
            // await this._iPopupsService.DisplayAlert("Attenzione!", "Occhio!", "Ok!");
        }
    }
}
