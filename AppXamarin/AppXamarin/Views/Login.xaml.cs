using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
		public Login ()
		{
            InitializeComponent();
            MessagingCenter.Subscribe<Login>(this, "LOGINFAIL",(sender) => {
                this.error.Text = "Usuario/Password incorrecto";
                this.error.TextColor = Color.Red;
            });
        }
	}
}