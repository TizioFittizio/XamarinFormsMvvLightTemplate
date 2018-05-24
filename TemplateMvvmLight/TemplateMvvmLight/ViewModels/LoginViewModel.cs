using System;
using System.Collections.Generic;
using System.Text;
using TemplateMvvmLight.IViewModels;
using Xamarin.Forms.Navigation;

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

        public LoginViewModel(INavigationService _iNavigationService)
        {
            this._iNavigationService = _iNavigationService;
            this.CanSubmit = false;
        }

        private void UpdateCanSubmit()
        {
            CanSubmit = !String.IsNullOrEmpty(this.Login) && !String.IsNullOrEmpty(this.Password);
        }
    }
}
