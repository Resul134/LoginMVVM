using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using GalaSoft.MvvmLight.Command;
using LoginMVVM.Annotations;

namespace LoginMVVM
{
    class Viewmodel : INotifyPropertyChanged
    {
        private RelayCommand _loginCommand;
        private RelayCommand _register;
        private string _inputUsername;
        private string _inputPassword;
        private string _loginCheck;
        ObservableCollection<User> _users = new ObservableCollection<User>();
        public Viewmodel()
        {

            _users.Add(new User("Lucas", "lucas123"));
            _users.Add(new User("Resul","Resul123"));
            _users.Add(new User("Thomas", "Storpik123"));
            
            _loginCommand = new RelayCommand(checkLogin);
            _register = new RelayCommand(RegisterAccount);
            
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

        public RelayCommand Register
        {
            get { return _register; }
            set { _register = value; }
        }

    

        public void checkLogin()
        {
            foreach (var user in _users)
            {
                if (InputUsername == user.Username)
                {
                    if (InputPassword == user.Password)
                    {
                        LoginCheck = "Access granted";
                        Frame currentFrame = Window.Current.Content as Frame;
                        currentFrame.Navigate(typeof(BlankPage2));
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

        public void RegisterAccount()
        {
            Boolean isTaken = false;
            foreach (var user in _users)
            {
                if (InputUsername == user.Username)
                {
                    isTaken = true;
                    break;
                }
            }
            if (!isTaken)
            {
                _users.Add(new User(_inputUsername, _inputPassword));
                LoginCheck = "User added";
            }
            else LoginCheck = "Username is taken";
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
