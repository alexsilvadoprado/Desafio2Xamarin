using System;

using Xamarin.Forms;

namespace Desafio2
{
    public class Movimentacoes : ContentPage
    {
        public Movimentacoes()
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

