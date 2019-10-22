using AppXamarin.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppXamarin.Services
{
    public class SessionService
    {
        public Session Session { get; set; }

        public SessionService()
        {
            this.Session = new Session();
        }
    }
}
