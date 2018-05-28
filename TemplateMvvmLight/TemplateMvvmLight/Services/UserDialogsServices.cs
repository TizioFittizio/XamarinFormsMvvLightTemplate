using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Text;
using TemplateMvvmLight.Constants;
using TemplateMvvmLight.IServices;

namespace TemplateMvvmLight.Services
{
    class UserDialogsServices : IUserDialogsServices
    {
        public void ShowToast(string text, ToastType toastType = ToastType.NORMAL, int duration = 3000)
        {
            var toastConfig = new ToastConfig(text);
            toastConfig.SetDuration(duration);
            switch (toastType)
            {
                case ToastType.SUCCESS:
                    toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(75, 181, 67));
                    break;
                case ToastType.ERROR:
                    toastConfig.SetBackgroundColor(System.Drawing.Color.FromArgb(255, 0, 51));
                    break;
            }
            UserDialogs.Instance.Toast(toastConfig);
        }
    }
}
