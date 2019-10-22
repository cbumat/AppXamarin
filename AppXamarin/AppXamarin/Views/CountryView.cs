using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace AppXamarin.Views
{
    public class CountryView : ContentPage
    {
        public CountryView()
        {
            Image imagen = new Image
            {
                WidthRequest = 200,
                HeightRequest = 200,
                HorizontalOptions = LayoutOptions.Center
            };
            imagen.SetBinding(Image.SourceProperty, "Image");
            Label lbldescripcion = new Label
            {
                FontSize = 15
            ,
                TextColor = Color.Red
            };
            lbldescripcion.SetBinding(Label.TextProperty, "Country");

            Content = new StackLayout
            {
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,

                Children =
                            {
                                  lbldescripcion, imagen
                            }

            };
        }
    }
}
