using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using TemplateMvvmLight.AppResources.Localization;
using TemplateMvvmLight.Constants;
using TemplateMvvmLight.IServices;
using TemplateMvvmLight.IViewModels;
using TemplateMvvmLight.Models;
using TemplateMvvmLight.Views;
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
                if (_isAccessing)
                {
                    this._iUserDialogsServices.ShowLoading("Autenticazione in corso");
                }
                else
                {
                    this._iUserDialogsServices.HideLoading();
                }
                OnPropertyChanged(nameof(IsAccessing));
            }
        }

        public ICommand AccessCommand { get; set; }
        public ICommand CheckIsLoggedCommand { get; set; }

        [Preserve]
        public LoginViewModel(INavigationService _iNavigationService,
            IConnectivityServices _connectivityServices, 
            IAuthenticationServices _authenticationServices,
            IUserDialogsServices _userDialogsServices,
            IStorageServices _storageServices
            )
        {
            this._iNavigationService = _iNavigationService;
            this._iConnectivityServices = _connectivityServices;
            this._iAuthenticationServices = _authenticationServices;
            this._iUserDialogsServices = _userDialogsServices;
            this._iStorageServices = _storageServices;

            CanSubmit = false;
            IsAccessing = false;
            AccessCommand = new Command(Access);
            CheckIsLoggedCommand = new Command(CheckIsLogged);
        }

        /// <summary>
        /// Controlla se è già presente un utente autenticato, in quel caso, verrà reindirizzato alla pagina di home
        /// </summary>
        private void CheckIsLogged()
        {
            User user = this._iStorageServices.GetObject<User>(StorageKey.USER_AUTHENTICATED);
            if (user != null)
            {
                NavigationPage home = new NavigationPage(new HomeView());
                Application.Current.MainPage = home;
            }
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
                this._iUserDialogsServices.ShowToast(Resources.ERROR_NO_CONNECTIVITY, ToastType.ERROR);
                return;
            }

            // Login
            var loginResponse = await this._iAuthenticationServices.Login(Login, Password);
            if (loginResponse.Error != null)
            {
                IsAccessing = false;
                string errorMessage = loginResponse.Error == ErrorResponse.AUTHENTICATION_FAILED ? Resources.ERROR_BAD_CREDENTIALS : Resources.ERROR_GENERIC;
                this._iUserDialogsServices.ShowToast(errorMessage, ToastType.ERROR);
                return;
            }

            User userAuthenticated = loginResponse.Result;
            this._iUserDialogsServices.ShowToast("Buon giorno " + userAuthenticated.Username, ToastType.SUCCESS);

            await this._iStorageServices.SetObject(StorageKey.USER_AUTHENTICATED, userAuthenticated);

            IsAccessing = false;
        }
    }
}
