using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TemplateMvvmLight.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TemplateMvvmLight.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginView : ContentPage
	{
		public LoginView ()
		{
			InitializeComponent ();
		}

        private async void Login_Completed(object sender, EventArgs e)
        {
            await Task.Delay(100);
            PasswordEntry.Focus();
        }

        protected override void OnAppearing()
        {
            var viewModel = (LoginViewModel) this.BindingContext;
            viewModel.CheckIsLoggedCommand.Execute(null);
        }
    }
}