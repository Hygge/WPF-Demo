using loginPage.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using loginPage.View;

namespace loginPage.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private string _userName = "admin";
        private SecureString _password;
        private string _errorMessage;
        private bool _isViewVisible = true;

        public string UserName { get => _userName; set { _userName = value; OnPropertyChanged(nameof(UserName)); }  }
        public SecureString Password { get => _password; set { _password = value; OnPropertyChanged(nameof(Password)); } }
        public string ErrorMessage { get => _errorMessage; set { _errorMessage = value; OnPropertyChanged(nameof(ErrorMessage)); } }
        public bool IsViewVisible { get => _isViewVisible; set { _isViewVisible = value; OnPropertyChanged(nameof(IsViewVisible)); } }
        public ICommand LoginCommand { get; }
        public ICommand RecoverPasswordCommand { get; }
        public ICommand ShowPasswordCommand { get; }

        public event Action CloseWindow;

        public IUserRepository repository = App.services.GetRequiredService<IUserRepository>();
        public ILogger<LoginViewModel> logger = App.services.GetRequiredService<ILogger<LoginViewModel>>();
        
        

        public LoginViewModel(Action action)
        {
            CloseWindow += action;
            LoginCommand = new ViewModelCommand(LoginExecute, LoginCanExecute);
            RecoverPasswordCommand = new ViewModelCommand(p => RecoverPasswordExecute("", ""));
        }

        private void RecoverPasswordExecute(string username, string email)
        {
            throw new NotImplementedException();
        }

        private bool LoginCanExecute(object obj)
        {
            try
            {
                bool validData;
                if (string.IsNullOrEmpty(UserName) ) //|| Password == null || Password.Length < 3)
                    validData = false;
                else
                    validData = true;
                return validData;
            }
            catch(Exception ex)
            {
                logger.LogError(ex.Message);
                return false;
            }
           
        }

        private async void LoginExecute(object obj)
        {
            bool b = await repository.AuthenticateUser(new NetworkCredential(UserName,  "123456"));
            if (b)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(UserName), null);
                App.services.GetRequiredService<MainView>().Show();
                CloseWindow.Invoke();
                ErrorMessage = string.Empty;
            }
            else
                ErrorMessage = "* 用户名或密码无效 *";

        }
    }
}
