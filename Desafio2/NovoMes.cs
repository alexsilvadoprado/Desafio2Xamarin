using System;

using Xamarin.Forms;

namespace Desafio2
{
    public class NovoMes : ContentPage
    {
        public NovoMes()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

