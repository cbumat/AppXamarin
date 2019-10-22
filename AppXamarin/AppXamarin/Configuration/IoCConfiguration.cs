using AppXamarin.Services;
using AppXamarin.ViewModels;
using AppXamarin.Views;
using Autofac;
using System;
using System.Collections.Generic;

using System.Text;

namespace AppXamarin.Configuration
{
    public class IoCConfiguration
    {
        private IContainer container;

        public IoCConfiguration()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterType<SessionService>().SingleInstance();
            builder.RegisterType<Login>();
            builder.RegisterType<PrincipalMaster>();
            this.container = builder.Build();
        }

        public PrincipalMaster PrincipalMaster
        {
            get
            {
                return this.container.Resolve<PrincipalMaster>();
            }
        }


        public SessionService SessionService
        {
            get
            {
                return this.container.Resolve<SessionService>();
            }
        }

        public Login Login
        {
            get
            {
                return this.container.Resolve<Login>();
            }
        }
    }
}
