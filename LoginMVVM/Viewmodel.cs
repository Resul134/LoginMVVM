using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Command;
using LoginMVVM.Annotations;

namespace LoginMVVM
{
    class Viewmodel : INotifyPropertyChanged
    {
        private RelayCommand _loginCommand;
        private string _inputUsername;
        private string _inputPassword;
        private string _loginCheck;
        ObservableCollection<User> users = new ObservableCollection<User>();

        public Viewmodel()
        {

            users.Add(new User("Lucas", "lucas123"));
            users.Add(new User("Resul","Resul123"));

            _loginCommand = new RelayCommand(checkLogin);

        }


        public RelayCommand LoginCommand
        {
            get { return _loginCommand; }
            set
            {
                _loginCommand = value;
                OnPropertyChanged();
                
            }
        }

        public string InputPassword
        {
            get { return _inputPassword; }
            set { _inputPassword = value; }
        }

        public string InputUsername
        {
            get { return _inputUsername; }
            set { _inputUsername = value; }
        }

        public string LoginCheck
        {
            get { return _loginCheck; }
            set
            {
                _loginCheck = value;
                OnPropertyChanged();
            }
        }

        public void checkLogin()
        {
            foreach (var user in users)
            {
                if (InputUsername == user.Username)
                {
                    if (InputPassword == user.Password)
                    {
                        LoginCheck = "Access granted";
                        break;
                    }

                    else
                    {
                        LoginCheck = "Wrong password";
                        break;
                    }

                    
                    
                }
                else LoginCheck = "Access denied";
                
            }
        }

        #region MyRegion

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}
