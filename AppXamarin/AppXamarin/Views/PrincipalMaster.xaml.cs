using System;
using System.Collections.Generic;
using AppXamarin.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PrincipalMaster : MasterDetailPage
    {
        public List<MenuItemPage> MenuPages { get; set; }
        public PrincipalMaster()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<PrincipalMaster>(this, "INIT", async (sender) => {
                PrincipalMaster view = new PrincipalMaster();
                await Application.Current.MainPage.Navigation.PushModalAsync(view);
            });

            this.MenuPages = new List<MenuItemPage>();
            
            User user = App.Locator.SessionService.Session.User;

            if(user != null)
            {
                Button btnlogout = new Button()
                {
                    Text = "Cerrar Sesión"
                };
                this.layoutLogout.Children.Add(btnlogout);
                btnlogout.SetBinding(Button.CommandProperty, "Logout");

                Label lab = new Label()
                {
                    Text = App.Locator.SessionService.Session.User.Name,
                    FontSize = 15,
                    TextColor = Color.Blue,
                    VerticalOptions = LayoutOptions.Center,
                    FontAttributes = FontAttributes.Bold
                };
                this.iniUsuario.Children.Add(lab);
            }
            else
            {
                var page1 = new MenuItemPage()
                {
                    Title = "Iniciar sesión",
                    TypePage = typeof(Login)
                };
                this.MenuPages.Add(page1);
            }
            
            
            var page3 = new MenuItemPage()
            {
                Title = "Inicio",
                TypePage = typeof(ListViewPage1)
            };
            this.MenuPages.Add(page3);
            this.lsvmenu.ItemsSource = this.MenuPages;
            Detail = new NavigationPage((Page)Activator.CreateInstance(typeof(ListViewPage1)));
            IsPresented = false;
            this.lsvmenu.ItemSelected += ChangePage;         
        }

        private void ChangePage(object sender, SelectedItemChangedEventArgs e)
        {
            MenuItemPage seleccionado = (MenuItemPage)e.SelectedItem;
            Detail = new NavigationPage((Page)Activator.CreateInstance(seleccionado.TypePage));
            IsPresented = false;
        }
    }
}