using System;
using System.Collections.Generic;
using System.Text;
using TemplateMvvmLight.Constants;

namespace TemplateMvvmLight.IServices
{
    public interface IUserDialogsServices
    {

        void ShowToast(string text, ToastType toastType = ToastType.NORMAL, int duration = 3000);
    }
}
