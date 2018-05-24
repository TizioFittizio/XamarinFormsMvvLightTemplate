/// Mohamed Ali NOUIRA
/// http://www.sweetmit.com
/// http://www.mohamedalinouira.com
/// https://github.com/medalinouira
/// Copyright © Mohamed Ali NOUIRA. All rights reserved.

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
