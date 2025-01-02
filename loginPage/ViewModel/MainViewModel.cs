using loginPage.Model;
using loginPage.ViewModel;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;
using loginPage.UserControls;

namespace loginPage.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private FrameworkElement _mainUserControl;

        public FrameworkElement MainUserControl
        {
            get
            {
                return _mainUserControl;
            }
            set
            {
                _mainUserControl = value;
                OnPropertyChanged(nameof(MainUserControl));
            }
        }
        
        private UserAccountModel _currentUserAccount;

        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set { _currentUserAccount = value; OnPropertyChanged(nameof(CurrentUserAccount)); }

        }
        public IUserRepository userRepository = App.services.GetRequiredService<IUserRepository>();

        public MainViewModel()
        {
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
            MainUserControl = App.services.GetRequiredService<HomeUC>();
        }

        private void LoadCurrentUserData()
        {
            var user =  userRepository.GetByName(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                CurrentUserAccount.UserName = user.userName;
                CurrentUserAccount.DisplayName = $"Welcome {user.userName} {user.lastName}";
                CurrentUserAccount.ProfilePicture = null;
             
            }
            else
            {
                MessageBox.Show("无效用户");
            }
        }
    }
}
