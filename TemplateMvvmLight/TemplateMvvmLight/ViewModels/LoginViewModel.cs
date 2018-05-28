using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TemplateMvvmLight.AppResources.Localization;
using TemplateMvvmLight.Constants;
using TemplateMvvmLight.IServices;
using TemplateMvvmLight.IViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Internals;
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

        [Preserve]
        public LoginViewModel(INavigationService _iNavigationService, IPopupsService _iPopupsService, IConnectivityServices _connectivityServices, IAuthenticationServices _authenticationServices)
        {
            this._iNavigationService = _iNavigationService;
            this._iPopupsService = _iPopupsService;
            this._iConnectivityServices = _connectivityServices;
            this._iAuthenticationServices = _authenticationServices;
            CanSubmit = false;
            IsAccessing = false;
            AccessCommand = new Command(Access);
        }

        /// <summary>
        /// Abilita/disabilita il pulsante per il submit in base alle credenziali inserite
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

            // Controllo della connessione
            if (!this._iConnectivityServices.HasWebConnection())
            {
                IsAccessing = false;
                await this._iPopupsService.DisplayAlert(Resources.ERROR_TITLE_NETWORK, Resources.ERROR_NO_CONNECTIVITY, "Ok");
                return;
            }

            // Login
            var loginResponse = await this._iAuthenticationServices.Login(Login, Password);
            if (loginResponse.Error != null)
            {
                IsAccessing = false;
                string errorMessage = loginResponse.Error == ErrorResponse.AUTHENTICATION_FAILED ? Resources.ERROR_BAD_CREDENTIALS : Resources.ERROR_GENERIC;
                await this._iPopupsService.DisplayAlert(Resources.ERROR_TITLE_AUTHENTICATION, errorMessage, "Ok");
            }
        }
    }
}
