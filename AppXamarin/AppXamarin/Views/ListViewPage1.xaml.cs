using AppXamarin.Models;
using AppXamarin.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListViewPage1 : CarouselPage
    {
        public ListViewPage1()
        {
            InitializeComponent();
            //Picker picker = new Picker
            //{
            //    Title = "Elige el país",
            //    VerticalOptions = LayoutOptions.CenterAndExpand,
            //};


            //List<string> itemsPicker = new List<string>()
            //{
            //    { "Spain" },
            //    { "UK" },
            //    { "France" },
            //    { "Alls" }
            //};

            //picker.Items.Add(itemsPicker.ToString());

            //ItemTemplate = new DataTemplate(() =>
            //{
            //    ContentPage contentPage = new ContentPage()
            //    {

            //        Content = new StackLayout
            //        {
            //            HorizontalOptions = LayoutOptions.Center,
            //            VerticalOptions = LayoutOptions.CenterAndExpand,


            //            Children =
            //                {
            //                      picker
            //                }
            //        }
            //    };

            //    return contentPage;
            //});

          this.PickerOptions.SelectedIndexChanged += PickerOptions_SelectedIndexChanged;
            

            

        }

        private async Task<string> CallApi()
        {
            using (HttpClient client = new HttpClient())
            {
                              
                string response = await client.GetStringAsync("https://source.unsplash.com/random");
                return response;
            }

        }

        private void PickerOptions_SelectedIndexChanged(object sender, EventArgs e)
        {
            var country = this.PickerOptions.SelectedItem.ToString();

            List<Country> countries = new List<Country>();

            

            Country country1 = new Country();
            country1.Image = "spainflag.jpg";
            country1.Name = "Spain";

            Country country2 = new Country();
            country2.Image = "spaincity.jpg";
            country2.Name = "Spain";

            Country country3 = new Country();
            country3.Image = "ukflag.jpg";
            country3.Name = "UK";

            Country country4 = new Country();
            country4.Image = "ukcity.jpg";
            country4.Name = "UK";

            Country country5 = new Country();
            country5.Image = "franceflag.jpg";
            country5.Name = "France";

            Country country6 = new Country();
            country6.Image = "francecity.jpg";
            country6.Name = "France";

            if (country == "Spain")
            {             
                countries.Add(country1);

                countries.Add(country2);

                ItemsSource = countries;
                
            }else if (country == "UK")
            {
                countries.Add(country3);

                countries.Add(country4);

                ItemsSource = countries;

            }else if(country == "France")
            {
                countries.Add(country5);

                countries.Add(country6);

                ItemsSource = countries;
            }
            else if(country == "Alls")
            {
                countries.Add(country1);

                countries.Add(country2);

                countries.Add(country3);

                countries.Add(country4);

                countries.Add(country5);

                countries.Add(country6);

                ItemsSource = countries;
            }

            int indice = this.PickerOptions.SelectedIndex;
            if (indice != -1)
            {
                ItemTemplate = new DataTemplate(() =>
                {
                    return new CountryView();
                });
            }


        }
    }
}
