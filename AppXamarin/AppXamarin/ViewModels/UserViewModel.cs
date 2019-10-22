using AppXamarin.Base;
using AppXamarin.Models;
using AppXamarin.Services;
using AppXamarin.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AppXamarin.ViewModels
{
    public class UserViewModel:ViewModelBase
    {
        public UserViewModel()
        {
            if (User == null)
            {
                User = new User();
            }

            if (App.Locator.SessionService.Session.User != null)
            {
                this.User = App.Locator.SessionService.Session.User;
            }
            
        }
        private User _User;

        public User User
        {
            get { return this._User; }
            set
            {
                this._User = value;
                OnPropertyChanged("User");
            }
        }

        public Command Login
        {
            get
            {
                return new Command(() => {

                    SessionService session = App.Locator.SessionService;
                    session.Session.User = User;
                    MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "INIT");
                });
            }
        }

        public Command Logout
        {
            get
            {
                return new Command(() => {
                    App.Locator.SessionService.Session = new Session();
                    MessagingCenter.Send<PrincipalMaster>(App.Locator.PrincipalMaster, "INIT");
                });
            }
        }
    }
}
