using TemplateMvvmLight.Models;
using Xamarin.Forms.Popups;
using System.ComponentModel;
using TemplateMvvmLight.IServices;
using Xamarin.Forms.Navigation;
using System.Runtime.CompilerServices;

namespace TemplateMvvmLight.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        protected IUserServices _iUserServices;
        protected IPopupsService _iPopupsService;
        protected INavigationService _iNavigationService;
        protected IConnectivityServices _iConnectivityServices;
        protected IAuthenticationServices _iAuthenticationServices;
        protected IUserDialogsServices _iUserDialogsServices;
        protected IStorageServices _iStorageServices;

        private User _user;
        public User User
        {
            get { return _user; }
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
